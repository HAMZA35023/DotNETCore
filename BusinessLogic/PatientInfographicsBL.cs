using Microsoft.AspNetCore.Server.IIS.Core;
using NHapi.Base.Model;
using PatientDemo.BusinessLogic.Message;
using PatientDemo.Views;
using System;

namespace PatientDemo.BusinessLogic
{
    public class PatientInfographicsBL
    {
        ADTPatientDemographicsV23 demographicsV23 = new ADTPatientDemographicsV23();
        public PatientInfographicsBL() { }

        public string SavePatientInfographics(PatientDataView patientData)
        {
            try
            {
                string message = FormADTMessage(patientData);
                return message;
            }
            catch (Exception ex) 
            {
                return string.Empty;
            }
        }

        private string FormADTMessage(PatientDataView patientData)
        {
            try 
            {
            
                string adtMessage = demographicsV23.CreateADTMessage(patientData);
               
                return adtMessage.ToString();
            }
            catch( Exception ex)
            {
                return string.Empty;
            }
            
        }
    }
}
