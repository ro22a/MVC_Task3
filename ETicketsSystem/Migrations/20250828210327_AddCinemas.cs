using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETicketsSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddCinemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Cinemas (Name, Description, CinemaLogo, Address) values ('Photospace', 'Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.\r\n\r\nDonec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.\r\n\r\nDuis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.', 'Quis.tiff', '395 Welch Junction');\r\ninsert into Cinemas (Name, Description, CinemaLogo, Address) values ('Trilith', 'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.\r\n\r\nSed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.', 'Sagittis.tiff', '6958 Debra Avenue');\r\ninsert into Cinemas (Name, Description, CinemaLogo, Address) values ('Oozz', 'Praesent id massa id nisl venenatis lacinia. Aenean sit amet justo. Morbi ut odio.', 'DisParturientMontes.jpeg', '710 Weeping Birch Junction');\r\ninsert into Cinemas (Name, Description, CinemaLogo, Address) values ('Dynava', 'Proin leo odio, porttitor id, consequat in, consequat ut, nulla. Sed accumsan felis. Ut at dolor quis odio consequat varius.\r\n\r\nInteger ac leo. Pellentesque ultrices mattis odio. Donec vitae nisi.\r\n\r\nNam ultrices, libero non mattis pulvinar, nulla pede ullamcorper augue, a suscipit nulla elit ac nulla. Sed vel enim sit amet nunc viverra dapibus. Nulla suscipit ligula in lacus.', 'Sapien.ppt', '8 Macpherson Place');\r\ninsert into Cinemas (Name, Description, CinemaLogo, Address) values ('Skinix', 'Fusce posuere felis sed lacus. Morbi sem mauris, laoreet ut, rhoncus aliquet, pulvinar sed, nisl. Nunc rhoncus dui vel sem.\r\n\r\nSed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.\r\n\r\nPellentesque at nulla. Suspendisse potenti. Cras in purus eu magna vulputate luctus.', 'SitAmetSem.tiff', '9435 Norway Maple Parkway');\r\ninsert into Cinemas (Name, Description, CinemaLogo, Address) values ('Brightbean', 'Sed sagittis. Nam congue, risus semper porta volutpat, quam pede lobortis ligula, sit amet eleifend pede libero quis orci. Nullam molestie nibh in lectus.', 'CurabiturConvallisDuis.xls', '4 Armistice Avenue');\r\ninsert into Cinemas (Name, Description, CinemaLogo, Address) values ('Topicblab', 'Duis bibendum. Morbi non quam nec dui luctus rutrum. Nulla tellus.\r\n\r\nIn sagittis dui vel nisl. Duis ac nibh. Fusce lacus purus, aliquet at, feugiat non, pretium quis, lectus.\r\n\r\nSuspendisse potenti. In eleifend quam a odio. In hac habitasse platea dictumst.', 'Dictumst.gif', '52 Paget Way');\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("truncate table Cinemas");
        }
    }
}
