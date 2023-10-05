using AutoMapper;
using BasicECommerceApp.Application.DTOs;
using BasicECommerceApp.Application.Exceptions;
using BasicECommerceApp.Application.Repositories;
using BasicECommerceApp.Application.Repositories.AppUser;
using BasicECommerceApp.Application.Repositories.Category;
using BasicECommerceApp.Application.Repositories.Product;
using BasicECommerceApp.Application.Repositories.Visitor;
using BasicECommerceApp.Application.Services;
using BasicECommerceApp.Application.UnitOfWork;
using BasicECommerceApp.Domain.Entities;
using BasicECommerceApp.Domain.Entities.Auth;
using BasicECommerceApp.Persistance.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasicECommerceApp.Persistence.Services
{
    public class CartService : GenericService<Cart>, ICartService
    {
        private readonly ICartReadRepository _categoryReadRepository;
        private readonly ICartWriteRepository _categoryWriteRepository;
        private readonly IVisitorReadRepository _visitorReadRepository;
        private readonly IVisitorWriteRepository _visitorWriteRepository;
        private readonly IAppUserReadRepository _appUserReadRepository;
        private readonly IAppUserWriteRepository _appUserWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CartService(IGenericReadRepository<Cart> readRepository, IGenericWriteRepository<Cart> writeRepository, IUnitOfWork unitOfWork, ICartReadRepository categoryReadRepository, ICartWriteRepository categoryWriteRepository, UserManager<AppUser> userManager, IVisitorReadRepository visitorReadRepository, IVisitorWriteRepository visitorWriteRepository, IAppUserReadRepository appUserReadRepository, IAppUserWriteRepository appUserWriteRepository, IMapper mapper) : base(readRepository, writeRepository, unitOfWork)
        {
            _categoryReadRepository = categoryReadRepository;
            _categoryWriteRepository = categoryWriteRepository;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _visitorReadRepository = visitorReadRepository;
            _visitorWriteRepository = visitorWriteRepository;
            _appUserReadRepository = appUserReadRepository;
            _appUserWriteRepository = appUserWriteRepository;
            _mapper = mapper;
        }

        public async Task<string> AddProductToCart(string visitorId, string userId, CartItemDto cartItemDto)
        {
            if (userId == null && visitorId == null)
            {
                throw new ClientSideException("Geçerli bir userId veya visitorId girilmek zorundadur !");
            }

            if (userId != null && visitorId != null) 
            {
                var testVisitor = await _visitorReadRepository.GetSingleVisitorWithCartAndCartItemsAsync(visitorId);
                var testUser = await _appUserReadRepository.GetSingleUserWithCartAndCartItemsAsync(userId);

                // Aktif olan sepetleri alın
                var visitorCart = testVisitor.Carts.FirstOrDefault(cart => cart.IsActive);
                var userCart = testUser.Carts.FirstOrDefault(cart => cart.IsActive);

                // Ziyaretçi sepetini kullanıcı sepetine birleştir
                foreach (var visitorCartItem in visitorCart.CartItems.ToList())
                {
                    var matchingUserCartItem = userCart.CartItems.FirstOrDefault(cartItem => cartItem.ProductId == visitorCartItem.ProductId);

                    if (matchingUserCartItem != null)
                    {
                        // Aynı ürün zaten kullanıcı sepetinde var, miktarı güncelle (Quantity sayısı fazla olanı tercih et)
                        matchingUserCartItem.Quantity = Math.Max(matchingUserCartItem.Quantity, visitorCartItem.Quantity);
                        // Ziyaretçi sepetinden bu öğeyi kaldır
                        visitorCart.CartItems.Remove(visitorCartItem);
                    }
                    else
                    {
                        // Eğer kullanıcı sepetinde bu ürün yoksa, kullanıcı sepetine ekle
                        userCart.CartItems.Add(visitorCartItem);
                        // Ziyaretçi sepetinden bu öğeyi kaldır
                        visitorCart.CartItems.Remove(visitorCartItem);
                    }
                }
                await _unitOfWork.CommitAsync();
            }
            

            if (userId == null)
            {
                // Ziyaretçi veri tabanında var mı?
                //var visitor = await _visitorReadRepository.GetByIdAsync(visitorId);

                var visitor = await _visitorReadRepository.GetSingleVisitorWithCartAndCartItemsAsync(visitorId);

                if (visitor == null)
                {
                    throw new NotFoundException("User not found");
                }

                // Kullanıcının aktif sepeti var mı?
                if (visitor.Carts.Count != 0)
                {
                    // Kullanıcının aktif bir sepeti varmış, onu bulalım
                    //var visitorCart = visitor.Carts.FirstOrDefault(cart => cart.IsActive);
                }
                else
                {
                    // Kullanıcının aktif bir sepeti var yokmuş, kendimiz oluşturalım
                    visitor.Carts = new List<Cart>
                    {
                        new Cart(){
                            IsActive = true,
                            IsCheckedOut = false,
                            VisitorId = Guid.Parse(visitorId),
                            CartItems = new List<CartItem>()
                        }
                    };
                    await _unitOfWork.CommitAsync();  
                }

                
                var visitorCartItem = new CartItem()
                {
                    ProductId = cartItemDto.ProductId,
                    Quantity = cartItemDto.Quantity
                };

                /*
                var testVisitor = await _visitorReadRepository.GetSingleVisitorWithCartAndCartItemsAsync(visitorId);
                
                // Ziyaretçinin aktif sepetini alın
                var visitorCart = testVisitor.Carts.FirstOrDefault(cart => cart.IsActive);

                // Aynı ürünü içeren öğeyi bulun (ProductId'ye göre)
                var existingCartItem = visitorCart.CartItems.FirstOrDefault(item => item.ProductId == cartItemDto.ProductId);

                if (existingCartItem != null)
                {
                    // Aynı ürün zaten sepette var, miktarı güncelle (Quantity sayısı eklenir)
                    existingCartItem.Quantity += cartItemDto.Quantity;
                }
                else
                {
                    // Aynı ürün sepette yok, yeni bir CartItem oluşturun ve ekleyin
                    var newCartItem = _mapper.Map<CartItem>(cartItemDto);
                    visitorCart.CartItems.Add(newCartItem);
                }
                */
                

                visitor.Carts.FirstOrDefault(cart => cart.IsActive).CartItems.Add(visitorCartItem);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                // Kullanıcı veri tabanında var mı?
                var user = await _appUserReadRepository.GetSingleUserWithCartAndCartItemsAsync(userId);

                if (user == null)
                {
                    throw new NotFoundException("User not found");
                }

                // Kullanıcının aktif sepeti var mı?
                if (user.Carts != null)
                {
                    // Kullanıcının aktif bir sepeti varmış, onu bulalım
                    //var userCart = user.Carts.FirstOrDefault(cart => cart.IsActive);
                }
                else
                {
                    // Kullanıcının aktif bir sepeti var yokmuş, kendimiz oluşturalım
                    user.Carts = new List<Cart>
                    {
                        new Cart(){
                            IsActive = true,
                            IsCheckedOut = false,
                            VisitorId = Guid.Parse(visitorId),
                            CartItems = new List<CartItem>()
                        }
                    };
                    await _unitOfWork.CommitAsync();
                }


                var userCartItem = new CartItem()
                {
                    ProductId = cartItemDto.ProductId,
                    Quantity = cartItemDto.Quantity
                };

                /*
                var testUser = await _appUserReadRepository.GetSingleUserWithCartAndCartItemsAsync(userId);

                // Ziyaretçinin aktif sepetini alın
                var userCart = testUser.Carts.FirstOrDefault(cart => cart.IsActive);

                // Aynı ürünü içeren öğeyi bulun (ProductId'ye göre)
                var existingCartItem = userCart.CartItems.FirstOrDefault(item => item.ProductId == cartItemDto.ProductId);

                if (existingCartItem != null)
                {
                    // Aynı ürün zaten sepette var, miktarı güncelle (Quantity sayısı eklenir)
                    existingCartItem.Quantity += cartItemDto.Quantity;
                }
                else
                {
                    // Aynı ürün sepette yok, yeni bir CartItem oluşturun ve ekleyin
                    var newCartItem = _mapper.Map<CartItem>(cartItemDto);
                    userCart.CartItems.Add(newCartItem);
                }
                */

                user.Carts.FirstOrDefault(cart => cart.IsActive).CartItems.Add(userCartItem);
                await _unitOfWork.CommitAsync();
            }

           return "Ürün sepete eklendi";
        }
    }
}
