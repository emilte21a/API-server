using APIserver;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

TeacherData data = new();

app.MapGet("/", GetSomething);
app.MapGet("/teachers/{ID}", data.GetTeacher);
app.Urls.Add("http://*:5096");

app.MapPost("/teachers", data.PostTeacher);

app.Run();

static string GetSomething()
{
    return "hooooo";
}

class TeacherData
{
    public List<Teacher> teachers = new(){
        new Teacher(){Name = "Micke", HitPoints = 100},
        new Teacher(){Name = "Martin", HitPoints = 3},
        new Teacher(){Name = "Lena", HitPoints = 9000}
    };

    public IResult PostTeacher(Teacher t)
    {
        System.Console.WriteLine(t.Name);
        return Results.Ok();
    }
    public IResult GetTeacher(int ID)
    {
        if (ID < 0 || ID >= teachers.Count)
            return Results.NotFound();

        return Results.Ok(teachers[ID]);
    }

}

