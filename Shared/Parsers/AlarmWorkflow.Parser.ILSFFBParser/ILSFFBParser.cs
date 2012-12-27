using System;
using AlarmWorkflow.AlarmSource.Fax;
using AlarmWorkflow.Shared.Core;
using AlarmWorkflow.Shared.Diagnostics;

namespace AlarmWorkflow.Parser.ILSFFBParser
{
    /// <summary>
    /// Description of ILSFFBParser.
    /// </summary>
    [Export("ILSFFBParser", typeof(IFaxParser))]
    sealed class ILSFFBParser : IFaxParser
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the ILSFFBParser class.
        /// </summary>
        public ILSFFBParser()
        {
        }

        #endregion

        #region IFaxParser Members


        Operation IFaxParser.Parse(string[] lines)
        {
            Operation operation = new Operation();

            try
            {

                //Definition der bool Variablen
                //bool nextIsOrt = false;
                bool ReplStreet = false;                
                bool ReplCity = false;
                bool ReplComment = false;
                bool ReplPicture = false;
                //bool Alarmtime = false;
                bool Faxtime = false;
                //bool getEinsatzort = false;

                foreach (string line in lines)
                {

                    string msg;
                    string prefix;
                    int x = line.IndexOf(':');
                    if (x != -1)
                    {
                        prefix = line.Substring(0, x);
                        msg = line.Substring(x + 1).Trim();

                        prefix = prefix.Trim().ToUpperInvariant();
                        switch (prefix)
                        {

                            //F�llen der Standardinformatione Alarmfax ILS FFB
                            case "MITTEILER":
                                operation.Messenger = msg;
                                break;
                            case "EINSATZORT":
                                operation.Zielort.Location = msg;
                                break;
                            case "STRA�E":
                            case "STRABE":
                                operation.Einsatzort.Street = msg;
                                break;                            
                            case "ORTSTEIL/ORT":
                                operation.Einsatzort.City = msg;
                                break;
                            case "OBJEKT":
                            case "9BJEKT":
                                operation.Einsatzort.Property = msg;
                                break;
                            case "MELDEBILD":
                                operation.Picture = msg;
                                break;
                            case "HINWEIS":
                                operation.Comment = msg;
                                break;
                            case "EINSATZPLAN":
                                operation.OperationPlan = msg;
                                break;
                            case "EINSATZSTICHWORT":
                                operation.Keywords.EmergencyKeyword = msg;
                                break;
                        }
                    }

                    // TODO: ist noch mit der ILS FFB zu kl�ren ob auf dem Fax die Alarmzeit wieder kommt. Daher aktuell Alarzeit noch mit Faxeingang gleich

                    // Anzeige des Zeitpunkts des Alarmeingangs
                    //if (Alarmtime == false)
                    //{
                    //    DateTime uhrzeit = DateTime.Now;
                    //    operation.CustomData["Alarmtime"] = "Alarmzeit: " + uhrzeit.ToString("HH:mm:ss ");
                    //    Alarmtime = true;
                    //}

                    if ((line.StartsWith("E - Nr")))
                    {
                        operation.OperationNumber = line.Substring(7);

                    }

                    // Anzeige des Zeitpunkts des Faxeingangs
                    if (Faxtime == false)
                    {
                        DateTime uhrzeit = DateTime.Now;
                        operation.CustomData["Faxtime"] = "Faxeingang: " + uhrzeit.ToString("HH:mm:ss ");
                        Faxtime = true;
                    }

                    // Fahrzeug f�llen TODO Check if needed in further cases
                    //operation.CustomData["Vehicles"] = "";
                    

                    // Sonderzeichenersetzung im Meldebild

                    if (ReplPicture == false)
                    {
                        operation.Picture = operation.Picture + " ";
                        ReplPicture = true;
                    }

                    if (operation.Picture.Contains("�") == true)
                    {
                        operation.Picture = operation.Picture.Replace("�", "ss");
                    }

                    if (operation.Picture.Contains("�") == true)
                    {
                        operation.Picture = operation.Picture.Replace("�", "ae");
                    }

                    if (operation.Picture.Contains("�") == true)
                    {
                        operation.Picture = operation.Picture.Replace("�", "oe");
                    }

                    if (operation.Picture.Contains("�") == true)
                    {
                        operation.Picture = operation.Picture.Replace("�", "ue");
                    }

                    // Sonderzeichenersetzung im Ort

                    if (ReplCity == false)
                    {
                        operation.Einsatzort.City = operation.Einsatzort.City + " ";
                        ReplCity = true;
                    }

                    if (operation.Einsatzort.City.Contains("�") == true)
                    {
                        operation.Einsatzort.City = operation.Einsatzort.City.Replace("�", "ss");
                    }

                    if (operation.Einsatzort.City.Contains("�") == true)
                    {
                        operation.Einsatzort.City = operation.Einsatzort.City.Replace("�", "ae");
                    }

                    if (operation.Einsatzort.City.Contains("�") == true)
                    {
                        operation.Einsatzort.City = operation.Einsatzort.City.Replace("�", "oe");
                    }

                    if (operation.Einsatzort.City.Contains("�") == true)
                    {
                        operation.Einsatzort.City = operation.Einsatzort.City.Replace("�", "ue");
                    }

                    // Sonderzeichenersetzung in der Strasse

                    if (ReplStreet == false)
                    {
                        operation.Einsatzort.Street = operation.Einsatzort.Street + " ";
                        ReplStreet = true;
                    }

                    if (operation.Einsatzort.Street.Contains("�") == true)
                    {
                        operation.Einsatzort.Street = operation.Einsatzort.Street.Replace("�", "ss");
                    }

                    if (operation.Einsatzort.Street.Contains("�") == true)
                    {
                        operation.Einsatzort.Street = operation.Einsatzort.Street.Replace("�", "ae");
                    }

                    if (operation.Einsatzort.Street.Contains("�") == true)
                    {
                        operation.Einsatzort.Street = operation.Einsatzort.Street.Replace("�", "oe");
                    }

                    if (operation.Einsatzort.Street.Contains("�") == true)
                    {
                        operation.Einsatzort.Street = operation.Einsatzort.Street.Replace("�", "ue");
                    }

                    // Sonderzeichenersetzung im Hinweis

                    if (ReplComment == false)
                    {
                        operation.Comment = operation.Comment + " ";
                        ReplComment = true;
                    }

                    if (operation.Comment.Contains("�") == true)
                    {
                        operation.Comment = operation.Comment.Replace("�", "ss");
                    }

                    if (operation.Comment.Contains("�") == true)
                    {
                        operation.Comment = operation.Comment.Replace("�", "ae");
                    }

                    if (operation.Comment.Contains("�") == true)
                    {
                        operation.Comment = operation.Comment.Replace("�", "oe");
                    }

                    if (operation.Comment.Contains("�") == true)
                    {
                        operation.Comment = operation.Comment.Replace("�", "ue");
                    }


                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(this, ex);
            }

            return operation;
        }

        #endregion

    }
}
