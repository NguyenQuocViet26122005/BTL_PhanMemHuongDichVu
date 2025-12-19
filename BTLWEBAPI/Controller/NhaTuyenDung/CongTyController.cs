using Microsoft.AspNetCore.Mvc;
using BTLWEBAPI.Models;

namespace BTLWEBAPI.Controllers.NhaTuyenDung
{
    [ApiController]
    [Route("api/nha-tuyen-dung/cong-ty")]
    public class CongTyController : ControllerBase
    {
        private readonly BtlwebapiContext _context;

        public CongTyController(BtlwebapiContext context)
        {
            _context = context;
        }

        // 1. Lấy danh sách công ty của nhà tuyển dụng
        [HttpGet("cua-toi/{maNguoiDung}")]
        public IActionResult LayCongTyCuaToi(Guid maNguoiDung)
        {
            var data = _context.CongTy
                .Where(ct => ct.TaoBoi == maNguoiDung)
                .ToList();

            return Ok(data);
        }

        // 2. Tạo công ty mới
        [HttpPost("tao-moi")]
        public IActionResult TaoCongTy([FromBody] CongTy model)
        {
            model.MaCongTy = Guid.NewGuid();
            model.NgayTao = DateTime.Now;
            model.NgayCapNhat = DateTime.Now;

            _context.CongTy.Add(model);
            _context.SaveChanges();

            return Ok(model);
        }

        // 3. Cập nhật công ty
        [HttpPut("cap-nhat/{maCongTy}")]
        public IActionResult CapNhatCongTy(Guid maCongTy, [FromBody] CongTy model)
        {
            var congTy = _context.CongTy.Find(maCongTy);
            if (congTy == null)
                return NotFound("Không tìm thấy công ty");

            congTy.TenCongTy = model.TenCongTy;
            congTy.MoTa = model.MoTa;
            congTy.Website = model.Website;
            congTy.Logo = model.Logo;
            congTy.NgayCapNhat = DateTime.Now;

            _context.SaveChanges();
            return Ok(congTy);
        }
    }
}
