using hefth.CQRS.Commands.SectionCommands;
using hefth.data;
using hefth.data.Model;
using MediatR;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Text;

namespace hefth.CQRS.Handlers.SectionHandler
{
    public class SectionInsertHandler : IRequestHandler<SectionInsertCommand, Section>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        AppDbContext _db;

        public SectionInsertHandler(AppDbContext db, IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;

        }
        public async Task<Section> Handle(SectionInsertCommand request, CancellationToken cancellationToken)
        {
            
            var part = await _db.Participants.SingleOrDefaultAsync(x => x.Email ==
            request.sectiondto.ParticipantEmail);

            


            double prevAverage = 0;

            
            
            var IsParticipant = await _db.Sections.Where(x => x.ParticipantId ==
            part.Id).ToListAsync();

            if(IsParticipant != null)
            {
                prevAverage = IsParticipant.Sum(x => x.Average);
            }


            var authorizationHeaderValue = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();

            var userid = "";
            
            if (!string.IsNullOrEmpty(authorizationHeaderValue) && authorizationHeaderValue.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var accessToken = authorizationHeaderValue.Substring("Bearer ".Length);
                userid = GetUserIdFromToken(accessToken);
               
            }

            

            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == userid);

            var section = new Section
            {
            HefthFullDegree = request.sectiondto.HefthFullDegree, 
            HefthPartDegree = request.sectiondto.HefthPartDegree,
            HefthNotes = request.sectiondto.HefthNotes,
            TaguidFullDegree = request.sectiondto.TaguidFullDegree, 
            TaguidPartDegree = request.sectiondto.TaguidPartDegree, 
            TaguidNotes = request.sectiondto.TaguidNotes,
            WaqfFullDegree =request.sectiondto.WaqfFullDegree,
            WaqfPartDegree = request.sectiondto.WaqfPartDegree,
            WaqfNotes = request.sectiondto.WaqfNotes,
            AzobaFullDegree = request.sectiondto.AzobaFullDegree,
            AzobaPartDegree = request.sectiondto.AzobaPartDegree,
            AzobaNotes = request.sectiondto.AzobaNotes,
            EnteqalFullDegree = request.sectiondto.EnteqalFullDegree,
            EnteqalPartDegree = request.sectiondto.EnteqalPartDegree,
            EnteqalNotes = request.sectiondto.EnteqalNotes,
            Average = (request.sectiondto.AzobaPartDegree 
            + request.sectiondto.EnteqalPartDegree
            + request.sectiondto.WaqfPartDegree
            + request.sectiondto.TaguidPartDegree
            + request.sectiondto.HefthPartDegree) / 5 + prevAverage,
            ParticipantId = part.Id,
            Participant = part,
            UserId = userid,
            User = user
            };

            await _db.Sections.AddAsync(section);
            _db.SaveChanges();
            return await Task.FromResult(section);
        }


        public string GetUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]);
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _configuration["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = _configuration["JWT:Audience"],
                ClockSkew = TimeSpan.Zero // You may need to adjust this based on your requirements
            };

            try
            {
                // Validate and decode the token
                var claimsPrincipal = tokenHandler.ValidateToken(token, validations, out SecurityToken validatedToken);

                // Retrieve the user ID from the decoded claims
                var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

                return userIdClaim?.Value;
            }
            catch (Exception ex)
            {
                // Handle the case where token validation fails
                return null;
            }
        }
    }
}
