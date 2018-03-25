//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace UrbeliKuldetes
//{
//	class Prog
//	{
//		public static void init ( )
//		{
//            var payload = new PayloadCreator ( Models.Commands.Scan, "Południca", Login, Token ).ToJson ( );
//            var client = new RestClient ( "https://simulation.future-processing.pl/execute" );
//            var request = new RestRequest ( );
//            request = CreateRequest.CreatePOSTRequest ( payload );
//            IRestResponse response = client.Execute ( request );
//            if ( response.StatusCode == HttpStatusCode.OK )
//            {
//                Console.WriteLine ( "Ok" );
//                Console.WriteLine ( response.Content );
//            }
//            else
//            {
//                Console.WriteLine ( "We have a problem:\n" + response.ErrorMessage );
//            }


//            // temporary Describe method for testing 

////            var describeClient = new RestClient ( "https://simulation.future-processing.pl/describe?login=agata.szysz@gmail.com.google&token=40FEBC05C9F74D4F53503794F1368B6A" );
////            var describeRequest = CreateRequest.CreateGETRequest ( );
////            IRestResponse describeResponse = describeClient.Execute ( describeRequest );
////            if ( describeResponse.StatusCode == HttpStatusCode.OK )
////            {
////                Console.WriteLine ( "Ok" );
////                Console.WriteLine ( describeResponse.Content );

////                var resultAsObject = JsonConvert.DeserializeObject<Result> ( describeResponse.Content );
////                Console.WriteLine ( resultAsObject );
////            }
////            else
////            {
////                Console.WriteLine ( "We have a problem!\n" + describeResponse.ErrorMessage );
////            }



//            Console.ReadKey ( );
//        }
//	}
//}
