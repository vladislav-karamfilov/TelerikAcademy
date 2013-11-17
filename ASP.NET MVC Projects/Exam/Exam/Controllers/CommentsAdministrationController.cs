namespace Exam.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using Exam.Data.Contracts;
    using Exam.Models;

    // [Authorize(Roles = "Administrator")]
    public class CommentsAdministrationController : BaseController
    {
        public CommentsAdministrationController(IExamData data)
            : base(data)
        { }

        public ActionResult Index()
        {
            var comments = this.Data.Comments.All().Include(c => c.Author).Include(c => c.Ticket);
            return View(comments.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.Data.Comments.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.Data.Comments.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment, string authorId)
        {
            comment.AuthorId = authorId;
            if (ModelState.IsValid)
            {
                var commentToUpdate = this.Data.Comments.GetById(comment.Id);
                commentToUpdate.Content = comment.Content;
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Comment comment = this.Data.Comments.GetById(id.Value);
            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = this.Data.Comments.GetById(id);
            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (this.Data != null)
            {
                this.Data.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
