using NHapi.Base.Model;
using NHapi.Base.Parser;
using NHapi.Model.V23.Message;
using NHapi.Model.V23.Segment;
using PatientDemo.Views;

namespace PatientDemo.BusinessLogic.Message
{
    public class ADTPatientDemographicsV23
    {
        public ADT_A04 adtMessage;
        PipeParser parser = new NHapi.Base.Parser.PipeParser();

        public ADTPatientDemographicsV23()
        {
            adtMessage = new ADT_A04();
        }

        public void CreateMSHSegment()
        {
            try
            {
                MSH mshSegment = adtMessage.MSH;

                // Set MSH segment fields
                mshSegment.FieldSeparator.Value = "|";
                mshSegment.EncodingCharacters.Value = "^~\\&";
                mshSegment.SendingApplication.UniversalID.Value = "Pakistan";
                mshSegment.SendingFacility.UniversalID.Value = "Pakistan";
                mshSegment.ReceivingApplication.UniversalID.Value = "Oman";
                mshSegment.ReceivingFacility.UniversalID.Value = "Oman";
                // Set other MSH fields as needed
            }
            catch (Exception ex) 
            { 
                //handle exception
            }
        }

        public void CreatePIDSegment(PatientDataView patientDataView)
        {
            try
            {
                PID pidSegment = adtMessage.PID;

                // Set PID segment fields
                pidSegment.SetIDPatientID.Value = (patientDataView.Id).ToString();

                pidSegment.GetPatientName(0).FamilyName.Value = patientDataView.LastName;
                pidSegment.GetPatientName(0).GivenName.Value = patientDataView.FirstName;
                pidSegment.Sex.Value = patientDataView.Gender;
                pidSegment.Race.Value = "Asian";
                pidSegment.Religion.Value = "Islam";
                pidSegment.PrimaryLanguage.Identifier.Value = "Urdu";
                pidSegment.BirthPlace.Value = "Lahore";
                pidSegment.MaritalStatus.Value = "Single";
                // Set other PID fields as needed
            }
            catch (Exception ex)
            {
                //handle exception
            }
           
        }

        public void CreatePV1Segment(PatientDataView patientDataView)
        {
            try
            {
                PV1 pv1Segment = adtMessage.PV1;

                pv1Segment.GetReferringDoctor(0).IDNumber.Value = (patientDataView.RefProvider.ProviderId).ToString();
                pv1Segment.GetReferringDoctor(0).GivenName.Value = patientDataView.RefProvider.FirstName;
                // Set other PV1 fields as needed
            }
            catch (Exception ex)
            {
                //handle exception
            }
            
        }

        public string CreateADTMessage(PatientDataView patientData)
        {
            CreateMSHSegment();
            CreatePIDSegment(patientData);
            CreatePV1Segment(patientData);
            string message = parser.Encode(adtMessage);

            string directoryPath = @"C:\Personal\"; 
            string fileName = $"output_{DateTime.Now:yyyyMMddHHmmss}.txt";

            // Combine the directory path and file name to create the full file path
            string filePath = Path.Combine(directoryPath, fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                
                writer.Write(message);
            }
            return message;
        }
    }
}
