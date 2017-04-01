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
    [Authentication(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Meeting()
        {
            var model = DALmeeting.getmeeting();
            return View(model);
        }

        public ActionResult Meeting_Partial()
        {
            var model = DALmeeting.getmeeting();
            return PartialView("Meeting_Partial", model);
        }

        public ActionResult Edit_Meeting(MVCxGridViewBatchUpdateValues<meeting, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.meeting;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        DALmeeting.insertmeeting(Item);
                    
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
                        DALmeeting.updatemeeting(Item);
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
                    var item = model.FirstOrDefault(it => it.ID_Mit.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("Meeting_Partial", DALmeeting.getmeeting());
        }
        public ActionResult instructor()
        {
            var model = DALprofile.getprofileInstuctor();
            return View(model);
        }
        public ActionResult Instructor_Partial()
        {
            var model = DALprofile.getprofileInstuctor();
            return PartialView("Instructor_Partial", model);
        }
        public ActionResult Edit_Instructor(MVCxGridViewBatchUpdateValues<profile, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.profile;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        DALprofile.insertprofile(Item);

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
                        DALprofile.updateprofile(Item);
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
                    var item = model.FirstOrDefault(it => it.ID.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("Instructor_Partial", DALprofile.getprofileInstuctor());
        }
        public ActionResult students()
        {

            var model = DALprofile.getprofileStudent();
            return View(model);
        }
        public ActionResult Student_Partial()
        {
            var model = DALprofile.getprofileStudent();
            return PartialView("Student_Partial", model);
        }

        public ActionResult Edit_Student(MVCxGridViewBatchUpdateValues<profile, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.profile;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        DALprofile.insertprofile(Item);

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
                        DALprofile.updateprofile(Item);
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
                    var item = model.FirstOrDefault(it => it.ID.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("Student_Partial", DALprofile.getprofileStudent());
        }
        public ActionResult company()
        {

            var model = DALcompany.getcompany();
            return View(model);
        }
        public ActionResult Company_Partial()
        {
            var model = DALcompany.getcompany();
            return PartialView("Company_Partial", model);
        }
        public ActionResult Edit_Company(MVCxGridViewBatchUpdateValues<company, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.company;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        DALcompany.insertcompany(Item);

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
                        DALcompany.updatecompany(Item);
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
                    var item = model.FirstOrDefault(it => it.ID_Compa.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("Company_Partial", DALcompany.getcompany());
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
            // Insert all added values. 
            //foreach (var Item in updateValues.Insert)
            //{
            //    if (updateValues.IsValid(Item))
            //    {
            //        try
            //        {
            //            Item.ID_Regis = Convert.ToInt32(Item.regis.profile.Fname);
            //            Item.regis = null;
            //            DALstatus_coop.insertstatus_coop(Item);

            //        }
            //        catch (Exception e)
            //        {
            //            updateValues.SetErrorText(Item, e.Message);
            //        }
            //    }
            //}
            // Update all edited values. 
            foreach (var Item in updateValues.Update)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        MyContext context = new MyContext();
                    
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
        public ActionResult status_coop()
        {
            var model = DALstatus_coop.getstatus_coop();
            return View(model);
        }
        public ActionResult status_coop_Partial()
        {
            var model = DALstatus_coop.getstatus_coop();
            return PartialView("status_coop_Partial", model);
        }
        public ActionResult Edit_status_coop(MVCxGridViewBatchUpdateValues<status_coop, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.status_coop;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        Item.ID_Regis = Convert.ToInt32(Item.regis.profile.Fname);
                        Item.regis = null;
                        DALstatus_coop.insertstatus_coop(Item);

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
                        MyContext context = new MyContext();
                        status_coop[] status_coop = context.status_coop.Where(x=>x.ID_StaCoop == Item.ID_StaCoop).ToArray();
                        Item.ID_Regis = status_coop[0].ID_Regis;
                        Item.regis = null;
                        DALstatus_coop.updatstatus_coop(Item);
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
                    var item = model.FirstOrDefault(it => it.ID_StaCoop.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("status_coop_Partial", DALstatus_coop.getstatus_coop());
        }
       
        public ActionResult status_proj()
        {
            
           
            var model = DALstatus_proj.getstatus_proj();
            return View(model);
        }
        public ActionResult status_proj_Partial()
        {
           
            var model = DALstatus_proj.getstatus_proj();
            return PartialView("status_proj_Partial", model);
        }
        public ActionResult Edit_status_proj(MVCxGridViewBatchUpdateValues<status_proj, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.status_proj;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        Item.ID_Regis =Convert.ToInt32( Item.regis.profile.Fname);
                        Item.regis = null;
                        DALstatus_proj.insertstatus_proj(Item);

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
                        MyContext context = new MyContext();
                        status_proj status_proj = context.status_proj.Find(Item.ID_StaProj);
                        ins ins = context.ins.Find(status_proj.ID_ins);
                        try {
                            ins.Ins_ID = Convert.ToInt32(Item.ins.profile1.Fname);
                        }
                        catch { }
                       
                        ins.Type = Item.ins.Type;
                        
                        DALstatus_proj.updatstatus_proj(Item);
                        context.SaveChanges();
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
                    var item = model.FirstOrDefault(it => it.ID_StaProj.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("status_proj_Partial", DALstatus_proj.getstatus_proj());
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

        //Edit_show_apprenPartial

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

                        DALadd_apprentice.updatadd_apprentice(Item, User.Identity.Name);
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
            add_apprentice model = context.add_apprentice.Find(id);
            var item = context.regis.Where(x => x.ID_Regis == model.ID_Regis).ToList();
            return View(item);
        }
        public ActionResult supervision()
        {
            var model = DALsupervision.getsupervision();
            return View(model);
        }
        public ActionResult supervision_Partial()
        {
            var model = DALsupervision.getsupervision();
            return PartialView("supervision_Partial", model);
        }
        public ActionResult Edit_supervision(MVCxGridViewBatchUpdateValues<supervision, int> updateValues)
        {
            MyContext Context = new MyContext();
            var model = Context.supervision;
            // Insert all added values. 
            foreach (var Item in updateValues.Insert)
            {
                if (updateValues.IsValid(Item))
                {
                    try
                    {
                        MyContext context = new MyContext();
                        try
                        {
                            regis regis = context.regis.Find(Item.ID_Regis);
                            regis.ID_Compa = Convert.ToInt32(Item.regis.company.Name_Compa);
                            context.SaveChanges();
                        }
                        catch { }
                        Item.regis = null;
                        DALsupervision.insertsupervision(Item);

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
                        MyContext context = new MyContext();
                        try
                        {
                            regis regis = context.regis.Find(Item.ID_Regis); 
                            regis.ID_Compa =Convert.ToInt32( Item.regis.company.Name_Compa);
                            context.SaveChanges();
                        }
                        catch { }
                        DALsupervision.updatesupervision(Item);
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
                    var item = model.FirstOrDefault(it => it.ID_Sup.ToString() == ItemUid.ToString());
                    if (item != null) model.Remove(item);
                    Context.SaveChanges();
                }
                catch (Exception e)
                {
                    updateValues.SetErrorText(ItemUid, e.Message);
                }
            }
            return PartialView("supervision_Partial", DALsupervision.getsupervision());
        }
    

    }
}