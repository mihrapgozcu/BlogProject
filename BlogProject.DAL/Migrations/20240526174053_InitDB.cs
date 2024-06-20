using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.DAL.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmCode = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Article_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Article_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleVisitor_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArticleVisitor_Visitor_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitor",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "85c8c1d8-c58a-494d-83e2-ea278fb6d537", "Admin", "ADMIN" },
                    { 2, "090f6b92-35b9-43be-8356-79b0bdee0255", "Author", "AUTHOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "ConfirmCode", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Path", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, "Super Admin", 0, "bf6298ad-3016-4cca-8d3e-91aa3c5b875c", null, "admin@deneme.com", true, "Cevdet", "Herodot", false, null, "ADMIN@DENEME.COM", "ADMIN@DENEME.COM", "AQAAAAEAACcQAAAAEElBerL2vKlV1UGLEZgBPoM1Z9U5P30OiiibI338ytyMJJN/ohqf590nv1MJ88mfsw==", "article-images/cevdet_heredot.png", "+905555555555555", true, "f9602784-8d3a-483b-b3c2-ecc866363244", false, "admin@deneme.com" },
                    { 2, "Yazmak onun işi.....", 0, "82b5d75c-23d0-4549-839e-38873c6403ee", null, "mihrapgozcu@gmail.com", true, "Mihrap", "Gözcü", false, null, "MIHRAPGOZCU@GMAIL.COM", "MIHRAPGOZCU@GMAIL.COM", "AQAAAAEAACcQAAAAEC4Srab3CChxKNRVxxi13JvY+Sp//0ji3PBrBUpNekWRifeoNli4oqj2V+H8ksSoug==", "article-images/mihrap_gozcu.png", "+905512444546", true, "1d1904a4-59ea-4e19-9a57-5a8e09cfcc02", false, "mihrapgozcu@gmail.com" },
                    { 3, "Yazmaya çalışıyor diyelim..", 0, "93d12010-bc2f-4dcc-9b51-c2cd0279c1ba", null, "akin@gmail.com", true, "Akın", "Gür", false, null, "AKIN@GMAIL.COM", "AKIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDhv0j3XXdy57G4YYnZwPwH+EepP3JpL6STe2XMMLv+DtwbY9GXlIxBrdrE5HOcKAA==", "article-images/resimsizler.png", "+9055358585858", true, "c3db2daa-1ac7-41f9-bcd9-5d6c53b3fd11", false, "akin@gmail.com" },
                    { 4, "Sitenin kıdemli yazar kadrosuna dahil.", 0, "460bc713-97fd-44d6-89b2-a09ec2743b1f", null, "yilmaz@gmail.com", true, "Yılmaz", "Uslu", false, null, "YILMAZ@GMAIL.COM", "YILMAZ@GMAIL.COM", "AQAAAAEAACcQAAAAELRxmCPa5eRqtw6KIsHWYx4U4ByJcEI1ePfJdYLVli2XOK2Osidl8rpAQLUjMlIDwQ==", "article-images/resimsizler.png", "+905556667788", true, "3e0b78fd-3c25-48be-85ec-21b42267a902", false, "yilmaz@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Yılmaz Uslu", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5463), null, null, false, "Teknoloji", null, null },
                    { 2, "Cevdet Heredot", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5465), null, null, false, "Ekonomi", null, null },
                    { 3, "Akın Gür", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5466), null, null, false, "Psikoloji", null, null },
                    { 4, "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5467), null, null, false, "Egitim", null, null },
                    { 5, "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5468), null, null, false, "Saglık", null, null }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Akın Gür", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5958), null, null, "article-images/psikoloji.png", "png", false, null, null },
                    { 2, "Cevdet Heredot", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5961), null, null, "article-images/ekonomi.png", "png", false, null, null },
                    { 3, "Yılmaz Uslu", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5962), null, null, "article-images/teknoloji.png", "png", false, null, null },
                    { 4, "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5963), null, null, "article-images/egitim.png", "png", false, null, null },
                    { 5, "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(5964), null, null, "article-images/saglik.png", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, null, 3, "Psikoloji, insan davranışlarını ve zihinsel süreçleri inceleyen bilim dalıdır. Bu disiplin, bireylerin düşünce, duygu ve davranışlarını anlamak, açıklamak ve bazen de değiştirmek amacıyla geliştirilmiştir. Psikoloji, çok yönlü bir alan olup, biyolojik, sosyal, bilişsel ve duygusal boyutları içerir.\n\nPsikolojinin kökenleri, antik filozofların insan doğasına dair sorular sormalarına kadar uzanır. Ancak, psikoloji modern anlamda 19. yüzyılın sonlarında Wilhelm Wundt’un ilk psikoloji laboratuvarını kurmasıyla bilimsel bir disiplin olarak şekillenmiştir. Wundt’un çalışmaları, deneysel yöntemleri psikolojik araştırmalara uygulamayı başlatmıştır.\n\nPsikoloji, zaman içinde çeşitli alt dallara ayrılmıştır. Klinik psikoloji, ruhsal bozuklukların tanı ve tedavisi ile ilgilenir. Danışmanlık psikolojisi, bireylerin yaşamlarındaki zorluklarla başa çıkmalarına yardımcı olur. Gelişim psikolojisi, yaşam boyu insan gelişimini inceler. Sosyal psikoloji, bireylerin grup içindeki davranışlarını ve toplumsal etkileri araştırır. Bilişsel psikoloji ise, zihinsel süreçler, öğrenme, hafıza ve problem çözme gibi konulara odaklanır.\n\nPsikolojinin pratik uygulamaları oldukça geniştir. Eğitimde, öğrenci başarısını artırmak ve öğretim yöntemlerini geliştirmek için psikolojik prensipler kullanılır. İş dünyasında, işyerinde verimliliği ve çalışan memnuniyetini artırmak amacıyla örgütsel psikoloji ilkeleri uygulanır. Sağlık alanında, hastaların hastalıklarıyla başa çıkmaları ve yaşam kalitelerini artırmaları için psikolojik destek sağlanır.\n\nSonuç olarak, psikoloji, insan davranışlarını ve zihinsel süreçleri anlamada ve iyileştirmede kritik bir rol oynar. Geniş uygulama alanları ve sürekli gelişen araştırma yöntemleri ile psikoloji, hem bireysel hem de toplumsal düzeyde önemli katkılar sunmaktadır.", "Akın Gür", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(3083), null, null, 1, false, "İnsan Davranışları ve Zihinsel Süreçlerin Bilimi: Psikolojiye Giriş", null, null, 3, 10 },
                    { 2, null, 2, "Ekonomi, kaynakların üretimi, dağıtımı ve tüketimi ile ilgilenen bir sosyal bilim dalıdır. Temel amacı, kıt kaynakların en verimli şekilde nasıl kullanılabileceğini incelemektir. Ekonomi, bireylerin, işletmelerin, hükümetlerin ve toplumların kararlarını nasıl aldıklarını ve bu kararların nasıl etkiler yarattığını araştırır.\n\nEkonominin iki ana dalı vardır: mikroekonomi ve makroekonomi. Mikroekonomi, bireysel tüketicilerin ve firmaların davranışlarını, piyasa mekanizmalarını ve fiyat oluşumunu inceler. Tüketici tercihleri, talep ve arz, fiyat esneklikleri gibi konular mikroekonominin temel inceleme alanlarıdır. Örneğin, bir ürünün fiyatı arttığında talebin nasıl değişeceği veya bir firmanın maliyetlerini minimize ederek karını nasıl maksimize edeceği gibi sorulara yanıt arar.\n\nMakroekonomi ise, genel ekonomik faaliyetleri, toplam üretim, işsizlik, enflasyon ve ekonomik büyüme gibi geniş çaplı konuları ele alır. Bir ülkenin Gayri Safi Yurtiçi Hasılası (GSYİH), işsizlik oranı, enflasyon oranı gibi makroekonomik göstergeler, o ülkenin ekonomik sağlığı hakkında bilgi verir. Merkez bankalarının para politikaları ve hükümetlerin mali politikaları, makroekonominin ana odak noktalarındandır.\n\nEkonomi teorileri ve modelleri, ekonomi politikalarının oluşturulmasında ve ekonomik sorunların çözümünde önemli bir rol oynar. Keynesyen ekonomi, özellikle ekonomik durgunluk dönemlerinde devlet müdahalesinin gerekliliğini savunur. Buna karşılık, neoliberal ekonomi teorisi, serbest piyasa mekanizmalarının ve minimal devlet müdahalesinin ekonomik büyüme için daha etkili olduğunu öne sürer.\n\nEkonominin pratik uygulamaları, günlük hayatımızda büyük bir etkiye sahiptir. Örneğin, bir hükümetin vergileri artırma veya azaltma kararı, bireylerin harcamalarını ve tasarruflarını doğrudan etkiler. Benzer şekilde, faiz oranlarındaki değişiklikler, hem kişisel hem de kurumsal borçlanma maliyetlerini belirler.\n\nSonuç olarak, ekonomi, hem bireysel hem de toplumsal düzeyde önemli kararların alınmasına rehberlik eden kapsamlı ve dinamik bir alandır. Ekonomik analizler ve politikalar, toplumların refahını artırmak, kaynakları daha etkin kullanmak ve sürdürülebilir büyümeyi sağlamak için kritik öneme sahiptir.", "Cevdet Heredot", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(3090), null, null, 2, false, "Kıt Kaynakların Yönetimi: Ekonomiye Giriş ve Temel Kavramlar", null, null, 1, 67 },
                    { 3, null, 1, "Teknoloji, insan yaşamını ve toplumu köklü bir şekilde değiştiren, geliştiren ve kolaylaştıran yenilikçi araçlar, sistemler ve yöntemler bütünüdür. Geniş kapsamıyla teknoloji, bilimsel bilgi ve mühendislik ilkelerinin pratik uygulamalara dönüştürülmesini içerir. Teknolojinin etkisi, tarımdan sağlığa, iletişimden eğitime, enerji üretiminden eğlenceye kadar hayatın her alanında görülür.\n\nTeknolojinin tarihçesi, insanlık tarihinin başlangıcına kadar uzanır. İlk teknolojik gelişmeler arasında taş aletler, ateşin kontrol edilmesi ve tekerleğin icadı bulunur. Bu buluşlar, insan yaşamını radikal bir şekilde değiştirmiş ve medeniyetlerin gelişimine katkıda bulunmuştur. Endüstri Devrimi ile birlikte, buhar gücü, makineler ve seri üretim teknikleri, sanayi ve ekonomi üzerinde büyük bir etki yarattı. 20. yüzyılda ise, elektrik, otomobil, uçak, radyo ve televizyon gibi icatlar, günlük yaşamın vazgeçilmez unsurları haline geldi.\n\nGünümüzde teknoloji, dijital devrim ile yeni bir boyuta taşınmıştır. Bilgisayarlar, internet, akıllı telefonlar ve yapay zeka, bilgiye erişim ve iletişimde devrim yaratmıştır. İnternet, dünyanın dört bir yanındaki insanların bilgi paylaşımını ve iletişimini kolaylaştırarak küresel bir ağ oluşturmuştur. Sosyal medya platformları, insanların birbirleriyle etkileşimde bulunma şeklini değiştirirken, e-ticaret siteleri alışveriş alışkanlıklarını dönüştürmüştür.\n\nYapay zeka ve makine öğrenimi, teknoloji alanındaki en son yenilikler arasındadır. Bu teknolojiler, veri analizi, tahmin yapma ve karmaşık problemleri çözme kapasitesine sahiptir. Sağlık sektöründe, tıbbi teşhis ve tedavi yöntemlerinde yapay zeka kullanımı hızla artmaktadır. Otomotiv endüstrisinde, otonom araçlar, güvenliği artırmak ve ulaşımı daha verimli hale getirmek amacıyla geliştirilmektedir.\n\nTeknolojinin sunduğu fırsatlar ve kolaylıkların yanı sıra, bazı zorluklar ve etik meseleler de gündeme gelmektedir. Siber güvenlik, kişisel verilerin korunması, dijital bağımlılık ve otomasyonun iş gücü üzerindeki etkileri, dikkatle ele alınması gereken konular arasındadır. Bu sorunların üstesinden gelmek için, teknoloji politikalarının geliştirilmesi ve etik kuralların uygulanması önemlidir.\n\nSonuç olarak, teknoloji, modern yaşamın ayrılmaz bir parçası haline gelmiş ve toplumsal dönüşümün ana itici güçlerinden biri olmuştur. Sürekli yenilenen ve gelişen teknolojik yenilikler, insanlığın karşılaştığı pek çok soruna çözüm sunarken, yaşam kalitesini de artırmaya devam etmektedir. Bu hızlı değişim sürecinde, teknolojinin bilinçli ve sorumlu bir şekilde kullanılması, sürdürülebilir ve adil bir gelecek için büyük önem taşımaktadır.", "Yılmaz Uslu", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(3092), null, null, 3, false, "Teknolojinin Toplumsal Dönüşümü: Geçmişten Günümüze Yeniliklerin İzinde", null, null, 4, 95 },
                    { 4, null, 4, "Eğitim, bireylerin bilgi, beceri, değer ve tutumlar edinmesini sağlayan, toplumların kültürel, sosyal ve ekonomik gelişimini destekleyen temel bir süreçtir. Eğitim, bireylerin potansiyellerini gerçekleştirmelerine, eleştirel düşünme yetilerini geliştirmelerine ve toplum içinde etkin bir şekilde yer almalarına yardımcı olur. Bu süreç, sadece formal eğitim kurumlarıyla sınırlı kalmaz; aynı zamanda aile, çevre ve çeşitli sosyal etkileşimlerle de gerçekleşir.\n\nEğitimin tarihçesi, insanlık tarihi kadar eskidir. Antik çağlarda eğitim, büyük ölçüde bire bir öğretim ve ustalık sistemi üzerinden yürütülürdü. Ortaçağ'da manastırlar ve medreseler, bilgi aktarımının merkezi haline gelirken, Rönesans dönemi ile birlikte bilim ve sanatın yeniden canlanması, modern eğitim anlayışının temellerini atmıştır. 19. ve 20. yüzyıllarda, sanayi devriminin etkisiyle, eğitimin yaygınlaşması ve devlet kontrolünde örgütlenmesi önem kazanmıştır. Bu dönemlerde okuryazarlık oranlarının artması ve zorunlu eğitimin yaygınlaştırılması, toplumların genel refahını ve ekonomik büyümesini olumlu yönde etkilemiştir.\n\nEğitimin ana bileşenleri arasında müfredat, öğretim yöntemleri, değerlendirme ve eğitim teknolojileri bulunur. Müfredat, öğrencilere ne öğretileceğini belirlerken, öğretim yöntemleri bu bilgilerin nasıl aktarılacağını açıklar. Değerlendirme, öğrencilerin öğrenme süreçlerini ve başarılarını ölçerken, eğitim teknolojileri, öğrenme sürecini daha etkili ve erişilebilir hale getirmek için kullanılan araç ve platformları içerir.\n\nGünümüzde eğitim teknolojilerinin kullanımı hızla artmaktadır. Bilgisayarlar, tabletler, akıllı tahtalar ve internet, eğitimde yeni olanaklar sunmaktadır. Uzaktan eğitim ve e-öğrenme platformları, coğrafi ve ekonomik engelleri aşarak, daha fazla insanın kaliteli eğitime erişimini sağlamaktadır. COVID-19 pandemisi sırasında, uzaktan eğitim ve dijital öğrenme araçlarının önemi daha da belirgin hale gelmiştir.\n\nEğitimde yenilikçi yaklaşımlar, öğrenci merkezli öğrenme, aktif öğrenme, proje tabanlı öğrenme ve disiplinlerarası öğretim gibi yöntemleri içerir. Bu yaklaşımlar, öğrencilerin sadece bilgiye pasif bir şekilde maruz kalmalarını değil, aynı zamanda bilgiyle aktif olarak etkileşime geçmelerini teşvik eder. Böylece, eleştirel düşünme, problem çözme ve işbirliği gibi 21. yüzyıl becerileri geliştirilir.\n\nEğitimin toplumsal etkileri de oldukça geniştir. İyi eğitim almış bireyler, iş gücünde daha rekabetçi olabilir, yenilikçi çözümler üretebilir ve toplumun genel refah seviyesini artırabilir. Eğitim aynı zamanda sosyal adaleti ve eşitliği teşvik eder, çünkü her bireye fırsat eşitliği sunarak, sosyoekonomik sınırlamaları aşma imkanı sağlar.\n\nSonuç olarak, eğitim, bireylerin ve toplumların sürdürülebilir gelişimi için hayati öneme sahiptir. Eğitimde sağlanacak kalite ve eşitlik, geleceğin daha bilinçli, yaratıcı ve adil bir şekilde şekillenmesine katkı sağlar. Eğitim politikalarının ve uygulamalarının sürekli olarak gözden geçirilmesi ve iyileştirilmesi, bu hedeflere ulaşmada kritik rol oynar.", "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(3093), null, null, 4, false, "Eğitimin Dönüştürücü Gücü: Geçmişten Geleceğe Yolculuk", null, null, 2, 49 },
                    { 5, null, 5, "Sağlık, bireylerin fiziksel, zihinsel ve sosyal yönden tam bir iyilik hali içinde bulunması durumudur. Dünya Sağlık Örgütü (WHO) tarafından tanımlanan bu geniş kapsamlı yaklaşım, sağlık kavramının sadece hastalık veya sakatlık olmaması durumunu değil, genel bir iyilik halini ifade eder. Sağlık, yaşam kalitesini doğrudan etkileyen ve toplumların sürdürülebilir gelişimi için temel bir bileşendir.\n\nSağlık hizmetleri, bireylerin sağlık durumlarını korumak, geliştirmek ve hastalıkları tedavi etmek amacıyla sunulan hizmetler bütünüdür. Bu hizmetler, koruyucu sağlık hizmetleri, tedavi edici sağlık hizmetleri ve rehabilite edici sağlık hizmetleri olmak üzere üç ana başlıkta toplanabilir. Koruyucu sağlık hizmetleri, hastalıkların önlenmesi ve erken teşhisi için önemlidir. Aşılar, halk sağlığı eğitim programları ve periyodik sağlık kontrolleri bu kapsamdadır. Tedavi edici sağlık hizmetleri, mevcut sağlık sorunlarının teşhis ve tedavisine odaklanır. Bu hizmetler, hastaneler, klinikler ve sağlık merkezleri tarafından sunulur. Rehabilite edici sağlık hizmetleri ise, hastalık veya sakatlık sonrası bireylerin işlevselliklerini yeniden kazanmalarını amaçlar.\n\nModern tıp ve teknoloji, sağlık alanında büyük ilerlemeler kaydetmiştir. Tıbbi cihazlar, gelişmiş görüntüleme teknikleri, genetik araştırmalar ve kişiye özel tedavi yöntemleri, sağlık hizmetlerinin kalitesini ve etkinliğini artırmıştır. Özellikle dijital sağlık teknolojileri, telemedicine ve mobil sağlık uygulamaları, sağlık hizmetlerine erişimi kolaylaştırmış ve hasta bakımını iyileştirmiştir. Örneğin, kronik hastalıkların yönetiminde kullanılan mobil uygulamalar, hastaların durumlarını takip etmelerine ve sağlık profesyonelleriyle sürekli iletişimde kalmalarına olanak tanır.\n\nSağlık politikaları, toplum sağlığını korumak ve geliştirmek amacıyla devletler tarafından oluşturulan stratejiler ve düzenlemelerdir. Bu politikalar, sağlık hizmetlerinin finansmanı, erişilebilirliği ve kalitesi gibi konuları kapsar. Evrensel sağlık sigortası sistemleri, bireylerin gelir düzeyine bakılmaksızın sağlık hizmetlerine erişimini sağlar ve sağlık eşitsizliklerini azaltır. Sağlık politikalarının etkili olabilmesi için, bilimsel verilere dayalı kararlar alınması ve sağlık sisteminin sürdürülebilirliği gözetilmelidir.\n\nToplum sağlığı, bireylerin sağlık durumlarının yanı sıra, çevresel ve sosyal faktörlerin de dikkate alındığı bir yaklaşımdır. Çevre kirliliği, iklim değişikliği, su ve gıda güvenliği gibi faktörler, toplum sağlığını doğrudan etkiler. Ayrıca, eğitim düzeyi, gelir dağılımı ve sosyal destek ağları gibi sosyal belirleyiciler de sağlık üzerinde önemli bir etkiye sahiptir.\n\nSağlığın korunması ve geliştirilmesi için bireylerin de sorumlulukları vardır. Dengeli beslenme, düzenli fiziksel aktivite, yeterli uyku ve stres yönetimi, sağlıklı bir yaşam tarzının temel unsurlarıdır. Ayrıca, sigara, alkol ve madde kullanımından kaçınmak, enfeksiyon hastalıklarından korunma yollarını bilmek ve düzenli sağlık kontrolleri yaptırmak da bireysel sağlığı koruma yollarıdır.\n\nSonuç olarak, sağlık, bireylerin ve toplumların genel iyilik hali için vazgeçilmez bir unsurdur. Sağlık hizmetlerinin kalitesinin artırılması, sağlık politikalarının etkinliği ve bireysel sağlığın korunması, daha sağlıklı ve mutlu toplumların oluşmasına katkıda bulunur. Sağlık alanındaki yenilikler ve bilimsel araştırmalar, gelecekte daha da ileri düzeyde sağlık çözümleri sunarak, yaşam kalitesini ve yaşam süresini artırmaya devam edecektir.", "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 40, 53, 186, DateTimeKind.Local).AddTicks(3095), null, null, 5, false, "Sağlık: İyilik Hali ve Toplumsal Refahın Temeli", null, null, 2, 17 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_AppUserId",
                table: "Article",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_ImageId",
                table: "Article",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitor_ArticleId",
                table: "ArticleVisitor",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitor_VisitorId",
                table: "ArticleVisitor",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitor");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Visitor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
