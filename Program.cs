 Console.WriteLine("Enter 1 to create data file.");
 Console.WriteLine("Enter 2 to parse data.");
 Console.WriteLine("Enter anything else to quit.");
 // input response
 string? resp = Console.ReadLine();

 if (resp == "1")
 {
    // create data file

     // ask a question
     Console.WriteLine("How many weeks of data is needed?");
     // input the response (convert to int)
     int weeks = Convert.ToInt32(Console.ReadLine());
         // determine start and end date
     DateTime today = DateTime.Now;
     // we want full weeks sunday - saturday
     DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
     // subtract # of weeks from endDate to get startDate
     DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
     // random number generator
     Random rnd = new();
      // create file
     StreamWriter sw = new("data.txt");

     // loop for the desired # of weeks
     while (dataDate < dataEndDate)
     {
         // 7 days in a week
         int [] hours = new  int[7];
         for (int i = 0; i < hours.Length; i++)
         {
             // generate random number of hours slept between 4-12 (inclusive)
             hours[i] = rnd.Next(4, 13);
         }
         // M/d/yyyy,#|#|#|#|#|#|#
         //Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
         sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");
         // add 1 week to date
         dataDate = dataDate.AddDays(7);
     } 
     sw.Close();
 }
 /////////////////////////////////////////////////////////////////////////////////////
 ////////////////////////////////////////////////////////////////////////////////////
 else if (resp == "2")
 {
////////////////////////////////////////////
// parse data file
 if (File.Exists("data.txt")) /* checking  the text format in case we find a record */
    {
 StreamReader sr = new StreamReader("data.txt");
        string? line;
        
  while (( line = sr.ReadLine()) != null )/* the only way the loop will not be executed is to have the text empty*/
        {
            
    var parts = line.Split(',');
    string weekDate = parts[0]; 
     string[] hours = parts[1].Split('|'); /* There is a "," separating the date from the hours of sleep and
             a "|" is used as a delimiter for each night’s hours of sleep */
       /*The data contains the start date of the week followed by the # of hours of slept for each night (Sunday – Saturday).*/
      Console.WriteLine($"Week of {DateTime.Parse(weekDate):MMM,  dd, yyyy}");/*Upper part of the calendar/ SlepDate */

     Console.WriteLine("su mo tu we th fr sa");
     Console.WriteLine("-- -- -- -- -- -- --");

            
         string formattedHours = string.Join(" ", hours.Select(h => h.PadLeft(2, ' ')));
     Console.WriteLine($"{formattedHours}");/*Hours to sleep*/
        Console.WriteLine();
        }
     sr.Close();
/////////////////////////////
 }


}
