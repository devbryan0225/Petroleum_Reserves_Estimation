using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ReservesEstimation.FormulaLib;

namespace ReservesEstimation.Web.Models
{
    public class VolumetricReserveModel
    {
        public float Area { get; set; }
        public float Height { get; set; }
        public float Porosity { get; set; }
        [Display(Name = "Connate Water Saturation")]
        public float ConnateWaterSaturation { get; set; }
        [Display(Name = "Formation Vol. Factor At Init")]
        //[RegularExpression("^[1-9]\d*$")]
        public float FormationVolFactorAtInit { get; set; }
        [Display(Name = "Formation Vol. Factor Gas At Init")]
        public float FormationVolFactorGasAtInit { get; set; }
        public float Result 
        { 
            get
            {
                VolumetricReserve volumetricReserve = new VolumetricReserve();

                volumetricReserve.Area = Area;
                volumetricReserve.Height = Height;
                volumetricReserve.Porosity = Porosity;
                volumetricReserve.ConnateWaterSaturation = ConnateWaterSaturation;
                volumetricReserve.FormationVolFactorAtInit = FormationVolFactorAtInit;
                volumetricReserve.FormationVolFactorGasAtInit = FormationVolFactorGasAtInit;

                return volumetricReserve.GetOriginalOilInPlace();
            }
        
        
        }
    }
}
