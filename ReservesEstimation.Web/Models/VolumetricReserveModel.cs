using System.ComponentModel.DataAnnotations;
using ReservesEstimation.FormulaLib;

namespace ReservesEstimation.Web.Models
{
    public class VolumetricReserveModel
    {
        public float Area { get; set; }
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Must be non-zero value.")]
        public float Height { get; set; }
        public float Porosity { get; set; }
        [Display(Name = "Connate Water Saturation")]
        public float ConnateWaterSaturation { get; set; }
        [Display(Name = "Formation Vol. Factor At Init")]
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Must be non-zero value.")]
        public float FormationVolFactorAtInit { get; set; }
        [Display(Name = "Formation Vol. Factor Gas At Init")]
        [RegularExpression("(.*[1-9].*)|(.*[.].*[1-9].*)", ErrorMessage = "Must be non-zero value.")]        
        public float FormationVolFactorGasAtInit { get; set; }
        public float Result 
        { 
            get
            {
                VolumetricReserve vr = new VolumetricReserve();

                vr.Area = Area;
                vr.Height = Height;
                vr.Porosity = Porosity;
                vr.ConnateWaterSaturation = ConnateWaterSaturation;
                vr.FormationVolFactorAtInit = FormationVolFactorAtInit;
                vr.FormationVolFactorGasAtInit = FormationVolFactorGasAtInit;

                return vr.GetOriginalOilInPlace();
            }
        
        
        }
    }
}
