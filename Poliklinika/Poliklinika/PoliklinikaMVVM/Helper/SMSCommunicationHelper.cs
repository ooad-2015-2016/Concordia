using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Contacts;
using Windows.Devices.Sms;

namespace Poliklinika.PoliklinikaMVVM.Helper
{
    class SmsCommunicationHelper : ICommunicateBehaviour
    {
        //device za Sms komunikaciju
        private SmsDevice2 device;
        String textPoruke = "Zakazan termin na Poliklinici 'Concordia'";

        public async void Communicate(Contact kontakt)
        {
            if (device == null)
            {
                try
                {
                   device = SmsDevice2.GetDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            if (device != null)
            {
                string msgStr;
                try
                {
                    SmsTextMessage2 msg = new SmsTextMessage2();

                    string telBroj = "+38761111111";
                    msg.Body = textPoruke;
                    SmsSendMessageResult result = await device.SendMessageAndGetResultAsync(msg);
                    if (result.IsSuccessful)
                    {
                        msgStr = "";
                        msgStr += "Text message sent, cellularClass: " + result.CellularClass.ToString();
                        IReadOnlyList<Int32> messageReferenceNumbers = result.MessageReferenceNumbers;

                        for (int i = 0; i < messageReferenceNumbers.Count; i++)
                        {
                            msgStr += "\n\t\tMessageReferenceNumber[" + i.ToString() + "]: " + messageReferenceNumbers[i].ToString();
                        }
                    }
                    else
                    {
                        //povratni info neuspjesnog slanja poruke
                        msgStr = "";
                        msgStr += "ModemErrorCode: " + result.ModemErrorCode.ToString();
                        msgStr += "\nIsErrorTransient: " + result.IsErrorTransient.ToString();
                        if (result.ModemErrorCode == SmsModemErrorCode.MessagingNetworkError)
                        {
                            msgStr += "\n\tNetworkCauseCode: " + result.NetworkCauseCode.ToString();

                            if (result.CellularClass == CellularClass.Cdma)
                            {
                                msgStr += "\n\tTransportFailureCause: " + result.TransportFailureCause.ToString();
                            }
                            throw new Exception(msgStr);
                        }
                    }
                }
                catch (Exception ex)
                {
                    //exceptione je dobro ponekad proslijediti onome ko koristi ovu metodu da moze obraditi sta da uradi u tim situacijama
                    throw ex;
                }
            }
            else
            {
                //ako je device null ne zna se zasto, pa se kaze da nema device 
                throw new Exception("Nema SMS device");
            }
        }

        public string dajMetodKomunikacije()
        {
            return "Sms";
        }
    }

}
