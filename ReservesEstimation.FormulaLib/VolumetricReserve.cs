using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ReservesEstimation.FormulaLib
{
    public class VolumetricReserve : ReservesEstimationBase
    {

        const int AcreftToBbl = 7758;
        const int AcreftToFeetCube = 43560;

        public float Area { get; set; }
        public float Height { get; set; }
        public float Porosity { get; set; }
        public float ConnateWaterSaturation { get; set; }
        //[RegularExpression("^[1-9]\d*$")]
        public float FormationVolFactorAtInit { get; set; }
        public float FormationVolFactorGasAtInit { get; set; }

        private float _N;
        private float _G;
        private int PrimaryRecoveryFactor;
        private int SecondaryRecoveryFactor;

        public float DisplacementEfficiency = 0;
        public float ArealSweepEfficiency = 0;
        public float VerticalSweepEfficiency = 0;

        /// <summary>
        /// Uses the basic volumetric calculation formula
        /// </summary>
        /// <param name="_Area">Acres.</param>
        /// <param name="_Height">Height or thickness of pay zone in feets.</param>
        /// <param name="_Porosity">In decimals.</param>
        /// <param name="_ConnateWaterSaturation">In decimals.</param>
        /// <param name="_FormationVolFactorAtInit">Reservoir bbl/STB</param>
        /// <returns></returns>
        public override float GetOriginalOilInPlace()
        {
            Console.WriteLine("Calculate Original Oil in Place...\n");

            try
            {
                _N = AcreftToBbl * Area * Height * Porosity * (1 - ConnateWaterSaturation) / FormationVolFactorAtInit;

                //Validation.CheckNonZero(FormationVolFactorAtInit);

                if (float.IsNaN(_N)) { Console.WriteLine("Not a number.\n"); }

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return _N;
        }
        public override float GetOriginalGasInPlace()
        {
            Console.WriteLine("Calculate Original Gas in Place...\n");
            try
            {
                _G = AcreftToFeetCube * Area * Height * Porosity * (1 - ConnateWaterSaturation) / FormationVolFactorGasAtInit;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return _G;
        }
        public override float GetRecoverableReserves(DriveMechanism drive)
        {
            Console.WriteLine("Calculate Recoverable Reserves...\n");
            float RecoveryFactor;
            float Reserves = 0;
            try
            {
                RecoveryFactor = PrimaryRecoveryFactor + SecondaryRecoveryFactor;
                Reserves = _N * RecoveryFactor;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }


            return Reserves;
        }
    }
}
