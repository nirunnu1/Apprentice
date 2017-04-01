using DevExpress.Web.Mvc;
using Jobb.DAL;
using Jobb.Models;
using Jobb.Security;
using System;
using System.Linq;
using System.Web.Mvc;
using static Jobb.Models.modelEnum;

namespace Jobb.Controllers
{
    [Authentication(Roles = "Student")]
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Home()
        {
            MyContext context = new MyContext();
            meeting[] model = context.meeting.Where(t => t.Type == meetingcase.meetingStu).ToArray();
            if (model.Length >0) {
                ViewBag.getreg = string.Format("ประชุม  {0} ถึง {1} ", model[0].Datetime_Start, model[0].Datetime_End);
            }
            return View();
        }
        public ActionResult stu()
        {
            MyContext context = new MyContext();
            profile[] profile = context.profile.Where(p=>p.Username == User.Identity.Name).ToArray();
            profile model = context.profile.Find(profile[0].ID);
            return View(model);
        }
        public ActionResult resume()
        {
            var model = DALresume.getresume(SessionPrincipal.Username);
            return View(model);
        }
        public ActionResult resume_in()
        {
            var model = DALresume.getresume(SessionPrincipal.Username);
            return View(model);
        }


        public ActionResult Resume_Partial()
        {
            var model = DALresume.getresume(SessionPrincipal.Username);
            return PartialView("Resume_Partial", model);
        }
        public ActionResult Edit_Resume(MVCxGridViewBatchUpdateValues<resume, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.resume;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {

                        profile[] profile = Context.profile.Where(p=>p.Username == User.Identity.Name).ToArray();
                        Item.ID_Pro = profile[0].ID;
                        DALresume.insertresume(Item);

                    }
                    catch (Exception e)
                    {
                        updateValues.SetErrorText(Item, e.Message);
                    }
                }
            }
            // Update all edited values. 
            foreach (var Item in updateValues.Update)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        DALresume.updateresume(Item);
                    }
                    catch (Exception e)
                    {
                        updateValues.SetErrorText(Item, e.Message);
                    }
                }
            }
            // Delete all values that were deleted on the client side from the data source. 
            foreach (var ItemUid in updateValues.DeleteKeys)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID_Resume.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("Resume_Partial", DALresume.getresume(SessionPrincipal.Username));
        }
      
    

        public ActionResult register()
        {
            var model = DALregis.getregis(SessionPrincipal.Username);
            return View(model);
        }
        public ActionResult Register_Partial()
        {
            var model = DALregis.getregis(SessionPrincipal.Username);
            return PartialView("Register_Partial", model);
        }
        public ActionResult Edit_Register(MVCxGridViewBatchUpdateValues<regis, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.regis;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        profile[] profile = Context.profile.Where(p => p.Username == User.Identity.Name).ToArray();
                        Item.ID_Pro = profile[0].ID;
                        DALregis.insertregis(Item);

                    }
                    catch (Exception e)
                    {
                        updateValues.SetErrorText(Item, e.Message);
                    }
                }
            }
            // Update all edited values. 
            foreach (var Item in updateValues.Update)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        DALregis.updateregis(Item);
                    }
                    catch (Exception e)
                    {
                        updateValues.SetErrorText(Item, e.Message);
                    }
                }
            }
            // Delete all values that were deleted on the client side from the data source. 
            foreach (var ItemUid in updateValues.DeleteKeys)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID_Regis.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("Register_Partial", DALregis.getregis(SessionPrincipal.Username));
        }


        public ActionResult add_apprentice()
        {
            var model = DALadd_apprentice.getadd_apprentice(SessionPrincipal.Username);
            return View(model);
        }
        public ActionResult add_apprentice_Partial()
        {
            var model = DALadd_apprentice.getadd_apprentice(SessionPrincipal.Username);
            return PartialView("add_apprentice_Partial", model);
        }
        public ActionResult Edit_add_apprentice(MVCxGridViewBatchUpdateValues<add_apprentice, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.add_apprentice;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        profile[] profile = Context.profile.Where(p => p.Username == User.Identity.Name).ToArray();
                        regis[] regis = Context.regis.Where(x => x.profile.Username == User.Identity.Name).ToArray();
                        Item.ID_Regis = regis[0].ID_Regis;
                        Item.Type = 0;
                        DALadd_apprentice.insertadd_apprentice(Item);

                    }
                    catch (Exception e)
                    {
                        updateValues.SetErrorText(Item, e.Message);
                    }
                }
            }
            // Update all edited values. 
            foreach (var Item in updateValues.Update)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        DALadd_apprentice.updatadd_apprentice(Item,User.Identity.Name);
                    }
                    catch (Exception e)
                    {
                        updateValues.SetErrorText(Item, e.Message);
                    }
                }
            }
            // Delete all values that were deleted on the client side from the data source. 
            foreach (var ItemUid in updateValues.DeleteKeys)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID_add.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("add_apprentice_Partial", DALadd_apprentice.getadd_apprentice(SessionPrincipal.Username));
        }
        public ActionResult status_cooperative()
        {
            status_coop model;
            MyContext context = new MyContext();
            status_coop[] status_coop = context.status_coop.Where(p => p.regis.profile.Username == User.Identity.Name).ToArray();
            if (status_coop.Length>0) {
                 model = context.status_coop.Find(status_coop[0].ID_StaCoop);
            }
            else
            {
                model = null;
                ViewBag.error = "ยังไม่มีข้อมูล";
            }           
            return View(model);
        }
        public ActionResult status_projects()
        {
            var model = DALstatus_proj.getstatus_proj_user(SessionPrincipal.Username);
            return View(model);
        }
        public ActionResult adviser()
        {
            var model = DALins.getins_stu(SessionPrincipal.Username);
            return View(model);
        }

        public ActionResult ReportView()
        {
            
            return View();
        }


        public ActionResult DocumentViewerPartial()
        {
            MyContext Context = new MyContext();
            profile[] pro = Context.profile.Where(x => x.Username == User.Identity.Name).ToArray();
            int id = pro[0].ID;
            var Report = Context.resume.Where(c => c.ID_Pro == id).ToList();
            return PartialView("DocumentViewerPartial", Report);
        }
        public ActionResult ExportDocumentViewer()
        {
            MyContext Context = new MyContext();
            profile[] pro = Context.profile.Where(x => x.Username == User.Identity.Name).ToArray();
            XtraReport1 report = new XtraReport1();
            int id = pro[0].ID;
            resume[] model = Context.resume.Where(c => c.ID_Pro == id).ToArray();
            report.DataSource = model;
            return ReportViewerExtension.ExportTo(report);
        }
    }
}