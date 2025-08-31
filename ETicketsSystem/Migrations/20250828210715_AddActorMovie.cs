using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicketsSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddActorMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into ActorMovie (ActorsId, MoviesId) values (25, 10);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (29, 26);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (41, 21);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (23, 30);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (26, 11);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (2, 13);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (28, 15);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (43, 13);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (40, 11);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (49, 29);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (11, 24);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (13, 1);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (44, 19);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (10, 9);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (42, 14);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (5, 16);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (44, 7);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (46, 11);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (16, 12);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (34, 7);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (1, 22);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (9, 2);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (42, 8);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (38, 19);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (27, 21);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (14, 15);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (22, 25);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (5, 6);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (24, 9);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (22, 28);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (29, 13);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (2, 21);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (22, 22);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (18, 29);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (6, 2);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (42, 28);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (47, 9);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (6, 9);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (9, 23);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (47, 29);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (40, 23);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (39, 11);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (34, 15);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (37, 4);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (22, 21);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (30, 1);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (49, 24);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (10, 18);\r\ninsert into ActorMovie (ActorsId, MoviesId) values (18, 19);\r\n\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("truncate table ActorMovie");
        }
    }
}
