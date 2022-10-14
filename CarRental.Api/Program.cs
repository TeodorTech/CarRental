
using CarRental.Api;
using CarRental.Api.Controllers;
using CarRental.Application.Cars.Commands;
using CarRental.Application.Repositories;
using CarRental.Domain;
using CarRental.Domain.Interfaces;
using CarRental.Domain.Interfaces.Repositories;
using CarRental.Infrastrcuture;
using CarRental.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                          });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckledata:image/pjpeg;base64,/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/2wBDAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQEBAQH/wAARCABAAEADASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD+mDJIHPOBzgdgB6elPEjcZx7/ACr/AIVGOg+g/lRzk+h5H9fzJqqcr9d/z0NasbPTp/X6mxZzbW2HGCR/COnscdj/ADP4bc/iDStBtBf6xq2maNZR71e81S9tdPtUKxyTsr3F1LFEu2CGWZ8uNsUUspwkbMv5mf8ABQL9qXxr+z/4L8CeCPhCdPt/jX8dNe1Hwt4K17WLO31DTPAmg6RFpi+MviH/AGZfxnSdd1bw2df8PWOg6Dq80enXGr6/a6xqdtq2i6Fq2kXs3wP/AOCTH7PHxp0fS/jb+1J8RfiT+0F8R20C3uNd174keOJbiwtBJeX+vahpmjXbPbx+FPCWnXuq6mNP8PeFbrw14Y0W1uLiKz0iG3lmeX57POKsJlGIo4GOGrY3HVYOfsaMoU4U4RV1KrVquybjqoQjOTTvax7+TcN4rNqFbGe2pYTB0Jwpyr1VUnKdSUklClSpQnKVrpSlLkpptJzvdH656LcDVEtpbGWK4huo4ZobiIpJBJBIiyR3CzJuVoWjYSLKpYOrKVLFgD67pYtNKt9sJ3SvgzSn/lqwz7lVRASEXHTk/MxNflj8N/hr+zZ+xR4w+HOmfATxVpfgv4YfG+9m8MxfDGw+KK+IvAHiHxdewR6jonj/AMC6DrM3iC8/4SaSa2Ph7VpPh1qeg+H9e0vxEuveN7HWpvC3hzUdH/RGLVwV4J/Bjjvx1X69TX03BmaZfn2ArZjh6VWlicPiZ4LE0K6XPhqsYU6loSi5RqQqUqtOca0bXvKm1GUJxPN4iyvGZHi6WDxE6c6dehDF4atS5lHEUZznSvKM0p05wqUZwlSle1uaMpwnGcvSZNYx3Uc8Y2/0XPT1qm2syA53/dPGBnBzxzgdTjHDfjmuAk1NsE7gOc8kf057+9U31M95T6jaD65wM5544xivsfW3Tfby38z57ml3/ry0/wAuvz+dB0H0H8qCM/hyPqKB0H0H8qr3l5b2FtLd3cqwwQrud2OPYKo6s7nCoi5ZmIABNfB0+ZzUYptyaUUle8m1ay7vY9uolZydkopuTeyS1u76WWrbeyPkj9pz9kG7/aU8U/CDxva+INN0yX4Q3Wv6XZaDf6Vq94fFuofFPX/h5pYtRqehPdapotnoul+G9V1jUtQg0TUrWzs4n1TWr3w94e0zWNcs/o/w/qvwS1r9j+31j4heIpvBXhzwf4EOq/EC1jgun1bT9fsNLM3iXRrrT7ZZdfl8WxauJYbCSxceJbjWre0j0+V5L7yLvwb4wfEjxPpuhL4g8HfFaf4KarpGu+F1sPGkUXh+4aKyv/FuhWWreHBp/iq3vPDWqap43055PCfh+01nT9Ugt/FWq6BqWnafca3pul4/OH4+fHfX/wBiP49eO/Dnxg8D6l4y8G658Tbr4g+Bte1K2tdU0nxB4d1bXtV8U6U/iTwhZ2NnY3WqW9zbDTNO1F7GXQFv47vV47We98LPoUP5R4jZbjssz+lWq044yOYYKNWjQ5nD2SpKnQqUYyg4SnWhUgqz963LJJXXMfrHh1meCxuS1MNRlLB1cvx969f/AJ/OcnUhVn7WNWnClOlJ4fWmkpQcpQTlFy7/APaK+P8A+xRe6r+y14D8Nr8SfCPiPw9r2maJ4I+K0OjWt1a2d9qEfhXxfpX23W10zUB41TW/Gkel6BPqukavYJpN03izUtP1q1sD4R125/Z/wL8Q9M8deFfDHjLw9NdTaJ4u8O6R4q0Z54ljuJdG1zSodZsZriKKWeONzp91HNOiTSpF8/710XzD/PV8cP2m/hN/wUk8feBvAH7MFjq9t8WvHF/4N1rxBp1t4Wm1Sz+Fy6TqVjofjT4y6lYXXijw34c01/A/gu8v7XT9Ykg0XWdeu38KeEbLxRaX2q6Npl7+/wCLHRvAHhDTdD0210uwUw2WjWVhpltHYadpWjaXBAINM0LT7aKGCw0jTorWxsILaKKGJYXjVYo4o7e2tvq/CWli8HSzac44hYbE1cFh6FOtSVFTq0FiJYjEUKfKnCjTpVoKbu41aqaXLOMz5/xXx2CxdfJ4UXR+sUKGNxeNnTxCxEqcMVPDqjh6layVSpOrRqzgnGMqdOTXvQcJP0k6uWUfvABx19cfTHr3NU31c9DIT6gsR377c5z+FeZ2+tbwAH/h5+Y449WyffnA59eolOpO7hFYu7OqIgEjMzMwVVGc7mLEAADkngE4FfskpWerelnaya6fPv8A0j8iVbRWfb3dL9F+qI7/AFGy0mxm1DULiO1tLaMPLNIcAZwqqoGWeSRyqRxoC8jsqKCxAr4w+NX7QvgnwXpNx4s+IXi3RfAvg+z+0pYy67qEdqb64t7K91E21lZhpLvW/ENzZWF3JZ6Lo1vf6pciCS2020u5Q5l+Y/2+P2q9T8BfA3x34u0TUE0a+MUHhj4fWctzbQX8niDxDMNNj1a1ilS7ttQ8RaJo76v4qtbB4bu1ig0S4heOW0F9PP8AybeJPGvi3xnql34h8b+KNd8Wa3fyRC51vxBq99rutTJBH5cFteajeme4uYrG3SK2spmjtyLeK0sZIUuA5bzMvwUcIlVqRU8S11d40U7e6kt5tbvp9l2bb3xOKljnKnSly4eMrPpKrtruvdV3aL6ayV7JfsB+0v8A8FNvB/jvx/8ACey8B/D2Xxr8OfhL8Z/AXxi1KXxHcXHhbVPiRqPwt8VQ67o+meHY5bS9vPDGh3jWkWp21/q2mnxFe3U2n2ur+HNG0/T9a0bxF/UJ46+Ev7Of/BQz4C/Dz4waYsPxA0jxJ4S0s6Df6Sun6nf2za7ELXUNH1oWF5d2+iapoVzNe6f4wsU1JJPD+oWOo2+rGaKwuYT/AAafBX4iD4P/ABM8J/Es+Avht8UR4Zur66XwL8XvBtl4++HniFNQ0rUNHeDxB4U1F0ttUNrDqLX+kvJLHNpes22narbNHeWETL/o1/su/Cn4K/Br4HTXnwc+F7/Bjwv8X9WuPjb4g+H0tnq+hXXh/wAS+PtD0Q61Z3HhTVtV1Gy+Ht3p+mWlhos/gzRH03w14SuLCS003TYGtJzL+U+KOFw+JxOErV4VYYiWDqwp4uFWHslTw9SMpUZUnNTp1aUsRCcK0Y8s41p05puMXH9H4Br4jLqNWGGlTnR+t0nUw8ozVRyrQS5va2cZQqRozjKndyi6cXFwvr+HX/BNX/gnLffDv9rf4wfHvwb4vk+H/wAN7G01b4ZXfgq40Cz8QN8R9F1fUIdRt5NHvbPxnJN4RHgvxN4f0LXbbXrjw9r8XiTRNa1PSVvfD6X1zdab9UftyftW/DD9k3x/4K8P/GnV9d8O+Etf0fV20zx/a+Edc1zwfZ+JrKTSbl/C+rzeGrfXtZ0/X/EOi6lDq/h8jTb7wxfWfh3xPBH4kTV9FvdNH5R/t5/8FiPg7+xz/wAFFfDNx8FvhH8MfiRDo8Oj/wDDRXjLWfBen+KPF/h+fUpLex1M/AHxOviXQ9W8I+Jk8HRuuqafdz6b4N8UNH4ev47CN9V1fxJqX6n/ABY8M/su/wDBXH9lDWtN8DfEjw/r+h+NLSz8eeD/AB9pi2t1rHgTxjby6g1jq1/oGvppmo6Pr2nTSa3oniLw2f7F1qbSrnxR4S+22E11eSw/JZJxHn3CsMkxVdTr5ZXqShV54c8KuGfPGpPDxcvaU66UniaUeeLxFKLUrqd6X0me5Fk/E9bOKVHkw2PpQpzUKT5HRxUVRlBVmouNSi3H2NSymqVWUVZOPLPpPhx8YfAHxO0ibX/hv488I+P9CtL59Ju9W8F+JdG8T6bZ6rDZ2d/PpV3f6HfXtrbalBZalYXctlLKtxHbXtpO8YhuoHk+g/h7v1nxfo8SpO8NpMdTnlgBP2caepubd52O4RwSXqWts7EfMZxGrCR0NfyTfsE+PvjH+wt+2fqX7EPxgs9MsfDfxU1bVBZ6lc69fxeH4PF+k6ZqS+EvGHw+uLoQ6PqmmfFCPS08GXttcWOm6/qWvweC9Kmn03WvD934Y1T+uv8AZ1tnvV1/X5klCxC20ezn3jyJC+b3UovLBJMkW3S5A7YCrMUTJL7f3uGaYbMMq/tDCVaVejXpRdOpSk3CaqqPLKF7yS5Z7NXjKMoS5ZRdvxB5disBmyy3FU6lOdKq+enVXLNRpPmmpW0veLV9VKMoyV4zV/5U/wDgqh4+vrfwF8LPANnb2bXPibxZrvim2vbu4KCK48G6PFpUdo8LtGs9tcL45kuZVhmjuRJYRAEwtIr/AIj3ujarLdpPd6jeIyWytFbxRwXOnC4EsUpM9vb6NDEscyQeSst3qc00UdxILeSG58u4r+lTxz+xvqX7cnxu+Cvw2XxfB8P/AA54f8P/ABT8Q+KvGk+iy+I57K3uJfh/pui6PpOjrc6bFfaxresvAqw3mu6DawaHaa/q4vL2+0ey0XUv08+Gn/BEv9hf4beLx4yvX+KvxI0rw3cAaV4b+Lut+GNW8O3mr2N1bOL++0zQPh/4LXWNLt7pZrKTSNbnv9Hu4I5pr6w1OwvLTyfn+I+Pcl4fxVfA13WxWZU6cKzwWGUYuKnSjVputWrTp06alHlk2pTajODcHzwU/pOFuE80znA4fG04wo4KrUqRWJqczUvZ1vYz9nTpKdScoyTgk1BSlGdpKMG4/ih/wRp/4J0X/wAevGmjftG/HLwm8f7Pvw61RLzw1pGv6fLHY/FbxbpkhaxsrXTriNINa8D+Fr+NJteu5fN0HXb+0h8PzQavpR8R2lt+k3/Bdb/go74p/Zq/Zgk+HXwe8RNp/wARPi/qMfgmy1uGW3uNT8O6Jaxfa9f1SyjtruKO3vJbK0Gnx38SXlkJ72HFvPFcS+R+qfxQ8f8AhnwF4a0nwD8PLTS/CuheHtMS0ttI0XTrLS9K8NaJp1rvK28FpaQaRaWcKWsebW1jhtAke6BPJkWaL/Pu/wCClv7SNx+1f+1j4r1KzvhdfD/4XT3fgjweEcy281xaTRp4j1SMXNtDIr3N7Z22nSIJLm1li0WC7tJPKuZN34jlmZZn4icaRliIw/s/BfvcRRg3Uw1HDQadPBwbSjUVas17ec0pYhKq1CMIxpU/2PMsvwfBXCUpwTWNxj9jhZVOWNeeIqq9XGSSu4OjSUnQ5XJUZKjBSlOUqlT87tIsNQ1m/vdU1u7utS1LV7q5vtQv7+4nub2/v76V57u/vrud5J7u8ubiR5p553kknmeWWVnkYtX6I/8ABPH9oLxD+yp+058M9aXx94s8M/CfxN4qtvD/AMRtF03xFfab4bRPE0KaBp3jHVtLfVLHRGbwpq0uj61qOp3tvPcReH9M1K0hEiz+RJ8W2iQ2yjb8oADcjJwDkkYyT8oA6euBnBov76AwskjKwzg78n5fQ8KPmzuC/LwO7Dn99xuR4PHZXXy/EUounVoTpK8I/urwUac6WnuSpO0qTjrBxVrNO/4tg81xGBx9HHUqklWpV4VXZte0tOM5wm1bmjVScaildTUpKV7s/sw/aN+APhb42yaJq934gn0T4j+DPFLeMvhN8ULa1s5tc8K+MtH1S01qHVJY7yBrXX7C91u00ybUvD2pTPpeoQ28zSmGeKC/f6X+AP7THxoufDb/AAw+JXhXRvhn4psrq4uW1rwBr9xq/hj4ohLLSDqfiDRtQvRD4h8HzWt5btax+BdQihvo9DxNBr/jyC38QanpX5J/sCfti6d8bfgVp/gvxfqhf4jfDn+z/DOr6rc3bzalqtvawtF4c8UT3E99qGo3NxqemySpqep309rc3niex12a3it7RLaSbrfFfxA8R+EPFtr4u0Sa71OHw7qlrqU0UN3PZfaYtPnWWTR5biweORYtUtUvLS4ijSSOayku7S6WZJ2tq/nzh7POIOBs6nk+JnDE5SswhHF4PEQbhTh7SzxeBqOTdCq6clXjC06NR/FBSm6i/eeI+Gsh44yOOe4NVMLmryyc8JjcNK06k4Uoy+p4+KSVaCqQVCc1yVqKuoTdNeyf/9k=
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();


builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddEntityFrameworkStores<DataContext>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ContentEditor", policy =>
    {
        policy.RequireRole("Warchief");
    });
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"))
        };
    });




builder.Services.AddMediatR(typeof(CreateCarHandler));
builder.Services.AddAutoMapper(typeof(Assembly));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMyMiddleware();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
