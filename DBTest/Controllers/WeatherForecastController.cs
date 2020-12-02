using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBTest.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DBTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> logger;
        private readonly ADBContext context;
        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ADBContext context
            )
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet("Prepare")]
        public async Task<ActionResult<int>> Prepare()
        {
            try
            {
                int ret = 0;
                var date1Origin = DateTime.Parse("2020-01-01");
                var date2Origin = DateTimeOffset.Parse("2020-01-01");
                for (int i = 1; i <= 100000; i++)
                {
                    try
                    {
                        context.Add(new Obj()
                        {
                            //Id = i,
                            DateTimeIndex = date1Origin.AddHours(i),
                            DateTimeValue = date1Origin.AddHours(i),
                            DateTime2Index = date2Origin.AddHours(i),
                            DateTime2Value = date2Origin.AddHours(i),
                            FloatIndex = i + 0.0f,
                            FloatValue = i + 0.0f,
                            IntIndex = i,
                            IntValue = i,
                            LongIndex = i,
                            LongValue = i
                        });
                        await context.SaveChangesAsync();
                        ret++;
                    }
                    catch
                    {

                    }
                }
                return Ok(ret);
            }
            catch (Exception exc)
            {
                logger.LogError(exc, exc.Message);
                return BadRequest(new ProblemDetails() { Detail = exc.Message + (exc.InnerException != null ? $";\n{exc.InnerException.Message}" : "") + "\n" + exc.StackTrace, Title = exc.Message, Type = exc.GetType().ToString() });
            }
        }
        [HttpGet("TestGt")]
        public ActionResult<string> TestGt([FromQuery] int test)
        {
            try
            {
                var ret = new StringBuilder();
                ret.Append($"Testing value: {test}\n");

                var date1Origin = DateTime.Parse("2020-01-01").AddHours(test);
                var date2Origin = DateTimeOffset.Parse("2020-01-01").AddHours(test);
                float floatTest = test + 0.0f;
                long longTest = test;
                ret.Append("DateTimeIndex >= : ");
                Stopwatch timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.DateTimeIndex >= date1Origin).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("DateTimeValue >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.DateTimeValue >= date1Origin).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("DateTime2Index >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.DateTime2Index >= date2Origin).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("DateTime2Value >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.DateTime2Value >= date2Origin).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");


                ret.Append("FloatIndex >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.FloatIndex >= floatTest).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("FloatValue >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.FloatValue >= floatTest).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");


                ret.Append("IntIndex >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.IntIndex >= test).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("IntValue >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.IntValue >= test).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("LongIndex >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.LongIndex >= test).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("LongValue >= : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.LongValue >= test).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");
                return ret.ToString();
            }
            catch (Exception exc)
            {
                logger.LogError(exc, exc.Message);
                return BadRequest(new ProblemDetails() { Detail = exc.Message + (exc.InnerException != null ? $";\n{exc.InnerException.Message}" : "") + "\n" + exc.StackTrace, Title = exc.Message, Type = exc.GetType().ToString() });
            }
        }
        [HttpGet("TestEq")]
        public ActionResult<string> TestEq([FromQuery] int test)
        {
            try
            {
                var ret = new StringBuilder();
                ret.Append($"Testing value: {test}\n");
                var date1Origin = DateTime.Parse("2020-01-01").AddHours(test);
                var date2Origin = DateTimeOffset.Parse("2020-01-01").AddHours(test);
                float floatTest = test + 0.0f;
                long longTest = test;
                ret.Append("DateTimeIndex == : ");
                Stopwatch timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.DateTimeIndex == date1Origin).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("DateTimeValue == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.DateTimeValue == date1Origin).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("DateTime2Index == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.DateTime2Index == date2Origin).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("DateTime2Value == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.DateTime2Value == date2Origin).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");


                ret.Append("FloatIndex == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.FloatIndex == floatTest).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("FloatValue == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.FloatValue == floatTest).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");


                ret.Append("IntIndex == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.IntIndex == test).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("IntValue == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.IntValue == test).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("LongIndex == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.LongIndex == test).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");

                ret.Append("LongValue == : ");
                timer = new Stopwatch();
                timer.Start();
                context.Objs.Where(o => o.LongValue == test).ToArray();
                timer.Stop();
                ret.Append(timer.Elapsed);
                ret.Append("\n");
                return ret.ToString();
            }
            catch (Exception exc)
            {
                logger.LogError(exc, exc.Message);
                return BadRequest(new ProblemDetails() { Detail = exc.Message + (exc.InnerException != null ? $";\n{exc.InnerException.Message}" : "") + "\n" + exc.StackTrace, Title = exc.Message, Type = exc.GetType().ToString() });
            }
        }
        [HttpGet("Weather")]
        public IEnumerable<WeatherForecast> Weather()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
