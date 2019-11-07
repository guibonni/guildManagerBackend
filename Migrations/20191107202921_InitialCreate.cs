using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GCGuildManager.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Mascotes",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Membros",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    cargoid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membros", x => x.id);
                    table.ForeignKey(
                        name: "FK_Membros_Cargos_cargoid",
                        column: x => x.cargoid,
                        principalTable: "Cargos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personagens",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    classeid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personagens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Personagens_Classes_classeid",
                        column: x => x.classeid,
                        principalTable: "Classes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosChefe",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    membroid = table.Column<long>(nullable: true),
                    data = table.Column<DateTime>(nullable: false),
                    dano = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosChefe", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegistrosChefe_Membros_membroid",
                        column: x => x.membroid,
                        principalTable: "Membros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosPoder",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    membroid = table.Column<long>(nullable: true),
                    data = table.Column<DateTime>(nullable: false),
                    poder = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosPoder", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegistrosPoder_Membros_membroid",
                        column: x => x.membroid,
                        principalTable: "Membros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    personagem1id = table.Column<long>(nullable: true),
                    personagem2id = table.Column<long>(nullable: true),
                    personagem3id = table.Column<long>(nullable: true),
                    personagem4id = table.Column<long>(nullable: true),
                    personagem5id = table.Column<long>(nullable: true),
                    personagem6id = table.Column<long>(nullable: true),
                    mascote1id = table.Column<long>(nullable: true),
                    mascote2id = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Equipes_Mascotes_mascote1id",
                        column: x => x.mascote1id,
                        principalTable: "Mascotes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Mascotes_mascote2id",
                        column: x => x.mascote2id,
                        principalTable: "Mascotes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Personagens_personagem1id",
                        column: x => x.personagem1id,
                        principalTable: "Personagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Personagens_personagem2id",
                        column: x => x.personagem2id,
                        principalTable: "Personagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Personagens_personagem3id",
                        column: x => x.personagem3id,
                        principalTable: "Personagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Personagens_personagem4id",
                        column: x => x.personagem4id,
                        principalTable: "Personagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Personagens_personagem5id",
                        column: x => x.personagem5id,
                        principalTable: "Personagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipes_Personagens_personagem6id",
                        column: x => x.personagem6id,
                        principalTable: "Personagens",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosBatalha",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    membroid = table.Column<long>(nullable: true),
                    data = table.Column<DateTime>(nullable: false),
                    primeiroAtaque = table.Column<int>(nullable: false),
                    segundoAtaque = table.Column<int>(nullable: false),
                    defesa = table.Column<int>(nullable: false),
                    equipeAtaqueid = table.Column<long>(nullable: true),
                    equipeDefesaid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosBatalha", x => x.id);
                    table.ForeignKey(
                        name: "FK_RegistrosBatalha_Equipes_equipeAtaqueid",
                        column: x => x.equipeAtaqueid,
                        principalTable: "Equipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosBatalha_Equipes_equipeDefesaid",
                        column: x => x.equipeDefesaid,
                        principalTable: "Equipes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosBatalha_Membros_membroid",
                        column: x => x.membroid,
                        principalTable: "Membros",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_mascote1id",
                table: "Equipes",
                column: "mascote1id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_mascote2id",
                table: "Equipes",
                column: "mascote2id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_personagem1id",
                table: "Equipes",
                column: "personagem1id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_personagem2id",
                table: "Equipes",
                column: "personagem2id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_personagem3id",
                table: "Equipes",
                column: "personagem3id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_personagem4id",
                table: "Equipes",
                column: "personagem4id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_personagem5id",
                table: "Equipes",
                column: "personagem5id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipes_personagem6id",
                table: "Equipes",
                column: "personagem6id");

            migrationBuilder.CreateIndex(
                name: "IX_Membros_cargoid",
                table: "Membros",
                column: "cargoid");

            migrationBuilder.CreateIndex(
                name: "IX_Personagens_classeid",
                table: "Personagens",
                column: "classeid");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosBatalha_equipeAtaqueid",
                table: "RegistrosBatalha",
                column: "equipeAtaqueid");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosBatalha_equipeDefesaid",
                table: "RegistrosBatalha",
                column: "equipeDefesaid");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosBatalha_membroid",
                table: "RegistrosBatalha",
                column: "membroid");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosChefe_membroid",
                table: "RegistrosChefe",
                column: "membroid");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosPoder_membroid",
                table: "RegistrosPoder",
                column: "membroid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosBatalha");

            migrationBuilder.DropTable(
                name: "RegistrosChefe");

            migrationBuilder.DropTable(
                name: "RegistrosPoder");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Membros");

            migrationBuilder.DropTable(
                name: "Mascotes");

            migrationBuilder.DropTable(
                name: "Personagens");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Classes");
        }
    }
}
