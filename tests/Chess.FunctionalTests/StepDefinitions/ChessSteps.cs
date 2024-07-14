// namespace Chess.FunctionalTests.StepDefinitions;
//
// using System.Drawing;
// using System.Globalization;
// using Chess.Core.Models;
// using NUnit.Framework;
// using RestSharp;
// using Support;
// using TechTalk.SpecFlow;
//
// [Binding]
// public class ChessSteps(ScenarioContext context) : TestBase(context)
// {
//     private ChessMoveRequest _request;
//     private RestResponse _response;
//
//     [Given(@"I have a chess request with following parameters:")]
//     public void GivenIHaveAChessRequestWithFollowingParameters(Table table)
//     {
//         var row = table.Rows[0];
//
//         _request = new ChessMoveRequest
//         {
//             Text = row["Text"],
//             Width = string.IsNullOrEmpty(row["Width"]) ? null : int.Parse(row["Width"], CultureInfo.InvariantCulture),
//             Height = string.IsNullOrEmpty(row["Height"]) ? null : int.Parse(row["Height"], CultureInfo.InvariantCulture),
//             Difficulty = string.IsNullOrEmpty(row["Difficulty"]) ? null
//                 : Enum.Parse<ChessDifficulty>(row["Difficulty"], true)
//         };
//     }
//
//     [When(@"I send the request to the Create endpoint of the ChessController")]
//     public async Task WhenISendTheRequestToTheCreateEndpointOfTheChessController()
//     {
//         var request = new RestRequest("chess") // calls localhost/chess
//         { RequestFormat = DataFormat.Json, Method = Method.Post };
//         request.AddJsonBody(_request);
//         _response = await Client.ExecuteAsync(request);
//     }
//
//     [Then(@"I expect a chess image to be returned with the following attributes:")]
//     public void ThenIExpectAChessImageToBeReturnedWithTheFollowingAttributes(Table table)
//     {
//         var row = table.Rows[0];
//         using var ms = new MemoryStream(_response.RawBytes);
//         var img = Image.FromStream(ms);
//
//         var expectedWidth = int.Parse(row["Width"], CultureInfo.InvariantCulture);
//         var expectedHeight = int.Parse(row["Height"], CultureInfo.InvariantCulture);
//
//         Assert.That(img.Width, Is.EqualTo(expectedWidth));
//         Assert.That(img.Height, Is.EqualTo(expectedHeight));
//     }
// }
