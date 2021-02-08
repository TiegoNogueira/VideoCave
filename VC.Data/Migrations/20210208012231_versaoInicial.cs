using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VC.Data.Migrations
{
    public partial class versaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(100)", nullable: false),
                    Etag = table.Column<string>(type: "varchar(100)", nullable: true),
                    DataPublicacao = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IdCanal = table.Column<string>(type: "varchar(100)", nullable: true),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(100)", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "varchar(100)", nullable: true),
                    ThumbnailmqUrl = table.Column<string>(type: "varchar(100)", nullable: true),
                    ThumbnailhqUrl = table.Column<string>(type: "varchar(100)", nullable: true),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");
        }
    }
}
