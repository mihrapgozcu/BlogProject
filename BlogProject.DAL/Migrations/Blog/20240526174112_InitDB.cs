using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.DAL.Migrations.Blog
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
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
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
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
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
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
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
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
                    table.PrimaryKey("PK_ArticleVisitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Yılmaz Uslu", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4312), null, null, false, "Teknoloji", null, null },
                    { 2, "Cevdet Heredot", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4313), null, null, false, "Ekonomi", null, null },
                    { 3, "Akın Gür", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4315), null, null, false, "Psikoloji", null, null },
                    { 4, "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4316), null, null, false, "Egitim", null, null },
                    { 5, "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4317), null, null, false, "Saglık", null, null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Akın Gür", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4660), null, null, "article-images/psikoloji.png", "png", false, null, null },
                    { 2, "Cevdet Heredot", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4661), null, null, "article-images/ekonomi.png", "png", false, null, null },
                    { 3, "Yılmaz Uslu", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4662), null, null, "article-images/teknoloji.png", "png", false, null, null },
                    { 4, "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4664), null, null, "article-images/egitim.png", "png", false, null, null },
                    { 5, "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(4665), null, null, "article-images/saglik.png", "png", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, 3, "Psikoloji, insan davranışlarını ve zihinsel süreçleri inceleyen bilim dalıdır. Bu disiplin, bireylerin düşünce, duygu ve davranışlarını anlamak, açıklamak ve bazen de değiştirmek amacıyla geliştirilmiştir. Psikoloji, çok yönlü bir alan olup, biyolojik, sosyal, bilişsel ve duygusal boyutları içerir.\n\nPsikolojinin kökenleri, antik filozofların insan doğasına dair sorular sormalarına kadar uzanır. Ancak, psikoloji modern anlamda 19. yüzyılın sonlarında Wilhelm Wundt’un ilk psikoloji laboratuvarını kurmasıyla bilimsel bir disiplin olarak şekillenmiştir. Wundt’un çalışmaları, deneysel yöntemleri psikolojik araştırmalara uygulamayı başlatmıştır.\n\nPsikoloji, zaman içinde çeşitli alt dallara ayrılmıştır. Klinik psikoloji, ruhsal bozuklukların tanı ve tedavisi ile ilgilenir. Danışmanlık psikolojisi, bireylerin yaşamlarındaki zorluklarla başa çıkmalarına yardımcı olur. Gelişim psikolojisi, yaşam boyu insan gelişimini inceler. Sosyal psikoloji, bireylerin grup içindeki davranışlarını ve toplumsal etkileri araştırır. Bilişsel psikoloji ise, zihinsel süreçler, öğrenme, hafıza ve problem çözme gibi konulara odaklanır.\n\nPsikolojinin pratik uygulamaları oldukça geniştir. Eğitimde, öğrenci başarısını artırmak ve öğretim yöntemlerini geliştirmek için psikolojik prensipler kullanılır. İş dünyasında, işyerinde verimliliği ve çalışan memnuniyetini artırmak amacıyla örgütsel psikoloji ilkeleri uygulanır. Sağlık alanında, hastaların hastalıklarıyla başa çıkmaları ve yaşam kalitelerini artırmaları için psikolojik destek sağlanır.\n\nSonuç olarak, psikoloji, insan davranışlarını ve zihinsel süreçleri anlamada ve iyileştirmede kritik bir rol oynar. Geniş uygulama alanları ve sürekli gelişen araştırma yöntemleri ile psikoloji, hem bireysel hem de toplumsal düzeyde önemli katkılar sunmaktadır.", "Akın Gür", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(3698), null, null, 1, false, "İnsan Davranışları ve Zihinsel Süreçlerin Bilimi: Psikolojiye Giriş", null, null, 3, 10 },
                    { 2, 2, "Ekonomi, kaynakların üretimi, dağıtımı ve tüketimi ile ilgilenen bir sosyal bilim dalıdır. Temel amacı, kıt kaynakların en verimli şekilde nasıl kullanılabileceğini incelemektir. Ekonomi, bireylerin, işletmelerin, hükümetlerin ve toplumların kararlarını nasıl aldıklarını ve bu kararların nasıl etkiler yarattığını araştırır.\n\nEkonominin iki ana dalı vardır: mikroekonomi ve makroekonomi. Mikroekonomi, bireysel tüketicilerin ve firmaların davranışlarını, piyasa mekanizmalarını ve fiyat oluşumunu inceler. Tüketici tercihleri, talep ve arz, fiyat esneklikleri gibi konular mikroekonominin temel inceleme alanlarıdır. Örneğin, bir ürünün fiyatı arttığında talebin nasıl değişeceği veya bir firmanın maliyetlerini minimize ederek karını nasıl maksimize edeceği gibi sorulara yanıt arar.\n\nMakroekonomi ise, genel ekonomik faaliyetleri, toplam üretim, işsizlik, enflasyon ve ekonomik büyüme gibi geniş çaplı konuları ele alır. Bir ülkenin Gayri Safi Yurtiçi Hasılası (GSYİH), işsizlik oranı, enflasyon oranı gibi makroekonomik göstergeler, o ülkenin ekonomik sağlığı hakkında bilgi verir. Merkez bankalarının para politikaları ve hükümetlerin mali politikaları, makroekonominin ana odak noktalarındandır.\n\nEkonomi teorileri ve modelleri, ekonomi politikalarının oluşturulmasında ve ekonomik sorunların çözümünde önemli bir rol oynar. Keynesyen ekonomi, özellikle ekonomik durgunluk dönemlerinde devlet müdahalesinin gerekliliğini savunur. Buna karşılık, neoliberal ekonomi teorisi, serbest piyasa mekanizmalarının ve minimal devlet müdahalesinin ekonomik büyüme için daha etkili olduğunu öne sürer.\n\nEkonominin pratik uygulamaları, günlük hayatımızda büyük bir etkiye sahiptir. Örneğin, bir hükümetin vergileri artırma veya azaltma kararı, bireylerin harcamalarını ve tasarruflarını doğrudan etkiler. Benzer şekilde, faiz oranlarındaki değişiklikler, hem kişisel hem de kurumsal borçlanma maliyetlerini belirler.\n\nSonuç olarak, ekonomi, hem bireysel hem de toplumsal düzeyde önemli kararların alınmasına rehberlik eden kapsamlı ve dinamik bir alandır. Ekonomik analizler ve politikalar, toplumların refahını artırmak, kaynakları daha etkin kullanmak ve sürdürülebilir büyümeyi sağlamak için kritik öneme sahiptir.", "Cevdet Heredot", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(3700), null, null, 2, false, "Kıt Kaynakların Yönetimi: Ekonomiye Giriş ve Temel Kavramlar", null, null, 1, 67 },
                    { 3, 1, "Teknoloji, insan yaşamını ve toplumu köklü bir şekilde değiştiren, geliştiren ve kolaylaştıran yenilikçi araçlar, sistemler ve yöntemler bütünüdür. Geniş kapsamıyla teknoloji, bilimsel bilgi ve mühendislik ilkelerinin pratik uygulamalara dönüştürülmesini içerir. Teknolojinin etkisi, tarımdan sağlığa, iletişimden eğitime, enerji üretiminden eğlenceye kadar hayatın her alanında görülür.\n\nTeknolojinin tarihçesi, insanlık tarihinin başlangıcına kadar uzanır. İlk teknolojik gelişmeler arasında taş aletler, ateşin kontrol edilmesi ve tekerleğin icadı bulunur. Bu buluşlar, insan yaşamını radikal bir şekilde değiştirmiş ve medeniyetlerin gelişimine katkıda bulunmuştur. Endüstri Devrimi ile birlikte, buhar gücü, makineler ve seri üretim teknikleri, sanayi ve ekonomi üzerinde büyük bir etki yarattı. 20. yüzyılda ise, elektrik, otomobil, uçak, radyo ve televizyon gibi icatlar, günlük yaşamın vazgeçilmez unsurları haline geldi.\n\nGünümüzde teknoloji, dijital devrim ile yeni bir boyuta taşınmıştır. Bilgisayarlar, internet, akıllı telefonlar ve yapay zeka, bilgiye erişim ve iletişimde devrim yaratmıştır. İnternet, dünyanın dört bir yanındaki insanların bilgi paylaşımını ve iletişimini kolaylaştırarak küresel bir ağ oluşturmuştur. Sosyal medya platformları, insanların birbirleriyle etkileşimde bulunma şeklini değiştirirken, e-ticaret siteleri alışveriş alışkanlıklarını dönüştürmüştür.\n\nYapay zeka ve makine öğrenimi, teknoloji alanındaki en son yenilikler arasındadır. Bu teknolojiler, veri analizi, tahmin yapma ve karmaşık problemleri çözme kapasitesine sahiptir. Sağlık sektöründe, tıbbi teşhis ve tedavi yöntemlerinde yapay zeka kullanımı hızla artmaktadır. Otomotiv endüstrisinde, otonom araçlar, güvenliği artırmak ve ulaşımı daha verimli hale getirmek amacıyla geliştirilmektedir.\n\nTeknolojinin sunduğu fırsatlar ve kolaylıkların yanı sıra, bazı zorluklar ve etik meseleler de gündeme gelmektedir. Siber güvenlik, kişisel verilerin korunması, dijital bağımlılık ve otomasyonun iş gücü üzerindeki etkileri, dikkatle ele alınması gereken konular arasındadır. Bu sorunların üstesinden gelmek için, teknoloji politikalarının geliştirilmesi ve etik kuralların uygulanması önemlidir.\n\nSonuç olarak, teknoloji, modern yaşamın ayrılmaz bir parçası haline gelmiş ve toplumsal dönüşümün ana itici güçlerinden biri olmuştur. Sürekli yenilenen ve gelişen teknolojik yenilikler, insanlığın karşılaştığı pek çok soruna çözüm sunarken, yaşam kalitesini de artırmaya devam etmektedir. Bu hızlı değişim sürecinde, teknolojinin bilinçli ve sorumlu bir şekilde kullanılması, sürdürülebilir ve adil bir gelecek için büyük önem taşımaktadır.", "Yılmaz Uslu", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(3702), null, null, 3, false, "Teknolojinin Toplumsal Dönüşümü: Geçmişten Günümüze Yeniliklerin İzinde", null, null, 4, 95 },
                    { 4, 4, "Eğitim, bireylerin bilgi, beceri, değer ve tutumlar edinmesini sağlayan, toplumların kültürel, sosyal ve ekonomik gelişimini destekleyen temel bir süreçtir. Eğitim, bireylerin potansiyellerini gerçekleştirmelerine, eleştirel düşünme yetilerini geliştirmelerine ve toplum içinde etkin bir şekilde yer almalarına yardımcı olur. Bu süreç, sadece formal eğitim kurumlarıyla sınırlı kalmaz; aynı zamanda aile, çevre ve çeşitli sosyal etkileşimlerle de gerçekleşir.\n\nEğitimin tarihçesi, insanlık tarihi kadar eskidir. Antik çağlarda eğitim, büyük ölçüde bire bir öğretim ve ustalık sistemi üzerinden yürütülürdü. Ortaçağ'da manastırlar ve medreseler, bilgi aktarımının merkezi haline gelirken, Rönesans dönemi ile birlikte bilim ve sanatın yeniden canlanması, modern eğitim anlayışının temellerini atmıştır. 19. ve 20. yüzyıllarda, sanayi devriminin etkisiyle, eğitimin yaygınlaşması ve devlet kontrolünde örgütlenmesi önem kazanmıştır. Bu dönemlerde okuryazarlık oranlarının artması ve zorunlu eğitimin yaygınlaştırılması, toplumların genel refahını ve ekonomik büyümesini olumlu yönde etkilemiştir.\n\nEğitimin ana bileşenleri arasında müfredat, öğretim yöntemleri, değerlendirme ve eğitim teknolojileri bulunur. Müfredat, öğrencilere ne öğretileceğini belirlerken, öğretim yöntemleri bu bilgilerin nasıl aktarılacağını açıklar. Değerlendirme, öğrencilerin öğrenme süreçlerini ve başarılarını ölçerken, eğitim teknolojileri, öğrenme sürecini daha etkili ve erişilebilir hale getirmek için kullanılan araç ve platformları içerir.\n\nGünümüzde eğitim teknolojilerinin kullanımı hızla artmaktadır. Bilgisayarlar, tabletler, akıllı tahtalar ve internet, eğitimde yeni olanaklar sunmaktadır. Uzaktan eğitim ve e-öğrenme platformları, coğrafi ve ekonomik engelleri aşarak, daha fazla insanın kaliteli eğitime erişimini sağlamaktadır. COVID-19 pandemisi sırasında, uzaktan eğitim ve dijital öğrenme araçlarının önemi daha da belirgin hale gelmiştir.\n\nEğitimde yenilikçi yaklaşımlar, öğrenci merkezli öğrenme, aktif öğrenme, proje tabanlı öğrenme ve disiplinlerarası öğretim gibi yöntemleri içerir. Bu yaklaşımlar, öğrencilerin sadece bilgiye pasif bir şekilde maruz kalmalarını değil, aynı zamanda bilgiyle aktif olarak etkileşime geçmelerini teşvik eder. Böylece, eleştirel düşünme, problem çözme ve işbirliği gibi 21. yüzyıl becerileri geliştirilir.\n\nEğitimin toplumsal etkileri de oldukça geniştir. İyi eğitim almış bireyler, iş gücünde daha rekabetçi olabilir, yenilikçi çözümler üretebilir ve toplumun genel refah seviyesini artırabilir. Eğitim aynı zamanda sosyal adaleti ve eşitliği teşvik eder, çünkü her bireye fırsat eşitliği sunarak, sosyoekonomik sınırlamaları aşma imkanı sağlar.\n\nSonuç olarak, eğitim, bireylerin ve toplumların sürdürülebilir gelişimi için hayati öneme sahiptir. Eğitimde sağlanacak kalite ve eşitlik, geleceğin daha bilinçli, yaratıcı ve adil bir şekilde şekillenmesine katkı sağlar. Eğitim politikalarının ve uygulamalarının sürekli olarak gözden geçirilmesi ve iyileştirilmesi, bu hedeflere ulaşmada kritik rol oynar.", "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(3733), null, null, 4, false, "Eğitimin Dönüştürücü Gücü: Geçmişten Geleceğe Yolculuk", null, null, 2, 49 },
                    { 5, 5, "Sağlık, bireylerin fiziksel, zihinsel ve sosyal yönden tam bir iyilik hali içinde bulunması durumudur. Dünya Sağlık Örgütü (WHO) tarafından tanımlanan bu geniş kapsamlı yaklaşım, sağlık kavramının sadece hastalık veya sakatlık olmaması durumunu değil, genel bir iyilik halini ifade eder. Sağlık, yaşam kalitesini doğrudan etkileyen ve toplumların sürdürülebilir gelişimi için temel bir bileşendir.\n\nSağlık hizmetleri, bireylerin sağlık durumlarını korumak, geliştirmek ve hastalıkları tedavi etmek amacıyla sunulan hizmetler bütünüdür. Bu hizmetler, koruyucu sağlık hizmetleri, tedavi edici sağlık hizmetleri ve rehabilite edici sağlık hizmetleri olmak üzere üç ana başlıkta toplanabilir. Koruyucu sağlık hizmetleri, hastalıkların önlenmesi ve erken teşhisi için önemlidir. Aşılar, halk sağlığı eğitim programları ve periyodik sağlık kontrolleri bu kapsamdadır. Tedavi edici sağlık hizmetleri, mevcut sağlık sorunlarının teşhis ve tedavisine odaklanır. Bu hizmetler, hastaneler, klinikler ve sağlık merkezleri tarafından sunulur. Rehabilite edici sağlık hizmetleri ise, hastalık veya sakatlık sonrası bireylerin işlevselliklerini yeniden kazanmalarını amaçlar.\n\nModern tıp ve teknoloji, sağlık alanında büyük ilerlemeler kaydetmiştir. Tıbbi cihazlar, gelişmiş görüntüleme teknikleri, genetik araştırmalar ve kişiye özel tedavi yöntemleri, sağlık hizmetlerinin kalitesini ve etkinliğini artırmıştır. Özellikle dijital sağlık teknolojileri, telemedicine ve mobil sağlık uygulamaları, sağlık hizmetlerine erişimi kolaylaştırmış ve hasta bakımını iyileştirmiştir. Örneğin, kronik hastalıkların yönetiminde kullanılan mobil uygulamalar, hastaların durumlarını takip etmelerine ve sağlık profesyonelleriyle sürekli iletişimde kalmalarına olanak tanır.\n\nSağlık politikaları, toplum sağlığını korumak ve geliştirmek amacıyla devletler tarafından oluşturulan stratejiler ve düzenlemelerdir. Bu politikalar, sağlık hizmetlerinin finansmanı, erişilebilirliği ve kalitesi gibi konuları kapsar. Evrensel sağlık sigortası sistemleri, bireylerin gelir düzeyine bakılmaksızın sağlık hizmetlerine erişimini sağlar ve sağlık eşitsizliklerini azaltır. Sağlık politikalarının etkili olabilmesi için, bilimsel verilere dayalı kararlar alınması ve sağlık sisteminin sürdürülebilirliği gözetilmelidir.\n\nToplum sağlığı, bireylerin sağlık durumlarının yanı sıra, çevresel ve sosyal faktörlerin de dikkate alındığı bir yaklaşımdır. Çevre kirliliği, iklim değişikliği, su ve gıda güvenliği gibi faktörler, toplum sağlığını doğrudan etkiler. Ayrıca, eğitim düzeyi, gelir dağılımı ve sosyal destek ağları gibi sosyal belirleyiciler de sağlık üzerinde önemli bir etkiye sahiptir.\n\nSağlığın korunması ve geliştirilmesi için bireylerin de sorumlulukları vardır. Dengeli beslenme, düzenli fiziksel aktivite, yeterli uyku ve stres yönetimi, sağlıklı bir yaşam tarzının temel unsurlarıdır. Ayrıca, sigara, alkol ve madde kullanımından kaçınmak, enfeksiyon hastalıklarından korunma yollarını bilmek ve düzenli sağlık kontrolleri yaptırmak da bireysel sağlığı koruma yollarıdır.\n\nSonuç olarak, sağlık, bireylerin ve toplumların genel iyilik hali için vazgeçilmez bir unsurdur. Sağlık hizmetlerinin kalitesinin artırılması, sağlık politikalarının etkinliği ve bireysel sağlığın korunması, daha sağlıklı ve mutlu toplumların oluşmasına katkıda bulunur. Sağlık alanındaki yenilikler ve bilimsel araştırmalar, gelecekte daha da ileri düzeyde sağlık çözümleri sunarak, yaşam kalitesini ve yaşam süresini artırmaya devam edecektir.", "Mihrap Gözcü", new DateTime(2024, 5, 26, 20, 41, 12, 407, DateTimeKind.Local).AddTicks(3734), null, null, 5, false, "Sağlık: İyilik Hali ve Toplumsal Refahın Temeli", null, null, 2, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_ArticleId",
                table: "ArticleVisitors",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
