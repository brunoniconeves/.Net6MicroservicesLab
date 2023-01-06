using GeekShopping.CouponAPI.Data.ValueObjects;

namespace GeekShopping.CartAPI.Repository
{
  public interface ICouponRepository
  {
    Task<CouponVO> GetCouponByCouponCode(string CounponCode);
    //Task<bool> RemoveCoupon(string userId);
  }
}
