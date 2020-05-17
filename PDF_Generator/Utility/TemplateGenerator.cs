using System.Text;

namespace PDF_Generator.Utility
{
    public class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var employee = DataStorage.GetAllEmployees();
            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>LastName</th>
                                        <th>Age</th>
                                        <th>Gender</th>
                                    </tr>");
            foreach(var e in employee)
            {
                sb.AppendFormat(@"<tr>
                                <td>{0}</td>
                                <td>{1}</td>
                                <td>{2}</td>
                                <td>{3}</td>
                                </tr>", e.Name, e.LastName, e.Age, e.Gender);
            }

            sb.Append(@"</table></body></html>");
            return sb.ToString();
        }
    }
}
