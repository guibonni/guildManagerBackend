using Microsoft.EntityFrameworkCore.Migrations;

namespace GCGuildManager.Migrations
{
    public partial class Teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosBatalha_Equipes_equipeAtaqueid",
                table: "RegistrosBatalha");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosBatalha_Equipes_equipeDefesaid",
                table: "RegistrosBatalha");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosBatalha_Membros_membroid",
                table: "RegistrosBatalha");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosChefe_Membros_membroid",
                table: "RegistrosChefe");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistrosPoder_Membros_membroid",
                table: "RegistrosPoder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrosPoder",
                table: "RegistrosPoder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrosChefe",
                table: "RegistrosChefe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrosBatalha",
                table: "RegistrosBatalha");

            migrationBuilder.RenameTable(
                name: "RegistrosPoder",
                newName: "registro_poder");

            migrationBuilder.RenameTable(
                name: "RegistrosChefe",
                newName: "registro_chefe");

            migrationBuilder.RenameTable(
                name: "RegistrosBatalha",
                newName: "registro_batalha");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosPoder_membroid",
                table: "registro_poder",
                newName: "IX_registro_poder_membroid");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosChefe_membroid",
                table: "registro_chefe",
                newName: "IX_registro_chefe_membroid");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosBatalha_membroid",
                table: "registro_batalha",
                newName: "IX_registro_batalha_membroid");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosBatalha_equipeDefesaid",
                table: "registro_batalha",
                newName: "IX_registro_batalha_equipeDefesaid");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosBatalha_equipeAtaqueid",
                table: "registro_batalha",
                newName: "IX_registro_batalha_equipeAtaqueid");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Cargos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_registro_poder",
                table: "registro_poder",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registro_chefe",
                table: "registro_chefe",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_registro_batalha",
                table: "registro_batalha",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_registro_batalha_Equipes_equipeAtaqueid",
                table: "registro_batalha",
                column: "equipeAtaqueid",
                principalTable: "Equipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_registro_batalha_Equipes_equipeDefesaid",
                table: "registro_batalha",
                column: "equipeDefesaid",
                principalTable: "Equipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_registro_batalha_Membros_membroid",
                table: "registro_batalha",
                column: "membroid",
                principalTable: "Membros",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_registro_chefe_Membros_membroid",
                table: "registro_chefe",
                column: "membroid",
                principalTable: "Membros",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_registro_poder_Membros_membroid",
                table: "registro_poder",
                column: "membroid",
                principalTable: "Membros",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_registro_batalha_Equipes_equipeAtaqueid",
                table: "registro_batalha");

            migrationBuilder.DropForeignKey(
                name: "FK_registro_batalha_Equipes_equipeDefesaid",
                table: "registro_batalha");

            migrationBuilder.DropForeignKey(
                name: "FK_registro_batalha_Membros_membroid",
                table: "registro_batalha");

            migrationBuilder.DropForeignKey(
                name: "FK_registro_chefe_Membros_membroid",
                table: "registro_chefe");

            migrationBuilder.DropForeignKey(
                name: "FK_registro_poder_Membros_membroid",
                table: "registro_poder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_registro_poder",
                table: "registro_poder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_registro_chefe",
                table: "registro_chefe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_registro_batalha",
                table: "registro_batalha");

            migrationBuilder.RenameTable(
                name: "registro_poder",
                newName: "RegistrosPoder");

            migrationBuilder.RenameTable(
                name: "registro_chefe",
                newName: "RegistrosChefe");

            migrationBuilder.RenameTable(
                name: "registro_batalha",
                newName: "RegistrosBatalha");

            migrationBuilder.RenameIndex(
                name: "IX_registro_poder_membroid",
                table: "RegistrosPoder",
                newName: "IX_RegistrosPoder_membroid");

            migrationBuilder.RenameIndex(
                name: "IX_registro_chefe_membroid",
                table: "RegistrosChefe",
                newName: "IX_RegistrosChefe_membroid");

            migrationBuilder.RenameIndex(
                name: "IX_registro_batalha_membroid",
                table: "RegistrosBatalha",
                newName: "IX_RegistrosBatalha_membroid");

            migrationBuilder.RenameIndex(
                name: "IX_registro_batalha_equipeDefesaid",
                table: "RegistrosBatalha",
                newName: "IX_RegistrosBatalha_equipeDefesaid");

            migrationBuilder.RenameIndex(
                name: "IX_registro_batalha_equipeAtaqueid",
                table: "RegistrosBatalha",
                newName: "IX_RegistrosBatalha_equipeAtaqueid");

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Cargos",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrosPoder",
                table: "RegistrosPoder",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrosChefe",
                table: "RegistrosChefe",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrosBatalha",
                table: "RegistrosBatalha",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosBatalha_Equipes_equipeAtaqueid",
                table: "RegistrosBatalha",
                column: "equipeAtaqueid",
                principalTable: "Equipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosBatalha_Equipes_equipeDefesaid",
                table: "RegistrosBatalha",
                column: "equipeDefesaid",
                principalTable: "Equipes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosBatalha_Membros_membroid",
                table: "RegistrosBatalha",
                column: "membroid",
                principalTable: "Membros",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosChefe_Membros_membroid",
                table: "RegistrosChefe",
                column: "membroid",
                principalTable: "Membros",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosPoder_Membros_membroid",
                table: "RegistrosPoder",
                column: "membroid",
                principalTable: "Membros",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
