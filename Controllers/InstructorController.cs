using DevExpress.Web.Mvc;
using Jobb.DAL;
using Jobb.Models;
using Jobb.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Jobb.Models.modelEnum;

namespace Jobb.Controllers
{
    [Authentication(Roles = "Instructor")]
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            MyContext context = new MyContext();
            meeting[] model = context.meeting.Where(t => t.Type == meetingcase.meetingIns).ToArray();
            ViewBag.getreg = string.Format("ประชุม  {0} ถึง {1} ", model[0].Datetime_Start, model[0].Datetime_End);
            return View();
        }
        public ActionResult sign_up()
        {
            var model = DALregis.getregis_all();
            return View(model);
        }
        public ActionResult sign_up_Partial()
        {
            var model = DALregis.getregis_all();
            return PartialView("sign_up_Partial", model);
        }
        public ActionResult Edit_sign_up(MVCxGridViewBatchUpdateValues<regis, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.regis;
           
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {

                        DALregis.insertregis(Item);

                    }
                    catch (Exception e)
                    {
                        updateValues.SetErrorText(Item, e.Message);
                    }
                }
            }
           
            foreach (var Item in updateValues.Update)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        MyContext context = new MyContext();
                        profile[] profile = context.profile.Where(x => x.Fname == Item.profile.Fname).ToArray();
                        Item.ID_Pro = profile[0].ID;
                        Item.profile = null;
                        regis[] regis = context.regis.Where(x => x.ID_Regis == Item.ID_Regis).ToArray();
                        Item.ID_Resume = regis[0].ID_Resume;
                        DALregis.updateregis(Item);
                    }
                    catch (Exception e)
                    {
                        updateValues.SetErrorText(Item, e.Message);
                    }
                }
            }
            // Delete all values that were deleted on the client side from the data source. 
            //foreach (var ItemUid in updateValues.DeleteKeys)
            //{
            //    try
            //    {
            //        var item = model.FirstOrDefault(it => it.ID_StaCoop.ToString() == ItemUid.ToString());
            //        if (item != null) model.Remove(item);
            //        Context.SaveChanges();
            //    }
            //    catch (Exception e)
            //    {
            //        updateValues.SetErrorText(ItemUid, e.Message);
            //    }
            //}
            return PartialView("sign_up_Partial", DALregis.getregis_all());
        }
        public ActionResult show_appren()
        {
            var model = DALadd_apprentice.getadd_apprentice(null);

            return View(model);
        }
        public ActionResult show_apprenPartial()
        {
            var model = DALadd_apprentice.getadd_apprentice(null);

            return PartialView("show_apprenPartial", model);
        }
        public ActionResult Edit_show_apprenPartial(MVCxGridViewBatchUpdateValues<add_apprentice, int> updateValues)
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
            return PartialView("show_apprenPartial", DALadd_apprentice.getadd_apprentice_all());
        }
        public ActionResult show_apprenprofile(int id)
        {
            MyContext context = new MyContext();
            add_apprentice  model = context.add_apprentice.Find(id);
            var item = context.regis.Where(x=>x.ID_Regis == model.ID_Regis).ToList();
            return View(item);
        }
        public ActionResult adviser()
        {
            var model = DALins.getins_stu(SessionPrincipal.Username);
            return View(model);
        }

    }
}