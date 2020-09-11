using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart.Data.Migrations
{
    public partial class addpermision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupRoles",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    RoleId = table.Column<string>(nullable: true),
                    ControllerName = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisions",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ICon = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    IsNewTab = table.Column<bool>(nullable: false),
                    ColorText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrackingActives",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    JsonObjectNew = table.Column<string>(nullable: true),
                    JsonObjectOld = table.Column<string>(nullable: true),
                    EntityName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingActives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleGroups",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 128, nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    GroupRoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleGroups", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupRoles");

            migrationBuilder.DropTable(
                name: "Permisions");

            migrationBuilder.DropTable(
                name: "TrackingActives");

            migrationBuilder.DropTable(
                name: "UserRoleGroups");
        }
    }
}
