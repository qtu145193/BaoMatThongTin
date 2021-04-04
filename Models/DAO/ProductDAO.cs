using Models.Framework;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class ProductDAO
    {
        //khoi tao dd context
        public atttDataContext db = null;

        public ProductDAO()
        {
            db = new atttDataContext();
        }
        public IEnumerable<WeaponViewModel> listProduct()
        {
            var model = from a in db.Weapons
                        join b in db.WeaponClasses on
                        a.IDclass equals b.IDclass
                        where a.IDclass == b.IDclass
                        select new WeaponViewModel
                        {
                            IDweapon = a.IDweapon,
                            IDclass = a.IDclass,
                            NameWea = a.NameWea,
                            Reloadtime = a.Reloadtime,
                            Description = a.Description,
                            Ammunition = a.Ammunition,
                            Image = a.Image,
                            WeaponClass = b.Name,
                            Price = a.Price
                        };
            return model.ToList();
        }
        public WeaponViewModel ViewDetail(int id)
        {
            var model = from a in db.Weapons
                        join b in db.WeaponClasses on
                        a.IDclass equals b.IDclass
                        where a.IDclass == b.IDclass
                        select new WeaponViewModel
                        {
                            IDweapon = a.IDweapon,
                            IDclass = a.IDclass,
                            NameWea = a.NameWea,
                            Reloadtime = a.Reloadtime,
                            Description = a.Description,
                            Ammunition = a.Ammunition,
                            Image = a.Image,
                            WeaponClass = b.Name,
                            Price = a.Price
                        };
            return model.FirstOrDefault(m=>m.IDweapon==id);
        }
        public bool UpdateProduct(WeaponViewModel model)
        {
            try
            {
                var pro = db.Weapons.Find(model.IDweapon);
                pro.NameWea = model.NameWea;
                pro.Price = model.Price;
                pro.Reloadtime = model.Reloadtime;
                pro.Image = model.Image;
                pro.Ammunition = model.Ammunition;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
