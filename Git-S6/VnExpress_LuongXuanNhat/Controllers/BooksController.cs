using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VnExpress_LuongXuanNhat.Models;

namespace VnExpress_LuongXuanNhat.Controllers
{

    // KKK 10 ddiemer a
    public class BooksController : Controller
    {
        // GET: Books
        private List<Book> listBooks;
        private List<Book> listBookDelete;
        public BooksController()
        {
            listBooks = new List<Book>();
            
            listBooks.Add(new Book()
            {
                Id = 1,
                Title = "Đừng lựa chọn an nhàn khi còn trẻ",
                Author = "Cảnh Thiên",
                PublicYear = 2020,
                Price = 120000,
                Cover = "Content/Images/b1.jpg",
                Description = "Khi than vãn rằng mình không có một người cha giàu có, bạn phải biết rằng: Thời đại này không thể dựa vào cha vào mẹ, mà phải dựa vào thực lực của bản thân.Mỗi giây qua đi là đã mất,mỗi phút chảy trôi là không thể lấy lại được,thời gian là vô giá nên đừng phí hoài nó.Tuy nhiên,một số bạn trẻ hiện nay lại chưa có ý thức sâu sắc được điều này mà mải mê rơi vào nhiều tật xấu như lười biếng,ngủ nướng,trì trệ… Cuốn sách là một lời cảnh tỉnh được gửi tới chúng ta - thế hệ trẻ hôm nay và ngày mai,phải biết trân trọng quãng đời thanh xuân để cống hiến và sống hết mình. "
            });
            listBooks.Add(new Book()
            {
                Id = 2,
                Title = "Hạt giống tâm hồn",
                Author = "Nhiều tác giả",
                PublicYear = 2015,
                Price = 1220000,
                Cover = "Content/Images/b2.jpg",
                Description = "Hạt giống tâm hồn là những trang văn mang đậm hơi thở cuộc sống đi kèm với những câu chuyện ý nghĩa. Có những câu chuyện khiến ta mỉm cười thỏa mãn nhưng cũng có những câu chuyện khiến trái tim ta trùng xuống một nhịp. Như những mảnh ghép phức tạp, ta nhận ra cuộc sống này còn nhiều mảnh đời bất hạnh, nhiều câu chuyện ý nghĩa. Những ai còn yêu cuộc sống này thì hãy thử tự mình chiêm nghiệm những giá trị nhân sinh giản dị và bình phàm mà Hạt giống tâm hồn mang lại. Bộ sách này còn rất phù hợp để trao tặng cho người bạn yêu thương. Bởi lẽ, cho đi chính là nhận lại."
            });
            listBooks.Add(new Book()
            {
                Id = 3,
                Title = "Trên đường băng",
                Author = "Tony buổi sáng",
                PublicYear = 2021,
                Price = 125000,
                Cover = "Content/Images/b3.jpg",
                Description = "Cuốn sách là sự kết tinh - tổng hợp những bài viết trên fanpage Tony BS. Những bài viết ấy là góc nhìn mới lạ về những thói hư tật xấu của người Việt, từ đó dấy lên cho người đọc những suy nghĩ và bài học quý giá. Từng trang trong cuốn sách đầy giản dị mà thâm sâu, bay bổng nhưng cũng hiện thực. Liệu chỉ với thu nhập 6 triệu/ tháng bạn có thể khởi nghiệp hay không? Nếu bạn còn nhiều điều tò mò thì chuyến bay đã chuẩn bị cất cánh, bạn đã sẵn sàng chưa?"
            });
            listBooks.Add(new Book()
            {
                Id = 4,
                Title = "Muôn kiếp nhân sinh",
                Author = "Nguyên Phong",
                PublicYear = 2020,
                Price = 320000,
                Cover = "Content/Images/b4.jpg",
                Description = "Thế sự đổi thay, vạn vật luân hồi, liệu rằng có kiếp sau hay không và liệu rằng mỗi người trong chúng ta có kết nối gì với vũ trụ? Cuốn sách là góc nhìn giữa tâm linh và khoa học, đem cho chúng ta cái nhìn toàn diện nhất về dòng chảy trôi của cuộc sống.Muôn kiếp nhân sinh là lời giải đáp những câu hỏi về cuộc sống, là sự chiêm nghiệm sâu sắc về thế giới, là những chuyến phiêu lưu lạc về tiền kiếp… Đây là một trong những cuốn sách hay đáng đọc về cuộc sống mà bạn không nên bỏ qua. Nếu có phút giây nào bạn đã quá mệt mỏi, hãy tìm về cuốn sách này như một điểm tựa an lành."
            });

        }
        public ActionResult ListBook()
        {
            ViewBag.TitlePageName = "Library Page";
            return View(listBooks);
        }
        public ActionResult ListBookDelete()
        {
            ViewBag.TitlePageName = "Library Page";
            return View(listBookDelete);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book); ;
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var editBook = listBooks.Find(b => b.Id == book.Id);
                    editBook.Title = book.Title;
                    editBook.Author = book.Author;
                    editBook.Cover = book.Cover;
                    editBook.Price = book.Price;
                    editBook.PublicYear = book.PublicYear;
                    editBook.Description = book.Description;
                    return View("ListBook", listBooks);
                }
                catch (Exception ex)
                {
                    return HttpNotFound();
                }
            }
            else
            {
                ModelState.AddModelError("", "Input Model Not Valid!");
                return View(book);
            }
        }

        // Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.Id == id);
            
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            foreach (var item in listBooks)
            {
                if (book.Id == item.Id) {

                    listBooks.Remove(item);
                    break;
                };
            }       
            return View("ListBook", listBooks);
        }

        // Order
        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = listBooks.Find(s => s.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book); ;
        }

    }
}