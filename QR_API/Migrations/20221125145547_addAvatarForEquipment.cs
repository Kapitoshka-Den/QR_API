using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace QRAPI.Migrations
{
    /// <inheritdoc />
    public partial class addAvatarForEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "equipment",
                columns: table => new
                {
                    equipmenttableid = table.Column<long>(name: "equipment_table_id", type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    responsiblename = table.Column<string>(name: "responsible_name", type: "character varying", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("equipment_pk", x => x.equipmenttableid);
                });

            migrationBuilder.CreateTable(
                name: "equipment_photos",
                columns: table => new
                {
                    phototableid = table.Column<long>(name: "photo_table_id", type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    photo = table.Column<string>(type: "character varying", nullable: true),
                    equipmentfkid = table.Column<long>(name: "equipment_fk_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("equipment_photos_pk", x => x.phototableid);
                    table.ForeignKey(
                        name: "equipment_photos_fk",
                        column: x => x.equipmentfkid,
                        principalTable: "equipment",
                        principalColumn: "equipment_table_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_equipment_photos_equipment_fk_id",
                table: "equipment_photos",
                column: "equipment_fk_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "equipment_photos");

            migrationBuilder.DropTable(
                name: "equipment");
        }
    }
}
