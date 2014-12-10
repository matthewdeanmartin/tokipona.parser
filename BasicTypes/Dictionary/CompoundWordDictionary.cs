using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Parts;
using NUnit.Framework.Constraints;

namespace BasicTypes.Dictionary
{

    [StructLayout(LayoutKind.Sequential)]
    public class CompoundWords
    {
        public static Dictionary<string, CompoundWord> Dictionary;
        public static Dictionary<string, Dictionary<string, Dictionary<string, string[]>>> Glosses;

        public static CompoundWord AkesiKiwenTomo;
public static CompoundWord AkesiLili;
public static CompoundWord AkesiLinja;
public static CompoundWord AkesiPalisa;
public static CompoundWord AkesiPiTomoKiwen;
public static CompoundWord AkesiPoka;
public static CompoundWord AkesiSikeTomo;
public static CompoundWord AkesiTelo;
public static CompoundWord AkesiTomo;
public static CompoundWord AkesiWaso;
public static CompoundWord AleAla;
public static CompoundWord KenAla;
public static CompoundWord LonTenpoPiPaliAla;
public static CompoundWord PilinAla;
public static CompoundWord SonaAla;
public static CompoundWord TenpoAla;
public static CompoundWord AleMa;
public static CompoundWord AlePiSitelenAla;
public static CompoundWord AleSewi;
public static CompoundWord TenpoAle;
public static CompoundWord AnpaAla;
public static CompoundWord AnpaIke;
public static CompoundWord AnpaLawa;
public static CompoundWord AnpaPiSinpinLawa;
public static CompoundWord KasiAnpa;
public static CompoundWord LonAnpa;
public static CompoundWord AnteLon;
public static CompoundWord JanPiMaAnte;
public static CompoundWord AwenLon;
public static CompoundWord AwenPona;
public static CompoundWord AwenSinpin;
public static CompoundWord AwenUnpaPiNasinSoweli;
public static CompoundWord PaliPiTenpoAwen;
public static CompoundWord TokiAwen;
public static CompoundWord TokiAwenSona;
public static CompoundWord TomoAwen;
public static CompoundWord TomoAwenIke;
public static CompoundWord IjoAnte;
public static CompoundWord IjoIke;
public static CompoundWord IjoKiwenTelo;
public static CompoundWord IjoLawa;
public static CompoundWord IjoLonTawa;
public static CompoundWord IjoLonTomo;
public static CompoundWord IjoMani;
public static CompoundWord IjoMusi;
public static CompoundWord IjoNasaLili;
public static CompoundWord IjoPana;
public static CompoundWord IjoPanaOlin;
public static CompoundWord IjoPanaSuno;
public static CompoundWord IjoPiPanaMute;
public static CompoundWord IjoPiSamaAla;
public static CompoundWord IjoSinLonIloPiSitelenTawa;
public static CompoundWord IjoSinpinLukaLukaTuTu;
public static CompoundWord IjoTawaPiKenMoli;
public static CompoundWord IjoUtaWalo;
public static CompoundWord IkeA;
public static CompoundWord IkeLukin;
public static CompoundWord IkeMoku;
public static CompoundWord IkePali;
public static CompoundWord IkeSijelo;
public static CompoundWord IloIke;
public static CompoundWord JanIke;
public static CompoundWord PilinIke;
public static CompoundWord IloJan;
public static CompoundWord IloKalamaPiTomaTawa;
public static CompoundWord IloKiwenPiPakalaKasi;
public static CompoundWord IloLape;
public static CompoundWord IloLapeSoweli;
public static CompoundWord IloLukin;
public static CompoundWord IloLukinPiLipuSona;
public static CompoundWord IloLukinOko;
public static CompoundWord IloLukinPiSikeTu;
public static CompoundWord IloMoku;
public static CompoundWord IloMusi;
public static CompoundWord IloNanpa;
public static CompoundWord IloNasa;
public static CompoundWord IloNasaWawa;
public static CompoundWord IloOko;
public static CompoundWord IloOpen;
public static CompoundWord IloPanaPiLipuSona;
public static CompoundWord IloPiPanaSuno;
public static CompoundWord IloPiSikeTu;
public static CompoundWord IloPiSitelenTawa;
public static CompoundWord IloPiSitelenToki;
public static CompoundWord IloPiSunoSin;
public static CompoundWord IloPiTawaKon;
public static CompoundWord IloPiTuIjo;
public static CompoundWord IloWaso;
public static CompoundWord IloSijeloWaso;
public static CompoundWord IloSitelen;
public static CompoundWord IloSona;
public static CompoundWord IloSonaTawa;
public static CompoundWord IloSuno;
public static CompoundWord IloTawa;
public static CompoundWord IloTawaKon;
public static CompoundWord IloTawaPiSikeTu;
public static CompoundWord IloTawaSupaPiSikeTu;
public static CompoundWord IloTawaTelo;
public static CompoundWord IloTokiTawa;
public static CompoundWord IloTu;
public static CompoundWord IloTuLili;
public static CompoundWord IloUnpa;
public static CompoundWord IloUtala;
public static CompoundWord IloWanMa;
public static CompoundWord IloWasoLipu;
public static CompoundWord InsaAla;
public static CompoundWord InsaKon;
public static CompoundWord InsaLawa;
public static CompoundWord InsaMa;
public static CompoundWord InsaNasinUtala;
public static CompoundWord InsaPimeja;
public static CompoundWord LonInsa;
public static CompoundWord JakiAla;
public static CompoundWord KoJaki;
public static CompoundWord KoJakiLonNenaSinpin;
public static CompoundWord KonJaki;
public static CompoundWord LupaJaki;
public static CompoundWord TeloJakiLonNenaSinpin;
public static CompoundWord JanIjo;
public static CompoundWord JanIkePiTomoTawaTelo;
public static CompoundWord JanKala;
public static CompoundWord JanKolisu;
public static CompoundWord JanKon;
public static CompoundWord JanKulupu;
public static CompoundWord JanLawa;
public static CompoundWord JanLawaAla;
public static CompoundWord JanLawaMa;
public static CompoundWord JanLawaPiJanUtala;
public static CompoundWord JanLawaPiMaTomo;
public static CompoundWord JanLili;
public static CompoundWord JanLiliPiJanSamaPiMama;
public static CompoundWord JanLiliSona;
public static CompoundWord JanLon;
public static CompoundWord JanMa;
public static CompoundWord JanMeliLawa;
public static CompoundWord JanMeliOlin;
public static CompoundWord JanMeliSewi;
public static CompoundWord JanMoli;
public static CompoundWord JanMu;
public static CompoundWord JanMusi;
public static CompoundWord JanNasa;
public static CompoundWord JanNasaUtala;
public static CompoundWord JanOlin;
public static CompoundWord JanPakala;
public static CompoundWord JanPali;
public static CompoundWord JanPaliMa;
public static CompoundWord JanPaliPiKasiMute;
public static CompoundWord JanPaliPiMokuSoweli;
public static CompoundWord JanPaliPiTomoPiMokuSoweli;
public static CompoundWord JanPiJanUnpaMute;
public static CompoundWord JanPiKalamaMusi;
public static CompoundWord JanPiKamaSona;
public static CompoundWord JanPiLawaAla;
public static CompoundWord JanPiMaSama;
public static CompoundWord JanPiMaTomo;
public static CompoundWord JanPiMusiSijelo;
public static CompoundWord JanPiNasinSewiKolisu;
public static CompoundWord JanMoku;
public static CompoundWord JanPiPaliMoku;
public static CompoundWord JanPiPaliMusi;
public static CompoundWord JanUnpa;
public static CompoundWord JanPiPaliUnpa;
public static CompoundWord JanPiPanaSona;
public static CompoundWord JanPiPonaPilin;
public static CompoundWord JanPiPonaSijelo;
public static CompoundWord JanPiSonaAli;
public static CompoundWord JanPiSonaKasi;
public static CompoundWord JanPiSonaNanpa;
public static CompoundWord JanPiSonaSin;
public static CompoundWord JanPiSonaToki;
public static CompoundWord JanPiTokiAwen;
public static CompoundWord JanPiTokiMusi;
public static CompoundWord JanPiTomoPali;
public static CompoundWord JanPiTomoSama;
public static CompoundWord JanPiWileAla;
public static CompoundWord JanPlaiPona;
public static CompoundWord JanPoka;
public static CompoundWord JanPona;
public static CompoundWord JanPonaSewi;
public static CompoundWord JanSama;
public static CompoundWord JanSamaPiMamaMi;
public static CompoundWord JanSeme;
public static CompoundWord JanSewi;
public static CompoundWord JanSewiMeli;
public static CompoundWord JanSin;
public static CompoundWord JanSonPiKulupuJan;
public static CompoundWord JanSona;
public static CompoundWord JanSonaNanpa;
public static CompoundWord JanSonaPilin;
public static CompoundWord JanSonaSijelo;
public static CompoundWord JanSuli;
public static CompoundWord JanToki;
public static CompoundWord JanUtala;
public static CompoundWord JanWawa;
public static CompoundWord JanWile;
public static CompoundWord TeloMamaJan;
public static CompoundWord JeloLaso;
public static CompoundWord LupaPiTeloJelo;
public static CompoundWord TeloJelo;
public static CompoundWord JoIke;
public static CompoundWord JoPiSikeSunoLili;
public static CompoundWord JoPiSikeSunoMute;
public static CompoundWord KamaJo;
public static CompoundWord KalaKo;
public static CompoundWord KalaPiLukaLinjaMute;
public static CompoundWord KalaPiLukaPalisa;
public static CompoundWord KalaPiLukaWawa;
public static CompoundWord KalaPiPanaPiTeloPimeja;
public static CompoundWord KalaPiSeloKiwen;
public static CompoundWord KalaPiTawaMonsi;
public static CompoundWord KalaPiWasoLili;
public static CompoundWord KalaSike;
public static CompoundWord KalaSoweliSuli;
public static CompoundWord KalaSuliSuwi;
public static CompoundWord KalaTomo;
public static CompoundWord KalaWaso;
public static CompoundWord KalamaAla;
public static CompoundWord KalamaLili;
public static CompoundWord KalamaLiliAwen;
public static CompoundWord KalamaLiliTawa;
public static CompoundWord KalamaMonsi;
public static CompoundWord KalamaMusi;
public static CompoundWord KalamaMusiUta;
public static CompoundWord KalamaMute;
public static CompoundWord KalamaMuteIke;
public static CompoundWord KalamaTelo;
public static CompoundWord KamaAnpa;
public static CompoundWord KamaInsa;
public static CompoundWord KamaJakiAla;
public static CompoundWord KamaKepekenPali;
public static CompoundWord KamaKulupu;
public static CompoundWord KamaLape;
public static CompoundWord KamaLili;
public static CompoundWord KamaLonTomo;
public static CompoundWord KamaLupaAla;
public static CompoundWord KamaPiLukinAla;
public static CompoundWord KamaPiLukinSin;
public static CompoundWord KamaPilinIke;
public static CompoundWord KamaPini;
public static CompoundWord KamaPona;
public static CompoundWord KamaPonaTawa;
public static CompoundWord KamaSeloTan;
public static CompoundWord KamaSewi;
public static CompoundWord KamaSewiSin;
public static CompoundWord KamaSin;
public static CompoundWord KamaSinpin;
public static CompoundWord KamaSona;
public static CompoundWord KamaSuli;
public static CompoundWord KamaSupa;
public static CompoundWord KamaTelo;
public static CompoundWord KamaWan;
public static CompoundWord KamaWile;
public static CompoundWord TeloKamaTanSewi;
public static CompoundWord TenpoKama;
public static CompoundWord WanPiKamaSona;
public static CompoundWord KasiIke;
public static CompoundWord KasiJaki;
public static CompoundWord KasiKule;
public static CompoundWord KasiLili;
public static CompoundWord KasiMoku;
public static CompoundWord KasiMute;
public static CompoundWord KasiNasa;
public static CompoundWord KasiPalisa;
public static CompoundWord KasiPalisaSuli;
public static CompoundWord KasiPalisaMute;
public static CompoundWord KasiPiTeloAla;
public static CompoundWord KasiPiTenpoPonaKolisu;
public static CompoundWord KasiPiUtaSeli;
public static CompoundWord KasiSona;
public static CompoundWord KasiWawa;
public static CompoundWord KenJan;
public static CompoundWord KenLukin;
public static CompoundWord KenPilin;
public static CompoundWord KenSona;
public static CompoundWord KepekenNasinSeme;
public static CompoundWord KepekenPaliLili;
public static CompoundWord KepekenPaliMute;
public static CompoundWord PilinUta;
public static CompoundWord KiliJelo;
public static CompoundWord KiliJeloPalisa;
public static CompoundWord KiliJeloPiSuwiAla;
public static CompoundWord KiliLiliLawa;
public static CompoundWord KiliLiliLawaSeli;
public static CompoundWord KiliLoje;
public static CompoundWord KiliMa;
public static CompoundWord KiliPiSikeLiliMute;
public static CompoundWord KiliSikeSoja;
public static CompoundWord KiliSin;
public static CompoundWord TeloKili;
public static CompoundWord KiwenLiliLili;
public static CompoundWord KiwenLiliMusi;
public static CompoundWord KiwenLukin;
public static CompoundWord KiwenManiJelo;
public static CompoundWord KiwenManiWalo;
public static CompoundWord KiwenPiKuleAla;
public static CompoundWord KiwenPiTeloMama;
public static CompoundWord KiwenPimeja;
public static CompoundWord KiwenTelo;
public static CompoundWord KoKasi;
public static CompoundWord KoLete;
public static CompoundWord KoMokuPiTeloMama;
public static CompoundWord KoPiTeloMama;
public static CompoundWord KoSeli;
public static CompoundWord KoSoweli;
public static CompoundWord KoSunoLinja;
public static CompoundWord KoSuwi;
public static CompoundWord KoTeloPiTeloMama;
public static CompoundWord KoWaloWawa;
public static CompoundWord KoWawa;
public static CompoundWord KonEnSewi;
public static CompoundWord KonPiPilinPona;
public static CompoundWord KonSeli;
public static CompoundWord KonSewi;
public static CompoundWord KonTawa;
public static CompoundWord KonTelo;
public static CompoundWord KonTeloWalo;
public static CompoundWord KonWawa;
public static CompoundWord TomoTawaKon;
public static CompoundWord KuleAla;
public static CompoundWord KuleAlaWaloAla;
public static CompoundWord KuleJaki;
public static CompoundWord KuleLonPalisaLuka;
public static CompoundWord KuleMoku;
public static CompoundWord KulePiTeloWawa;
public static CompoundWord KuleSewi;
public static CompoundWord KulupuJan;
public static CompoundWord KulupuKasi;
public static CompoundWord KulupuKiwen;
public static CompoundWord KulupuLawa;
public static CompoundWord KulupuLili;
public static CompoundWord KulupuLipu;
public static CompoundWord KulupuMama;
public static CompoundWord KulupuMani;
public static CompoundWord KulupuMusi;
public static CompoundWord KulupuNimi;
public static CompoundWord KulupuNimiAla;
public static CompoundWord KulupuNimiAnte;
public static CompoundWord KulupuNimiIjo;
public static CompoundWord KulupuNimiPali;
public static CompoundWord KulupuNimiPiKamaJo;
public static CompoundWord KulupuNimiPini;
public static CompoundWord KulupuNimiSeme;
public static CompoundWord KulupuOlin;
public static CompoundWord KulupuPiLipuSona;
public static CompoundWord KulupuPiPaliToki;
public static CompoundWord KulupuPiPonaSijelo;
public static CompoundWord KulupuSike;
public static CompoundWord KulupuSitelen;
public static CompoundWord KulupuToki;
public static CompoundWord KulupuTokiJaju;
public static CompoundWord KulupuUtala;
public static CompoundWord LupaKute;
public static CompoundWord KuteSona;
public static CompoundWord KuteTawa;
public static CompoundWord LapePona;
public static CompoundWord SupaLape;
public static CompoundWord WileLape;
        public static CompoundWord TokiSewi;
public static CompoundWord LasoJelo;
public static CompoundWord LasoLoje;
public static CompoundWord LasoPimeja;
public static CompoundWord LojeLasoPimeja;
public static CompoundWord PimejaLaso;
public static CompoundWord LawaLukin;
public static CompoundWord LawaMa;
public static CompoundWord LawaSewi;
public static CompoundWord LenLawa;
public static CompoundWord TokiLawa;
public static CompoundWord LenAnpa;
public static CompoundWord LenLipu;
public static CompoundWord LenLuka;
public static CompoundWord LenLupa;
public static CompoundWord LenNoka;
public static CompoundWord LenNokaPalisa;
public static CompoundWord LenSinpin;
public static CompoundWord LeteLili;
public static CompoundWord PokiLete;
public static CompoundWord TenpoLete;
public static CompoundWord LiliAla;
public static CompoundWord LiliMute;
public static CompoundWord LiliTaso;
public static CompoundWord LinjaLiliOko;
public static CompoundWord LinjaLiliPiInsaLawa;
public static CompoundWord MaLili;
public static CompoundWord MeliLili;
public static CompoundWord MijeLili;
public static CompoundWord MokuLili;
public static CompoundWord MokuLiliPiPilinPonaMute;
public static CompoundWord MuteLili;
public static CompoundWord NenaLiliMeli;
public static CompoundWord NenaLiliUnpaMeli;
public static CompoundWord NenaLiliPiNenaMama;
public static CompoundWord PalisaLiliNoka;
public static CompoundWord TenpoLili;
public static CompoundWord LinjaAwen;
public static CompoundWord LinjaLawa;
public static CompoundWord LinjaLuka;
public static CompoundWord LinjaSewi;
public static CompoundWord LinjaSinpin;
public static CompoundWord LinjaToki;
public static CompoundWord LinjaUta;
public static CompoundWord PokaTeloLinja;
public static CompoundWord SoweliPiNenaLinja;
public static CompoundWord TeloLinja;
public static CompoundWord LipuAwen;
public static CompoundWord LipuIjo;
public static CompoundWord LipuIloTokiPoki;
public static CompoundWord LipuKasi;
public static CompoundWord LipuKili;
public static CompoundWord LipuKiwenPiTeloMama;
public static CompoundWord LipuLawa;
public static CompoundWord LipuMani;
public static CompoundWord LipuMusi;
public static CompoundWord LipuMusiMani;
public static CompoundWord LipuMusiNasa;
public static CompoundWord LipuMusiPona;
public static CompoundWord LipuMute;
public static CompoundWord LipuNasin;
public static CompoundWord LipuOpen;
public static CompoundWord LipuPali;
public static CompoundWord LipuPiJanLawa;
public static CompoundWord LipuPiJanMeli;
public static CompoundWord LipuPiJanPali;
public static CompoundWord LipuPiLawaMeli;
public static CompoundWord LipuPiManiMusi;
public static CompoundWord LipuPiNasaMusi;
public static CompoundWord LipuPiSitelenLon;
public static CompoundWord LipuPiTawaKon;
public static CompoundWord LipuPiTenpoSuno;
public static CompoundWord LipuSewi;
public static CompoundWord LipuSewiPipija;
public static CompoundWord LipuSona;
public static CompoundWord LipuToki;
public static CompoundWord LipuTokiSin;
public static CompoundWord LipuWeka;
public static CompoundWord LojeLaso;
public static CompoundWord LojeWalo;
public static CompoundWord TeloLojeMun;
public static CompoundWord TeloMun;
public static CompoundWord TeloLoje;
public static CompoundWord LonAla;
public static CompoundWord LonAliMa;
public static CompoundWord LonAnpaMani;
public static CompoundWord LonKulupuSama;
public static CompoundWord LonLukaWan;
public static CompoundWord LonLukaAnte;
public static CompoundWord LonMonsi;
public static CompoundWord LonNi;
public static CompoundWord LonPoka;
public static CompoundWord LonPokaPiNanpaTu;
public static CompoundWord LonPokaPiNanpaWan;
public static CompoundWord LonPokaSinpin;
public static CompoundWord LonSelo;
public static CompoundWord LonSewi;
public static CompoundWord LonSewiMani;
public static CompoundWord LonSinpin;
public static CompoundWord LonTempoKamaTan;
public static CompoundWord LonTenpoPiniTan;
public static CompoundWord SinaLonMaSeme;
public static CompoundWord LukaPiNanpaTu;
public static CompoundWord LukaPiNanpaWan;
public static CompoundWord LukaLinja;
public static CompoundWord LukaLipu;
public static CompoundWord LukaOpen;
public static CompoundWord LukaPiLukaPiLukaPiNimi;
public static CompoundWord LukaPini;
public static CompoundWord LukaTuAnuLili;
public static CompoundWord LukaWawa;
public static CompoundWord LukaWawaAla;
public static CompoundWord PalisaLuka;
public static CompoundWord LukinPona;
public static CompoundWord LukinSama;
public static CompoundWord LukinSona;
public static CompoundWord LukinTawa;
public static CompoundWord LukinTu;
public static CompoundWord LukinWawa;
public static CompoundWord NasaLukin;
public static CompoundWord PonaLukin;
public static CompoundWord SuwiLukin;
public static CompoundWord LupaLon;
public static CompoundWord LupaMeli;
public static CompoundWord LupaMonsi;
public static CompoundWord LupaNena;
public static CompoundWord LupaPalisaMonsi;
public static CompoundWord LupaPiKoJaki;
public static CompoundWord LupaPiNena;
public static CompoundWord LupaSijeloMonsi;
public static CompoundWord LupaSinpin;
public static CompoundWord LupaTomoMonsi;
public static CompoundWord PanaUtaLonLupa;
public static CompoundWord PanaUtaLonLupaMeli;
public static CompoundWord MaEkato;
public static CompoundWord MaElena;
public static CompoundWord MaEliteja;
public static CompoundWord MaEpanja;
public static CompoundWord MaEsalasi;
public static CompoundWord MaEsi;
public static CompoundWord MaEsuka;
public static CompoundWord MaIlakija;
public static CompoundWord MaIlan;
public static CompoundWord MaInli;
public static CompoundWord MaIntonesija;
public static CompoundWord MaIsale;
public static CompoundWord MaIsijopija;
public static CompoundWord MaIsilan;
public static CompoundWord MaItalija;
public static CompoundWord MaJamanija;
public static CompoundWord MaKalalinuna;
public static CompoundWord MaKamelun;
public static CompoundWord MaKampija;
public static CompoundWord MaKana;
public static CompoundWord MaKanata;
public static CompoundWord MaKanpusi;
public static CompoundWord MaKanse;
public static CompoundWord MaKapon;
public static CompoundWord MaKatala;
public static CompoundWord MaKatelo;
public static CompoundWord MaKatemala;
public static CompoundWord MaKenata;
public static CompoundWord MaKenja;
public static CompoundWord MaKeposi;
public static CompoundWord MaKilipasi;
public static CompoundWord MaKine;
public static CompoundWord MaKinejekatolija;
public static CompoundWord MaKinepisa;
public static CompoundWord MaKinla;
public static CompoundWord MaKomo;
public static CompoundWord MaKonko;
public static CompoundWord MaKosalika;
public static CompoundWord MaKosiwa;
public static CompoundWord MaKuli;
public static CompoundWord MaKupa;
public static CompoundWord MaKusala;
public static CompoundWord MaKusawasi;
public static CompoundWord MaLanka;
public static CompoundWord MaLapewija;
public static CompoundWord MaLawi;
public static CompoundWord MaLesoto;
public static CompoundWord MaLijatuwa;
public static CompoundWord MaLipija;
public static CompoundWord MaLisensan;
public static CompoundWord MaLomani;
public static CompoundWord MaLosi;
public static CompoundWord MaLowasi;
public static CompoundWord MaLowenki;
public static CompoundWord MaLowensina;
public static CompoundWord MaLunpan;
public static CompoundWord MaLusepu;
public static CompoundWord MaLuwanta;
public static CompoundWord MaMaketonija;
public static CompoundWord MaMalakasi;
public static CompoundWord MaMalasija;
public static CompoundWord MaMalawi;
public static CompoundWord MaMali;
public static CompoundWord MaMalipe;
public static CompoundWord MaMasu;
public static CompoundWord MaMesiko;
public static CompoundWord MaMewika;
public static CompoundWord MaMijanma;
public static CompoundWord MaMosanpi;
public static CompoundWord MaMosijo;
public static CompoundWord MaMotowa;
public static CompoundWord MaMowisi;
public static CompoundWord MaMulitanija;
public static CompoundWord MaNamipija;
public static CompoundWord MaNaselija;
public static CompoundWord MaNetelan;
public static CompoundWord MaNikalala;
public static CompoundWord MaNijon;
public static CompoundWord MaNise;
public static CompoundWord MaNosiki;
public static CompoundWord MaNusilan;
public static CompoundWord MaOntula;
public static CompoundWord MaOselija;
public static CompoundWord MaPakisan;
public static CompoundWord MaPalakawi;
public static CompoundWord MaPalani;
public static CompoundWord MaPalata;
public static CompoundWord MaPanama;
public static CompoundWord MaPanla;
public static CompoundWord MaPapeto;
public static CompoundWord MaPapuwanijukini;
public static CompoundWord MaPasila;
public static CompoundWord MaPawama;
public static CompoundWord MaPelelusi;
public static CompoundWord MaPelu;
public static CompoundWord MaPeluta;
public static CompoundWord MaPenen;
public static CompoundWord MaPenesuwela;
public static CompoundWord MaPesije;
public static CompoundWord MaPilipina;
public static CompoundWord MaPilisin;
public static CompoundWord MaPiten;
public static CompoundWord MaPokasi;
public static CompoundWord MaPosan;
public static CompoundWord MaPosuka;
public static CompoundWord MaPosuwana;
public static CompoundWord MaPotuke;
public static CompoundWord MaPukinapaso;
public static CompoundWord MaSamalino;
public static CompoundWord MaSameka;
public static CompoundWord MaSamowa;
public static CompoundWord MaSanpija;
public static CompoundWord MaSantapiken;
public static CompoundWord MaSasali;
public static CompoundWord MaSate;
public static CompoundWord MaSawasi;
public static CompoundWord MaSeki;
public static CompoundWord MaSeneka;
public static CompoundWord MaSetapika;
public static CompoundWord MaSibeta;
public static CompoundWord MaSijelalijon;
public static CompoundWord MaSile;
public static CompoundWord MaSinita;
public static CompoundWord MaSinpapuwe;
public static CompoundWord MaSipe;
public static CompoundWord MaSipusi;
public static CompoundWord MaSomalija;
public static CompoundWord MaSonko;
public static CompoundWord MaSopisi;
public static CompoundWord MaSukosi;
public static CompoundWord MaSulija;
public static CompoundWord MaSumi;
public static CompoundWord MaSutan;
public static CompoundWord MaSuwasi;
public static CompoundWord MaTansanija;
public static CompoundWord MaTansi;
public static CompoundWord MaTawi;
public static CompoundWord MaToko;
public static CompoundWord MaTominika;
public static CompoundWord MaTona;
public static CompoundWord MaTosi;
public static CompoundWord MaTuki;
public static CompoundWord MaTunisi;
public static CompoundWord MaTuwalu;
public static CompoundWord MaUkanta;
public static CompoundWord MaUkawina;
public static CompoundWord MaUlukawi;
public static CompoundWord MaUman;
public static CompoundWord MaUtan;
public static CompoundWord MaWanawatu;
public static CompoundWord MaWasikano;
public static CompoundWord MaWatemala;
public static CompoundWord MaWensa;
public static CompoundWord MaWije;
public static CompoundWord MaTomoEle;
public static CompoundWord MaTomoEsupo;
public static CompoundWord MaTomoIwesun;
public static CompoundWord MaTomoKakawi;
public static CompoundWord MaTomoKenpisi;
public static CompoundWord MaTomoKinsasa;
public static CompoundWord MaTomoKunte;
public static CompoundWord MaTomoLanten;
public static CompoundWord MaTomoLesinki;
public static CompoundWord MaTomoLoma;
public static CompoundWord MaTomoMansasa;
public static CompoundWord MaTomoManten;
public static CompoundWord MaTomoMesiko;
public static CompoundWord MaTomoMinsen;
public static CompoundWord MaTomoMonkela;
public static CompoundWord MaTomoMunpa;
public static CompoundWord MaTomoNapoli;
public static CompoundWord MaTomoNujoka;
public static CompoundWord MaTomoNuwewen;
public static CompoundWord MaTomoOlanto;
public static CompoundWord MaTomoOsaka;
public static CompoundWord MaTomoPasen;
public static CompoundWord MaTomoPelin;
public static CompoundWord MaTomoPeminan;
public static CompoundWord MaTomoPankalo;
public static CompoundWord MaTomoPesin;
public static CompoundWord MaTomoPetepuko;
public static CompoundWord MaTomoPilense;
public static CompoundWord MaTomoPisawi;
public static CompoundWord MaTomoPolan;
public static CompoundWord MaTomoPutapesi;
public static CompoundWord MaTomoSakata;
//public static CompoundWord MaTomoSalajewo;
public static CompoundWord MaTomoSanpansiko;
public static CompoundWord MaTomoSatupu;
public static CompoundWord MaTomoSawi;
public static CompoundWord MaTomoSene;
public static CompoundWord MaTomoSensan;
public static CompoundWord MaTomoSesija;
public static CompoundWord MaTomoSije;
public static CompoundWord MaTomoSolu;
public static CompoundWord MaTomoTamen;
public static CompoundWord MaTomoTanpele;
public static CompoundWord MaTomoTelawi;
public static CompoundWord MaTomoTokijo;
public static CompoundWord MaTomoTowano;
public static CompoundWord MaTomoTuku;
public static CompoundWord MaTomoWankuwa;
public static CompoundWord MaTomoWenesija;
public static CompoundWord MaPasiki;
public static CompoundWord MaPalisija;
public static CompoundWord MaTomoPontepeta;
public static CompoundWord MaTomoMapi;
public static CompoundWord MaTomoKapulu;
public static CompoundWord MaTomoKatepu;
public static CompoundWord MaTomoOfo;
public static CompoundWord Mila;
public static CompoundWord Tulo;
public static CompoundWord LipuTatesen;
public static CompoundWord LipuPipija;
public static CompoundWord LipuPakawakita;
public static CompoundWord JanSewiJawe;
public static CompoundWord MamaMewi;
public static CompoundWord TeloPison;
public static CompoundWord MaKevilatu;
public static CompoundWord TeloKekon;
public static CompoundWord TeloTikisu;
public static CompoundWord TeloElupatu;
public static CompoundWord LipuSon;
public static CompoundWord NasinPajaje;
public static CompoundWord TokiLosupan;
public static CompoundWord NenaKiwenPilene;
public static CompoundWord NanpaLili;
public static CompoundWord NanpaSeme;
public static CompoundWord NanpaWeka;
public static CompoundWord NanpaWile;
public static CompoundWord TenpoPiNanpaWan;
public static CompoundWord NasaIke;
public static CompoundWord NasaNanpa;
public static CompoundWord NasaPona;
public static CompoundWord PilinNasa;
public static CompoundWord TeloNasa;
public static CompoundWord UnpaNasa;
public static CompoundWord NasinKama;
public static CompoundWord NasinKamaPiTawaSuno;
public static CompoundWord NasinKatolike;
public static CompoundWord NasinKulupu;
public static CompoundWord NasinLawa;
public static CompoundWord NasinLukin;
public static CompoundWord NasinLukinPiLipuSona;
public static CompoundWord NasinMa;
public static CompoundWord NasinMani;
public static CompoundWord NasinMusi;
public static CompoundWord NasinPali;
public static CompoundWord NasinPiJanNijonSamaNasinPiJanAli;
public static CompoundWord NasinPiJanSewiAla;
public static CompoundWord NasinPiKamaSuno;
public static CompoundWord NasinPiLawaAla;
public static CompoundWord NasinPini;
public static CompoundWord NasinPiniPiTawaSuno;
public static CompoundWord NasinPona;
public static CompoundWord NasinPonaJuju;
public static CompoundWord NasinPonaLasapali;
public static CompoundWord NasinPonaPiIloLen;
public static CompoundWord NasinSewi;
public static CompoundWord NasinSewiJawatu;
public static CompoundWord NasinSewiKolisu;
public static CompoundWord NasinSewiMa;
public static CompoundWord NasinSewiPuta;
public static CompoundWord NasinSewiSilami;
public static CompoundWord NasinSinpin;
public static CompoundWord NasinSitelen;
public static CompoundWord NasinSuli;
public static CompoundWord NasinSupa;
public static CompoundWord NasinTawa;
public static CompoundWord NasinToki;
public static CompoundWord NasinWawa;
public static CompoundWord NasinWeka;
public static CompoundWord NasinWekaLinja;
public static CompoundWord TomoPiNasinSewi;
public static CompoundWord NenaLawa;
public static CompoundWord MaNena;
public static CompoundWord NenaKute;
public static CompoundWord NenaMama;
public static CompoundWord NenaMeli;
public static CompoundWord NenaPalisa;
public static CompoundWord NenaUnpaMeli;
public static CompoundWord PiniPiNenaMama;
public static CompoundWord NiAli;
public static CompoundWord TenpoNi;
public static CompoundWord TenpoPimejaNi;
public static CompoundWord NimiAnte;
public static CompoundWord NimiAnteSinpin;
public static CompoundWord NimiJan;
public static CompoundWord NimiLili;
public static CompoundWord NimiPali;
public static CompoundWord NimiPaliAnte;
public static CompoundWord NimiPaliPiAnteAla;
public static CompoundWord NimiPiPaliAla;
public static CompoundWord NimiSinaOSewi;
public static CompoundWord NimiSinpin;
public static CompoundWord NimiSuli;
public static CompoundWord NimiToki;
public static CompoundWord MeliOlin;
public static CompoundWord MijeOlin;
public static CompoundWord OlinSuli;
public static CompoundWord PaliOlin;
public static CompoundWord OpenAla;
public static CompoundWord OpenPiSikeSunoSin;
public static CompoundWord OpenSinpin;
public static CompoundWord OpenSuno;
public static CompoundWord PakalaAla;
public static CompoundWord PalakaSeli;
public static CompoundWord PaliAwen;
public static CompoundWord PaliEIjoTawa;
public static CompoundWord PaliEMoku;
public static CompoundWord PaliESikeMama;
public static CompoundWord PaliESoweli;
public static CompoundWord PaliETokiLinja;
public static CompoundWord PaliEUtaSuwi;
public static CompoundWord PaliIke;
public static CompoundWord PaliInsaMa;
public static CompoundWord PaliKalamaMusi;
public static CompoundWord PaliMusi;
public static CompoundWord PaliMute;
public static CompoundWord PaliMuteNanpa;
public static CompoundWord PaliNanpa;
public static CompoundWord PaliNanpaPoka;
public static CompoundWord PaliNanpaTenpo;
public static CompoundWord PaliOlinTawa;
public static CompoundWord PaliPiIloNanpa;
public static CompoundWord PaliPiTomoPiTeloNasa;
public static CompoundWord PaliPonaA;
public static CompoundWord PaliSewi;
public static CompoundWord PaliSewiTawa;
public static CompoundWord PaliSitelen;
public static CompoundWord PaliiETokiPiJanSewi;
public static CompoundWord PiPaliLili;
public static CompoundWord PiPaliMute;
public static CompoundWord PonaPali;
public static CompoundWord TomoPali;
public static CompoundWord PalisaKasi;
public static CompoundWord PalisaKiwenWalo;
public static CompoundWord PalisaLawa;
public static CompoundWord PalisaMoli;
public static CompoundWord PalisaMoliLili;
public static CompoundWord PalisaPiKamaJoKala;
public static CompoundWord PalisaSeli;
public static CompoundWord PalisaSuliUtala;
public static CompoundWord PalisaTawa;
public static CompoundWord PalisaUta;
public static CompoundWord PanaEPalisaUtaLon;
public static CompoundWord PanaUtaLonPalisa;
public static CompoundWord PiniPalisa;
public static CompoundWord SeloLonPiniPalisa;
public static CompoundWord PanaAwen;
public static CompoundWord PanaLon;
public static CompoundWord PanaLukin;
public static CompoundWord PanaNasinPonaTawa;
public static CompoundWord PanaPiTokiSewi;
public static CompoundWord PanaPoka;
public static CompoundWord PanaSewi;
public static CompoundWord PanaSina;
public static CompoundWord PanaTawa;
public static CompoundWord PanaToki;
public static CompoundWord PanaWawa;
public static CompoundWord PiLukinAla;
public static CompoundWord PiMuteSeme;
public static CompoundWord PiPonaMute;
public static CompoundWord PilinAlaLonAle;
public static CompoundWord PilinAli;
public static CompoundWord PilinAnte;
public static CompoundWord PilinIkeLonKulupu;
public static CompoundWord PilinIkeMute;
public static CompoundWord PilinIkeNanpaLukaTu;
//public static CompoundWord PilinIkeTan;
public static CompoundWord PilinLon;
public static CompoundWord PilinNasaLawa;
public static CompoundWord PilinPiPaliPiniPakala;
public static CompoundWord PilinPona;
public static CompoundWord PilinSama;
public static CompoundWord PilinSitelen;
public static CompoundWord PilinWawa;
//public static CompoundWord SinaPilinSeme;
public static CompoundWord PimejaLoje;
public static CompoundWord PimejaSeli;
public static CompoundWord TeloPimejaWawaPiTomoTawa;
public static CompoundWord TeloWawaPiTomoTawa;
public static CompoundWord TenpoPimeja;
public static CompoundWord TenpoPimejaPini;
public static CompoundWord PiniNi;
public static CompoundWord PiniSuno;
public static CompoundWord TenpoPini;
public static CompoundWord PipiKule;
public static CompoundWord PipiLoje;
public static CompoundWord PipiLonKasi;
public static CompoundWord PipiMute;
public static CompoundWord PipiPimejaEnLoje;
public static CompoundWord PipiSuwi;
public static CompoundWord PokaAla;
public static CompoundWord PokaPiNanpaTu;
public static CompoundWord PokaPiNanpaWan;
public static CompoundWord PokaPiSunoKama;
public static CompoundWord PokaPiSunoWeka;
public static CompoundWord PokaPilin;
public static CompoundWord PokaPilinAla;
public static CompoundWord PokaTawa;
public static CompoundWord PokaTelo;
public static CompoundWord PokiKiwenSuli;
public static CompoundWord PokiPiTeloSeli;
public static CompoundWord PokiSamaLipu;
public static CompoundWord MokuPona;
public static CompoundWord PonaA;
public static CompoundWord PonaAla;
public static CompoundWord PonaMoku;
public static CompoundWord PonaMute;
public static CompoundWord PonaNasa;
public static CompoundWord PonaPilin;
public static CompoundWord PonaTawaAla;
//public static CompoundWord PonaTawaSina;
public static CompoundWord PonaUnpa;
public static CompoundWord TawaPona;
public static CompoundWord MeliSama;
public static CompoundWord MijeSama;
public static CompoundWord SamaAla;
public static CompoundWord SamaPokaKalamaMusi;
public static CompoundWord UnpaSamaSoweli;
public static CompoundWord SeliLili;
public static CompoundWord TeloSeliWawa;
public static CompoundWord TenpoSeli;
public static CompoundWord TenpoSeme;
public static CompoundWord SewiKon;
public static CompoundWord SewiMonsi;
public static CompoundWord SewiPona;
public static CompoundWord SewiSijelo;
public static CompoundWord SewiTomo;
public static CompoundWord WawaSewi;
public static CompoundWord SijeloAliInsaMa;
public static CompoundWord SijeloPona;
public static CompoundWord SijeloToki;
public static CompoundWord WanSijelo;
public static CompoundWord SikeJan;
public static CompoundWord SikeKili;
public static CompoundWord SikeKiwenMani;
public static CompoundWord SikeKonSuli;
public static CompoundWord SikeMama;
public static CompoundWord SikeMije;
public static CompoundWord SikeMijeTu;
public static CompoundWord SikeMoliWawa;
public static CompoundWord SikeNena;
public static CompoundWord SikeNoka;
public static CompoundWord SikeSelo;
public static CompoundWord SikeSewiLaso;
public static CompoundWord SikeSunoMute;
public static CompoundWord SikeTu;
public static CompoundWord SikeTuSupa;
public static CompoundWord TenpoSike;
public static CompoundWord SinAla;
public static CompoundWord SinPona;
public static CompoundWord TenpoSin;
public static CompoundWord SinpinLawa;
public static CompoundWord SinpinSike;
public static CompoundWord SinpinSuli;
public static CompoundWord SitelenKalama;
public static CompoundWord SitelenLili;
public static CompoundWord SitelenMa;
public static CompoundWord SitelenSamaLipuSona;
public static CompoundWord SitelenSelo;
public static CompoundWord SitelenSuli;
public static CompoundWord SitelenTawa;
public static CompoundWord SitelenToki;
public static CompoundWord SitelenTomo;
public static CompoundWord SitelenUnpa;
public static CompoundWord SonaAle;
public static CompoundWord SonaIlo;
public static CompoundWord SonaLukin;
public static CompoundWord SonaMute;
public static CompoundWord SonaNanpa;
public static CompoundWord SonaNimi;
public static CompoundWord SonaPiKalamaToki;
public static CompoundWord SonaPiLukinAla;
public static CompoundWord SonaPiNasinPonaEnIke;
public static CompoundWord SonaPona;
public static CompoundWord SonaToki;
public static CompoundWord TomoSona;
public static CompoundWord TomoSonaSuli;
public static CompoundWord WanPiTomoSona;
public static CompoundWord SoweliJaki;
public static CompoundWord SoweliJakiPiMaKasi;
public static CompoundWord SoweliJan;
public static CompoundWord SoweliKalaSuli;
public static CompoundWord SoweliLiliJaki;
public static CompoundWord SoweliLiliPiLinjaKiwen;
public static CompoundWord SoweliLiliTomo;
public static CompoundWord SoweliLojeWalo;
public static CompoundWord SoweliLojeWaloLonMa;
public static CompoundWord SoweliLojeWaloSeli;
public static CompoundWord SoweliLukinSamaJan;
public static CompoundWord SoweliMani;
public static CompoundWord SoweliMeli;
public static CompoundWord SoweliMu;
public static CompoundWord SoweliMusi;
public static CompoundWord SoweliNasa;
public static CompoundWord SoweliPiAwenTomo;
public static CompoundWord SoweliPiMokuPipi;
public static CompoundWord SoweliPiPalisaLawa;
public static CompoundWord SoweliPiTawaLonTu;
public static CompoundWord SoweliSuli;
public static CompoundWord SoweliSuliIke;
public static CompoundWord SoweliSuliLapePiKasiSuli;
public static CompoundWord SoweliSuliPalisa;
public static CompoundWord SoweliSuliPiNenaTu;
public static CompoundWord SoweliSuliPiNeneWan;
public static CompoundWord SoweliSuliWaloEnPimeja;
public static CompoundWord SoweliSuwi;
public static CompoundWord SoweliSuwiTomo;
public static CompoundWord SoweliTawa;
public static CompoundWord SoweliTawaPimejaEnWalo;
public static CompoundWord SoweliTomoPiLinjaUta;
public static CompoundWord SoweliWaso;
public static CompoundWord SoweliWawa;
public static CompoundWord SoweliWawaPimeja;
public static CompoundWord SoweliWawaTomo;
public static CompoundWord TeloMamaSoweli;
public static CompoundWord MaSuli;
public static CompoundWord SuliPiNanpaWan;
public static CompoundWord TeloSuli;
public static CompoundWord TenpoSuli;
public static CompoundWord SunoKamaNi;
public static CompoundWord TenpoSuno;
public static CompoundWord TenpoSunoKama;
public static CompoundWord TenpoSunoNi;
public static CompoundWord TenpoSunoPini;
public static CompoundWord SupaMoku;
public static CompoundWord SupaMonsi;
public static CompoundWord SupaPali;
public static CompoundWord TeloSuwi;
public static CompoundWord TeloWawaSuwi;
public static CompoundWord TanAli;
public static CompoundWord TanSeme;
public static CompoundWord TanSijelo;
public static CompoundWord MiTawa;
public static CompoundWord TawaAnpa;
public static CompoundWord TawaAnpaTelo;
public static CompoundWord TawaInsa;
public static CompoundWord TawaInsaKon;
public static CompoundWord TawaJo;
public static CompoundWord TawaKon;
public static CompoundWord TawaLonKon;
public static CompoundWord TawaLonLukaPona;
public static CompoundWord TawaLonLukaIke;
public static CompoundWord TawaMoli;
public static CompoundWord TawaMusi;
public static CompoundWord TawaMute;
public static CompoundWord TawaMuteLonTempoLili;
public static CompoundWord TawaNoka;
public static CompoundWord TawaNokaWawa;
public static CompoundWord TawaPokaAnte;
public static CompoundWord TawaSeloKon;
public static CompoundWord TawaSewi;
public static CompoundWord TawaSikeLon;
public static CompoundWord TawaWawa;
public static CompoundWord TawaWawaNoka;
public static CompoundWord TomoTawa;
public static CompoundWord TomoTawaTelo;
public static CompoundWord TomoTawaTeloAnpa;
public static CompoundWord MokuTelo;
public static CompoundWord TeloInsa;
public static CompoundWord TeloMoku;
public static CompoundWord TeloMoli;
public static CompoundWord TeloNasaKasi;
public static CompoundWord TeloNasaKili;
public static CompoundWord TeloNasaPona;
public static CompoundWord TeloPiKonSuwi;
public static CompoundWord TeloPimejaSeli;
public static CompoundWord TeloSeli;
public static CompoundWord TeloSelo;
public static CompoundWord TeloSewi;
public static CompoundWord TeloSijelo;
public static CompoundWord TeloSuno;
public static CompoundWord TeloTawa;
public static CompoundWord TeloWalo;
public static CompoundWord TeloWaloMama;
public static CompoundWord TeloMije;
public static CompoundWord TeloWaloMije;
public static CompoundWord TeloWawa;
public static CompoundWord TenpoTelo;
public static CompoundWord TomoTelo;
public static CompoundWord TenpoAleAla;
public static CompoundWord TenpoIjo;
public static CompoundWord TenpoMun;
public static CompoundWord TenpoMute;
public static CompoundWord TenpoMuteLili;
public static CompoundWord TenpoNasa;
public static CompoundWord TenpoOpen;
public static CompoundWord TenpoPiKamaSeli;
public static CompoundWord TenpoPiLeteLili;
public static CompoundWord TenpoPiLeteMute;
public static CompoundWord TenpoPiSeliLili;
public static CompoundWord TenpoPiSeliMute;
public static CompoundWord TenpoPiniPiKulupuMama;
public static CompoundWord TenpoSikeLili;
public static CompoundWord TenpoSinpin;
public static CompoundWord TenpoSinpinNi;
public static CompoundWord TenpoSuliMonsi;
public static CompoundWord TenpoSunoPiLukaTu;
public static CompoundWord TenpoSunoPiMokuMute;
public static CompoundWord TenpoSunoSewi;
public static CompoundWord TenpoSunoSike;
public static CompoundWord TokiAla;
public static CompoundWord TokiAkesi;
public static CompoundWord TokiAnte;
public static CompoundWord TokiETokiPona;
public static CompoundWord TokiIlo;
public static CompoundWord TokiKepeken;
public static CompoundWord TokiKepekenUta;
public static CompoundWord TokiLon;
public static CompoundWord TokiMusi;
public static CompoundWord TokiOlin;
public static CompoundWord TokiPali;
public static CompoundWord TokiPiKalamaMusi;
public static CompoundWord TokiPiNimiSama;
public static CompoundWord TokiPiPilinSama;
public static CompoundWord TokiPiTenpoMute;
public static CompoundWord TokiPiTenpoSuno;
public static CompoundWord TokiPilin;
public static CompoundWord TokiSike;
public static CompoundWord TokiSona;
public static CompoundWord TokiTawa;
public static CompoundWord TokiUtala;
public static CompoundWord TokiUtalaLon;
public static CompoundWord TokiWawa;
public static CompoundWord MaTomo;
public static CompoundWord TomoLen;
public static CompoundWord TomoMani;
public static CompoundWord TomoMoku;
public static CompoundWord TomoNasa;
public static CompoundWord TomoPalisa;
public static CompoundWord TomoPiIjoManiMute;
public static CompoundWord TomoPiKaJoIjoMute;
public static CompoundWord TomoPiKamaSona;
public static CompoundWord TomoPiKiliMoku;
public static CompoundWord TomoPiMokuKili;
public static CompoundWord TomoPiMokuSoweli;
public static CompoundWord TomoPiMokuSuwi;
public static CompoundWord TomoPiPonaSijelo;
public static CompoundWord TomoPiSoweliMuMoku;
public static CompoundWord TomoPiSuwiMoku;
public static CompoundWord TomoPiTeloNasa;
public static CompoundWord TomoSeme;
public static CompoundWord TomoSewi;
public static CompoundWord TomoSuliPiKamaJoIjoMute;
public static CompoundWord TomoTawaKulupuPiAnpaMa;
public static CompoundWord TomoTawaKulupuPiSikeMute;
public static CompoundWord TomoTawaKulupuPiSikeTuTu;
public static CompoundWord TomoTawaPiJanMute;
public static CompoundWord TomoTawaPiKulupuJan;
public static CompoundWord TomoUnpa;
public static CompoundWord TomoUtala;
public static CompoundWord TokiElena;
public static CompoundWord TokiEpanja;
public static CompoundWord TokiEpelanto;
public static CompoundWord TokiEsi;
public static CompoundWord TokiEsuka;
public static CompoundWord TokiIlan;
public static CompoundWord TokiIngilisi;
public static CompoundWord TokiIntelinka;
public static CompoundWord TokiIntonesija;
public static CompoundWord TokiIsilan;
public static CompoundWord TokiItalija;
public static CompoundWord TokiIto;
public static CompoundWord TokiIwisi;
public static CompoundWord TokiKalika;
public static CompoundWord TokiKanse;
public static CompoundWord TokiKatala;
public static CompoundWord TokiKatelo;
public static CompoundWord TokiKinla;
public static CompoundWord TokiKuli;
public static CompoundWord TokiLasina;
public static CompoundWord TokiLawi;
public static CompoundWord TokiLijatuwa;
public static CompoundWord TokiLomani;
public static CompoundWord TokiLosi;
public static CompoundWord TokiLowasi;
public static CompoundWord TokiLowenki;
public static CompoundWord TokiLowensina;
public static CompoundWord TokiMalasi;
public static CompoundWord TokiMalasija;
public static CompoundWord TokiMosijo;
public static CompoundWord TokiNetelan;
public static CompoundWord TokiNijon;
public static CompoundWord TokiNosiki;
public static CompoundWord TokiNosikiSin;
public static CompoundWord TokiPalataElopa;
public static CompoundWord TokiPelalusi;
public static CompoundWord TokiPilipina;
public static CompoundWord TokiPokasi;
public static CompoundWord TokiPosan;
public static CompoundWord TokiPosuka;
public static CompoundWord TokiPotuka;
public static CompoundWord TokiSankitu;
public static CompoundWord TokiSanko;
public static CompoundWord TokiSawa;
public static CompoundWord TokiSeki;
public static CompoundWord TokiSinan;
public static CompoundWord TokiSipe;
public static CompoundWord TokiSonwen;
public static CompoundWord TokiSopisi;
public static CompoundWord TokiSumi;
public static CompoundWord TokiTansi;
public static CompoundWord TokiTawi;
public static CompoundWord TokiTosi;
public static CompoundWord TokiTuku;
public static CompoundWord TokiUkawina;
public static CompoundWord TokiWensa;
public static CompoundWord TokiWije;
public static CompoundWord MeliUnpa;
public static CompoundWord MijeUnpa;
public static CompoundWord UnpaPilin;
public static CompoundWord UnpaUta;
public static CompoundWord WileUnpa;
public static CompoundWord UtalaAla;
public static CompoundWord UtalaMusi;
public static CompoundWord UtalaSewi;
public static CompoundWord UtalaSuli;
public static CompoundWord UtalaToki;
public static CompoundWord WaloEnPimeja;
public static CompoundWord WaloUta;
public static CompoundWord WanNimi;
public static CompoundWord WanPaliPiKulupuNimiPini;
public static CompoundWord WanPiNanpaTuPiKulupuNimiPini;
public static CompoundWord WanPiNanpaWanPiKulupuNimiPini;
public static CompoundWord WanPiPaliAlaPiKulupuNimiPini;
public static CompoundWord WanPiTenpoSike;
public static CompoundWord WanPiWanNimi;
public static CompoundWord WanPoka;
public static CompoundWord WanSuli;
public static CompoundWord WasoAkesi;
public static CompoundWord WasoKuleToki;
public static CompoundWord WasoMa;
public static CompoundWord WasoMaPiTawaMute;
public static CompoundWord WasoPiMaLete;
public static CompoundWord WasoSoweli;
public static CompoundWord WasoWaloTelo;
public static CompoundWord WawaSin;
public static CompoundWord WawaAla;
public static CompoundWord WawaAlaSin;
public static CompoundWord WawaLili;
public static CompoundWord WekaELipuTanKulupuLipu;
public static CompoundWord WekaLon;
public static CompoundWord WekaTan;
public static CompoundWord WilePona;
public static CompoundWord WileESona;
public static CompoundWord WileMoku;
public static CompoundWord WilePali;
public static CompoundWord WileSona;
public static CompoundWord WileSoweli;
public static CompoundWord KanAla;
public static CompoundWord AliAla;
public static CompoundWord KiwenUnpa;
public static CompoundWord MaAli;
public static CompoundWord MaKasi;
public static CompoundWord MaKina;
public static CompoundWord MaPelija;
public static CompoundWord MaPiIkeAle;
public static CompoundWord MaPiKamaJoIjoMute;
public static CompoundWord MaPiKasiMoku;
public static CompoundWord MaPiPonaAle;
public static CompoundWord MaPiSonaTawa;
public static CompoundWord MaSewi;
public static CompoundWord MaSupa;
public static CompoundWord MaTelo;
public static CompoundWord MaTeloJaki;
public static CompoundWord MaTomoTelo;
public static CompoundWord MamaMa;
public static CompoundWord MeliSuwi;
public static CompoundWord MokuPiTeloMama;
public static CompoundWord MokuKiwenPiTeloMama;
public static CompoundWord MokuKiwen;
public static CompoundWord MokuLeteSuwi;
public static CompoundWord MokuLinja;
public static CompoundWord MokuPimejaSuwi;
public static CompoundWord MoliAla;
public static CompoundWord MusiIke;
public static CompoundWord MusiPona;
public static CompoundWord MusiToki;
public static CompoundWord MuteLiliLili;
public static CompoundWord MutePona;
public static CompoundWord MuteSeme;
public static CompoundWord WikeESona;
public static CompoundWord SikeNasa;
public static CompoundWord MokuSikeNasa;
public static CompoundWord SitelenKiwenPiJanSewi;
public static CompoundWord KiwenPiJanSewi;
public static CompoundWord ASoweli;
public static CompoundWord AkesiPiUtaSuli;
public static CompoundWord AkesiTeloWawa;
public static CompoundWord AwenTawa;
public static CompoundWord AwenWeka;
//public static CompoundWord EnTenpoSunoEnTenpoPimeja;
public static CompoundWord IjoNanpaWan;
public static CompoundWord IjoPiAnpaSelo;
public static CompoundWord IjoPiAwenIjo;
public static CompoundWord IjoPiLukinAla;
public static CompoundWord IjoSelo;
public static CompoundWord IjoTawaJanSewi;
public static CompoundWord IloLen;
public static CompoundWord IloPiKalamaSewi;
public static CompoundWord IloPiTawaPiTeloLoje;
public static CompoundWord IloPiTokiSuli;
public static CompoundWord IloSewi;
public static CompoundWord IloUtalaPalisaKasi;
public static CompoundWord InsaLoje;
public static CompoundWord JanMi;
public static CompoundWord JanIlo;
public static CompoundWord JanJaki;
public static CompoundWord JanKiwen;
public static CompoundWord JanLawaSewi;
public static CompoundWord JanPaliPiKoMa;
public static CompoundWord JanPiPonaIjo;
public static CompoundWord JanPiPonaIke;
public static CompoundWord JanPiTenpoKama;
public static CompoundWord JanPiTenpoKamaSama;
public static CompoundWord JanPiWekaLipu;
public static CompoundWord JanSewiPiSijeloAla;
public static CompoundWord JanSewiAle;
public static CompoundWord JanSewiLili;
public static CompoundWord JanSuliLili;
public static CompoundWord JanSuliPiNasinLawa;
public static CompoundWord JanTawaAwen;
public static CompoundWord JanUtalaLawa;
public static CompoundWord JanWeka;
public static CompoundWord JeloWawa;
public static CompoundWord JoWawa;
public static CompoundWord KalaKiwen;
public static CompoundWord KalamaMusiPiPonaTawaPakawan;
public static CompoundWord KalamaMusiSewi;
public static CompoundWord KalamaMusiToki;
public static CompoundWord KalamaNimi;
public static CompoundWord KalamaPiKonAnte;
public static CompoundWord KalamaPiKonAwen;
public static CompoundWord KamaJoWawa;
public static CompoundWord KamaLon;
public static CompoundWord KamaLonOna;
public static CompoundWord KamaLukin;
public static CompoundWord KamaMusi;
public static CompoundWord KamaNasa;
public static CompoundWord KamaPiTenpoSuno;
public static CompoundWord KamaSonaAla;
public static CompoundWord KamaWawaIjo;
public static CompoundWord KasiLiliNasa;
public static CompoundWord KasiLojePiLenLawa;
public static CompoundWord KasiMuteInsaTomoMute;
public static CompoundWord KasiSewi;
public static CompoundWord KenKama;
public static CompoundWord KenToki;
public static CompoundWord KepekenPonaLili;
public static CompoundWord KiliLinja;
public static CompoundWord KiliSuwiJelo;
public static CompoundWord KiwenKule;
public static CompoundWord KiwenWawaPimeja;
public static CompoundWord KoKili;
public static CompoundWord KoMama;
public static CompoundWord KoPiTeloLete;
public static CompoundWord KoPimeja;
public static CompoundWord KoWawaWalo;
public static CompoundWord KonPakala;
public static CompoundWord KuleMa;
public static CompoundWord KuleTelo;
public static CompoundWord KulupuJanPiMaSuli;
public static CompoundWord KulupuLipuSitelen;
public static CompoundWord KulupuMonsi;
public static CompoundWord KulupuOpen;
public static CompoundWord KulupuPiJanMa;
public static CompoundWord KulupuPiNimiAnte;
public static CompoundWord KulupuPini;
public static CompoundWord KulupuSinpin;
public static CompoundWord LawaNim;
public static CompoundWord LawaPiKalamaNimi;
public static CompoundWord LenIloNanpa;
public static CompoundWord LenLinja;
public static CompoundWord LenSewi;
public static CompoundWord LinjaPiMaSeli;
public static CompoundWord LinjaPilin;
public static CompoundWord LipuLipu;
public static CompoundWord LipuPana;
public static CompoundWord LipuPiKamaSin;
public static CompoundWord LipuSuliPiTeloKiwen;
public static CompoundWord LipuTokiSewi;
public static CompoundWord LipuTokiSewiKolan;
public static CompoundWord LipuTokiSewiPipija;
public static CompoundWord LipuTokiSewiTola;
public static CompoundWord LojeJelo;
public static CompoundWord LonLawaMi;
public static CompoundWord LonMonsiTenpoMute;
public static CompoundWord LonPoki;
public static CompoundWord LonPonaLili;
public static CompoundWord LonSina;
public static CompoundWord LonWeka;
public static CompoundWord LukaSike;
public static CompoundWord LukaTawa;
public static CompoundWord LukinESina;
public static CompoundWord LukinPiTomoPoka;
public static CompoundWord LukinTawaSina;
public static CompoundWord LukinToki;
public static CompoundWord MaKamaAnpaSuno;
public static CompoundWord MaKamaSewiSuno;
public static CompoundWord MaLawa;
public static CompoundWord MaMusi;
public static CompoundWord MaPan;
public static CompoundWord MaPiKasiPalisa;
public static CompoundWord MaPiSunoKama;
public static CompoundWord MaPiSunoSewi;
public static CompoundWord MaPiSunoWeka;
public static CompoundWord MaSike;
public static CompoundWord MaTomoMutePona;
public static CompoundWord MiPanaETomoTawaSina;
public static CompoundWord MijePonaEnMijeIke;
public static CompoundWord MijePonaEnOnaIke;
public static CompoundWord MokuAli;
public static CompoundWord MokuPiMoliAla;
public static CompoundWord MoliTawaJanSewi;
public static CompoundWord MonsiLinja;
public static CompoundWord MuJan;
public static CompoundWord MunNanpaLukaLukaWan;
public static CompoundWord MunTenpWan;
public static CompoundWord MunTenpo;
public static CompoundWord MusiMani;
public static CompoundWord MuteIke;
public static CompoundWord MuteLonTenpoLili;
public static CompoundWord NasinAnpaLukaLuka;
public static CompoundWord NasinAnpaPiNanpaTuWan;
public static CompoundWord NasinLinja;
public static CompoundWord NasinPajawi;
public static CompoundWord NasinPiAnpaSuno;
public static CompoundWord NasinPiKalamaToki;
public static CompoundWord NasinPiSewiSuno;
public static CompoundWord NasinPiSupaMute;
public static CompoundWord NasinPilin;
public static CompoundWord NasinSantelija;
public static CompoundWord NasinSatan;
public static CompoundWord NasinSona;
public static CompoundWord NasinTokiTenpo;
public static CompoundWord NasinWika;
public static CompoundWord NenaMa;
public static CompoundWord NenaSinpin;
public static CompoundWord NenaUta;
public static CompoundWord NimiAnteNimi;
public static CompoundWord NimiAntePiNimiKama;
public static CompoundWord NimiIjo;
public static CompoundWord NimiKama;
public static CompoundWord NimiKamaJo;
public static CompoundWord NimiLawa;
public static CompoundWord NimiLupa;
public static CompoundWord NimiMiSeme;
public static CompoundWord NimiNimi;
public static CompoundWord NimiOpen;
public static CompoundWord NimiPaliPini;
public static CompoundWord NimiPiPokaLawa;
public static CompoundWord NimiPoka;
public static CompoundWord NimiPoki;
public static CompoundWord NimiPokiLili;
public static CompoundWord NimiTawa;
public static CompoundWord NimiTokiLili;
public static CompoundWord NimiWan;
public static CompoundWord OlinPiUnpaAla;
public static CompoundWord OlinUnpa;
public static CompoundWord OnaSama;
public static CompoundWord PaliAlaPiPaliMute;
public static CompoundWord PaliMusiKiwen;
public static CompoundWord PaliSuli;
public static CompoundWord PaliTawa;
public static CompoundWord PaliWeka;
public static CompoundWord PalisaMije;
public static CompoundWord PalisaSike;
public static CompoundWord PanPiSikeMamaWaso;
public static CompoundWord PanaPiWileJanTawaJanSewi;
public static CompoundWord PanaWileAla;
public static CompoundWord PilinAle;
public static CompoundWord PilinENenaMamaKepekenUta;
public static CompoundWord PilinEPonaInsa;
public static CompoundWord PilinInsa;
public static CompoundWord PilinSijeloPiJanSewi;
public static CompoundWord PiniA;
public static CompoundWord PiniEInsa;
public static CompoundWord PiniKalama;
public static CompoundWord PiniSona;
public static CompoundWord PipiJaki;
public static CompoundWord PipiKonPiKoSuwi;
public static CompoundWord PipiLili;
public static CompoundWord PipiLinja;
public static CompoundWord PipiPiKalamaMusi;
public static CompoundWord PipiPiPaliMute;
public static CompoundWord PipiPiTomoNena;
public static CompoundWord PipiPiTomoNenaKiwen;
public static CompoundWord PipiPonaLukinLonKon;
public static CompoundWord PokaPiKamaSuno;
public static CompoundWord PokaPiSinpinLawa;
public static CompoundWord PokaPiWekaSuno;
public static CompoundWord PokiKama;
public static CompoundWord PokiWawa;
public static CompoundWord PonaSuwi;
public static CompoundWord SamaPiSoweliSukosi;
public static CompoundWord SeloKasi;
public static CompoundWord SeloPiPokaTuTu;
public static CompoundWord SesloOko;
public static CompoundWord SikeLuka;
public static CompoundWord SikePiPipiLinja;
public static CompoundWord SikeSupa;
public static CompoundWord SikeWalo;
public static CompoundWord SinpinSuno;
public static CompoundWord SitelenELinja;
public static CompoundWord SitelenIke;
public static CompoundWord SitelenJanSewiTuWanLonJanSewiWan;
public static CompoundWord SitelenLapeIke;
public static CompoundWord SitelenLiliLili;
public static CompoundWord SitelenLiliNanpa;
public static CompoundWord SitelenLiliSin;
public static CompoundWord SitelenLiliSuli;
public static CompoundWord SitelenLiliToki;
public static CompoundWord SitelenMoku;
public static CompoundWord SitelenNanpa;
public static CompoundWord SitelenPiJanSewi;
public static CompoundWord SitelenSinpin;
public static CompoundWord SitelenSuno;
public static CompoundWord SonaKama;
public static CompoundWord SonaPiAnteToki;
public static CompoundWord SonaPiInsaToki;
public static CompoundWord SonaPiKalamaNimi;
public static CompoundWord SonaPiTenpoKama;
public static CompoundWord SonaPilin;
public static CompoundWord SonaTawa;
public static CompoundWord SonaTokiPiTenpoPini;
public static CompoundWord SonsPiSonaToki;
public static CompoundWord SoweliIke;
public static CompoundWord SoweliKasiLinja;
public static CompoundWord SoweliKiwen;
public static CompoundWord SoweliLapeMa;
public static CompoundWord SoweliLili;
public static CompoundWord SoweliLiliLili;
public static CompoundWord SoweliLinjaWawa;
public static CompoundWord SoweliPiMokuKiliKiwen;
public static CompoundWord SoweliPiNenaKiwen;
public static CompoundWord SoweliPiNenaPalisa;
public static CompoundWord SoweliPiNeneLinja;
public static CompoundWord SoweliSuliPiLupaNenaPiMaLete;
public static CompoundWord SoweliTomoKo;
public static CompoundWord SoweliTomoWawa;
public static CompoundWord SuliAla;
public static CompoundWord SuliMute;
public static CompoundWord TawaAwen;
public static CompoundWord TawaKama;
public static CompoundWord TawaKepekenNokaTu;
public static CompoundWord TawaKonWeka;
public static CompoundWord TawaLonSeloTelo;
public static CompoundWord TeloJaki;
public static CompoundWord TeloKiwen;
public static CompoundWord TeloKon;
public static CompoundWord TeloMamaSoweliKon;
public static CompoundWord TeloNasaJelo;
public static CompoundWord TeloNasaPiLawaWalo;
public static CompoundWord TeloPiSuliMute;
public static CompoundWord TenpLili;
public static CompoundWord TenpoLaso;
public static CompoundWord TenpoLasoJelo;
public static CompoundWord TenpoLiliMute;
public static CompoundWord TomoToki;
public static CompoundWord TenpoLoje;
public static CompoundWord TenpoLojeJelo;
public static CompoundWord TenpoPiSeloOkoTawa;
public static CompoundWord TenpoPimejaLaMiLukinESina;
public static CompoundWord TenpoPonaSuno;
public static CompoundWord TenpoSunoPaliAlaPiNanpaWan;
public static CompoundWord TenpoSunoPaliPiNanpaWan;
public static CompoundWord TokiPonaSewi;
public static CompoundWord TokiKamaEnTokiTawa;
public static CompoundWord TokiKepekenToki;
public static CompoundWord KalamaSewi;
public static CompoundWord TokiLonNanpa;
public static CompoundWord TokiLukin;
public static CompoundWord TokiNanpa;
public static CompoundWord TokiPiJoIke;
public static CompoundWord TokiPiNanpaSuli;
public static CompoundWord TokiPiTenpoNi;
public static CompoundWord TokiSin;
public static CompoundWord TokiSuli;
public static CompoundWord TokiTawaJaSewi;
public static CompoundWord TokiTawaJanSewi;
public static CompoundWord TokiWile;
//public static CompoundWord TomoAwen;
public static CompoundWord TomoKiwen;
public static CompoundWord TomoMoli;
public static CompoundWord TomoNanpaWan;
public static CompoundWord TomoPiKasiPalisa;
public static CompoundWord TomoPiLipuKasi;
public static CompoundWord TomoPiLonTenpo;
public static CompoundWord TomoTawaPiInsaMa;
public static CompoundWord TomoTawaPiLinjaTu;
public static CompoundWord TrenpoSunoPiMokuMute;
public static CompoundWord UtaKiwen;
public static CompoundWord WabPiKamaSona;
public static CompoundWord WanKalama;
public static CompoundWord WanLetePiSikeMa;
public static CompoundWord WanPiMaLiliMewika;
public static CompoundWord WanPiMaLiliMute;
public static CompoundWord WanPiMaLiliMuteMewika;
public static CompoundWord WanPiSonaToki;
public static CompoundWord WanSonaToki;
public static CompoundWord WasoKiwen;
public static CompoundWord WasoPimeja;
public static CompoundWord WasoToki;
public static CompoundWord WawaPiTuWan;
public static CompoundWord WekaPiJanJaku;
public static CompoundWord WekaTanKamaSinEnKamaMoli;
public static CompoundWord TepoMuteLili;
public static CompoundWord UnpaLukin;
public static CompoundWord SitelenNimi;
public static CompoundWord SikeLonLiliPiInsaWan;
public static CompoundWord WanInsa;
public static CompoundWord TokiLuka;
public static CompoundWord LukaNimi;
public static CompoundWord PokaPona;
public static CompoundWord PokaIke;
public static CompoundWord SitelenSewi;
public static CompoundWord SitelenWan;
//public static CompoundWord MiSewi;
public static CompoundWord MusiSike;
public static CompoundWord MaPiKasiLili;
public static CompoundWord MaSewiPona;
public static CompoundWord MaIke;
public static CompoundWord MusiPilin;
public static CompoundWord MijeLawaOlinMi;
public static CompoundWord MeliLawaOlinMi;
public static CompoundWord MaMama;
public static CompoundWord MuteAlaIke;
public static CompoundWord MeliSuli;
public static CompoundWord MunLili;
public static CompoundWord MijeInsa;
public static CompoundWord MeliInsa;
public static CompoundWord MeliJan;
public static CompoundWord MaPijawi;
public static CompoundWord MaJukan;
public static CompoundWord MaKaliponija;
public static CompoundWord MaKanesika;
public static CompoundWord MaKepeka;
public static CompoundWord MaLuwisijana;
public static CompoundWord MaManitopa;
public static CompoundWord MaMasasusi;
public static CompoundWord MaMisikan;
public static CompoundWord MaNowasosa;
public static CompoundWord MaNowetewetowi;
public static CompoundWord MaNujoka;
public static CompoundWord MaNunanu;
public static CompoundWord MaNupansuwi;
public static CompoundWord MaNupenlan;
public static CompoundWord MaNuwansa;
public static CompoundWord MaOwekan;
public static CompoundWord MaPisi;
public static CompoundWord MaPowita;
public static CompoundWord MaSakasuwan;
public static CompoundWord MaSosa;
public static CompoundWord MaTesa;
public static CompoundWord MaElopa;
public static CompoundWord MaEnkon;
public static CompoundWord MaLiliPijawi;
public static CompoundWord MaLiliJukan;
public static CompoundWord MaLiliKaliponija;
public static CompoundWord MaLiliKanesika;
public static CompoundWord MaLiliKepeka;
public static CompoundWord MaLiliLuwisijana;
public static CompoundWord MaLiliManitopa;
public static CompoundWord MaLiliMasasusi;
public static CompoundWord MaLiliMisikan;
public static CompoundWord MaLiliNowasosa;
public static CompoundWord MaLiliNowetewetowi;
public static CompoundWord MaLiliNujoka;
public static CompoundWord MaLiliNunanu;
public static CompoundWord MaLiliNupansuwi;
public static CompoundWord MaLiliNupenlan;
public static CompoundWord MaLiliNuwansa;
public static CompoundWord MaLiliOwekan;
public static CompoundWord MaLiliPisi;
public static CompoundWord MaLiliPowita;
public static CompoundWord MaLiliSakasuwan;
public static CompoundWord MaLiliSosa;
public static CompoundWord MaLiliTesa;
public static CompoundWord MaSuliElopa;
public static CompoundWord MaTomoEnkon;

        static CompoundWords()
        {


BuildIt();

        }

        public static void BuildIt()
        {

            Dictionary = new Dictionary<string, CompoundWord>(1500);
            Glosses = new Dictionary<string, Dictionary<string, Dictionary<string, string[]>>>(1500);

            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-kiwen-tomo", new[] { "turtle" });
                    glossMap.Add("en", en);
                }
                AkesiKiwenTomo = new CompoundWord("akesi-kiwen-tomo");

                Dictionary.Add("akesi-kiwen-tomo", AkesiKiwenTomo);
                Glosses.Add("akesi-kiwen-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-lili", new[] { "frog" });
                    glossMap.Add("en", en);
                }
                AkesiLili = new CompoundWord("akesi-lili");

                Dictionary.Add("akesi-lili", AkesiLili);
                Glosses.Add("akesi-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-linja", new[] { "snake", " serpent" });
                    glossMap.Add("en", en);
                }
                AkesiLinja = new CompoundWord("akesi-linja");

                Dictionary.Add("akesi-linja", AkesiLinja);
                Glosses.Add("akesi-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-palisa", new[] { "serpent", " snake", " alligator" });
                    glossMap.Add("en", en);
                }
                AkesiPalisa = new CompoundWord("akesi-palisa");

                Dictionary.Add("akesi-palisa", AkesiPalisa);
                Glosses.Add("akesi-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-pi-tomo-kiwen", new[] { "turtle", " tortoise" });
                    glossMap.Add("en", en);
                }
                AkesiPiTomoKiwen = new CompoundWord("akesi-pi-tomo-kiwen");

                Dictionary.Add("akesi-pi-tomo-kiwen", AkesiPiTomoKiwen);
                Glosses.Add("akesi-pi-tomo-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-poka", new[] { "turtle" });
                    glossMap.Add("en", en);
                }
                AkesiPoka = new CompoundWord("akesi-poka");

                Dictionary.Add("akesi-poka", AkesiPoka);
                Glosses.Add("akesi-poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-sike-tomo", new[] { "turtle" });
                    glossMap.Add("en", en);
                }
                AkesiSikeTomo = new CompoundWord("akesi-sike-tomo");

                Dictionary.Add("akesi-sike-tomo", AkesiSikeTomo);
                Glosses.Add("akesi-sike-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-telo", new[] { "frog", " amphibian" });
                    glossMap.Add("en", en);
                }
                AkesiTelo = new CompoundWord("akesi-telo");

                Dictionary.Add("akesi-telo", AkesiTelo);
                Glosses.Add("akesi-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-tomo", new[] { "lizard", " etc" });
                    glossMap.Add("en", en);
                }
                AkesiTomo = new CompoundWord("akesi-tomo");

                Dictionary.Add("akesi-tomo", AkesiTomo);
                Glosses.Add("akesi-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-waso", new[] { "pterodactyl" });
                    glossMap.Add("en", en);
                }
                AkesiWaso = new CompoundWord("akesi-waso");

                Dictionary.Add("akesi-waso", AkesiWaso);
                Glosses.Add("akesi-waso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ale-ala", new[] { "some", " something", " someone", " not all" });
                    glossMap.Add("en", en);
                }
                AleAla = new CompoundWord("ale-ala");

                Dictionary.Add("ale-ala", AleAla);
                Glosses.Add("ale-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ken-ala", new[] { "uneducated", " disabled" });
                    glossMap.Add("en", en);
                }
                KenAla = new CompoundWord("ken-ala");

                Dictionary.Add("ken-ala", KenAla);
                Glosses.Add("ken-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-tenpo-pi-pali-ala", new[] { "be taking a sabbatical", " break from work" });
                    glossMap.Add("en", en);
                }
                LonTenpoPiPaliAla = new CompoundWord("lon-tenpo-pi-pali-ala");

                Dictionary.Add("lon-tenpo-pi-pali-ala", LonTenpoPiPaliAla);
                Glosses.Add("lon-tenpo-pi-pali-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ala", new[] { "indifferent", " unfeeling", " meditate", " Buddhist meditation", " sense", " concept", " meaning" });
                    glossMap.Add("en", en);
                }
                PilinAla = new CompoundWord("pilin-ala");

                Dictionary.Add("pilin-ala", PilinAla);
                Glosses.Add("pilin-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-ala", new[] { "uneducated" });
                    glossMap.Add("en", en);
                }
                SonaAla = new CompoundWord("sona-ala");

                Dictionary.Add("sona-ala", SonaAla);
                Glosses.Add("sona-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-ala", new[] { "never" });
                    glossMap.Add("en", en);
                }
                TenpoAla = new CompoundWord("tenpo-ala");

                Dictionary.Add("tenpo-ala", TenpoAla);
                Glosses.Add("tenpo-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ale-ma", new[] { "earth's life" });
                    glossMap.Add("en", en);
                }
                AleMa = new CompoundWord("ale-ma");

                Dictionary.Add("ale-ma", AleMa);
                Glosses.Add("ale-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ale-pi-sitelen-ala", new[] { "the Unmanifested" });
                    glossMap.Add("en", en);
                }
                AlePiSitelenAla = new CompoundWord("ale-pi-sitelen-ala");

                Dictionary.Add("ale-pi-sitelen-ala", AlePiSitelenAla);
                Glosses.Add("ale-pi-sitelen-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ale-sewi", new[] { "The All (The One", " The Omni-)" });
                    glossMap.Add("en", en);
                }
                AleSewi = new CompoundWord("ale-sewi");

                Dictionary.Add("ale-sewi", AleSewi);
                Glosses.Add("ale-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-ale", new[] { "always", " all the time" });
                    glossMap.Add("en", en);
                }
                TenpoAle = new CompoundWord("tenpo-ale");

                Dictionary.Add("tenpo-ale", TenpoAle);
                Glosses.Add("tenpo-ale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("anpa-ala", new[] { "below zero" });
                    glossMap.Add("en", en);
                }
                AnpaAla = new CompoundWord("anpa-ala");

                Dictionary.Add("anpa-ala", AnpaAla);
                Glosses.Add("anpa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("anpa-ike", new[] { "fall", " collapse (vi", " n)" });
                    glossMap.Add("en", en);
                }
                AnpaIke = new CompoundWord("anpa-ike");

                Dictionary.Add("anpa-ike", AnpaIke);
                Glosses.Add("anpa-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("anpa-lawa", new[] { "neck", " throat" });
                    glossMap.Add("en", en);
                }
                AnpaLawa = new CompoundWord("anpa-lawa");

                Dictionary.Add("anpa-lawa", AnpaLawa);
                Glosses.Add("anpa-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("anpa-pi-sinpin-lawa", new[] { "chin" });
                    glossMap.Add("en", en);
                }
                AnpaPiSinpinLawa = new CompoundWord("anpa-pi-sinpin-lawa");

                Dictionary.Add("anpa-pi-sinpin-lawa", AnpaPiSinpinLawa);
                Glosses.Add("anpa-pi-sinpin-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-anpa", new[] { "grass" });
                    glossMap.Add("en", en);
                }
                KasiAnpa = new CompoundWord("kasi-anpa");

                Dictionary.Add("kasi-anpa", KasiAnpa);
                Glosses.Add("kasi-anpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-anpa", new[] { "below", " under", " beneath", " at the bottom", " down from" });
                    glossMap.Add("en", en);
                }
                LonAnpa = new CompoundWord("lon-anpa");

                Dictionary.Add("lon-anpa", LonAnpa);
                Glosses.Add("lon-anpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ante-lon", new[] { "alter (vt)", " speed" });
                    glossMap.Add("en", en);
                }
                AnteLon = new CompoundWord("ante-lon");

                Dictionary.Add("ante-lon", AnteLon);
                Glosses.Add("ante-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-ma-ante", new[] { "foreigner" });
                    glossMap.Add("en", en);
                }
                JanPiMaAnte = new CompoundWord("jan-pi-ma-ante");

                Dictionary.Add("jan-pi-ma-ante", JanPiMaAnte);
                Glosses.Add("jan-pi-ma-ante", glossMap);
            }


            //Template li awen xxx lon yyy
            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("awen-lon", new[] { "live in/at", " keep/remain in" });
            //        glossMap.Add("en", en);
            //    }
            //    AwenLon = new CompoundWord("awen-lon");
            //
            //    Dictionary.Add("awen-lon", AwenLon);
            //    Glosses.Add("awen-lon", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("awen-pona", new[] { "keep well", " patient" });
                    glossMap.Add("en", en);
                }
                AwenPona = new CompoundWord("awen-pona");

                Dictionary.Add("awen-pona", AwenPona);
                Glosses.Add("awen-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("awen-sinpin", new[] { "stand (keep standing)" });
                    glossMap.Add("en", en);
                }
                AwenSinpin = new CompoundWord("awen-sinpin");

                Dictionary.Add("awen-sinpin", AwenSinpin);
                Glosses.Add("awen-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("awen-unpa-pi-nasin-soweli", new[] { "doggy style" });
                    glossMap.Add("en", en);
                }
                AwenUnpaPiNasinSoweli = new CompoundWord("awen-unpa-pi-nasin-soweli");

                Dictionary.Add("awen-unpa-pi-nasin-soweli", AwenUnpaPiNasinSoweli);
                Glosses.Add("awen-unpa-pi-nasin-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-pi-tenpo-awen", new[] { "part-time work" });
                    glossMap.Add("en", en);
                }
                PaliPiTenpoAwen = new CompoundWord("pali-pi-tenpo-awen");

                Dictionary.Add("pali-pi-tenpo-awen", PaliPiTenpoAwen);
                Glosses.Add("pali-pi-tenpo-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    //"text", " literature", " dictionary"
                    en.Add("toki-awen", new[] { "text", " literature", " books in libraries", " preserved", "dictionary" });
                    glossMap.Add("en", en);
                }
                TokiAwen = new CompoundWord("toki-awen");

                Dictionary.Add("toki-awen", TokiAwen);
                Glosses.Add("toki-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-awen-sona", new[] { "lesson", " course of lessons" });
                    glossMap.Add("en", en);
                }
                TokiAwenSona = new CompoundWord("toki-awen-sona");

                Dictionary.Add("toki-awen-sona", TokiAwenSona);
                Glosses.Add("toki-awen-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-awen", new[] { "prison", " jail" });
                    glossMap.Add("en", en);
                }
                TomoAwen = new CompoundWord("tomo-awen");

                Dictionary.Add("tomo-awen", TomoAwen);
                Glosses.Add("tomo-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-awen-ike", new[] { "prison", " jail" });
                    glossMap.Add("en", en);
                }
                TomoAwenIke = new CompoundWord("tomo-awen-ike");

                Dictionary.Add("tomo-awen-ike", TomoAwenIke);
                Glosses.Add("tomo-awen-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-ante", new[] { "other things", " otherwise" });
                    glossMap.Add("en", en);
                }
                IjoAnte = new CompoundWord("ijo-ante");

                Dictionary.Add("ijo-ante", IjoAnte);
                Glosses.Add("ijo-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-ike", new[] { "problem" });
                    glossMap.Add("en", en);
                }
                IjoIke = new CompoundWord("ijo-ike");

                Dictionary.Add("ijo-ike", IjoIke);
                Glosses.Add("ijo-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-kiwen-telo", new[] { "brick" });
                    glossMap.Add("en", en);
                }
                IjoKiwenTelo = new CompoundWord("ijo-kiwen-telo");

                Dictionary.Add("ijo-kiwen-telo", IjoKiwenTelo);
                Glosses.Add("ijo-kiwen-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-lawa", new[] { "aim", " goal", " main point" });
                    glossMap.Add("en", en);
                }
                IjoLawa = new CompoundWord("ijo-lawa");

                Dictionary.Add("ijo-lawa", IjoLawa);
                Glosses.Add("ijo-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-lon-tawa", new[] { "animal" });
                    glossMap.Add("en", en);
                }
                IjoLonTawa = new CompoundWord("ijo-lon-tawa");

                Dictionary.Add("ijo-lon-tawa", IjoLonTawa);
                Glosses.Add("ijo-lon-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-lon-tomo", new[] { "household items" });
                    glossMap.Add("en", en);
                }
                IjoLonTomo = new CompoundWord("ijo-lon-tomo");

                Dictionary.Add("ijo-lon-tomo", IjoLonTomo);
                Glosses.Add("ijo-lon-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-mani", new[] { "merchandise" });
                    glossMap.Add("en", en);
                }
                IjoMani = new CompoundWord("ijo-mani");

                Dictionary.Add("ijo-mani", IjoMani);
                Glosses.Add("ijo-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-musi", new[] { "gift", " trinket" });
                    glossMap.Add("en", en);
                }
                IjoMusi = new CompoundWord("ijo-musi");

                Dictionary.Add("ijo-musi", IjoMusi);
                Glosses.Add("ijo-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-nasa-lili", new[] { "bustle" });
                    glossMap.Add("en", en);
                }
                IjoNasaLili = new CompoundWord("ijo-nasa-lili");

                Dictionary.Add("ijo-nasa-lili", IjoNasaLili);
                Glosses.Add("ijo-nasa-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-pana", new[] { "gift", " sacrifice", " offering", " present (gift)" });
                    glossMap.Add("en", en);
                }
                IjoPana = new CompoundWord("ijo-pana");

                Dictionary.Add("ijo-pana", IjoPana);
                Glosses.Add("ijo-pana", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-pana-olin", new[] { "love gift" });
                    glossMap.Add("en", en);
                }
                IjoPanaOlin = new CompoundWord("ijo-pana-olin");

                Dictionary.Add("ijo-pana-olin", IjoPanaOlin);
                Glosses.Add("ijo-pana-olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-pana-suno", new[] { "light", " lamp" });
                    glossMap.Add("en", en);
                }
                IjoPanaSuno = new CompoundWord("ijo-pana-suno");

                Dictionary.Add("ijo-pana-suno", IjoPanaSuno);
                Glosses.Add("ijo-pana-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-pi-pana-mute", new[] { "better thing" });
                    glossMap.Add("en", en);
                }
                IjoPiPanaMute = new CompoundWord("ijo-pi-pana-mute");

                Dictionary.Add("ijo-pi-pana-mute", IjoPiPanaMute);
                Glosses.Add("ijo-pi-pana-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-pi-sama-ala", new[] { "difference" });
                    glossMap.Add("en", en);
                }
                IjoPiSamaAla = new CompoundWord("ijo-pi-sama-ala");

                Dictionary.Add("ijo-pi-sama-ala", IjoPiSamaAla);
                Glosses.Add("ijo-pi-sama-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-sin-lon-ilo-pi-sitelen-tawa", new[] { "tv news" });
                    glossMap.Add("en", en);
                }
                IjoSinLonIloPiSitelenTawa = new CompoundWord("ijo-sin-lon-ilo-pi-sitelen-tawa");

                Dictionary.Add("ijo-sin-lon-ilo-pi-sitelen-tawa", IjoSinLonIloPiSitelenTawa);
                Glosses.Add("ijo-sin-lon-ilo-pi-sitelen-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-sinpin-luka-luka-tu-tu", new[] { "thing with 14 faces" });
                    glossMap.Add("en", en);
                }
                IjoSinpinLukaLukaTuTu = new CompoundWord("ijo-sinpin-luka-luka-tu-tu");

                Dictionary.Add("ijo-sinpin-luka-luka-tu-tu", IjoSinpinLukaLukaTuTu);
                Glosses.Add("ijo-sinpin-luka-luka-tu-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-tawa-pi-ken-moli", new[] { "animal" });
                    glossMap.Add("en", en);
                }
                IjoTawaPiKenMoli = new CompoundWord("ijo-tawa-pi-ken-moli");

                Dictionary.Add("ijo-tawa-pi-ken-moli", IjoTawaPiKenMoli);
                Glosses.Add("ijo-tawa-pi-ken-moli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-uta-walo", new[] { "teeth" });
                    glossMap.Add("en", en);
                }
                IjoUtaWalo = new CompoundWord("ijo-uta-walo");

                Dictionary.Add("ijo-uta-walo", IjoUtaWalo);
                Glosses.Add("ijo-uta-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ike-a", new[] { "Oh dear!  That sucks!" });
                    glossMap.Add("en", en);
                }
                IkeA = new CompoundWord("ike-a");

                Dictionary.Add("ike-a", IkeA);
                Glosses.Add("ike-a", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ike-lukin", new[] { "ugly" });
                    glossMap.Add("en", en);
                }
                IkeLukin = new CompoundWord("ike-lukin");

                Dictionary.Add("ike-lukin", IkeLukin);
                Glosses.Add("ike-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ike-moku", new[] { "nasty" });
                    glossMap.Add("en", en);
                }
                IkeMoku = new CompoundWord("ike-moku");

                Dictionary.Add("ike-moku", IkeMoku);
                Glosses.Add("ike-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ike-pali", new[] { "difficult", " hard (to do)" });
                    glossMap.Add("en", en);
                }
                IkePali = new CompoundWord("ike-pali");

                Dictionary.Add("ike-pali", IkePali);
                Glosses.Add("ike-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ike-sijelo", new[] { "sick" });
                    glossMap.Add("en", en);
                }
                IkeSijelo = new CompoundWord("ike-sijelo");

                Dictionary.Add("ike-sijelo", IkeSijelo);
                Glosses.Add("ike-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-ike", new[] { "television" });
                    glossMap.Add("en", en);
                }
                IloIke = new CompoundWord("ilo-ike");

                Dictionary.Add("ilo-ike", IloIke);
                Glosses.Add("ilo-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-ike", new[] { "bad person", " jerk", " negative person", " enemy" });
                    glossMap.Add("en", en);
                }
                JanIke = new CompoundWord("jan-ike");

                Dictionary.Add("jan-ike", JanIke);
                Glosses.Add("jan-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ike", new[] { "feel sad", " afraid", " fear" });
                    glossMap.Add("en", en);
                }
                PilinIke = new CompoundWord("pilin-ike");

                Dictionary.Add("pilin-ike", PilinIke);
                Glosses.Add("pilin-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-jan", new[] { "robot" });
                    glossMap.Add("en", en);
                }
                IloJan = new CompoundWord("ilo-jan");

                Dictionary.Add("ilo-jan", IloJan);
                Glosses.Add("ilo-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-kalama-pi-toma-tawa", new[] { "horn (of a car)" });
                    glossMap.Add("en", en);
                }
                IloKalamaPiTomaTawa = new CompoundWord("ilo-kalama-pi-toma-tawa");

                Dictionary.Add("ilo-kalama-pi-toma-tawa", IloKalamaPiTomaTawa);
                Glosses.Add("ilo-kalama-pi-toma-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-kiwen-pi-pakala-kasi", new[] { "ax" });
                    glossMap.Add("en", en);
                }
                IloKiwenPiPakalaKasi = new CompoundWord("ilo-kiwen-pi-pakala-kasi");

                Dictionary.Add("ilo-kiwen-pi-pakala-kasi", IloKiwenPiPakalaKasi);
                Glosses.Add("ilo-kiwen-pi-pakala-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-lape", new[] { "sleeping pill" });
                    glossMap.Add("en", en);
                }
                IloLape = new CompoundWord("ilo-lape");

                Dictionary.Add("ilo-lape", IloLape);
                Glosses.Add("ilo-lape", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-lape-soweli", new[] { "animal tranquilizer/anesthetic" });
                    glossMap.Add("en", en);
                }
                IloLapeSoweli = new CompoundWord("ilo-lape-soweli");

                Dictionary.Add("ilo-lape-soweli", IloLapeSoweli);
                Glosses.Add("ilo-lape-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-lukin", new[] { "telescope (astronomical)", " mirror", " x-ray or sonic scanner", " telescope", " microscope", " spectacles" });
                    glossMap.Add("en", en);
                }
                IloLukin = new CompoundWord("ilo-lukin");

                Dictionary.Add("ilo-lukin", IloLukin);
                Glosses.Add("ilo-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-lukin-pi-lipu-sona", new[] { "browser" });
                    glossMap.Add("en", en);
                }
                IloLukinPiLipuSona = new CompoundWord("ilo-lukin-pi-lipu-sona");

                Dictionary.Add("ilo-lukin-pi-lipu-sona", IloLukinPiLipuSona);
                Glosses.Add("ilo-lukin-pi-lipu-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-lukin-", new[] { "browser" });
                    glossMap.Add("en", en);
                }
                IloLukin = new CompoundWord("ilo-lukin-");

                Dictionary.Add("ilo-lukin-", IloLukin);
                Glosses.Add("ilo-lukin-", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-lukin-oko", new[] { "glassess" });
                    glossMap.Add("en", en);
                }
                IloLukinOko = new CompoundWord("ilo-lukin-oko");

                Dictionary.Add("ilo-lukin-oko", IloLukinOko);
                Glosses.Add("ilo-lukin-oko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-lukin-pi-sike-tu", new[] { "glasses" });
                    glossMap.Add("en", en);
                }
                IloLukinPiSikeTu = new CompoundWord("ilo-lukin-pi-sike-tu");

                Dictionary.Add("ilo-lukin-pi-sike-tu", IloLukinPiSikeTu);
                Glosses.Add("ilo-lukin-pi-sike-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-moku", new[] { "eating untensil", " knife" });
                    glossMap.Add("en", en);
                }
                IloMoku = new CompoundWord("ilo-moku");

                Dictionary.Add("ilo-moku", IloMoku);
                Glosses.Add("ilo-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-musi", new[] { "toy", " plaything" });
                    glossMap.Add("en", en);
                }
                IloMusi = new CompoundWord("ilo-musi");

                Dictionary.Add("ilo-musi", IloMusi);
                Glosses.Add("ilo-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-nanpa", new[] { "computer", " calculator" });
                    glossMap.Add("en", en);
                }
                IloNanpa = new CompoundWord("ilo-nanpa");

                Dictionary.Add("ilo-nanpa", IloNanpa);
                Glosses.Add("ilo-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-nasa", new[] { "drugs", " drug/dope" });
                    glossMap.Add("en", en);
                }
                IloNasa = new CompoundWord("ilo-nasa");

                Dictionary.Add("ilo-nasa", IloNasa);
                Glosses.Add("ilo-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-nasa-wawa", new[] { "energy giving drug" });
                    glossMap.Add("en", en);
                }
                IloNasaWawa = new CompoundWord("ilo-nasa-wawa");

                Dictionary.Add("ilo-nasa-wawa", IloNasaWawa);
                Glosses.Add("ilo-nasa-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-oko", new[] { "glasses" });
                    glossMap.Add("en", en);
                }
                IloOko = new CompoundWord("ilo-oko");

                Dictionary.Add("ilo-oko", IloOko);
                Glosses.Add("ilo-oko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-open", new[] { "key" });
                    glossMap.Add("en", en);
                }
                IloOpen = new CompoundWord("ilo-open");

                Dictionary.Add("ilo-open", IloOpen);
                Glosses.Add("ilo-open", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pana-pi-lipu-sona", new[] { "web page server", " web page server" });
                    glossMap.Add("en", en);
                }
                IloPanaPiLipuSona = new CompoundWord("ilo-pana-pi-lipu-sona");

                Dictionary.Add("ilo-pana-pi-lipu-sona", IloPanaPiLipuSona);
                Glosses.Add("ilo-pana-pi-lipu-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-pana-suno", new[] { "mirror", " reflector" });
                    glossMap.Add("en", en);
                }
                IloPiPanaSuno = new CompoundWord("ilo-pi-pana-suno");

                Dictionary.Add("ilo-pi-pana-suno", IloPiPanaSuno);
                Glosses.Add("ilo-pi-pana-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-sike-tu", new[] { "bicycle" });
                    glossMap.Add("en", en);
                }
                IloPiSikeTu = new CompoundWord("ilo-pi-sike-tu");

                Dictionary.Add("ilo-pi-sike-tu", IloPiSikeTu);
                Glosses.Add("ilo-pi-sike-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-sitelen-tawa", new[] { "television", " tv" });
                    glossMap.Add("en", en);
                }
                IloPiSitelenTawa = new CompoundWord("ilo-pi-sitelen-tawa");

                Dictionary.Add("ilo-pi-sitelen-tawa", IloPiSitelenTawa);
                Glosses.Add("ilo-pi-sitelen-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-sitelen-toki", new[] { "pen","pencil", " etc." });
                    glossMap.Add("en", en);
                }
                IloPiSitelenToki = new CompoundWord("ilo-pi-sitelen-toki");

                Dictionary.Add("ilo-pi-sitelen-toki", IloPiSitelenToki);
                Glosses.Add("ilo-pi-sitelen-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-suno-sin", new[] { "mirror" });
                    glossMap.Add("en", en);
                }
                IloPiSunoSin = new CompoundWord("ilo-pi-suno-sin");

                Dictionary.Add("ilo-pi-suno-sin", IloPiSunoSin);
                Glosses.Add("ilo-pi-suno-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-tawa-kon", new[] { "wings", " wing" });
                    glossMap.Add("en", en);
                }
                IloPiTawaKon = new CompoundWord("ilo-pi-tawa-kon");

                Dictionary.Add("ilo-pi-tawa-kon", IloPiTawaKon);
                Glosses.Add("ilo-pi-tawa-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-tu-ijo", new[] { "cutting tool" });
                    glossMap.Add("en", en);
                }
                IloPiTuIjo = new CompoundWord("ilo-pi-tu-ijo");

                Dictionary.Add("ilo-pi-tu-ijo", IloPiTuIjo);
                Glosses.Add("ilo-pi-tu-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-waso", new[] { "wing" });
                    glossMap.Add("en", en);
                }
                IloWaso = new CompoundWord("ilo-waso");

                Dictionary.Add("ilo-waso", IloWaso);
                Glosses.Add("ilo-waso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-sijelo-waso", new[] { "wing" });
                    glossMap.Add("en", en);
                }
                IloSijeloWaso = new CompoundWord("ilo-sijelo-waso");

                Dictionary.Add("ilo-sijelo-waso", IloSijeloWaso);
                Glosses.Add("ilo-sijelo-waso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-sitelen", new[] { "bruch", " pen", " pencil", " etc.", " typewriter", " keyboard" });
                    glossMap.Add("en", en);
                }
                IloSitelen = new CompoundWord("ilo-sitelen");

                Dictionary.Add("ilo-sitelen", IloSitelen);
                Glosses.Add("ilo-sitelen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-sona", new[] { "computer" });
                    glossMap.Add("en", en);
                }
                IloSona = new CompoundWord("ilo-sona");

                Dictionary.Add("ilo-sona", IloSona);
                Glosses.Add("ilo-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-sona-tawa", new[] { "laptop computer", " internet", " computer", " laptop" });
                    glossMap.Add("en", en);
                }
                IloSonaTawa = new CompoundWord("ilo-sona-tawa");

                Dictionary.Add("ilo-sona-tawa", IloSonaTawa);
                Glosses.Add("ilo-sona-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-suno", new[] { "lamp", " flashlight", " light" });
                    glossMap.Add("en", en);
                }
                IloSuno = new CompoundWord("ilo-suno");

                Dictionary.Add("ilo-suno", IloSuno);
                Glosses.Add("ilo-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-tawa", new[] { "means of transportation" });
                    glossMap.Add("en", en);
                }
                IloTawa = new CompoundWord("ilo-tawa");

                Dictionary.Add("ilo-tawa", IloTawa);
                Glosses.Add("ilo-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-tawa-kon", new[] { "wings" });
                    glossMap.Add("en", en);
                }
                IloTawaKon = new CompoundWord("ilo-tawa-kon");

                Dictionary.Add("ilo-tawa-kon", IloTawaKon);
                Glosses.Add("ilo-tawa-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-tawa-pi-sike-tu", new[] { "bicycle" });
                    glossMap.Add("en", en);
                }
                IloTawaPiSikeTu = new CompoundWord("ilo-tawa-pi-sike-tu");

                Dictionary.Add("ilo-tawa-pi-sike-tu", IloTawaPiSikeTu);
                Glosses.Add("ilo-tawa-pi-sike-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-tawa-supa-pi-sike-tu", new[] { "recumbent bicycle" });
                    glossMap.Add("en", en);
                }
                IloTawaSupaPiSikeTu = new CompoundWord("ilo-tawa-supa-pi-sike-tu");

                Dictionary.Add("ilo-tawa-supa-pi-sike-tu", IloTawaSupaPiSikeTu);
                Glosses.Add("ilo-tawa-supa-pi-sike-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-tawa-telo", new[] { "boat" });
                    glossMap.Add("en", en);
                }
                IloTawaTelo = new CompoundWord("ilo-tawa-telo");

                Dictionary.Add("ilo-tawa-telo", IloTawaTelo);
                Glosses.Add("ilo-tawa-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-toki-tawa", new[] { "cell phone" });
                    glossMap.Add("en", en);
                }
                IloTokiTawa = new CompoundWord("ilo-toki-tawa");

                Dictionary.Add("ilo-toki-tawa", IloTokiTawa);
                Glosses.Add("ilo-toki-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-tu", new[] { "two tools" });
                    glossMap.Add("en", en);
                }
                IloTu = new CompoundWord("ilo-tu");

                Dictionary.Add("ilo-tu", IloTu);
                Glosses.Add("ilo-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-tu-lili", new[] { "jacknife" });
                    glossMap.Add("en", en);
                }
                IloTuLili = new CompoundWord("ilo-tu-lili");

                Dictionary.Add("ilo-tu-lili", IloTuLili);
                Glosses.Add("ilo-tu-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-unpa", new[] { "sex toy" });
                    glossMap.Add("en", en);
                }
                IloUnpa = new CompoundWord("ilo-unpa");

                Dictionary.Add("ilo-unpa", IloUnpa);
                Glosses.Add("ilo-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-utala", new[] { "weapon", " sword" });
                    glossMap.Add("en", en);
                }
                IloUtala = new CompoundWord("ilo-utala");

                Dictionary.Add("ilo-utala", IloUtala);
                Glosses.Add("ilo-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-wan-ma", new[] { "internet" });
                    glossMap.Add("en", en);
                }
                IloWanMa = new CompoundWord("ilo-wan-ma");

                Dictionary.Add("ilo-wan-ma", IloWanMa);
                Glosses.Add("ilo-wan-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-waso-lipu", new[] { "kite" });
                    glossMap.Add("en", en);
                }
                IloWasoLipu = new CompoundWord("ilo-waso-lipu");

                Dictionary.Add("ilo-waso-lipu", IloWasoLipu);
                Glosses.Add("ilo-waso-lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("insa-ala", new[] { "outside", " beyond", " outside of" });
                    glossMap.Add("en", en);
                }
                InsaAla = new CompoundWord("insa-ala");

                Dictionary.Add("insa-ala", InsaAla);
                Glosses.Add("insa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("insa-kon", new[] { "lung" });
                    glossMap.Add("en", en);
                }
                InsaKon = new CompoundWord("insa-kon");

                Dictionary.Add("insa-kon", InsaKon);
                Glosses.Add("insa-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("insa-lawa", new[] { "brain" });
                    glossMap.Add("en", en);
                }
                InsaLawa = new CompoundWord("insa-lawa");

                Dictionary.Add("insa-lawa", InsaLawa);
                Glosses.Add("insa-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("insa-ma", new[] { "on earth" });
                    glossMap.Add("en", en);
                }
                InsaMa = new CompoundWord("insa-ma");

                Dictionary.Add("insa-ma", InsaMa);
                Glosses.Add("insa-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("insa-nasin-utala", new[] { "be enemies" });
                    glossMap.Add("en", en);
                }
                InsaNasinUtala = new CompoundWord("insa-nasin-utala");

                Dictionary.Add("insa-nasin-utala", InsaNasinUtala);
                Glosses.Add("insa-nasin-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("insa-pimeja", new[] { "liver" });
                    glossMap.Add("en", en);
                }
                InsaPimeja = new CompoundWord("insa-pimeja");

                Dictionary.Add("insa-pimeja", InsaPimeja);
                Glosses.Add("insa-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-insa", new[] { "inside of", " in the middle of", " at the center of", " inside" });
                    glossMap.Add("en", en);
                }
                LonInsa = new CompoundWord("lon-insa");

                Dictionary.Add("lon-insa", LonInsa);
                Glosses.Add("lon-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-insa", new[] { "person who identifies as female", " male to female transsexual" });
                    glossMap.Add("en", en);
                }
                MeliInsa = new CompoundWord("meli-insa");

                Dictionary.Add("meli-insa", MeliInsa);
                Glosses.Add("meli-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mije-insa", new[] { "identifies as male", " female to male transsexual" });
                    glossMap.Add("en", en);
                }
                MijeInsa = new CompoundWord("mije-insa");

                Dictionary.Add("mije-insa", MijeInsa);
                Glosses.Add("mije-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jaki-ala", new[] { "clean" });
                    glossMap.Add("en", en);
                }
                JakiAla = new CompoundWord("jaki-ala");

                Dictionary.Add("jaki-ala", JakiAla);
                Glosses.Add("jaki-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-jaki", new[] { "shit", " feces", " pooh", " crap", " dung" });
                    glossMap.Add("en", en);
                }
                KoJaki = new CompoundWord("ko-jaki");

                Dictionary.Add("ko-jaki", KoJaki);
                Glosses.Add("ko-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-jaki-lon-nena-sinpin", new[] { "boogers", " snot" });
                    glossMap.Add("en", en);
                }
                KoJakiLonNenaSinpin = new CompoundWord("ko-jaki-lon-nena-sinpin");

                Dictionary.Add("ko-jaki-lon-nena-sinpin", KoJakiLonNenaSinpin);
                Glosses.Add("ko-jaki-lon-nena-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-jaki", new[] { "fart", " bad smell" });
                    glossMap.Add("en", en);
                }
                KonJaki = new CompoundWord("kon-jaki");

                Dictionary.Add("kon-jaki", KonJaki);
                Glosses.Add("kon-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-jaki", new[] { "anus" });
                    glossMap.Add("en", en);
                }
                LupaJaki = new CompoundWord("lupa-jaki");

                Dictionary.Add("lupa-jaki", LupaJaki);
                Glosses.Add("lupa-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-jaki-lon-nena-sinpin", new[] { "snot" });
                    glossMap.Add("en", en);
                }
                TeloJakiLonNenaSinpin = new CompoundWord("telo-jaki-lon-nena-sinpin");

                Dictionary.Add("telo-jaki-lon-nena-sinpin", TeloJakiLonNenaSinpin);
                Glosses.Add("telo-jaki-lon-nena-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-ijo", new[] { "any man" });
                    glossMap.Add("en", en);
                }
                JanIjo = new CompoundWord("jan-ijo");

                Dictionary.Add("jan-ijo", JanIjo);
                Glosses.Add("jan-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-ike-pi-tomo-tawa-telo", new[] { "pirate", " Viklng" });
                    glossMap.Add("en", en);
                }
                JanIkePiTomoTawaTelo = new CompoundWord("jan-ike-pi-tomo-tawa-telo");

                Dictionary.Add("jan-ike-pi-tomo-tawa-telo", JanIkePiTomoTawaTelo);
                Glosses.Add("jan-ike-pi-tomo-tawa-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-kala", new[] { "mermaid" });
                    glossMap.Add("en", en);
                }
                JanKala = new CompoundWord("jan-kala");

                Dictionary.Add("jan-kala", JanKala);
                Glosses.Add("jan-kala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-kolisu", new[] { "Christian" });
                    glossMap.Add("en", en);
                }
                JanKolisu = new CompoundWord("jan-kolisu");

                Dictionary.Add("jan-kolisu", JanKolisu);
                Glosses.Add("jan-kolisu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-kon", new[] { "spirit", " spiritual being", " " });
                    glossMap.Add("en", en);
                }
                JanKon = new CompoundWord("jan-kon");

                Dictionary.Add("jan-kon", JanKon);
                Glosses.Add("jan-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-kulupu", new[] { "member of a group", " member" });
                    glossMap.Add("en", en);
                }
                JanKulupu = new CompoundWord("jan-kulupu");

                Dictionary.Add("jan-kulupu", JanKulupu);
                Glosses.Add("jan-kulupu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lawa", new[] { "leader", " boss", " master", " chairperson", " president", " director", " Head of state/President/Mayor/leader" });
                    glossMap.Add("en", en);
                }
                JanLawa = new CompoundWord("jan-lawa");

                Dictionary.Add("jan-lawa", JanLawa);
                Glosses.Add("jan-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lawa-ala", new[] { "non-chief" });
                    glossMap.Add("en", en);
                }
                JanLawaAla = new CompoundWord("jan-lawa-ala");

                Dictionary.Add("jan-lawa-ala", JanLawaAla);
                Glosses.Add("jan-lawa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lawa-ma", new[] { "president of country", " governor of state", " premier of province", " leader of country", " minister", " governor" });
                    glossMap.Add("en", en);
                }
                JanLawaMa = new CompoundWord("jan-lawa-ma");

                Dictionary.Add("jan-lawa-ma", JanLawaMa);
                Glosses.Add("jan-lawa-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lawa-pi-jan-utala", new[] { "leader of army", " commander", " general" });
                    glossMap.Add("en", en);
                }
                JanLawaPiJanUtala = new CompoundWord("jan-lawa-pi-jan-utala");

                Dictionary.Add("jan-lawa-pi-jan-utala", JanLawaPiJanUtala);
                Glosses.Add("jan-lawa-pi-jan-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lawa-pi-ma-tomo", new[] { "mayor" });
                    glossMap.Add("en", en);
                }
                JanLawaPiMaTomo = new CompoundWord("jan-lawa-pi-ma-tomo");

                Dictionary.Add("jan-lawa-pi-ma-tomo", JanLawaPiMaTomo);
                Glosses.Add("jan-lawa-pi-ma-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lili", new[] { "child", " daughter", " son; smal", " short", " thin or young person", " son; small" });
                    glossMap.Add("en", en);
                }
                JanLili = new CompoundWord("jan-lili");

                Dictionary.Add("jan-lili", JanLili);
                Glosses.Add("jan-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lili-pi-jan-sama-pi-mama", new[] { "cousin" });
                    glossMap.Add("en", en);
                }
                JanLiliPiJanSamaPiMama = new CompoundWord("jan-lili-pi-jan-sama-pi-mama");

                Dictionary.Add("jan-lili-pi-jan-sama-pi-mama", JanLiliPiJanSamaPiMama);
                Glosses.Add("jan-lili-pi-jan-sama-pi-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lili-sona", new[] { "student", " pupil" });
                    glossMap.Add("en", en);
                }
                JanLiliSona = new CompoundWord("jan-lili-sona");

                Dictionary.Add("jan-lili-sona", JanLiliSona);
                Glosses.Add("jan-lili-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lon", new[] { "the living" });
                    glossMap.Add("en", en);
                }
                JanLon = new CompoundWord("jan-lon");

                Dictionary.Add("jan-lon", JanLon);
                Glosses.Add("jan-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-ma", new[] { "farmer", " someone living in the country" });
                    glossMap.Add("en", en);
                }
                JanMa = new CompoundWord("jan-ma");

                Dictionary.Add("jan-ma", JanMa);
                Glosses.Add("jan-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-meli-lawa", new[] { "queen" });
                    glossMap.Add("en", en);
                }
                JanMeliLawa = new CompoundWord("jan-meli-lawa");

                Dictionary.Add("jan-meli-lawa", JanMeliLawa);
                Glosses.Add("jan-meli-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-meli-olin", new[] { "wife" });
                    glossMap.Add("en", en);
                }
                JanMeliOlin = new CompoundWord("jan-meli-olin");

                Dictionary.Add("jan-meli-olin", JanMeliOlin);
                Glosses.Add("jan-meli-olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-meli-sewi", new[] { "queen", " goddess" });
                    glossMap.Add("en", en);
                }
                JanMeliSewi = new CompoundWord("jan-meli-sewi");

                Dictionary.Add("jan-meli-sewi", JanMeliSewi);
                Glosses.Add("jan-meli-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-moli", new[] { "the dead" });
                    glossMap.Add("en", en);
                }
                JanMoli = new CompoundWord("jan-moli");

                Dictionary.Add("jan-moli", JanMoli);
                Glosses.Add("jan-moli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-mu", new[] { "animal in general", " animal" });
                    glossMap.Add("en", en);
                }
                JanMu = new CompoundWord("jan-mu");

                Dictionary.Add("jan-mu", JanMu);
                Glosses.Add("jan-mu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-musi", new[] { "anyone interesting", " attractive.amusing" });
                    glossMap.Add("en", en);
                }
                JanMusi = new CompoundWord("jan-musi");

                Dictionary.Add("jan-musi", JanMusi);
                Glosses.Add("jan-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-nasa", new[] { "strange", " foolish", " unconventional or crazy person", " idiot", " drunkard" });
                    glossMap.Add("en", en);
                }
                JanNasa = new CompoundWord("jan-nasa");

                Dictionary.Add("jan-nasa", JanNasa);
                Glosses.Add("jan-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-nasa-utala", new[] { "fighting fool" });
                    glossMap.Add("en", en);
                }
                JanNasaUtala = new CompoundWord("jan-nasa-utala");

                Dictionary.Add("jan-nasa-utala", JanNasaUtala);
                Glosses.Add("jan-nasa-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-olin", new[] { "partner", " spouse", " significant other","loved one" });
                    glossMap.Add("en", en);
                }
                JanOlin = new CompoundWord("jan-olin");

                Dictionary.Add("jan-olin", JanOlin);
                Glosses.Add("jan-olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pakala", new[] { "victim", " handicapped person" });
                    glossMap.Add("en", en);
                }
                JanPakala = new CompoundWord("jan-pakala");

                Dictionary.Add("jan-pakala", JanPakala);
                Glosses.Add("jan-pakala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pali", new[] { "worker", " employee" });
                    glossMap.Add("en", en);
                }
                JanPali = new CompoundWord("jan-pali");

                Dictionary.Add("jan-pali", JanPali);
                Glosses.Add("jan-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pali-ma", new[] { "farmer", " cultivator of land" });
                    glossMap.Add("en", en);
                }
                JanPaliMa = new CompoundWord("jan-pali-ma");

                Dictionary.Add("jan-pali-ma", JanPaliMa);
                Glosses.Add("jan-pali-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pali-pi-kasi-mute", new[] { "forester" });
                    glossMap.Add("en", en);
                }
                JanPaliPiKasiMute = new CompoundWord("jan-pali-pi-kasi-mute");

                Dictionary.Add("jan-pali-pi-kasi-mute", JanPaliPiKasiMute);
                Glosses.Add("jan-pali-pi-kasi-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pali-pi-moku-soweli", new[] { "butcher" });
                    glossMap.Add("en", en);
                }
                JanPaliPiMokuSoweli = new CompoundWord("jan-pali-pi-moku-soweli");

                Dictionary.Add("jan-pali-pi-moku-soweli", JanPaliPiMokuSoweli);
                Glosses.Add("jan-pali-pi-moku-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pali-pi-tomo-pi-moku-soweli", new[] { "butcher" });
                    glossMap.Add("en", en);
                }
                JanPaliPiTomoPiMokuSoweli = new CompoundWord("jan-pali-pi-tomo-pi-moku-soweli");

                Dictionary.Add("jan-pali-pi-tomo-pi-moku-soweli", JanPaliPiTomoPiMokuSoweli);
                Glosses.Add("jan-pali-pi-tomo-pi-moku-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-jan-unpa-mute", new[] { "promiscuous person" });
                    glossMap.Add("en", en);
                }
                JanPiJanUnpaMute = new CompoundWord("jan-pi-jan-unpa-mute");

                Dictionary.Add("jan-pi-jan-unpa-mute", JanPiJanUnpaMute);
                Glosses.Add("jan-pi-jan-unpa-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-kalama-musi", new[] { "musician" });
                    glossMap.Add("en", en);
                }
                JanPiKalamaMusi = new CompoundWord("jan-pi-kalama-musi");

                Dictionary.Add("jan-pi-kalama-musi", JanPiKalamaMusi);
                Glosses.Add("jan-pi-kalama-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-kama-sona", new[] { "student" });
                    glossMap.Add("en", en);
                }
                JanPiKamaSona = new CompoundWord("jan-pi-kama-sona");

                Dictionary.Add("jan-pi-kama-sona", JanPiKamaSona);
                Glosses.Add("jan-pi-kama-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-lawa-ala", new[] { "outlaw" });
                    glossMap.Add("en", en);
                }
                JanPiLawaAla = new CompoundWord("jan-pi-lawa-ala");

                Dictionary.Add("jan-pi-lawa-ala", JanPiLawaAla);
                Glosses.Add("jan-pi-lawa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-ma-sama", new[] { "fellow citizen", " countryman" });
                    glossMap.Add("en", en);
                }
                JanPiMaSama = new CompoundWord("jan-pi-ma-sama");

                Dictionary.Add("jan-pi-ma-sama", JanPiMaSama);
                Glosses.Add("jan-pi-ma-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-ma-tomo", new[] { "city dweller" });
                    glossMap.Add("en", en);
                }
                JanPiMaTomo = new CompoundWord("jan-pi-ma-tomo");

                Dictionary.Add("jan-pi-ma-tomo", JanPiMaTomo);
                Glosses.Add("jan-pi-ma-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-musi-sijelo", new[] { "athlete" });
                    glossMap.Add("en", en);
                }
                JanPiMusiSijelo = new CompoundWord("jan-pi-musi-sijelo");

                Dictionary.Add("jan-pi-musi-sijelo", JanPiMusiSijelo);
                Glosses.Add("jan-pi-musi-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-nasin-sewi-Kolisu", new[] { "Christian" });
                    glossMap.Add("en", en);
                }
                JanPiNasinSewiKolisu = new CompoundWord("jan-pi-nasin-sewi-Kolisu");

                Dictionary.Add("jan-pi-nasin-sewi-Kolisu", JanPiNasinSewiKolisu);
                Glosses.Add("jan-pi-nasin-sewi-Kolisu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-moku", new[] { "chef", " cook" });
                    glossMap.Add("en", en);
                }
                JanMoku = new CompoundWord("jan-moku");

                Dictionary.Add("jan-moku", JanMoku);
                Glosses.Add("jan-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-pali-moku", new[] { "chef", " cook" });
                    glossMap.Add("en", en);
                }
                JanPiPaliMoku = new CompoundWord("jan-pi-pali-moku");

                Dictionary.Add("jan-pi-pali-moku", JanPiPaliMoku);
                Glosses.Add("jan-pi-pali-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-pali-musi", new[] { "athlete" });
                    glossMap.Add("en", en);
                }
                JanPiPaliMusi = new CompoundWord("jan-pi-pali-musi");

                Dictionary.Add("jan-pi-pali-musi", JanPiPaliMusi);
                Glosses.Add("jan-pi-pali-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-unpa", new[] { "sex partner", " prostitute" });
                    glossMap.Add("en", en);
                }
                JanUnpa = new CompoundWord("jan-unpa");

                Dictionary.Add("jan-unpa", JanUnpa);
                Glosses.Add("jan-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-pali-unpa", new[] { "sex partner", " prostitute" });
                    glossMap.Add("en", en);
                }
                JanPiPaliUnpa = new CompoundWord("jan-pi-pali-unpa");

                Dictionary.Add("jan-pi-pali-unpa", JanPiPaliUnpa);
                Glosses.Add("jan-pi-pali-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-pana-sona", new[] { "teacher" });
                    glossMap.Add("en", en);
                }
                JanPiPanaSona = new CompoundWord("jan-pi-pana-sona");

                Dictionary.Add("jan-pi-pana-sona", JanPiPanaSona);
                Glosses.Add("jan-pi-pana-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-pona-pilin", new[] { "psychotherapist" });
                    glossMap.Add("en", en);
                }
                JanPiPonaPilin = new CompoundWord("jan-pi-pona-pilin");

                Dictionary.Add("jan-pi-pona-pilin", JanPiPonaPilin);
                Glosses.Add("jan-pi-pona-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-pona-sijelo", new[] { "doctor", " healer" });
                    glossMap.Add("en", en);
                }
                JanPiPonaSijelo = new CompoundWord("jan-pi-pona-sijelo");

                Dictionary.Add("jan-pi-pona-sijelo", JanPiPonaSijelo);
                Glosses.Add("jan-pi-pona-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-sona-ali", new[] { "philosopher", " savant" });
                    glossMap.Add("en", en);
                }
                JanPiSonaAli = new CompoundWord("jan-pi-sona-ali");

                Dictionary.Add("jan-pi-sona-ali", JanPiSonaAli);
                Glosses.Add("jan-pi-sona-ali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-sona-kasi", new[] { "orchard keeper" });
                    glossMap.Add("en", en);
                }
                JanPiSonaKasi = new CompoundWord("jan-pi-sona-kasi");

                Dictionary.Add("jan-pi-sona-kasi", JanPiSonaKasi);
                Glosses.Add("jan-pi-sona-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-sona-nanpa", new[] { "mathematician" });
                    glossMap.Add("en", en);
                }
                JanPiSonaNanpa = new CompoundWord("jan-pi-sona-nanpa");

                Dictionary.Add("jan-pi-sona-nanpa", JanPiSonaNanpa);
                Glosses.Add("jan-pi-sona-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-sona-sin", new[] { "journalist", " reporter" });
                    glossMap.Add("en", en);
                }
                JanPiSonaSin = new CompoundWord("jan-pi-sona-sin");

                Dictionary.Add("jan-pi-sona-sin", JanPiSonaSin);
                Glosses.Add("jan-pi-sona-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-sona-toki", new[] { "linguist (polyglot)" });
                    glossMap.Add("en", en);
                }
                JanPiSonaToki = new CompoundWord("jan-pi-sona-toki");

                Dictionary.Add("jan-pi-sona-toki", JanPiSonaToki);
                Glosses.Add("jan-pi-sona-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-toki-awen", new[] { "writer", " author" });
                    glossMap.Add("en", en);
                }
                JanPiTokiAwen = new CompoundWord("jan-pi-toki-awen");

                Dictionary.Add("jan-pi-toki-awen", JanPiTokiAwen);
                Glosses.Add("jan-pi-toki-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-toki-musi", new[] { "singer" });
                    glossMap.Add("en", en);
                }
                JanPiTokiMusi = new CompoundWord("jan-pi-toki-musi");

                Dictionary.Add("jan-pi-toki-musi", JanPiTokiMusi);
                Glosses.Add("jan-pi-toki-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-tomo-pali", new[] { "office worker" });
                    glossMap.Add("en", en);
                }
                JanPiTomoPali = new CompoundWord("jan-pi-tomo-pali");

                Dictionary.Add("jan-pi-tomo-pali", JanPiTomoPali);
                Glosses.Add("jan-pi-tomo-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-tomo-sama", new[] { "housemate", " roommate" });
                    glossMap.Add("en", en);
                }
                JanPiTomoSama = new CompoundWord("jan-pi-tomo-sama");

                Dictionary.Add("jan-pi-tomo-sama", JanPiTomoSama);
                Glosses.Add("jan-pi-tomo-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-wile-ala", new[] { "person without desires" });
                    glossMap.Add("en", en);
                }
                JanPiWileAla = new CompoundWord("jan-pi-wile-ala");

                Dictionary.Add("jan-pi-wile-ala", JanPiWileAla);
                Glosses.Add("jan-pi-wile-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-plai-pona", new[] { "servant", " domestic" });
                    glossMap.Add("en", en);
                }
                JanPlaiPona = new CompoundWord("jan-plai-pona");

                Dictionary.Add("jan-plai-pona", JanPlaiPona);
                Glosses.Add("jan-plai-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-poka", new[] { "neighbor" });
                    glossMap.Add("en", en);
                }
                JanPoka = new CompoundWord("jan-poka");

                Dictionary.Add("jan-poka", JanPoka);
                Glosses.Add("jan-poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pona", new[] { "friend", "positive person", " repairman" });
                    glossMap.Add("en", en);
                }
                JanPona = new CompoundWord("jan-pona");

                Dictionary.Add("jan-pona", JanPona);
                Glosses.Add("jan-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pona-sewi", new[] { "saint" });
                    glossMap.Add("en", en);
                }
                JanPonaSewi = new CompoundWord("jan-pona-sewi");

                Dictionary.Add("jan-pona-sewi", JanPonaSewi);
                Glosses.Add("jan-pona-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sama", new[] { "sibling", " sister", " brother; similar person", " counterpart", " peer", " person in same situation" });
                    glossMap.Add("en", en);
                }
                JanSama = new CompoundWord("jan-sama");

                Dictionary.Add("jan-sama", JanSama);
                Glosses.Add("jan-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sama-pi-mama-mi", new[] { "uncle", " aunt" });
                    glossMap.Add("en", en);
                }
                JanSamaPiMamaMi = new CompoundWord("jan-sama-pi-mama-mi");

                Dictionary.Add("jan-sama-pi-mama-mi", JanSamaPiMamaMi);
                Glosses.Add("jan-sama-pi-mama-mi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-seme", new[] { "who", " anybody (it doesn't matter who)", " a person" });
                    glossMap.Add("en", en);
                }
                JanSeme = new CompoundWord("jan-seme");

                Dictionary.Add("jan-seme", JanSeme);
                Glosses.Add("jan-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sewi", new[] { "god (personal)", " priest", " God", " the faithful", " god" });
                    glossMap.Add("en", en);
                }
                JanSewi = new CompoundWord("jan-sewi");

                Dictionary.Add("jan-sewi", JanSewi);
                Glosses.Add("jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sewi-meli", new[] { "goddess" });
                    glossMap.Add("en", en);
                }
                JanSewiMeli = new CompoundWord("jan-sewi-meli");

                Dictionary.Add("jan-sewi-meli", JanSewiMeli);
                Glosses.Add("jan-sewi-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sin", new[] { "young person", " youth" });
                    glossMap.Add("en", en);
                }
                JanSin = new CompoundWord("jan-sin");

                Dictionary.Add("jan-sin", JanSin);
                Glosses.Add("jan-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-son-pi-kulupu-jan", new[] { "sociologists" });
                    glossMap.Add("en", en);
                }
                JanSonPiKulupuJan = new CompoundWord("jan-son-pi-kulupu-jan");

                Dictionary.Add("jan-son-pi-kulupu-jan", JanSonPiKulupuJan);
                Glosses.Add("jan-son-pi-kulupu-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sona", new[] { "knowledgeable person", " wise person", " educated person", " academic", " specialist", "Teacher", " scientist", " savant", " expert" });
                    glossMap.Add("en", en);
                }
                JanSona = new CompoundWord("jan-sona");

                Dictionary.Add("jan-sona", JanSona);
                Glosses.Add("jan-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sona-nanpa", new[] { "mathematician" });
                    glossMap.Add("en", en);
                }
                JanSonaNanpa = new CompoundWord("jan-sona-nanpa");

                Dictionary.Add("jan-sona-nanpa", JanSonaNanpa);
                Glosses.Add("jan-sona-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sona-pilin", new[] { "psychologist" });
                    glossMap.Add("en", en);
                }
                JanSonaPilin = new CompoundWord("jan-sona-pilin");

                Dictionary.Add("jan-sona-pilin", JanSonaPilin);
                Glosses.Add("jan-sona-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sona-sijelo", new[] { "doctor", " physician", " surgeon (plastic)" });
                    glossMap.Add("en", en);
                }
                JanSonaSijelo = new CompoundWord("jan-sona-sijelo");

                Dictionary.Add("jan-sona-sijelo", JanSonaSijelo);
                Glosses.Add("jan-sona-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-suli", new[] { "big", " tall person","fat person; adult", " giant", " celebrity", " lord" });
                    glossMap.Add("en", en);
                }
                JanSuli = new CompoundWord("jan-suli");

                Dictionary.Add("jan-suli", JanSuli);
                Glosses.Add("jan-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-toki", new[] { "speaker", " messenger", " person communicating", " prophet", " speakers (of a language)", " herald" });
                    glossMap.Add("en", en);
                }
                JanToki = new CompoundWord("jan-toki");

                Dictionary.Add("jan-toki", JanToki);
                Glosses.Add("jan-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-utala", new[] { "soldier" });
                    glossMap.Add("en", en);
                }
                JanUtala = new CompoundWord("jan-utala");

                Dictionary.Add("jan-utala", JanUtala);
                Glosses.Add("jan-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-wawa", new[] { "enchanter", " magician", " sorcerer", " medicine man" });
                    glossMap.Add("en", en);
                }
                JanWawa = new CompoundWord("jan-wawa");

                Dictionary.Add("jan-wawa", JanWawa);
                Glosses.Add("jan-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-wile", new[] { "person with desires" });
                    glossMap.Add("en", en);
                }
                JanWile = new CompoundWord("jan-wile");

                Dictionary.Add("jan-wile", JanWile);
                Glosses.Add("jan-wile", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-mama-jan", new[] { "human breast milk" });
                    glossMap.Add("en", en);
                }
                TeloMamaJan = new CompoundWord("telo-mama-jan");

                Dictionary.Add("telo-mama-jan", TeloMamaJan);
                Glosses.Add("telo-mama-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jelo-laso", new[] { "green" });
                    glossMap.Add("en", en);
                }
                JeloLaso = new CompoundWord("jelo-laso");

                Dictionary.Add("jelo-laso", JeloLaso);
                Glosses.Add("jelo-laso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-pi-telo-jelo", new[] { "urethra" });
                    glossMap.Add("en", en);
                }
                LupaPiTeloJelo = new CompoundWord("lupa-pi-telo-jelo");

                Dictionary.Add("lupa-pi-telo-jelo", LupaPiTeloJelo);
                Glosses.Add("lupa-pi-telo-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-jelo", new[] { "urine", " pee", " piss" });
                    glossMap.Add("en", en);
                }
                TeloJelo = new CompoundWord("telo-jelo");

                Dictionary.Add("telo-jelo", TeloJelo);
                Glosses.Add("telo-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jo-ike", new[] { "steal", " rob" });
                    glossMap.Add("en", en);
                }
                JoIke = new CompoundWord("jo-ike");

                Dictionary.Add("jo-ike", JoIke);
                Glosses.Add("jo-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jo-pi-sike-suno-lili", new[] { "young (age)" });
                    glossMap.Add("en", en);
                }
                JoPiSikeSunoLili = new CompoundWord("jo-pi-sike-suno-lili");

                Dictionary.Add("jo-pi-sike-suno-lili", JoPiSikeSunoLili);
                Glosses.Add("jo-pi-sike-suno-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jo-pi-sike-suno-mute", new[] { "old (aged)" });
                    glossMap.Add("en", en);
                }
                JoPiSikeSunoMute = new CompoundWord("jo-pi-sike-suno-mute");

                Dictionary.Add("jo-pi-sike-suno-mute", JoPiSikeSunoMute);
                Glosses.Add("jo-pi-sike-suno-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-jo", new[] { "receive", " get", " take", " obtain" });
                    glossMap.Add("en", en);
                }
                KamaJo = new CompoundWord("kama-jo");

                Dictionary.Add("kama-jo", KamaJo);
                Glosses.Add("kama-jo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-ko", new[] { "jellyfish" });
                    glossMap.Add("en", en);
                }
                KalaKo = new CompoundWord("kala-ko");

                Dictionary.Add("kala-ko", KalaKo);
                Glosses.Add("kala-ko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-pi-luka-linja-mute", new[] { "jellyfish" });
                    glossMap.Add("en", en);
                }
                KalaPiLukaLinjaMute = new CompoundWord("kala-pi-luka-linja-mute");

                Dictionary.Add("kala-pi-luka-linja-mute", KalaPiLukaLinjaMute);
                Glosses.Add("kala-pi-luka-linja-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-pi-luka-palisa", new[] { "squid" });
                    glossMap.Add("en", en);
                }
                KalaPiLukaPalisa = new CompoundWord("kala-pi-luka-palisa");

                Dictionary.Add("kala-pi-luka-palisa", KalaPiLukaPalisa);
                Glosses.Add("kala-pi-luka-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-pi-luka-wawa", new[] { "crab" });
                    glossMap.Add("en", en);
                }
                KalaPiLukaWawa = new CompoundWord("kala-pi-luka-wawa");

                Dictionary.Add("kala-pi-luka-wawa", KalaPiLukaWawa);
                Glosses.Add("kala-pi-luka-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-pi-pana-pi-telo-pimeja", new[] { "squid" });
                    glossMap.Add("en", en);
                }
                KalaPiPanaPiTeloPimeja = new CompoundWord("kala-pi-pana-pi-telo-pimeja");

                Dictionary.Add("kala-pi-pana-pi-telo-pimeja", KalaPiPanaPiTeloPimeja);
                Glosses.Add("kala-pi-pana-pi-telo-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-pi-selo-kiwen", new[] { "crab" });
                    glossMap.Add("en", en);
                }
                KalaPiSeloKiwen = new CompoundWord("kala-pi-selo-kiwen");

                Dictionary.Add("kala-pi-selo-kiwen", KalaPiSeloKiwen);
                Glosses.Add("kala-pi-selo-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-pi-tawa-monsi", new[] { "crab" });
                    glossMap.Add("en", en);
                }
                KalaPiTawaMonsi = new CompoundWord("kala-pi-tawa-monsi");

                Dictionary.Add("kala-pi-tawa-monsi", KalaPiTawaMonsi);
                Glosses.Add("kala-pi-tawa-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-pi-waso-lili", new[] { "flying fish" });
                    glossMap.Add("en", en);
                }
                KalaPiWasoLili = new CompoundWord("kala-pi-waso-lili");

                Dictionary.Add("kala-pi-waso-lili", KalaPiWasoLili);
                Glosses.Add("kala-pi-waso-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-sike", new[] { "jellyfish" });
                    glossMap.Add("en", en);
                }
                KalaSike = new CompoundWord("kala-sike");

                Dictionary.Add("kala-sike", KalaSike);
                Glosses.Add("kala-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-soweli-suli", new[] { "whale" });
                    glossMap.Add("en", en);
                }
                KalaSoweliSuli = new CompoundWord("kala-soweli-suli");

                Dictionary.Add("kala-soweli-suli", KalaSoweliSuli);
                Glosses.Add("kala-soweli-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-suli-suwi", new[] { "dolphin" });
                    glossMap.Add("en", en);
                }
                KalaSuliSuwi = new CompoundWord("kala-suli-suwi");

                Dictionary.Add("kala-suli-suwi", KalaSuliSuwi);
                Glosses.Add("kala-suli-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-tomo", new[] { "aquarium fish" });
                    glossMap.Add("en", en);
                }
                KalaTomo = new CompoundWord("kala-tomo");

                Dictionary.Add("kala-tomo", KalaTomo);
                Glosses.Add("kala-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-waso", new[] { "flying fish" });
                    glossMap.Add("en", en);
                }
                KalaWaso = new CompoundWord("kala-waso");

                Dictionary.Add("kala-waso", KalaWaso);
                Glosses.Add("kala-waso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-ala", new[] { "silence", " silent" });
                    glossMap.Add("en", en);
                }
                KalamaAla = new CompoundWord("kalama-ala");

                Dictionary.Add("kalama-ala", KalamaAla);
                Glosses.Add("kalama-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-lili", new[] { "sound", " sound (phoneme)", " phoneme" });
                    glossMap.Add("en", en);
                }
                KalamaLili = new CompoundWord("kalama-lili");

                Dictionary.Add("kalama-lili", KalamaLili);
                Glosses.Add("kalama-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-lili-awen", new[] { "consonant" });
                    glossMap.Add("en", en);
                }
                KalamaLiliAwen = new CompoundWord("kalama-lili-awen");

                Dictionary.Add("kalama-lili-awen", KalamaLiliAwen);
                Glosses.Add("kalama-lili-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-lili-tawa", new[] { "vowel" });
                    glossMap.Add("en", en);
                }
                KalamaLiliTawa = new CompoundWord("kalama-lili-tawa");

                Dictionary.Add("kalama-lili-tawa", KalamaLiliTawa);
                Glosses.Add("kalama-lili-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-monsi", new[] { "fart", " poot" });
                    glossMap.Add("en", en);
                }
                KalamaMonsi = new CompoundWord("kalama-monsi");

                Dictionary.Add("kalama-monsi", KalamaMonsi);
                Glosses.Add("kalama-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-musi", new[] { "song", " music", " sing (without words)" });
                    glossMap.Add("en", en);
                }
                KalamaMusi = new CompoundWord("kalama-musi");

                Dictionary.Add("kalama-musi", KalamaMusi);
                Glosses.Add("kalama-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-musi-uta", new[] { "sing" });
                    glossMap.Add("en", en);
                }
                KalamaMusiUta = new CompoundWord("kalama-musi-uta");

                Dictionary.Add("kalama-musi-uta", KalamaMusiUta);
                Glosses.Add("kalama-musi-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-mute", new[] { "make loud", " emphasize (in speech)" });
                    glossMap.Add("en", en);
                }
                KalamaMute = new CompoundWord("kalama-mute");

                Dictionary.Add("kalama-mute", KalamaMute);
                Glosses.Add("kalama-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-mute-ike", new[] { "noise", " racket" });
                    glossMap.Add("en", en);
                }
                KalamaMuteIke = new CompoundWord("kalama-mute-ike");

                Dictionary.Add("kalama-mute-ike", KalamaMuteIke);
                Glosses.Add("kalama-mute-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-telo", new[] { "splash" });
                    glossMap.Add("en", en);
                }
                KalamaTelo = new CompoundWord("kalama-telo");

                Dictionary.Add("kalama-telo", KalamaTelo);
                Glosses.Add("kalama-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-anpa", new[] { "go down", " descend" });
                    glossMap.Add("en", en);
                }
                KamaAnpa = new CompoundWord("kama-anpa");

                Dictionary.Add("kama-anpa", KamaAnpa);
                Glosses.Add("kama-anpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-insa", new[] { "come into", " enter" });
                    glossMap.Add("en", en);
                }
                KamaInsa = new CompoundWord("kama-insa");

                Dictionary.Add("kama-insa", KamaInsa);
                Glosses.Add("kama-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-jaki-ala", new[] { "clean up" });
                    glossMap.Add("en", en);
                }
                KamaJakiAla = new CompoundWord("kama-jaki-ala");

                Dictionary.Add("kama-jaki-ala", KamaJakiAla);
                Glosses.Add("kama-jaki-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-kepeken-pali", new[] { "goal" });
                    glossMap.Add("en", en);
                }
                KamaKepekenPali = new CompoundWord("kama-kepeken-pali");

                Dictionary.Add("kama-kepeken-pali", KamaKepekenPali);
                Glosses.Add("kama-kepeken-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-kulupu", new[] { "group meets/ing", " meeting", " convention", " conference", " come together", " congress", " meet(ing)" });
                    glossMap.Add("en", en);
                }
                KamaKulupu = new CompoundWord("kama-kulupu");

                Dictionary.Add("kama-kulupu", KamaKulupu);
                Glosses.Add("kama-kulupu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-lape", new[] { "rest", " go to sleep" });
                    glossMap.Add("en", en);
                }
                KamaLape = new CompoundWord("kama-lape");

                Dictionary.Add("kama-lape", KamaLape);
                Glosses.Add("kama-lape", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-lili", new[] { "diminish", " decrease" });
                    glossMap.Add("en", en);
                }
                KamaLili = new CompoundWord("kama-lili");

                Dictionary.Add("kama-lili", KamaLili);
                Glosses.Add("kama-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-lon-tomo", new[] { "came to the house" });
                    glossMap.Add("en", en);
                }
                KamaLonTomo = new CompoundWord("kama-lon-tomo");

                Dictionary.Add("kama-lon-tomo", KamaLonTomo);
                Glosses.Add("kama-lon-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-lupa-ala", new[] { "close a hole/wound" });
                    glossMap.Add("en", en);
                }
                KamaLupaAla = new CompoundWord("kama-lupa-ala");

                Dictionary.Add("kama-lupa-ala", KamaLupaAla);
                Glosses.Add("kama-lupa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-pi-lukin-ala", new[] { "hide" });
                    glossMap.Add("en", en);
                }
                KamaPiLukinAla = new CompoundWord("kama-pi-lukin-ala");

                Dictionary.Add("kama-pi-lukin-ala", KamaPiLukinAla);
                Glosses.Add("kama-pi-lukin-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-pi-lukin-sin", new[] { "find" });
                    glossMap.Add("en", en);
                }
                KamaPiLukinSin = new CompoundWord("kama-pi-lukin-sin");

                Dictionary.Add("kama-pi-lukin-sin", KamaPiLukinSin);
                Glosses.Add("kama-pi-lukin-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-pilin-ike", new[] { "get angry" });
                    glossMap.Add("en", en);
                }
                KamaPilinIke = new CompoundWord("kama-pilin-ike");

                Dictionary.Add("kama-pilin-ike", KamaPilinIke);
                Glosses.Add("kama-pilin-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-pini", new[] { "attain", " achieve" });
                    glossMap.Add("en", en);
                }
                KamaPini = new CompoundWord("kama-pini");

                Dictionary.Add("kama-pini", KamaPini);
                Glosses.Add("kama-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-pona", new[] { "Welcome" });
                    glossMap.Add("en", en);
                }
                KamaPona = new CompoundWord("kama-pona");

                Dictionary.Add("kama-pona", KamaPona);
                Glosses.Add("kama-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-pona-tawa", new[] { "be welcome at" });
                    glossMap.Add("en", en);
                }
                KamaPonaTawa = new CompoundWord("kama-pona-tawa");

                Dictionary.Add("kama-pona-tawa", KamaPonaTawa);
                Glosses.Add("kama-pona-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-selo-tan", new[] { "come out from" });
                    glossMap.Add("en", en);
                }
                KamaSeloTan = new CompoundWord("kama-selo-tan");

                Dictionary.Add("kama-selo-tan", KamaSeloTan);
                Glosses.Add("kama-selo-tan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-sewi", new[] { "go up", " ascend" });
                    glossMap.Add("en", en);
                }
                KamaSewi = new CompoundWord("kama-sewi");

                Dictionary.Add("kama-sewi", KamaSewi);
                Glosses.Add("kama-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-sewi-sin", new[] { "revive", " resuscitate", "resurrect" });
                    glossMap.Add("en", en);
                }
                KamaSewiSin = new CompoundWord("kama-sewi-sin");

                Dictionary.Add("kama-sewi-sin", KamaSewiSin);
                Glosses.Add("kama-sewi-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-sin", new[] { "rebirth", " news" });
                    glossMap.Add("en", en);
                }
                KamaSin = new CompoundWord("kama-sin");

                Dictionary.Add("kama-sin", KamaSin);
                Glosses.Add("kama-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-sinpin", new[] { "stand up", " stand" });
                    glossMap.Add("en", en);
                }
                KamaSinpin = new CompoundWord("kama-sinpin");

                Dictionary.Add("kama-sinpin", KamaSinpin);
                Glosses.Add("kama-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-sona", new[] { "get to know (person)", " learn", " understand", " get it", " encounter" });
                    glossMap.Add("en", en);
                }
                KamaSona = new CompoundWord("kama-sona");

                Dictionary.Add("kama-sona", KamaSona);
                Glosses.Add("kama-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-suli", new[] { "augment", " increase" });
                    glossMap.Add("en", en);
                }
                KamaSuli = new CompoundWord("kama-suli");

                Dictionary.Add("kama-suli", KamaSuli);
                Glosses.Add("kama-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-supa", new[] { "lie down" });
                    glossMap.Add("en", en);
                }
                KamaSupa = new CompoundWord("kama-supa");

                Dictionary.Add("kama-supa", KamaSupa);
                Glosses.Add("kama-supa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-telo", new[] { "melt" });
                    glossMap.Add("en", en);
                }
                KamaTelo = new CompoundWord("kama-telo");

                Dictionary.Add("kama-telo", KamaTelo);
                Glosses.Add("kama-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-wan", new[] { "unite", " meet", " come together", " meet up" });
                    glossMap.Add("en", en);
                }
                KamaWan = new CompoundWord("kama-wan");

                Dictionary.Add("kama-wan", KamaWan);
                Glosses.Add("kama-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-wile", new[] { "turned on", " began to lust", " …" });
                    glossMap.Add("en", en);
                }
                KamaWile = new CompoundWord("kama-wile");

                Dictionary.Add("kama-wile", KamaWile);
                Glosses.Add("kama-wile", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-kama-tan-sewi", new[] { "it rains", " it is raining" });
                    glossMap.Add("en", en);
                }
                TeloKamaTanSewi = new CompoundWord("telo-kama-tan-sewi");

                Dictionary.Add("telo-kama-tan-sewi", TeloKamaTanSewi);
                Glosses.Add("telo-kama-tan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-kama", new[] { "future" });
                    glossMap.Add("en", en);
                }
                TenpoKama = new CompoundWord("tenpo-kama");

                Dictionary.Add("tenpo-kama", TenpoKama);
                Glosses.Add("tenpo-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-kama-sona", new[] { "course", " credit hour" });
                    glossMap.Add("en", en);
                }
                WanPiKamaSona = new CompoundWord("wan-pi-kama-sona");

                Dictionary.Add("wan-pi-kama-sona", WanPiKamaSona);
                Glosses.Add("wan-pi-kama-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-ike", new[] { "weed", " tobacco" });
                    glossMap.Add("en", en);
                }
                KasiIke = new CompoundWord("kasi-ike");

                Dictionary.Add("kasi-ike", KasiIke);
                Glosses.Add("kasi-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-jaki", new[] { "tobacco" });
                    glossMap.Add("en", en);
                }
                KasiJaki = new CompoundWord("kasi-jaki");

                Dictionary.Add("kasi-jaki", KasiJaki);
                Glosses.Add("kasi-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-kule", new[] { "flower" });
                    glossMap.Add("en", en);
                }
                KasiKule = new CompoundWord("kasi-kule");

                Dictionary.Add("kasi-kule", KasiKule);
                Glosses.Add("kasi-kule", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-lili", new[] { "grass", " plant", " herb", " little weed" });
                    glossMap.Add("en", en);
                }
                KasiLili = new CompoundWord("kasi-lili");

                Dictionary.Add("kasi-lili", KasiLili);
                Glosses.Add("kasi-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-moku", new[] { "seed" });
                    glossMap.Add("en", en);
                }
                KasiMoku = new CompoundWord("kasi-moku");

                Dictionary.Add("kasi-moku", KasiMoku);
                Glosses.Add("kasi-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-mute", new[] { "forest" });
                    glossMap.Add("en", en);
                }
                KasiMute = new CompoundWord("kasi-mute");

                Dictionary.Add("kasi-mute", KasiMute);
                Glosses.Add("kasi-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-nasa", new[] { "marijuana", " intoxicating plant (recreational use)", " herb or some sort", " aphrodisiac", " smoke weed", " includes tobacco" });
                    glossMap.Add("en", en);
                }
                KasiNasa = new CompoundWord("kasi-nasa");

                Dictionary.Add("kasi-nasa", KasiNasa);
                Glosses.Add("kasi-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-palisa", new[] { "tree" });
                    glossMap.Add("en", en);
                }
                KasiPalisa = new CompoundWord("kasi-palisa");

                Dictionary.Add("kasi-palisa", KasiPalisa);
                Glosses.Add("kasi-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-palisa-suli", new[] { "tree" });
                    glossMap.Add("en", en);
                }
                KasiPalisaSuli = new CompoundWord("kasi-palisa-suli");

                Dictionary.Add("kasi-palisa-suli", KasiPalisaSuli);
                Glosses.Add("kasi-palisa-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-palisa-mute", new[] { "forest" });
                    glossMap.Add("en", en);
                }
                KasiPalisaMute = new CompoundWord("kasi-palisa-mute");

                Dictionary.Add("kasi-palisa-mute", KasiPalisaMute);
                Glosses.Add("kasi-palisa-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-pi-telo-ala", new[] { "cactus" });
                    glossMap.Add("en", en);
                }
                KasiPiTeloAla = new CompoundWord("kasi-pi-telo-ala");

                Dictionary.Add("kasi-pi-telo-ala", KasiPiTeloAla);
                Glosses.Add("kasi-pi-telo-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-pi-tenpo-pona-Kolisu", new[] { "Christmas tree" });
                    glossMap.Add("en", en);
                }
                KasiPiTenpoPonaKolisu = new CompoundWord("kasi-pi-tenpo-pona-Kolisu");

                Dictionary.Add("kasi-pi-tenpo-pona-Kolisu", KasiPiTenpoPonaKolisu);
                Glosses.Add("kasi-pi-tenpo-pona-Kolisu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-pi-uta-seli", new[] { "spice" });
                    glossMap.Add("en", en);
                }
                KasiPiUtaSeli = new CompoundWord("kasi-pi-uta-seli");

                Dictionary.Add("kasi-pi-uta-seli", KasiPiUtaSeli);
                Glosses.Add("kasi-pi-uta-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-sona", new[] { "intoxicating plant used in meditation" });
                    glossMap.Add("en", en);
                }
                KasiSona = new CompoundWord("kasi-sona");

                Dictionary.Add("kasi-sona", KasiSona);
                Glosses.Add("kasi-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-wawa", new[] { "spice" });
                    glossMap.Add("en", en);
                }
                KasiWawa = new CompoundWord("kasi-wawa");

                Dictionary.Add("kasi-wawa", KasiWawa);
                Glosses.Add("kasi-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ken-jan", new[] { "human rights", " Rights of Man" });
                    glossMap.Add("en", en);
                }
                KenJan = new CompoundWord("ken-jan");

                Dictionary.Add("ken-jan", KenJan);
                Glosses.Add("ken-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ken-lukin", new[] { "transparent" });
                    glossMap.Add("en", en);
                }
                KenLukin = new CompoundWord("ken-lukin");

                Dictionary.Add("ken-lukin", KenLukin);
                Glosses.Add("ken-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ken-pilin", new[] { "smart" });
                    glossMap.Add("en", en);
                }
                KenPilin = new CompoundWord("ken-pilin");

                Dictionary.Add("ken-pilin", KenPilin);
                Glosses.Add("ken-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ken-sona", new[] { "reason" });
                    glossMap.Add("en", en);
                }
                KenSona = new CompoundWord("ken-sona");

                Dictionary.Add("ken-sona", KenSona);
                Glosses.Add("ken-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kepeken-nasin-seme", new[] { "how" });
                    glossMap.Add("en", en);
                }
                KepekenNasinSeme = new CompoundWord("kepeken-nasin-seme");

                Dictionary.Add("kepeken-nasin-seme", KepekenNasinSeme);
                Glosses.Add("kepeken-nasin-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kepeken-pali-lili", new[] { "easily" });
                    glossMap.Add("en", en);
                }
                KepekenPaliLili = new CompoundWord("kepeken-pali-lili");

                Dictionary.Add("kepeken-pali-lili", KepekenPaliLili);
                Glosses.Add("kepeken-pali-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kepeken-pali-mute", new[] { "with difficulty" });
                    glossMap.Add("en", en);
                }
                KepekenPaliMute = new CompoundWord("kepeken-pali-mute");

                Dictionary.Add("kepeken-pali-mute", KepekenPaliMute);
                Glosses.Add("kepeken-pali-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-uta", new[] { "kiss" });
                    glossMap.Add("en", en);
                }
                PilinUta = new CompoundWord("pilin-uta");

                Dictionary.Add("pilin-uta", PilinUta);
                Glosses.Add("pilin-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-jelo", new[] { "pear", " banana" });
                    glossMap.Add("en", en);
                }
                KiliJelo = new CompoundWord("kili-jelo");

                Dictionary.Add("kili-jelo", KiliJelo);
                Glosses.Add("kili-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-jelo-palisa", new[] { "banana" });
                    glossMap.Add("en", en);
                }
                KiliJeloPalisa = new CompoundWord("kili-jelo-palisa");

                Dictionary.Add("kili-jelo-palisa", KiliJeloPalisa);
                Glosses.Add("kili-jelo-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-jelo-pi-suwi-ala", new[] { "lemon" });
                    glossMap.Add("en", en);
                }
                KiliJeloPiSuwiAla = new CompoundWord("kili-jelo-pi-suwi-ala");

                Dictionary.Add("kili-jelo-pi-suwi-ala", KiliJeloPiSuwiAla);
                Glosses.Add("kili-jelo-pi-suwi-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-lili-lawa", new[] { "mushroom" });
                    glossMap.Add("en", en);
                }
                KiliLiliLawa = new CompoundWord("kili-lili-lawa");

                Dictionary.Add("kili-lili-lawa", KiliLiliLawa);
                Glosses.Add("kili-lili-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-lili-lawa-seli", new[] { "magic mushroom", " hallucinogenic mushrooms" });
                    glossMap.Add("en", en);
                }
                KiliLiliLawaSeli = new CompoundWord("kili-lili-lawa-seli");

                Dictionary.Add("kili-lili-lawa-seli", KiliLiliLawaSeli);
                Glosses.Add("kili-lili-lawa-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-loje", new[] { "tomato", " apple" });
                    glossMap.Add("en", en);
                }
                KiliLoje = new CompoundWord("kili-loje");

                Dictionary.Add("kili-loje", KiliLoje);
                Glosses.Add("kili-loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-ma", new[] { "potato" });
                    glossMap.Add("en", en);
                }
                KiliMa = new CompoundWord("kili-ma");

                Dictionary.Add("kili-ma", KiliMa);
                Glosses.Add("kili-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-pi-sike-lili-mute", new[] { "grape", " raisin" });
                    glossMap.Add("en", en);
                }
                KiliPiSikeLiliMute = new CompoundWord("kili-pi-sike-lili-mute");

                Dictionary.Add("kili-pi-sike-lili-mute", KiliPiSikeLiliMute);
                Glosses.Add("kili-pi-sike-lili-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-sike-Soja", new[] { "soy bean" });
                    glossMap.Add("en", en);
                }
                KiliSikeSoja = new CompoundWord("kili-sike-Soja");

                Dictionary.Add("kili-sike-Soja", KiliSikeSoja);
                Glosses.Add("kili-sike-Soja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-sin", new[] { "greens", " fresh vegetables" });
                    glossMap.Add("en", en);
                }
                KiliSin = new CompoundWord("kili-sin");

                Dictionary.Add("kili-sin", KiliSin);
                Glosses.Add("kili-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-kili", new[] { "fruit juice" });
                    glossMap.Add("en", en);
                }
                TeloKili = new CompoundWord("telo-kili");

                Dictionary.Add("telo-kili", TeloKili);
                Glosses.Add("telo-kili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-lili-lili", new[] { "clod", " lump of clay", " dust" });
                    glossMap.Add("en", en);
                }
                KiwenLiliLili = new CompoundWord("kiwen-lili-lili");

                Dictionary.Add("kiwen-lili-lili", KiwenLiliLili);
                Glosses.Add("kiwen-lili-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-lili-musi", new[] { "dice" });
                    glossMap.Add("en", en);
                }
                KiwenLiliMusi = new CompoundWord("kiwen-lili-musi");

                Dictionary.Add("kiwen-lili-musi", KiwenLiliMusi);
                Glosses.Add("kiwen-lili-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-lukin", new[] { "transparent" });
                    glossMap.Add("en", en);
                }
                KiwenLukin = new CompoundWord("kiwen-lukin");

                Dictionary.Add("kiwen-lukin", KiwenLukin);
                Glosses.Add("kiwen-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-mani-jelo", new[] { "gold" });
                    glossMap.Add("en", en);
                }
                KiwenManiJelo = new CompoundWord("kiwen-mani-jelo");

                Dictionary.Add("kiwen-mani-jelo", KiwenManiJelo);
                Glosses.Add("kiwen-mani-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-mani-walo", new[] { "precious stones (diamonds)" });
                    glossMap.Add("en", en);
                }
                KiwenManiWalo = new CompoundWord("kiwen-mani-walo");

                Dictionary.Add("kiwen-mani-walo", KiwenManiWalo);
                Glosses.Add("kiwen-mani-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-pi-kule-ala", new[] { "glass" });
                    glossMap.Add("en", en);
                }
                KiwenPiKuleAla = new CompoundWord("kiwen-pi-kule-ala");

                Dictionary.Add("kiwen-pi-kule-ala", KiwenPiKuleAla);
                Glosses.Add("kiwen-pi-kule-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-pi-telo-mama", new[] { "cheese" });
                    glossMap.Add("en", en);
                }
                KiwenPiTeloMama = new CompoundWord("kiwen-pi-telo-mama");

                Dictionary.Add("kiwen-pi-telo-mama", KiwenPiTeloMama);
                Glosses.Add("kiwen-pi-telo-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-pimeja", new[] { "iron" });
                    glossMap.Add("en", en);
                }
                KiwenPimeja = new CompoundWord("kiwen-pimeja");

                Dictionary.Add("kiwen-pimeja", KiwenPimeja);
                Glosses.Add("kiwen-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-telo", new[] { "mud" });
                    glossMap.Add("en", en);
                }
                KiwenTelo = new CompoundWord("kiwen-telo");

                Dictionary.Add("kiwen-telo", KiwenTelo);
                Glosses.Add("kiwen-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-kasi", new[] { "pitch" });
                    glossMap.Add("en", en);
                }
                KoKasi = new CompoundWord("ko-kasi");

                Dictionary.Add("ko-kasi", KoKasi);
                Glosses.Add("ko-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-lete", new[] { "snow" });
                    glossMap.Add("en", en);
                }
                KoLete = new CompoundWord("ko-lete");

                Dictionary.Add("ko-lete", KoLete);
                Glosses.Add("ko-lete", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-moku-pi-telo-mama", new[] { "cheese" });
                    glossMap.Add("en", en);
                }
                KoMokuPiTeloMama = new CompoundWord("ko-moku-pi-telo-mama");

                Dictionary.Add("ko-moku-pi-telo-mama", KoMokuPiTeloMama);
                Glosses.Add("ko-moku-pi-telo-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-pi-telo-mama", new[] { "cheese" });
                    glossMap.Add("en", en);
                }
                KoPiTeloMama = new CompoundWord("ko-pi-telo-mama");

                Dictionary.Add("ko-pi-telo-mama", KoPiTeloMama);
                Glosses.Add("ko-pi-telo-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-seli", new[] { "plasma (state of matter)" });
                    glossMap.Add("en", en);
                }
                KoSeli = new CompoundWord("ko-seli");

                Dictionary.Add("ko-seli", KoSeli);
                Glosses.Add("ko-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-soweli", new[] { "animal fat" });
                    glossMap.Add("en", en);
                }
                KoSoweli = new CompoundWord("ko-soweli");

                Dictionary.Add("ko-soweli", KoSoweli);
                Glosses.Add("ko-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-suno-linja", new[] { "light rays" });
                    glossMap.Add("en", en);
                }
                KoSunoLinja = new CompoundWord("ko-suno-linja");

                Dictionary.Add("ko-suno-linja", KoSunoLinja);
                Glosses.Add("ko-suno-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-suwi", new[] { "honey" });
                    glossMap.Add("en", en);
                }
                KoSuwi = new CompoundWord("ko-suwi");

                Dictionary.Add("ko-suwi", KoSuwi);
                Glosses.Add("ko-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-telo-pi-telo-mama", new[] { "yogurt" });
                    glossMap.Add("en", en);
                }
                KoTeloPiTeloMama = new CompoundWord("ko-telo-pi-telo-mama");

                Dictionary.Add("ko-telo-pi-telo-mama", KoTeloPiTeloMama);
                Glosses.Add("ko-telo-pi-telo-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-walo-wawa", new[] { "cocaine" });
                    glossMap.Add("en", en);
                }
                KoWaloWawa = new CompoundWord("ko-walo-wawa");

                Dictionary.Add("ko-walo-wawa", KoWaloWawa);
                Glosses.Add("ko-walo-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-wawa", new[] { "cocaine" });
                    glossMap.Add("en", en);
                }
                KoWawa = new CompoundWord("ko-wawa");

                Dictionary.Add("ko-wawa", KoWawa);
                Glosses.Add("ko-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-en-sewi", new[] { "weather" });
                    glossMap.Add("en", en);
                }
                KonEnSewi = new CompoundWord("kon-en-sewi");

                Dictionary.Add("kon-en-sewi", KonEnSewi);
                Glosses.Add("kon-en-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-pi-pilin-pona", new[] { "laughter" });
                    glossMap.Add("en", en);
                }
                KonPiPilinPona = new CompoundWord("kon-pi-pilin-pona");

                Dictionary.Add("kon-pi-pilin-pona", KonPiPilinPona);
                Glosses.Add("kon-pi-pilin-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-seli", new[] { "smoke" });
                    glossMap.Add("en", en);
                }
                KonSeli = new CompoundWord("kon-seli");

                Dictionary.Add("kon-seli", KonSeli);
                Glosses.Add("kon-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-sewi", new[] { "Heaven" });
                    glossMap.Add("en", en);
                }
                KonSewi = new CompoundWord("kon-sewi");

                Dictionary.Add("kon-sewi", KonSewi);
                Glosses.Add("kon-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-tawa", new[] { "wind" });
                    glossMap.Add("en", en);
                }
                KonTawa = new CompoundWord("kon-tawa");

                Dictionary.Add("kon-tawa", KonTawa);
                Glosses.Add("kon-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-telo", new[] { "rain" });
                    glossMap.Add("en", en);
                }
                KonTelo = new CompoundWord("kon-telo");

                Dictionary.Add("kon-telo", KonTelo);
                Glosses.Add("kon-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-telo-walo", new[] { "snow", " fog" });
                    glossMap.Add("en", en);
                }
                KonTeloWalo = new CompoundWord("kon-telo-walo");

                Dictionary.Add("kon-telo-walo", KonTeloWalo);
                Glosses.Add("kon-telo-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-wawa", new[] { "soul", " spirit" });
                    glossMap.Add("en", en);
                }
                KonWawa = new CompoundWord("kon-wawa");

                Dictionary.Add("kon-wawa", KonWawa);
                Glosses.Add("kon-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-kon", new[] { "airplane" });
                    glossMap.Add("en", en);
                }
                TomoTawaKon = new CompoundWord("tomo-tawa-kon");

                Dictionary.Add("tomo-tawa-kon", TomoTawaKon);
                Glosses.Add("tomo-tawa-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-ala", new[] { "transparent" });
                    glossMap.Add("en", en);
                }
                KuleAla = new CompoundWord("kule-ala");

                Dictionary.Add("kule-ala", KuleAla);
                Glosses.Add("kule-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-ala-walo-ala", new[] { "transparent" });
                    glossMap.Add("en", en);
                }
                KuleAlaWaloAla = new CompoundWord("kule-ala-walo-ala");

                Dictionary.Add("kule-ala-walo-ala", KuleAlaWaloAla);
                Glosses.Add("kule-ala-walo-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-jaki", new[] { "brown" });
                    glossMap.Add("en", en);
                }
                KuleJaki = new CompoundWord("kule-jaki");

                Dictionary.Add("kule-jaki", KuleJaki);
                Glosses.Add("kule-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-lon-palisa-luka", new[] { "nail polish" });
                    glossMap.Add("en", en);
                }
                KuleLonPalisaLuka = new CompoundWord("kule-lon-palisa-luka");

                Dictionary.Add("kule-lon-palisa-luka", KuleLonPalisaLuka);
                Glosses.Add("kule-lon-palisa-luka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-moku", new[] { "taste" });
                    glossMap.Add("en", en);
                }
                KuleMoku = new CompoundWord("kule-moku");

                Dictionary.Add("kule-moku", KuleMoku);
                Glosses.Add("kule-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-pi-telo-wawa", new[] { "brown" });
                    glossMap.Add("en", en);
                }
                KulePiTeloWawa = new CompoundWord("kule-pi-telo-wawa");

                Dictionary.Add("kule-pi-telo-wawa", KulePiTeloWawa);
                Glosses.Add("kule-pi-telo-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-sewi", new[] { "rainbow" });
                    glossMap.Add("en", en);
                }
                KuleSewi = new CompoundWord("kule-sewi");

                Dictionary.Add("kule-sewi", KuleSewi);
                Glosses.Add("kule-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-jan", new[] { "race", " team", " society" });
                    glossMap.Add("en", en);
                }
                KulupuJan = new CompoundWord("kulupu-jan");

                Dictionary.Add("kulupu-jan", KulupuJan);
                Glosses.Add("kulupu-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-kasi", new[] { "clubs" });
                    glossMap.Add("en", en);
                }
                KulupuKasi = new CompoundWord("kulupu-kasi");

                Dictionary.Add("kulupu-kasi", KulupuKasi);
                Glosses.Add("kulupu-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-kiwen", new[] { "diamonds" });
                    glossMap.Add("en", en);
                }
                KulupuKiwen = new CompoundWord("kulupu-kiwen");

                Dictionary.Add("kulupu-kiwen", KulupuKiwen);
                Glosses.Add("kulupu-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-lawa", new[] { "government", " governement" });
                    glossMap.Add("en", en);
                }
                KulupuLawa = new CompoundWord("kulupu-lawa");

                Dictionary.Add("kulupu-lawa", KulupuLawa);
                Glosses.Add("kulupu-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-lili", new[] { "subgroup", " branch" });
                    glossMap.Add("en", en);
                }
                KulupuLili = new CompoundWord("kulupu-lili");

                Dictionary.Add("kulupu-lili", KulupuLili);
                Glosses.Add("kulupu-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-lipu", new[] { "catregory", " class", " type", " division", " file (computer)", " text file of seveal pages" });
                    glossMap.Add("en", en);
                }
                KulupuLipu = new CompoundWord("kulupu-lipu");

                Dictionary.Add("kulupu-lipu", KulupuLipu);
                Glosses.Add("kulupu-lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-mama", new[] { "family", " humanity" });
                    glossMap.Add("en", en);
                }
                KulupuMama = new CompoundWord("kulupu-mama");

                Dictionary.Add("kulupu-mama", KulupuMama);
                Glosses.Add("kulupu-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-mani", new[] { "diamonds", " company", " corporation" });
                    glossMap.Add("en", en);
                }
                KulupuMani = new CompoundWord("kulupu-mani");

                Dictionary.Add("kulupu-mani", KulupuMani);
                Glosses.Add("kulupu-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-musi", new[] { "circus" });
                    glossMap.Add("en", en);
                }
                KulupuMusi = new CompoundWord("kulupu-musi");

                Dictionary.Add("kulupu-musi", KulupuMusi);
                Glosses.Add("kulupu-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-nimi", new[] { "phrase", " clause", " sentence", " expression" });
                    glossMap.Add("en", en);
                }
                KulupuNimi = new CompoundWord("kulupu-nimi");

                Dictionary.Add("kulupu-nimi", KulupuNimi);
                Glosses.Add("kulupu-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-nimi-ala", new[] { "negative phrase" });
                    glossMap.Add("en", en);
                }
                KulupuNimiAla = new CompoundWord("kulupu-nimi-ala");

                Dictionary.Add("kulupu-nimi-ala", KulupuNimiAla);
                Glosses.Add("kulupu-nimi-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-nimi-ante", new[] { "condition phrase, la-phrase" });
                    glossMap.Add("en", en);
                }
                KulupuNimiAnte = new CompoundWord("kulupu-nimi-ante");

                Dictionary.Add("kulupu-nimi-ante", KulupuNimiAnte);
                Glosses.Add("kulupu-nimi-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-nimi-ijo", new[] { "noun phrase" });
                    glossMap.Add("en", en);
                }
                KulupuNimiIjo = new CompoundWord("kulupu-nimi-ijo");

                Dictionary.Add("kulupu-nimi-ijo", KulupuNimiIjo);
                Glosses.Add("kulupu-nimi-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-nimi-pali", new[] { "verb phrase" });
                    glossMap.Add("en", en);
                }
                KulupuNimiPali = new CompoundWord("kulupu-nimi-pali");

                Dictionary.Add("kulupu-nimi-pali", KulupuNimiPali);
                Glosses.Add("kulupu-nimi-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-nimi-pi-kama-jo", new[] { "grocery (etc.) list", " shopping list" });
                    glossMap.Add("en", en);
                }
                KulupuNimiPiKamaJo = new CompoundWord("kulupu-nimi-pi-kama-jo");

                Dictionary.Add("kulupu-nimi-pi-kama-jo", KulupuNimiPiKamaJo);
                Glosses.Add("kulupu-nimi-pi-kama-jo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-nimi-pini", new[] { "sentence" });
                    glossMap.Add("en", en);
                }
                KulupuNimiPini = new CompoundWord("kulupu-nimi-pini");

                Dictionary.Add("kulupu-nimi-pini", KulupuNimiPini);
                Glosses.Add("kulupu-nimi-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-nimi-seme", new[] { "interrogative phrase", " question" });
                    glossMap.Add("en", en);
                }
                KulupuNimiSeme = new CompoundWord("kulupu-nimi-seme");

                Dictionary.Add("kulupu-nimi-seme", KulupuNimiSeme);
                Glosses.Add("kulupu-nimi-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-olin", new[] { "hearts" });
                    glossMap.Add("en", en);
                }
                KulupuOlin = new CompoundWord("kulupu-olin");

                Dictionary.Add("kulupu-olin", KulupuOlin);
                Glosses.Add("kulupu-olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-pi-lipu-sona", new[] { "web site (collection of pages)" });
                    glossMap.Add("en", en);
                }
                KulupuPiLipuSona = new CompoundWord("kulupu-pi-lipu-sona");

                Dictionary.Add("kulupu-pi-lipu-sona", KulupuPiLipuSona);
                Glosses.Add("kulupu-pi-lipu-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-pi-pali-toki", new[] { "language creaation society" });
                    glossMap.Add("en", en);
                }
                KulupuPiPaliToki = new CompoundWord("kulupu-pi-pali-toki");

                Dictionary.Add("kulupu-pi-pali-toki", KulupuPiPaliToki);
                Glosses.Add("kulupu-pi-pali-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-pi-pona-sijelo", new[] { "group of doctors (health professionals)" });
                    glossMap.Add("en", en);
                }
                KulupuPiPonaSijelo = new CompoundWord("kulupu-pi-pona-sijelo");

                Dictionary.Add("kulupu-pi-pona-sijelo", KulupuPiPonaSijelo);
                Glosses.Add("kulupu-pi-pona-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-sike", new[] { "circus" });
                    glossMap.Add("en", en);
                }
                KulupuSike = new CompoundWord("kulupu-sike");

                Dictionary.Add("kulupu-sike", KulupuSike);
                Glosses.Add("kulupu-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-sitelen", new[] { "alphabet (writing system)" });
                    glossMap.Add("en", en);
                }
                KulupuSitelen = new CompoundWord("kulupu-sitelen");

                Dictionary.Add("kulupu-sitelen", KulupuSitelen);
                Glosses.Add("kulupu-sitelen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-toki", new[] { "forum" });
                    glossMap.Add("en", en);
                }
                KulupuToki = new CompoundWord("kulupu-toki");

                Dictionary.Add("kulupu-toki", KulupuToki);
                Glosses.Add("kulupu-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-toki-Jaju", new[] { "list group Yahoo" });
                    glossMap.Add("en", en);
                }
                KulupuTokiJaju = new CompoundWord("kulupu-toki-Jaju");

                Dictionary.Add("kulupu-toki-Jaju", KulupuTokiJaju);
                Glosses.Add("kulupu-toki-Jaju", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-utala", new[] { "military", " army", " spades", " nelanties" });
                    glossMap.Add("en", en);
                }
                KulupuUtala = new CompoundWord("kulupu-utala");

                Dictionary.Add("kulupu-utala", KulupuUtala);
                Glosses.Add("kulupu-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-kute", new[] { "ear" });
                    glossMap.Add("en", en);
                }
                LupaKute = new CompoundWord("lupa-kute");

                Dictionary.Add("lupa-kute", LupaKute);
                Glosses.Add("lupa-kute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kute-sona", new[] { "understand (when hearing)" });
                    glossMap.Add("en", en);
                }
                KuteSona = new CompoundWord("kute-sona");

                Dictionary.Add("kute-sona", KuteSona);
                Glosses.Add("kute-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kute-tawa", new[] { "listen to" });
                    glossMap.Add("en", en);
                }
                KuteTawa = new CompoundWord("kute-tawa");

                Dictionary.Add("kute-tawa", KuteTawa);
                Glosses.Add("kute-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lape-pona", new[] { "Sleep well!" });
                    glossMap.Add("en", en);
                }
                LapePona = new CompoundWord("lape-pona");

                Dictionary.Add("lape-pona", LapePona);
                Glosses.Add("lape-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("supa-lape", new[] { "bed" });
                    glossMap.Add("en", en);
                }
                SupaLape = new CompoundWord("supa-lape");

                Dictionary.Add("supa-lape", SupaLape);
                Glosses.Add("supa-lape", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wile-lape", new[] { "tired", " sleepy" });
                    glossMap.Add("en", en);
                }
                WileLape = new CompoundWord("wile-lape");

                Dictionary.Add("wile-lape", WileLape);
                Glosses.Add("wile-lape", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("laso-jelo", new[] { "green" });
                    glossMap.Add("en", en);
                }
                LasoJelo = new CompoundWord("laso-jelo");

                Dictionary.Add("laso-jelo", LasoJelo);
                Glosses.Add("laso-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("laso-loje", new[] { "purple" });
                    glossMap.Add("en", en);
                }
                LasoLoje = new CompoundWord("laso-loje");

                Dictionary.Add("laso-loje", LasoLoje);
                Glosses.Add("laso-loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("laso-pimeja", new[] { "dark blue" });
                    glossMap.Add("en", en);
                }
                LasoPimeja = new CompoundWord("laso-pimeja");

                Dictionary.Add("laso-pimeja", LasoPimeja);
                Glosses.Add("laso-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("loje-laso", new[] { "(dark) blueish red", " purple" });
                    glossMap.Add("en", en);
                }
                LojeLaso = new CompoundWord("loje-laso");

                Dictionary.Add("loje-laso", LojeLaso);
                Glosses.Add("loje-laso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("loje-laso-pimeja", new[] { "(dark) blueish red", " purple" });
                    glossMap.Add("en", en);
                }
                LojeLasoPimeja = new CompoundWord("loje-laso-pimeja");

                Dictionary.Add("loje-laso-pimeja", LojeLasoPimeja);
                Glosses.Add("loje-laso-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pimeja-laso", new[] { "bluish black" });
                    glossMap.Add("en", en);
                }
                PimejaLaso = new CompoundWord("pimeja-laso");

                Dictionary.Add("pimeja-laso", PimejaLaso);
                Glosses.Add("pimeja-laso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lawa-lukin", new[] { "expression", " mien", " look" });
                    glossMap.Add("en", en);
                }
                LawaLukin = new CompoundWord("lawa-lukin");

                Dictionary.Add("lawa-lukin", LawaLukin);
                Glosses.Add("lawa-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lawa-ma", new[] { "government", " govern" });
                    glossMap.Add("en", en);
                }
                LawaMa = new CompoundWord("lawa-ma");

                Dictionary.Add("lawa-ma", LawaMa);
                Glosses.Add("lawa-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lawa-sewi", new[] { "haunting", " magical", " hallucinatory" });
                    glossMap.Add("en", en);
                }
                LawaSewi = new CompoundWord("lawa-sewi");

                Dictionary.Add("lawa-sewi", LawaSewi);
                Glosses.Add("lawa-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-lawa", new[] { "hat", " cap", " hood", " mask", " veil" });
                    glossMap.Add("en", en);
                }
                LenLawa = new CompoundWord("len-lawa");

                Dictionary.Add("len-lawa", LenLawa);
                Glosses.Add("len-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-lawa", new[] { "commandment", " command", " order", " bar (lawyer)" });
                    glossMap.Add("en", en);
                }
                TokiLawa = new CompoundWord("toki-lawa");

                Dictionary.Add("toki-lawa", TokiLawa);
                Glosses.Add("toki-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-anpa", new[] { "trousers", " underwear" });
                    glossMap.Add("en", en);
                }
                LenAnpa = new CompoundWord("len-anpa");

                Dictionary.Add("len-anpa", LenAnpa);
                Glosses.Add("len-anpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-lipu", new[] { "flag" });
                    glossMap.Add("en", en);
                }
                LenLipu = new CompoundWord("len-lipu");

                Dictionary.Add("len-lipu", LenLipu);
                Glosses.Add("len-lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-luka", new[] { "gloves", " mittens" });
                    glossMap.Add("en", en);
                }
                LenLuka = new CompoundWord("len-luka");

                Dictionary.Add("len-luka", LenLuka);
                Glosses.Add("len-luka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-lupa", new[] { "curtains", " screen" });
                    glossMap.Add("en", en);
                }
                LenLupa = new CompoundWord("len-lupa");

                Dictionary.Add("len-lupa", LenLupa);
                Glosses.Add("len-lupa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-noka", new[] { "shoes", " socks", " pants" });
                    glossMap.Add("en", en);
                }
                LenNoka = new CompoundWord("len-noka");

                Dictionary.Add("len-noka", LenNoka);
                Glosses.Add("len-noka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-noka-palisa", new[] { "trousers" });
                    glossMap.Add("en", en);
                }
                LenNokaPalisa = new CompoundWord("len-noka-palisa");

                Dictionary.Add("len-noka-palisa", LenNokaPalisa);
                Glosses.Add("len-noka-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-sinpin", new[] { "jacket" });
                    glossMap.Add("en", en);
                }
                LenSinpin = new CompoundWord("len-sinpin");

                Dictionary.Add("len-sinpin", LenSinpin);
                Glosses.Add("len-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lete-lili", new[] { "cool" });
                    glossMap.Add("en", en);
                }
                LeteLili = new CompoundWord("lete-lili");

                Dictionary.Add("lete-lili", LeteLili);
                Glosses.Add("lete-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poki-lete", new[] { "refrigerator" });
                    glossMap.Add("en", en);
                }
                PokiLete = new CompoundWord("poki-lete");

                Dictionary.Add("poki-lete", PokiLete);
                Glosses.Add("poki-lete", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-lete", new[] { "winter", " the cool of the day", " Winter" });
                    glossMap.Add("en", en);
                }
                TenpoLete = new CompoundWord("tenpo-lete");

                Dictionary.Add("tenpo-lete", TenpoLete);
                Glosses.Add("tenpo-lete", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lili-ala", new[] { "old", " not young" });
                    glossMap.Add("en", en);
                }
                LiliAla = new CompoundWord("lili-ala");

                Dictionary.Add("lili-ala", LiliAla);
                Glosses.Add("lili-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lili-mute", new[] { "very few" });
                    glossMap.Add("en", en);
                }
                LiliMute = new CompoundWord("lili-mute");

                Dictionary.Add("lili-mute", LiliMute);
                Glosses.Add("lili-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lili-taso", new[] { "only a little" });
                    glossMap.Add("en", en);
                }
                LiliTaso = new CompoundWord("lili-taso");

                Dictionary.Add("lili-taso", LiliTaso);
                Glosses.Add("lili-taso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-lili-oko", new[] { "eyebrows", " eyelashes" });
                    glossMap.Add("en", en);
                }
                LinjaLiliOko = new CompoundWord("linja-lili-oko");

                Dictionary.Add("linja-lili-oko", LinjaLiliOko);
                Glosses.Add("linja-lili-oko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-lili-pi-insa-lawa", new[] { "nerve cell" });
                    glossMap.Add("en", en);
                }
                LinjaLiliPiInsaLawa = new CompoundWord("linja-lili-pi-insa-lawa");

                Dictionary.Add("linja-lili-pi-insa-lawa", LinjaLiliPiInsaLawa);
                Glosses.Add("linja-lili-pi-insa-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili", new[] { "state", " province", " county", " departement", "…" });
                    glossMap.Add("en", en);
                }
                MaLili = new CompoundWord("ma-lili");

                Dictionary.Add("ma-lili", MaLili);
                Glosses.Add("ma-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-lili", new[] { "daughter", " girl" });
                    glossMap.Add("en", en);
                }
                MeliLili = new CompoundWord("meli-lili");

                Dictionary.Add("meli-lili", MeliLili);
                Glosses.Add("meli-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mije-lili", new[] { "son", " boy" });
                    glossMap.Add("en", en);
                }
                MijeLili = new CompoundWord("mije-lili");

                Dictionary.Add("mije-lili", MijeLili);
                Glosses.Add("mije-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-lili", new[] { "pill" });
                    glossMap.Add("en", en);
                }
                MokuLili = new CompoundWord("moku-lili");

                Dictionary.Add("moku-lili", MokuLili);
                Glosses.Add("moku-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-lili-pi-pilin-pona-mute", new[] { "strong euphoric drug taken orally" });
                    glossMap.Add("en", en);
                }
                MokuLiliPiPilinPonaMute = new CompoundWord("moku-lili-pi-pilin-pona-mute");

                Dictionary.Add("moku-lili-pi-pilin-pona-mute", MokuLiliPiPilinPonaMute);
                Glosses.Add("moku-lili-pi-pilin-pona-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mute-lili", new[] { "some", " few", " not a lot", " some (a small number)", " a few", " a small number" });
                    glossMap.Add("en", en);
                }
                MuteLili = new CompoundWord("mute-lili");

                Dictionary.Add("mute-lili", MuteLili);
                Glosses.Add("mute-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-lili-meli", new[] { "clitoris" });
                    glossMap.Add("en", en);
                }
                NenaLiliMeli = new CompoundWord("nena-lili-meli");

                Dictionary.Add("nena-lili-meli", NenaLiliMeli);
                Glosses.Add("nena-lili-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-lili-unpa-meli", new[] { "clitoris" });
                    glossMap.Add("en", en);
                }
                NenaLiliUnpaMeli = new CompoundWord("nena-lili-unpa-meli");

                Dictionary.Add("nena-lili-unpa-meli", NenaLiliUnpaMeli);
                Glosses.Add("nena-lili-unpa-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-lili-pi-nena-mama", new[] { "nipples" });
                    glossMap.Add("en", en);
                }
                NenaLiliPiNenaMama = new CompoundWord("nena-lili-pi-nena-mama");

                Dictionary.Add("nena-lili-pi-nena-mama", NenaLiliPiNenaMama);
                Glosses.Add("nena-lili-pi-nena-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-lili-noka", new[] { "toes" });
                    glossMap.Add("en", en);
                }
                PalisaLiliNoka = new CompoundWord("palisa-lili-noka");

                Dictionary.Add("palisa-lili-noka", PalisaLiliNoka);
                Glosses.Add("palisa-lili-noka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-lili", new[] { "soon", " moment", " briefly", " hour" });
                    glossMap.Add("en", en);
                }
                TenpoLili = new CompoundWord("tenpo-lili");

                Dictionary.Add("tenpo-lili", TenpoLili);
                Glosses.Add("tenpo-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-awen", new[] { "length" });
                    glossMap.Add("en", en);
                }
                LinjaAwen = new CompoundWord("linja-awen");

                Dictionary.Add("linja-awen", LinjaAwen);
                Glosses.Add("linja-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-lawa", new[] { "hair" });
                    glossMap.Add("en", en);
                }
                LinjaLawa = new CompoundWord("linja-lawa");

                Dictionary.Add("linja-lawa", LinjaLawa);
                Glosses.Add("linja-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-luka", new[] { "width" });
                    glossMap.Add("en", en);
                }
                LinjaLuka = new CompoundWord("linja-luka");

                Dictionary.Add("linja-luka", LinjaLuka);
                Glosses.Add("linja-luka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-sewi", new[] { "heigth" });
                    glossMap.Add("en", en);
                }
                LinjaSewi = new CompoundWord("linja-sewi");

                Dictionary.Add("linja-sewi", LinjaSewi);
                Glosses.Add("linja-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-sinpin", new[] { "beard", " facial hair" });
                    glossMap.Add("en", en);
                }
                LinjaSinpin = new CompoundWord("linja-sinpin");

                Dictionary.Add("linja-sinpin", LinjaSinpin);
                Glosses.Add("linja-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-toki", new[] { "sentence" });
                    glossMap.Add("en", en);
                }
                LinjaToki = new CompoundWord("linja-toki");

                Dictionary.Add("linja-toki", LinjaToki);
                Glosses.Add("linja-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-uta", new[] { "whiskers", " moustache" });
                    glossMap.Add("en", en);
                }
                LinjaUta = new CompoundWord("linja-uta");

                Dictionary.Add("linja-uta", LinjaUta);
                Glosses.Add("linja-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-telo-linja", new[] { "river bank" });
                    glossMap.Add("en", en);
                }
                PokaTeloLinja = new CompoundWord("poka-telo-linja");

                Dictionary.Add("poka-telo-linja", PokaTeloLinja);
                Glosses.Add("poka-telo-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-nena-linja", new[] { "elephant" });
                    glossMap.Add("en", en);
                }
                SoweliPiNenaLinja = new CompoundWord("soweli-pi-nena-linja");

                Dictionary.Add("soweli-pi-nena-linja", SoweliPiNenaLinja);
                Glosses.Add("soweli-pi-nena-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-linja", new[] { "river", " stream" });
                    glossMap.Add("en", en);
                }
                TeloLinja = new CompoundWord("telo-linja");

                Dictionary.Add("telo-linja", TeloLinja);
                Glosses.Add("telo-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-awen", new[] { "lesson", " text" });
                    glossMap.Add("en", en);
                }
                LipuAwen = new CompoundWord("lipu-awen");

                Dictionary.Add("lipu-awen", LipuAwen);
                Glosses.Add("lipu-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-ijo", new[] { "mirror" });
                    glossMap.Add("en", en);
                }
                LipuIjo = new CompoundWord("lipu-ijo");

                Dictionary.Add("lipu-ijo", LipuIjo);
                Glosses.Add("lipu-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-ilo-toki-poki", new[] { "e-mail", " email" });
                    glossMap.Add("en", en);
                }
                LipuIloTokiPoki = new CompoundWord("lipu-ilo-toki-poki");

                Dictionary.Add("lipu-ilo-toki-poki", LipuIloTokiPoki);
                Glosses.Add("lipu-ilo-toki-poki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-kasi", new[] { "leaf (of tree)" });
                    glossMap.Add("en", en);
                }
                LipuKasi = new CompoundWord("lipu-kasi");

                Dictionary.Add("lipu-kasi", LipuKasi);
                Glosses.Add("lipu-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-kili", new[] { "leaf" });
                    glossMap.Add("en", en);
                }
                LipuKili = new CompoundWord("lipu-kili");

                Dictionary.Add("lipu-kili", LipuKili);
                Glosses.Add("lipu-kili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-kiwen-pi-telo-mama", new[] { "cheese slice" });
                    glossMap.Add("en", en);
                }
                LipuKiwenPiTeloMama = new CompoundWord("lipu-kiwen-pi-telo-mama");

                Dictionary.Add("lipu-kiwen-pi-telo-mama", LipuKiwenPiTeloMama);
                Glosses.Add("lipu-kiwen-pi-telo-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-lawa", new[] { "trumps" });
                    glossMap.Add("en", en);
                }
                LipuLawa = new CompoundWord("lipu-lawa");

                Dictionary.Add("lipu-lawa", LipuLawa);
                Glosses.Add("lipu-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-mani", new[] { "(bank) check" });
                    glossMap.Add("en", en);
                }
                LipuMani = new CompoundWord("lipu-mani");

                Dictionary.Add("lipu-mani", LipuMani);
                Glosses.Add("lipu-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-musi", new[] { "cards" });
                    glossMap.Add("en", en);
                }
                LipuMusi = new CompoundWord("lipu-musi");

                Dictionary.Add("lipu-musi", LipuMusi);
                Glosses.Add("lipu-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-musi-mani", new[] { "poker (other gambling games)" });
                    glossMap.Add("en", en);
                }
                LipuMusiMani = new CompoundWord("lipu-musi-mani");

                Dictionary.Add("lipu-musi-mani", LipuMusiMani);
                Glosses.Add("lipu-musi-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-musi-nasa", new[] { "card tricks", " cartomagy" });
                    glossMap.Add("en", en);
                }
                LipuMusiNasa = new CompoundWord("lipu-musi-nasa");

                Dictionary.Add("lipu-musi-nasa", LipuMusiNasa);
                Glosses.Add("lipu-musi-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-musi-pona", new[] { "play cards in the family" });
                    glossMap.Add("en", en);
                }
                LipuMusiPona = new CompoundWord("lipu-musi-pona");

                Dictionary.Add("lipu-musi-pona", LipuMusiPona);
                Glosses.Add("lipu-musi-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-mute", new[] { "book" });
                    glossMap.Add("en", en);
                }
                LipuMute = new CompoundWord("lipu-mute");

                Dictionary.Add("lipu-mute", LipuMute);
                Glosses.Add("lipu-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-nasin", new[] { "web page", " instructional diagram" });
                    glossMap.Add("en", en);
                }
                LipuNasin = new CompoundWord("lipu-nasin");

                Dictionary.Add("lipu-nasin", LipuNasin);
                Glosses.Add("lipu-nasin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-Open", new[] { "Genesis" });
                    glossMap.Add("en", en);
                }
                LipuOpen = new CompoundWord("lipu-Open");

                Dictionary.Add("lipu-Open", LipuOpen);
                Glosses.Add("lipu-Open", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pali", new[] { "homework", " test", " workbooks homework", " web site", " home work", " work sheets" });
                    glossMap.Add("en", en);
                }
                LipuPali = new CompoundWord("lipu-pali");

                Dictionary.Add("lipu-pali", LipuPali);
                Glosses.Add("lipu-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-jan-lawa", new[] { "king" });
                    glossMap.Add("en", en);
                }
                LipuPiJanLawa = new CompoundWord("lipu-pi-jan-lawa");

                Dictionary.Add("lipu-pi-jan-lawa", LipuPiJanLawa);
                Glosses.Add("lipu-pi-jan-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-jan-meli", new[] { "queen" });
                    glossMap.Add("en", en);
                }
                LipuPiJanMeli = new CompoundWord("lipu-pi-jan-meli");

                Dictionary.Add("lipu-pi-jan-meli", LipuPiJanMeli);
                Glosses.Add("lipu-pi-jan-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-jan-pali", new[] { "jack" });
                    glossMap.Add("en", en);
                }
                LipuPiJanPali = new CompoundWord("lipu-pi-jan-pali");

                Dictionary.Add("lipu-pi-jan-pali", LipuPiJanPali);
                Glosses.Add("lipu-pi-jan-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-lawa-meli", new[] { "queen" });
                    glossMap.Add("en", en);
                }
                LipuPiLawaMeli = new CompoundWord("lipu-pi-lawa-meli");

                Dictionary.Add("lipu-pi-lawa-meli", LipuPiLawaMeli);
                Glosses.Add("lipu-pi-lawa-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-mani-musi", new[] { "poker" });
                    glossMap.Add("en", en);
                }
                LipuPiManiMusi = new CompoundWord("lipu-pi-mani-musi");

                Dictionary.Add("lipu-pi-mani-musi", LipuPiManiMusi);
                Glosses.Add("lipu-pi-mani-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-nasa-musi", new[] { "card tricks" });
                    glossMap.Add("en", en);
                }
                LipuPiNasaMusi = new CompoundWord("lipu-pi-nasa-musi");

                Dictionary.Add("lipu-pi-nasa-musi", LipuPiNasaMusi);
                Glosses.Add("lipu-pi-nasa-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-sitelen-lon", new[] { "mirror" });
                    glossMap.Add("en", en);
                }
                LipuPiSitelenLon = new CompoundWord("lipu-pi-sitelen-lon");

                Dictionary.Add("lipu-pi-sitelen-lon", LipuPiSitelenLon);
                Glosses.Add("lipu-pi-sitelen-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-tawa-kon", new[] { "wing -- natural" });
                    glossMap.Add("en", en);
                }
                LipuPiTawaKon = new CompoundWord("lipu-pi-tawa-kon");

                Dictionary.Add("lipu-pi-tawa-kon", LipuPiTawaKon);
                Glosses.Add("lipu-pi-tawa-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-tenpo-suno", new[] { "diary web page" });
                    glossMap.Add("en", en);
                }
                LipuPiTenpoSuno = new CompoundWord("lipu-pi-tenpo-suno");

                Dictionary.Add("lipu-pi-tenpo-suno", LipuPiTenpoSuno);
                Glosses.Add("lipu-pi-tenpo-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-sewi", new[] { "holy book" });
                    glossMap.Add("en", en);
                }
                LipuSewi = new CompoundWord("lipu-sewi");

                Dictionary.Add("lipu-sewi", LipuSewi);
                Glosses.Add("lipu-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-sewi-Pipija", new[] { "Bible" });
                    glossMap.Add("en", en);
                }
                LipuSewiPipija = new CompoundWord("lipu-sewi-Pipija");

                Dictionary.Add("lipu-sewi-Pipija", LipuSewiPipija);
                Glosses.Add("lipu-sewi-Pipija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-sona", new[] { "encyclopedia", " lesson" });
                    glossMap.Add("en", en);
                }
                LipuSona = new CompoundWord("lipu-sona");

                Dictionary.Add("lipu-sona", LipuSona);
                Glosses.Add("lipu-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-toki", new[] { "book", " document" });
                    glossMap.Add("en", en);
                }
                LipuToki = new CompoundWord("lipu-toki");

                Dictionary.Add("lipu-toki", LipuToki);
                Glosses.Add("lipu-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-toki-sin", new[] { "translation" });
                    glossMap.Add("en", en);
                }
                LipuTokiSin = new CompoundWord("lipu-toki-sin");

                Dictionary.Add("lipu-toki-sin", LipuTokiSin);
                Glosses.Add("lipu-toki-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-Weka", new[] { "Exodus" });
                    glossMap.Add("en", en);
                }
                LipuWeka = new CompoundWord("lipu-Weka");

                Dictionary.Add("lipu-Weka", LipuWeka);
                Glosses.Add("lipu-Weka", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("loje-laso", new[] { "purple" });
            //        glossMap.Add("en", en);
            //    }
            //    LojeLaso = new CompoundWord("loje-laso");

            //    Dictionary.Add("loje-laso", LojeLaso);
            //    Glosses.Add("loje-laso", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("loje-walo", new[] { "light red", " pink" });
                    glossMap.Add("en", en);
                }
                LojeWalo = new CompoundWord("loje-walo");

                Dictionary.Add("loje-walo", LojeWalo);
                Glosses.Add("loje-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-loje-mun", new[] { "menses" });
                    glossMap.Add("en", en);
                }
                TeloLojeMun = new CompoundWord("telo-loje-mun");

                Dictionary.Add("telo-loje-mun", TeloLojeMun);
                Glosses.Add("telo-loje-mun", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-mun", new[] { "menses" });
                    glossMap.Add("en", en);
                }
                TeloMun = new CompoundWord("telo-mun");

                Dictionary.Add("telo-mun", TeloMun);
                Glosses.Add("telo-mun", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-loje", new[] { "blood" });
                    glossMap.Add("en", en);
                }
                TeloLoje = new CompoundWord("telo-loje");

                Dictionary.Add("telo-loje", TeloLoje);
                Glosses.Add("telo-loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-ala", new[] { "no", " false", " falsehood", " lie" });
                    glossMap.Add("en", en);
                }
                LonAla = new CompoundWord("lon-ala");

                Dictionary.Add("lon-ala", LonAla);
                Glosses.Add("lon-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-ali-ma", new[] { "all terrestrial life" });
                    glossMap.Add("en", en);
                }
                LonAliMa = new CompoundWord("lon-ali-ma");

                Dictionary.Add("lon-ali-ma", LonAliMa);
                Glosses.Add("lon-ali-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-anpa-mani", new[] { "under money:  ruled by it" });
                    glossMap.Add("en", en);
                }
                LonAnpaMani = new CompoundWord("lon-anpa-mani");

                Dictionary.Add("lon-anpa-mani", LonAnpaMani);
                Glosses.Add("lon-anpa-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-kulupu-sama", new[] { "kind of" });
                    glossMap.Add("en", en);
                }
                LonKulupuSama = new CompoundWord("lon-kulupu-sama");

                Dictionary.Add("lon-kulupu-sama", LonKulupuSama);
                Glosses.Add("lon-kulupu-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-luka-wan", new[] { "on the one hand" });
                    glossMap.Add("en", en);
                }
                LonLukaWan = new CompoundWord("lon-luka-wan");

                Dictionary.Add("lon-luka-wan", LonLukaWan);
                Glosses.Add("lon-luka-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-luka-ante", new[] { "on the other hand" });
                    glossMap.Add("en", en);
                }
                LonLukaAnte = new CompoundWord("lon-luka-ante");

                Dictionary.Add("lon-luka-ante", LonLukaAnte);
                Glosses.Add("lon-luka-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-monsi", new[] { "after (time)", " behind", " in back of" });
                    glossMap.Add("en", en);
                }
                LonMonsi = new CompoundWord("lon-monsi");

                Dictionary.Add("lon-monsi", LonMonsi);
                Glosses.Add("lon-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-ni", new[] { "Here" });
                    glossMap.Add("en", en);
                }
                LonNi = new CompoundWord("lon-ni");

                Dictionary.Add("lon-ni", LonNi);
                Glosses.Add("lon-ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-poka", new[] { "beside", " to the side of", " at…'s side" });
                    glossMap.Add("en", en);
                }
                LonPoka = new CompoundWord("lon-poka");

                Dictionary.Add("lon-poka", LonPoka);
                Glosses.Add("lon-poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-poka-pi-nanpa-tu", new[] { "to the right of", " on the right side of" });
                    glossMap.Add("en", en);
                }
                LonPokaPiNanpaTu = new CompoundWord("lon-poka-pi-nanpa-tu");

                Dictionary.Add("lon-poka-pi-nanpa-tu", LonPokaPiNanpaTu);
                Glosses.Add("lon-poka-pi-nanpa-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-poka-pi-nanpa-wan", new[] { "to the left of", " on the left side of" });
                    glossMap.Add("en", en);
                }
                LonPokaPiNanpaWan = new CompoundWord("lon-poka-pi-nanpa-wan");

                Dictionary.Add("lon-poka-pi-nanpa-wan", LonPokaPiNanpaWan);
                Glosses.Add("lon-poka-pi-nanpa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-poka-sinpin", new[] { "in front of" });
                    glossMap.Add("en", en);
                }
                LonPokaSinpin = new CompoundWord("lon-poka-sinpin");

                Dictionary.Add("lon-poka-sinpin", LonPokaSinpin);
                Glosses.Add("lon-poka-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-selo", new[] { "on the outside of" });
                    glossMap.Add("en", en);
                }
                LonSelo = new CompoundWord("lon-selo");

                Dictionary.Add("lon-selo", LonSelo);
                Glosses.Add("lon-selo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-sewi", new[] { "above", " over", " on top of" });
                    glossMap.Add("en", en);
                }
                LonSewi = new CompoundWord("lon-sewi");

                Dictionary.Add("lon-sewi", LonSewi);
                Glosses.Add("lon-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-sewi-mani", new[] { "above money" });
                    glossMap.Add("en", en);
                }
                LonSewiMani = new CompoundWord("lon-sewi-mani");

                Dictionary.Add("lon-sewi-mani", LonSewiMani);
                Glosses.Add("lon-sewi-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-sinpin", new[] { "before", " in front of" });
                    glossMap.Add("en", en);
                }
                LonSinpin = new CompoundWord("lon-sinpin");

                Dictionary.Add("lon-sinpin", LonSinpin);
                Glosses.Add("lon-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-tempo-kama-tan", new[] { "after" });
                    glossMap.Add("en", en);
                }
                LonTempoKamaTan = new CompoundWord("lon-tempo-kama-tan");

                Dictionary.Add("lon-tempo-kama-tan", LonTempoKamaTan);
                Glosses.Add("lon-tempo-kama-tan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-tenpo-pini-tan", new[] { "before" });
                    glossMap.Add("en", en);
                }
                LonTenpoPiniTan = new CompoundWord("lon-tenpo-pini-tan");

                Dictionary.Add("lon-tenpo-pini-tan", LonTenpoPiniTan);
                Glosses.Add("lon-tenpo-pini-tan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sina-lon-ma-seme", new[] { "Where (what country) are you from" });
                    glossMap.Add("en", en);
                }
                SinaLonMaSeme = new CompoundWord("sina-lon-ma-seme");

                Dictionary.Add("sina-lon-ma-seme", SinaLonMaSeme);
                Glosses.Add("sina-lon-ma-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-pi-nanpa-tu", new[] { "right  side" });
                    glossMap.Add("en", en);
                }
                LukaPiNanpaTu = new CompoundWord("luka-pi-nanpa-tu");

                Dictionary.Add("luka-pi-nanpa-tu", LukaPiNanpaTu);
                Glosses.Add("luka-pi-nanpa-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-pi-nanpa-wan", new[] { "left  side" });
                    glossMap.Add("en", en);
                }
                LukaPiNanpaWan = new CompoundWord("luka-pi-nanpa-wan");

                Dictionary.Add("luka-pi-nanpa-wan", LukaPiNanpaWan);
                Glosses.Add("luka-pi-nanpa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-linja", new[] { "cubit" });
                    glossMap.Add("en", en);
                }
                LukaLinja = new CompoundWord("luka-linja");

                Dictionary.Add("luka-linja", LukaLinja);
                Glosses.Add("luka-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-lipu", new[] { "wing (bird", " insect)", " (insect) wings" });
                    glossMap.Add("en", en);
                }
                LukaLipu = new CompoundWord("luka-lipu");

                Dictionary.Add("luka-lipu", LukaLipu);
                Glosses.Add("luka-lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-open", new[] { "right hand" });
                    glossMap.Add("en", en);
                }
                LukaOpen = new CompoundWord("luka-open");

                Dictionary.Add("luka-open", LukaOpen);
                Glosses.Add("luka-open", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-pi-luka-pi-luka-pi-nimi", new[] { "125 words" });
                    glossMap.Add("en", en);
                }
                LukaPiLukaPiLukaPiNimi = new CompoundWord("luka-pi-luka-pi-luka-pi-nimi");

                Dictionary.Add("luka-pi-luka-pi-luka-pi-nimi", LukaPiLukaPiLukaPiNimi);
                Glosses.Add("luka-pi-luka-pi-luka-pi-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-pini", new[] { "left hand" });
                    glossMap.Add("en", en);
                }
                LukaPini = new CompoundWord("luka-pini");

                Dictionary.Add("luka-pini", LukaPini);
                Glosses.Add("luka-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-tu-anu-lili", new[] { "seven or less" });
                    glossMap.Add("en", en);
                }
                LukaTuAnuLili = new CompoundWord("luka-tu-anu-lili");

                Dictionary.Add("luka-tu-anu-lili", LukaTuAnuLili);
                Glosses.Add("luka-tu-anu-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-wawa", new[] { "behind", " right hand" });
                    glossMap.Add("en", en);
                }
                LukaWawa = new CompoundWord("luka-wawa");

                Dictionary.Add("luka-wawa", LukaWawa);
                Glosses.Add("luka-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-wawa-ala", new[] { "in front", " left hand" });
                    glossMap.Add("en", en);
                }
                LukaWawaAla = new CompoundWord("luka-wawa-ala");

                Dictionary.Add("luka-wawa-ala", LukaWawaAla);
                Glosses.Add("luka-wawa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-luka", new[] { "fingers", " finger/ arm" });
                    glossMap.Add("en", en);
                }
                PalisaLuka = new CompoundWord("palisa-luka");

                Dictionary.Add("palisa-luka", PalisaLuka);
                Glosses.Add("palisa-luka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-pona", new[] { "see well" });
                    glossMap.Add("en", en);
                }
                LukinPona = new CompoundWord("lukin-pona");

                Dictionary.Add("lukin-pona", LukinPona);
                Glosses.Add("lukin-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-sama", new[] { "resemble", " look like" });
                    glossMap.Add("en", en);
                }
                LukinSama = new CompoundWord("lukin-sama");

                Dictionary.Add("lukin-sama", LukinSama);
                Glosses.Add("lukin-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-sona", new[] { "study", " test (of knowledge) exam", " see in your mind", " picture to yourself", " imagine" });
                    glossMap.Add("en", en);
                }
                LukinSona = new CompoundWord("lukin-sona");

                Dictionary.Add("lukin-sona", LukinSona);
                Glosses.Add("lukin-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-tawa", new[] { "look at" });
                    glossMap.Add("en", en);
                }
                LukinTawa = new CompoundWord("lukin-tawa");

                Dictionary.Add("lukin-tawa", LukinTawa);
                Glosses.Add("lukin-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-tu", new[] { "meet" });
                    glossMap.Add("en", en);
                }
                LukinTu = new CompoundWord("lukin-tu");

                Dictionary.Add("lukin-tu", LukinTu);
                Glosses.Add("lukin-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-wawa", new[] { "examine", " stare at" });
                    glossMap.Add("en", en);
                }
                LukinWawa = new CompoundWord("lukin-wawa");

                Dictionary.Add("lukin-wawa", LukinWawa);
                Glosses.Add("lukin-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasa-lukin", new[] { "funny-looking" });
                    glossMap.Add("en", en);
                }
                NasaLukin = new CompoundWord("nasa-lukin");

                Dictionary.Add("nasa-lukin", NasaLukin);
                Glosses.Add("nasa-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-lukin", new[] { "beautiful", " good looking", " pretty", " handsome" });
                    glossMap.Add("en", en);
                }
                PonaLukin = new CompoundWord("pona-lukin");

                Dictionary.Add("pona-lukin", PonaLukin);
                Glosses.Add("pona-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("suwi-lukin", new[] { "cute" });
                    glossMap.Add("en", en);
                }
                SuwiLukin = new CompoundWord("suwi-lukin");

                Dictionary.Add("suwi-lukin", SuwiLukin);
                Glosses.Add("suwi-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-lon", new[] { "gates of/to" });
                    glossMap.Add("en", en);
                }
                LupaLon = new CompoundWord("lupa-lon");

                Dictionary.Add("lupa-lon", LupaLon);
                Glosses.Add("lupa-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-meli", new[] { "vagina", " pussy" });
                    glossMap.Add("en", en);
                }
                LupaMeli = new CompoundWord("lupa-meli");

                Dictionary.Add("lupa-meli", LupaMeli);
                Glosses.Add("lupa-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-monsi", new[] { "anus" });
                    glossMap.Add("en", en);
                }
                LupaMonsi = new CompoundWord("lupa-monsi");

                Dictionary.Add("lupa-monsi", LupaMonsi);
                Glosses.Add("lupa-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-nena", new[] { "nostrils" });
                    glossMap.Add("en", en);
                }
                LupaNena = new CompoundWord("lupa-nena");

                Dictionary.Add("lupa-nena", LupaNena);
                Glosses.Add("lupa-nena", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-palisa-monsi", new[] { "tailpipe" });
                    glossMap.Add("en", en);
                }
                LupaPalisaMonsi = new CompoundWord("lupa-palisa-monsi");

                Dictionary.Add("lupa-palisa-monsi", LupaPalisaMonsi);
                Glosses.Add("lupa-palisa-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-pi-ko-jaki", new[] { "asshole" });
                    glossMap.Add("en", en);
                }
                LupaPiKoJaki = new CompoundWord("lupa-pi-ko-jaki");

                Dictionary.Add("lupa-pi-ko-jaki", LupaPiKoJaki);
                Glosses.Add("lupa-pi-ko-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-pi-nena", new[] { "pass" });
                    glossMap.Add("en", en);
                }
                LupaPiNena = new CompoundWord("lupa-pi-nena");

                Dictionary.Add("lupa-pi-nena", LupaPiNena);
                Glosses.Add("lupa-pi-nena", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-sijelo-monsi", new[] { "anus" });
                    glossMap.Add("en", en);
                }
                LupaSijeloMonsi = new CompoundWord("lupa-sijelo-monsi");

                Dictionary.Add("lupa-sijelo-monsi", LupaSijeloMonsi);
                Glosses.Add("lupa-sijelo-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-sinpin", new[] { "front door" });
                    glossMap.Add("en", en);
                }
                LupaSinpin = new CompoundWord("lupa-sinpin");

                Dictionary.Add("lupa-sinpin", LupaSinpin);
                Glosses.Add("lupa-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lupa-tomo-monsi", new[] { "back door" });
                    glossMap.Add("en", en);
                }
                LupaTomoMonsi = new CompoundWord("lupa-tomo-monsi");

                Dictionary.Add("lupa-tomo-monsi", LupaTomoMonsi);
                Glosses.Add("lupa-tomo-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-uta-lon-lupa", new[] { "perform cunnilingus", " perform cunnilinus" });
                    glossMap.Add("en", en);
                }
                PanaUtaLonLupa = new CompoundWord("pana-uta-lon-lupa");

                Dictionary.Add("pana-uta-lon-lupa", PanaUtaLonLupa);
                Glosses.Add("pana-uta-lon-lupa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-uta-lon-lupa-meli", new[] { "perform cunnilingus", " perform cunnilinus" });
                    glossMap.Add("en", en);
                }
                PanaUtaLonLupaMeli = new CompoundWord("pana-uta-lon-lupa-meli");

                Dictionary.Add("pana-uta-lon-lupa-meli", PanaUtaLonLupaMeli);
                Glosses.Add("pana-uta-lon-lupa-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Ekato", new[] { "Ecuador" });
                    glossMap.Add("en", en);
                }
                MaEkato = new CompoundWord("ma-Ekato");

                Dictionary.Add("ma-Ekato", MaEkato);
                Glosses.Add("ma-Ekato", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Elena", new[] { "Greece" });
                    glossMap.Add("en", en);
                }
                MaElena = new CompoundWord("ma-Elena");

                Dictionary.Add("ma-Elena", MaElena);
                Glosses.Add("ma-Elena", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Eliteja", new[] { "Eritrea" });
                    glossMap.Add("en", en);
                }
                MaEliteja = new CompoundWord("ma-Eliteja");

                Dictionary.Add("ma-Eliteja", MaEliteja);
                Glosses.Add("ma-Eliteja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Epanja", new[] { "Spain" });
                    glossMap.Add("en", en);
                }
                MaEpanja = new CompoundWord("ma-Epanja");

                Dictionary.Add("ma-Epanja", MaEpanja);
                Glosses.Add("ma-Epanja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Esalasi", new[] { "Austria" });
                    glossMap.Add("en", en);
                }
                MaEsalasi = new CompoundWord("ma-Esalasi");

                Dictionary.Add("ma-Esalasi", MaEsalasi);
                Glosses.Add("ma-Esalasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Esi", new[] { "Estonia" });
                    glossMap.Add("en", en);
                }
                MaEsi = new CompoundWord("ma-Esi");

                Dictionary.Add("ma-Esi", MaEsi);
                Glosses.Add("ma-Esi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Esuka", new[] { "Basque country" });
                    glossMap.Add("en", en);
                }
                MaEsuka = new CompoundWord("ma-Esuka");

                Dictionary.Add("ma-Esuka", MaEsuka);
                Glosses.Add("ma-Esuka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Ilakija", new[] { "Iraq" });
                    glossMap.Add("en", en);
                }
                MaIlakija = new CompoundWord("ma-Ilakija");

                Dictionary.Add("ma-Ilakija", MaIlakija);
                Glosses.Add("ma-Ilakija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Ilan", new[] { "Iran" });
                    glossMap.Add("en", en);
                }
                MaIlan = new CompoundWord("ma-Ilan");

                Dictionary.Add("ma-Ilan", MaIlan);
                Glosses.Add("ma-Ilan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Inli", new[] { "England" });
                    glossMap.Add("en", en);
                }
                MaInli = new CompoundWord("ma-Inli");

                Dictionary.Add("ma-Inli", MaInli);
                Glosses.Add("ma-Inli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Intonesija", new[] { "Indonesia" });
                    glossMap.Add("en", en);
                }
                MaIntonesija = new CompoundWord("ma-Intonesija");

                Dictionary.Add("ma-Intonesija", MaIntonesija);
                Glosses.Add("ma-Intonesija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Isale", new[] { "Israel" });
                    glossMap.Add("en", en);
                }
                MaIsale = new CompoundWord("ma-Isale");

                Dictionary.Add("ma-Isale", MaIsale);
                Glosses.Add("ma-Isale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Isijopija", new[] { "Ethiopia" });
                    glossMap.Add("en", en);
                }
                MaIsijopija = new CompoundWord("ma-Isijopija");

                Dictionary.Add("ma-Isijopija", MaIsijopija);
                Glosses.Add("ma-Isijopija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Isilan", new[] { "Iceland" });
                    glossMap.Add("en", en);
                }
                MaIsilan = new CompoundWord("ma-Isilan");

                Dictionary.Add("ma-Isilan", MaIsilan);
                Glosses.Add("ma-Isilan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Italija", new[] { "Italy" });
                    glossMap.Add("en", en);
                }
                MaItalija = new CompoundWord("ma-Italija");

                Dictionary.Add("ma-Italija", MaItalija);
                Glosses.Add("ma-Italija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Jamanija", new[] { "Yemen" });
                    glossMap.Add("en", en);
                }
                MaJamanija = new CompoundWord("ma-Jamanija");

                Dictionary.Add("ma-Jamanija", MaJamanija);
                Glosses.Add("ma-Jamanija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kalalinuna", new[] { "Greenland" });
                    glossMap.Add("en", en);
                }
                MaKalalinuna = new CompoundWord("ma-Kalalinuna");

                Dictionary.Add("ma-Kalalinuna", MaKalalinuna);
                Glosses.Add("ma-Kalalinuna", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kamelun", new[] { "Cameroon" });
                    glossMap.Add("en", en);
                }
                MaKamelun = new CompoundWord("ma-Kamelun");

                Dictionary.Add("ma-Kamelun", MaKamelun);
                Glosses.Add("ma-Kamelun", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kampija", new[] { "Gambia" });
                    glossMap.Add("en", en);
                }
                MaKampija = new CompoundWord("ma-Kampija");

                Dictionary.Add("ma-Kampija", MaKampija);
                Glosses.Add("ma-Kampija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kana", new[] { "Ghana" });
                    glossMap.Add("en", en);
                }
                MaKana = new CompoundWord("ma-Kana");

                Dictionary.Add("ma-Kana", MaKana);
                Glosses.Add("ma-Kana", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kanata", new[] { "Canada" });
                    glossMap.Add("en", en);
                }
                MaKanata = new CompoundWord("ma-Kanata");

                Dictionary.Add("ma-Kanata", MaKanata);
                Glosses.Add("ma-Kanata", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kanpusi", new[] { "Cambodia" });
                    glossMap.Add("en", en);
                }
                MaKanpusi = new CompoundWord("ma-Kanpusi");

                Dictionary.Add("ma-Kanpusi", MaKanpusi);
                Glosses.Add("ma-Kanpusi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kanse", new[] { "France" });
                    glossMap.Add("en", en);
                }
                MaKanse = new CompoundWord("ma-Kanse");

                Dictionary.Add("ma-Kanse", MaKanse);
                Glosses.Add("ma-Kanse", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kapon", new[] { "Gabon" });
                    glossMap.Add("en", en);
                }
                MaKapon = new CompoundWord("ma-Kapon");

                Dictionary.Add("ma-Kapon", MaKapon);
                Glosses.Add("ma-Kapon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Katala", new[] { "Catalan country" });
                    glossMap.Add("en", en);
                }
                MaKatala = new CompoundWord("ma-Katala");

                Dictionary.Add("ma-Katala", MaKatala);
                Glosses.Add("ma-Katala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Katelo", new[] { "Georgia" });
                    glossMap.Add("en", en);
                }
                MaKatelo = new CompoundWord("ma-Katelo");

                Dictionary.Add("ma-Katelo", MaKatelo);
                Glosses.Add("ma-Katelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Katemala", new[] { "Guatemala" });
                    glossMap.Add("en", en);
                }
                MaKatemala = new CompoundWord("ma-Katemala");

                Dictionary.Add("ma-Katemala", MaKatemala);
                Glosses.Add("ma-Katemala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kenata", new[] { "Grenada" });
                    glossMap.Add("en", en);
                }
                MaKenata = new CompoundWord("ma-Kenata");

                Dictionary.Add("ma-Kenata", MaKenata);
                Glosses.Add("ma-Kenata", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kenja", new[] { "Kenya" });
                    glossMap.Add("en", en);
                }
                MaKenja = new CompoundWord("ma-Kenja");

                Dictionary.Add("ma-Kenja", MaKenja);
                Glosses.Add("ma-Kenja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Keposi", new[] { "Cyprus" });
                    glossMap.Add("en", en);
                }
                MaKeposi = new CompoundWord("ma-Keposi");

                Dictionary.Add("ma-Keposi", MaKeposi);
                Glosses.Add("ma-Keposi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kilipasi", new[] { "Kiribati" });
                    glossMap.Add("en", en);
                }
                MaKilipasi = new CompoundWord("ma-Kilipasi");

                Dictionary.Add("ma-Kilipasi", MaKilipasi);
                Glosses.Add("ma-Kilipasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kine", new[] { "Guinea" });
                    glossMap.Add("en", en);
                }
                MaKine = new CompoundWord("ma-Kine");

                Dictionary.Add("ma-Kine", MaKine);
                Glosses.Add("ma-Kine", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kinejekatolija", new[] { "Equitorial Guinea" });
                    glossMap.Add("en", en);
                }
                MaKinejekatolija = new CompoundWord("ma-Kinejekatolija");

                Dictionary.Add("ma-Kinejekatolija", MaKinejekatolija);
                Glosses.Add("ma-Kinejekatolija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kinepisa", new[] { "Guinea-Bissau" });
                    glossMap.Add("en", en);
                }
                MaKinepisa = new CompoundWord("ma-Kinepisa");

                Dictionary.Add("ma-Kinepisa", MaKinepisa);
                Glosses.Add("ma-Kinepisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kinla", new[] { "Wales" });
                    glossMap.Add("en", en);
                }
                MaKinla = new CompoundWord("ma-Kinla");

                Dictionary.Add("ma-Kinla", MaKinla);
                Glosses.Add("ma-Kinla", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Komo", new[] { "Comoros" });
                    glossMap.Add("en", en);
                }
                MaKomo = new CompoundWord("ma-Komo");

                Dictionary.Add("ma-Komo", MaKomo);
                Glosses.Add("ma-Komo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Konko", new[] { "Congo" });
                    glossMap.Add("en", en);
                }
                MaKonko = new CompoundWord("ma-Konko");

                Dictionary.Add("ma-Konko", MaKonko);
                Glosses.Add("ma-Konko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kosalika", new[] { "Costa Rica" });
                    glossMap.Add("en", en);
                }
                MaKosalika = new CompoundWord("ma-Kosalika");

                Dictionary.Add("ma-Kosalika", MaKosalika);
                Glosses.Add("ma-Kosalika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kosiwa", new[] { "Cote d'Ivoire" });
                    glossMap.Add("en", en);
                }
                MaKosiwa = new CompoundWord("ma-Kosiwa");

                Dictionary.Add("ma-Kosiwa", MaKosiwa);
                Glosses.Add("ma-Kosiwa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kuli", new[] { "Kurdistan" });
                    glossMap.Add("en", en);
                }
                MaKuli = new CompoundWord("ma-Kuli");

                Dictionary.Add("ma-Kuli", MaKuli);
                Glosses.Add("ma-Kuli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kupa", new[] { "Cuba" });
                    glossMap.Add("en", en);
                }
                MaKupa = new CompoundWord("ma-Kupa");

                Dictionary.Add("ma-Kupa", MaKupa);
                Glosses.Add("ma-Kupa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kusala", new[] { "Gujarat" });
                    glossMap.Add("en", en);
                }
                MaKusala = new CompoundWord("ma-Kusala");

                Dictionary.Add("ma-Kusala", MaKusala);
                Glosses.Add("ma-Kusala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kusawasi", new[] { "Kuwait" });
                    glossMap.Add("en", en);
                }
                MaKusawasi = new CompoundWord("ma-Kusawasi");

                Dictionary.Add("ma-Kusawasi", MaKusawasi);
                Glosses.Add("ma-Kusawasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lanka", new[] { "Sri Lanka" });
                    glossMap.Add("en", en);
                }
                MaLanka = new CompoundWord("ma-Lanka");

                Dictionary.Add("ma-Lanka", MaLanka);
                Glosses.Add("ma-Lanka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lapewija", new[] { "Liberia" });
                    glossMap.Add("en", en);
                }
                MaLapewija = new CompoundWord("ma-Lapewija");

                Dictionary.Add("ma-Lapewija", MaLapewija);
                Glosses.Add("ma-Lapewija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lawi", new[] { "Latvia" });
                    glossMap.Add("en", en);
                }
                MaLawi = new CompoundWord("ma-Lawi");

                Dictionary.Add("ma-Lawi", MaLawi);
                Glosses.Add("ma-Lawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lesoto", new[] { "Lesotho" });
                    glossMap.Add("en", en);
                }
                MaLesoto = new CompoundWord("ma-Lesoto");

                Dictionary.Add("ma-Lesoto", MaLesoto);
                Glosses.Add("ma-Lesoto", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lijatuwa", new[] { "Lithuania" });
                    glossMap.Add("en", en);
                }
                MaLijatuwa = new CompoundWord("ma-Lijatuwa");

                Dictionary.Add("ma-Lijatuwa", MaLijatuwa);
                Glosses.Add("ma-Lijatuwa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lipija", new[] { "Libya" });
                    glossMap.Add("en", en);
                }
                MaLipija = new CompoundWord("ma-Lipija");

                Dictionary.Add("ma-Lipija", MaLipija);
                Glosses.Add("ma-Lipija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lisensan", new[] { "Liechtenstein" });
                    glossMap.Add("en", en);
                }
                MaLisensan = new CompoundWord("ma-Lisensan");

                Dictionary.Add("ma-Lisensan", MaLisensan);
                Glosses.Add("ma-Lisensan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lomani", new[] { "Romania" });
                    glossMap.Add("en", en);
                }
                MaLomani = new CompoundWord("ma-Lomani");

                Dictionary.Add("ma-Lomani", MaLomani);
                Glosses.Add("ma-Lomani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Losi", new[] { "Russia" });
                    glossMap.Add("en", en);
                }
                MaLosi = new CompoundWord("ma-Losi");

                Dictionary.Add("ma-Losi", MaLosi);
                Glosses.Add("ma-Losi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lowasi", new[] { "Croation" });
                    glossMap.Add("en", en);
                }
                MaLowasi = new CompoundWord("ma-Lowasi");

                Dictionary.Add("ma-Lowasi", MaLowasi);
                Glosses.Add("ma-Lowasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lowenki", new[] { "Slovakia" });
                    glossMap.Add("en", en);
                }
                MaLowenki = new CompoundWord("ma-Lowenki");

                Dictionary.Add("ma-Lowenki", MaLowenki);
                Glosses.Add("ma-Lowenki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lowensina", new[] { "Slovenia" });
                    glossMap.Add("en", en);
                }
                MaLowensina = new CompoundWord("ma-Lowensina");

                Dictionary.Add("ma-Lowensina", MaLowensina);
                Glosses.Add("ma-Lowensina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lunpan", new[] { "Lebanon" });
                    glossMap.Add("en", en);
                }
                MaLunpan = new CompoundWord("ma-Lunpan");

                Dictionary.Add("ma-Lunpan", MaLunpan);
                Glosses.Add("ma-Lunpan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Lusepu", new[] { "Luxembourg" });
                    glossMap.Add("en", en);
                }
                MaLusepu = new CompoundWord("ma-Lusepu");

                Dictionary.Add("ma-Lusepu", MaLusepu);
                Glosses.Add("ma-Lusepu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Luwanta", new[] { "Rwanda" });
                    glossMap.Add("en", en);
                }
                MaLuwanta = new CompoundWord("ma-Luwanta");

                Dictionary.Add("ma-Luwanta", MaLuwanta);
                Glosses.Add("ma-Luwanta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Maketonija", new[] { "Macedonia" });
                    glossMap.Add("en", en);
                }
                MaMaketonija = new CompoundWord("ma-Maketonija");

                Dictionary.Add("ma-Maketonija", MaMaketonija);
                Glosses.Add("ma-Maketonija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Malakasi", new[] { "Madagascar" });
                    glossMap.Add("en", en);
                }
                MaMalakasi = new CompoundWord("ma-Malakasi");

                Dictionary.Add("ma-Malakasi", MaMalakasi);
                Glosses.Add("ma-Malakasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Malasija", new[] { "Malaysia" });
                    glossMap.Add("en", en);
                }
                MaMalasija = new CompoundWord("ma-Malasija");

                Dictionary.Add("ma-Malasija", MaMalasija);
                Glosses.Add("ma-Malasija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Malawi", new[] { "Malawi" });
                    glossMap.Add("en", en);
                }
                MaMalawi = new CompoundWord("ma-Malawi");

                Dictionary.Add("ma-Malawi", MaMalawi);
                Glosses.Add("ma-Malawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Mali", new[] { "Mali" });
                    glossMap.Add("en", en);
                }
                MaMali = new CompoundWord("ma-Mali");

                Dictionary.Add("ma-Mali", MaMali);
                Glosses.Add("ma-Mali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Malipe", new[] { "Morocco" });
                    glossMap.Add("en", en);
                }
                MaMalipe = new CompoundWord("ma-Malipe");

                Dictionary.Add("ma-Malipe", MaMalipe);
                Glosses.Add("ma-Malipe", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Masu", new[] { "Egypt" });
                    glossMap.Add("en", en);
                }
                MaMasu = new CompoundWord("ma-Masu");

                Dictionary.Add("ma-Masu", MaMasu);
                Glosses.Add("ma-Masu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Mesiko", new[] { "Mexico" });
                    glossMap.Add("en", en);
                }
                MaMesiko = new CompoundWord("ma-Mesiko");

                Dictionary.Add("ma-Mesiko", MaMesiko);
                Glosses.Add("ma-Mesiko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Mewika", new[] { "United States" });
                    glossMap.Add("en", en);
                }
                MaMewika = new CompoundWord("ma-Mewika");

                Dictionary.Add("ma-Mewika", MaMewika);
                Glosses.Add("ma-Mewika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Mijanma", new[] { "Myanmar (Burma)" });
                    glossMap.Add("en", en);
                }
                MaMijanma = new CompoundWord("ma-Mijanma");

                Dictionary.Add("ma-Mijanma", MaMijanma);
                Glosses.Add("ma-Mijanma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Mosanpi", new[] { "Mozambique" });
                    glossMap.Add("en", en);
                }
                MaMosanpi = new CompoundWord("ma-Mosanpi");

                Dictionary.Add("ma-Mosanpi", MaMosanpi);
                Glosses.Add("ma-Mosanpi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Mosijo", new[] { "Hungary" });
                    glossMap.Add("en", en);
                }
                MaMosijo = new CompoundWord("ma-Mosijo");

                Dictionary.Add("ma-Mosijo", MaMosijo);
                Glosses.Add("ma-Mosijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Motowa", new[] { "Moldava" });
                    glossMap.Add("en", en);
                }
                MaMotowa = new CompoundWord("ma-Motowa");

                Dictionary.Add("ma-Motowa", MaMotowa);
                Glosses.Add("ma-Motowa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Mowisi", new[] { "Mauritius" });
                    glossMap.Add("en", en);
                }
                MaMowisi = new CompoundWord("ma-Mowisi");

                Dictionary.Add("ma-Mowisi", MaMowisi);
                Glosses.Add("ma-Mowisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Mulitanija", new[] { "Mauritania" });
                    glossMap.Add("en", en);
                }
                MaMulitanija = new CompoundWord("ma-Mulitanija");

                Dictionary.Add("ma-Mulitanija", MaMulitanija);
                Glosses.Add("ma-Mulitanija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Namipija", new[] { "Namibia" });
                    glossMap.Add("en", en);
                }
                MaNamipija = new CompoundWord("ma-Namipija");

                Dictionary.Add("ma-Namipija", MaNamipija);
                Glosses.Add("ma-Namipija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Naselija", new[] { "Nigeria" });
                    glossMap.Add("en", en);
                }
                MaNaselija = new CompoundWord("ma-Naselija");

                Dictionary.Add("ma-Naselija", MaNaselija);
                Glosses.Add("ma-Naselija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Netelan", new[] { "Netherlands" });
                    glossMap.Add("en", en);
                }
                MaNetelan = new CompoundWord("ma-Netelan");

                Dictionary.Add("ma-Netelan", MaNetelan);
                Glosses.Add("ma-Netelan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nikalala", new[] { "Nicaragua" });
                    glossMap.Add("en", en);
                }
                MaNikalala = new CompoundWord("ma-Nikalala");

                Dictionary.Add("ma-Nikalala", MaNikalala);
                Glosses.Add("ma-Nikalala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nijon", new[] { "Japan" });
                    glossMap.Add("en", en);
                }
                MaNijon = new CompoundWord("ma-Nijon");

                Dictionary.Add("ma-Nijon", MaNijon);
                Glosses.Add("ma-Nijon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nise", new[] { "Niger" });
                    glossMap.Add("en", en);
                }
                MaNise = new CompoundWord("ma-Nise");

                Dictionary.Add("ma-Nise", MaNise);
                Glosses.Add("ma-Nise", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nosiki", new[] { "Norway" });
                    glossMap.Add("en", en);
                }
                MaNosiki = new CompoundWord("ma-Nosiki");

                Dictionary.Add("ma-Nosiki", MaNosiki);
                Glosses.Add("ma-Nosiki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nusilan", new[] { "New Zealand" });
                    glossMap.Add("en", en);
                }
                MaNusilan = new CompoundWord("ma-Nusilan");

                Dictionary.Add("ma-Nusilan", MaNusilan);
                Glosses.Add("ma-Nusilan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Ontula", new[] { "Honduras" });
                    glossMap.Add("en", en);
                }
                MaOntula = new CompoundWord("ma-Ontula");

                Dictionary.Add("ma-Ontula", MaOntula);
                Glosses.Add("ma-Ontula", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Oselija", new[] { "Australia" });
                    glossMap.Add("en", en);
                }
                MaOselija = new CompoundWord("ma-Oselija");

                Dictionary.Add("ma-Oselija", MaOselija);
                Glosses.Add("ma-Oselija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pakisan", new[] { "Pakistan" });
                    glossMap.Add("en", en);
                }
                MaPakisan = new CompoundWord("ma-Pakisan");

                Dictionary.Add("ma-Pakisan", MaPakisan);
                Glosses.Add("ma-Pakisan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Palakawi", new[] { "Paraguay" });
                    glossMap.Add("en", en);
                }
                MaPalakawi = new CompoundWord("ma-Palakawi");

                Dictionary.Add("ma-Palakawi", MaPalakawi);
                Glosses.Add("ma-Palakawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Palani", new[] { "Bahrein" });
                    glossMap.Add("en", en);
                }
                MaPalani = new CompoundWord("ma-Palani");

                Dictionary.Add("ma-Palani", MaPalani);
                Glosses.Add("ma-Palani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Palata", new[] { "India" });
                    glossMap.Add("en", en);
                }
                MaPalata = new CompoundWord("ma-Palata");

                Dictionary.Add("ma-Palata", MaPalata);
                Glosses.Add("ma-Palata", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Panama", new[] { "Panama" });
                    glossMap.Add("en", en);
                }
                MaPanama = new CompoundWord("ma-Panama");

                Dictionary.Add("ma-Panama", MaPanama);
                Glosses.Add("ma-Panama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Panla", new[] { "Bangladesh" });
                    glossMap.Add("en", en);
                }
                MaPanla = new CompoundWord("ma-Panla");

                Dictionary.Add("ma-Panla", MaPanla);
                Glosses.Add("ma-Panla", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Papeto", new[] { "Barbados" });
                    glossMap.Add("en", en);
                }
                MaPapeto = new CompoundWord("ma-Papeto");

                Dictionary.Add("ma-Papeto", MaPapeto);
                Glosses.Add("ma-Papeto", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Papuwanijukini", new[] { "Papua New Guinea" });
                    glossMap.Add("en", en);
                }
                MaPapuwanijukini = new CompoundWord("ma-Papuwanijukini");

                Dictionary.Add("ma-Papuwanijukini", MaPapuwanijukini);
                Glosses.Add("ma-Papuwanijukini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pasila", new[] { "Brazil" });
                    glossMap.Add("en", en);
                }
                MaPasila = new CompoundWord("ma-Pasila");

                Dictionary.Add("ma-Pasila", MaPasila);
                Glosses.Add("ma-Pasila", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pawama", new[] { "Bahamas" });
                    glossMap.Add("en", en);
                }
                MaPawama = new CompoundWord("ma-Pawama");

                Dictionary.Add("ma-Pawama", MaPawama);
                Glosses.Add("ma-Pawama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pelelusi", new[] { "Belarus" });
                    glossMap.Add("en", en);
                }
                MaPelelusi = new CompoundWord("ma-Pelelusi");

                Dictionary.Add("ma-Pelelusi", MaPelelusi);
                Glosses.Add("ma-Pelelusi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pelu", new[] { "Peru" });
                    glossMap.Add("en", en);
                }
                MaPelu = new CompoundWord("ma-Pelu");

                Dictionary.Add("ma-Pelu", MaPelu);
                Glosses.Add("ma-Pelu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Peluta", new[] { "Bermuda" });
                    glossMap.Add("en", en);
                }
                MaPeluta = new CompoundWord("ma-Peluta");

                Dictionary.Add("ma-Peluta", MaPeluta);
                Glosses.Add("ma-Peluta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Penen", new[] { "Benin" });
                    glossMap.Add("en", en);
                }
                MaPenen = new CompoundWord("ma-Penen");

                Dictionary.Add("ma-Penen", MaPenen);
                Glosses.Add("ma-Penen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Penesuwela", new[] { "Venezuela" });
                    glossMap.Add("en", en);
                }
                MaPenesuwela = new CompoundWord("ma-Penesuwela");

                Dictionary.Add("ma-Penesuwela", MaPenesuwela);
                Glosses.Add("ma-Penesuwela", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pesije", new[] { "Belgium" });
                    glossMap.Add("en", en);
                }
                MaPesije = new CompoundWord("ma-Pesije");

                Dictionary.Add("ma-Pesije", MaPesije);
                Glosses.Add("ma-Pesije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pilipina", new[] { "Philipines" });
                    glossMap.Add("en", en);
                }
                MaPilipina = new CompoundWord("ma-Pilipina");

                Dictionary.Add("ma-Pilipina", MaPilipina);
                Glosses.Add("ma-Pilipina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pilisin", new[] { "Palestine" });
                    glossMap.Add("en", en);
                }
                MaPilisin = new CompoundWord("ma-Pilisin");

                Dictionary.Add("ma-Pilisin", MaPilisin);
                Glosses.Add("ma-Pilisin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pisi", new[] { "Fiji" });
                    glossMap.Add("en", en);
                }
                MaPisi = new CompoundWord("ma-Pisi");

                Dictionary.Add("ma-Pisi", MaPisi);
                Glosses.Add("ma-Pisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Piten", new[] { "United Kingdom (Great Britain)" });
                    glossMap.Add("en", en);
                }
                MaPiten = new CompoundWord("ma-Piten");

                Dictionary.Add("ma-Piten", MaPiten);
                Glosses.Add("ma-Piten", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pokasi", new[] { "Bulgaria" });
                    glossMap.Add("en", en);
                }
                MaPokasi = new CompoundWord("ma-Pokasi");

                Dictionary.Add("ma-Pokasi", MaPokasi);
                Glosses.Add("ma-Pokasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Posan", new[] { "Bosnia and Herzegovina" });
                    glossMap.Add("en", en);
                }
                MaPosan = new CompoundWord("ma-Posan");

                Dictionary.Add("ma-Posan", MaPosan);
                Glosses.Add("ma-Posan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Posuka", new[] { "Poland" });
                    glossMap.Add("en", en);
                }
                MaPosuka = new CompoundWord("ma-Posuka");

                Dictionary.Add("ma-Posuka", MaPosuka);
                Glosses.Add("ma-Posuka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Posuwana", new[] { "Botswana" });
                    glossMap.Add("en", en);
                }
                MaPosuwana = new CompoundWord("ma-Posuwana");

                Dictionary.Add("ma-Posuwana", MaPosuwana);
                Glosses.Add("ma-Posuwana", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Potuke", new[] { "Portugal" });
                    glossMap.Add("en", en);
                }
                MaPotuke = new CompoundWord("ma-Potuke");

                Dictionary.Add("ma-Potuke", MaPotuke);
                Glosses.Add("ma-Potuke", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pukinapaso", new[] { "Burkina Faso" });
                    glossMap.Add("en", en);
                }
                MaPukinapaso = new CompoundWord("ma-Pukinapaso");

                Dictionary.Add("ma-Pukinapaso", MaPukinapaso);
                Glosses.Add("ma-Pukinapaso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Samalino", new[] { "San Marino" });
                    glossMap.Add("en", en);
                }
                MaSamalino = new CompoundWord("ma-Samalino");

                Dictionary.Add("ma-Samalino", MaSamalino);
                Glosses.Add("ma-Samalino", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sameka", new[] { "Jamaica" });
                    glossMap.Add("en", en);
                }
                MaSameka = new CompoundWord("ma-Sameka");

                Dictionary.Add("ma-Sameka", MaSameka);
                Glosses.Add("ma-Sameka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Samowa", new[] { "Samoa" });
                    glossMap.Add("en", en);
                }
                MaSamowa = new CompoundWord("ma-Samowa");

                Dictionary.Add("ma-Samowa", MaSamowa);
                Glosses.Add("ma-Samowa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sanpija", new[] { "Zambia" });
                    glossMap.Add("en", en);
                }
                MaSanpija = new CompoundWord("ma-Sanpija");

                Dictionary.Add("ma-Sanpija", MaSanpija);
                Glosses.Add("ma-Sanpija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Santapiken", new[] { "Central African Republic" });
                    glossMap.Add("en", en);
                }
                MaSantapiken = new CompoundWord("ma-Santapiken");

                Dictionary.Add("ma-Santapiken", MaSantapiken);
                Glosses.Add("ma-Santapiken", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sasali", new[] { "Algeria" });
                    glossMap.Add("en", en);
                }
                MaSasali = new CompoundWord("ma-Sasali");

                Dictionary.Add("ma-Sasali", MaSasali);
                Glosses.Add("ma-Sasali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sate", new[] { "Chad" });
                    glossMap.Add("en", en);
                }
                MaSate = new CompoundWord("ma-Sate");

                Dictionary.Add("ma-Sate", MaSate);
                Glosses.Add("ma-Sate", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sawasi", new[] { "Swaziland" });
                    glossMap.Add("en", en);
                }
                MaSawasi = new CompoundWord("ma-Sawasi");

                Dictionary.Add("ma-Sawasi", MaSawasi);
                Glosses.Add("ma-Sawasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Seki", new[] { "Czech Republic" });
                    glossMap.Add("en", en);
                }
                MaSeki = new CompoundWord("ma-Seki");

                Dictionary.Add("ma-Seki", MaSeki);
                Glosses.Add("ma-Seki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Seneka", new[] { "Senegal" });
                    glossMap.Add("en", en);
                }
                MaSeneka = new CompoundWord("ma-Seneka");

                Dictionary.Add("ma-Seneka", MaSeneka);
                Glosses.Add("ma-Seneka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Setapika", new[] { "South Africa" });
                    glossMap.Add("en", en);
                }
                MaSetapika = new CompoundWord("ma-Setapika");

                Dictionary.Add("ma-Setapika", MaSetapika);
                Glosses.Add("ma-Setapika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sibeta", new[] { "Tibet" });
                    glossMap.Add("en", en);
                }
                MaSibeta = new CompoundWord("ma-Sibeta");

                Dictionary.Add("ma-Sibeta", MaSibeta);
                Glosses.Add("ma-Sibeta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sijelalijon", new[] { "Sierra leone" });
                    glossMap.Add("en", en);
                }
                MaSijelalijon = new CompoundWord("ma-Sijelalijon");

                Dictionary.Add("ma-Sijelalijon", MaSijelalijon);
                Glosses.Add("ma-Sijelalijon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sile", new[] { "Chile" });
                    glossMap.Add("en", en);
                }
                MaSile = new CompoundWord("ma-Sile");

                Dictionary.Add("ma-Sile", MaSile);
                Glosses.Add("ma-Sile", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sinita", new[] { "Trinidad and Tobago" });
                    glossMap.Add("en", en);
                }
                MaSinita = new CompoundWord("ma-Sinita");

                Dictionary.Add("ma-Sinita", MaSinita);
                Glosses.Add("ma-Sinita", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sinpapuwe", new[] { "Zimbabwe" });
                    glossMap.Add("en", en);
                }
                MaSinpapuwe = new CompoundWord("ma-Sinpapuwe");

                Dictionary.Add("ma-Sinpapuwe", MaSinpapuwe);
                Glosses.Add("ma-Sinpapuwe", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-sipe", new[] { "Albania" });
                    glossMap.Add("en", en);
                }
                MaSipe = new CompoundWord("ma-sipe");

                Dictionary.Add("ma-sipe", MaSipe);
                Glosses.Add("ma-sipe", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sipusi", new[] { "Djibouti" });
                    glossMap.Add("en", en);
                }
                MaSipusi = new CompoundWord("ma-Sipusi");

                Dictionary.Add("ma-Sipusi", MaSipusi);
                Glosses.Add("ma-Sipusi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Somalija", new[] { "Somalia" });
                    glossMap.Add("en", en);
                }
                MaSomalija = new CompoundWord("ma-Somalija");

                Dictionary.Add("ma-Somalija", MaSomalija);
                Glosses.Add("ma-Somalija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sonko", new[] { "China" });
                    glossMap.Add("en", en);
                }
                MaSonko = new CompoundWord("ma-Sonko");

                Dictionary.Add("ma-Sonko", MaSonko);
                Glosses.Add("ma-Sonko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sopisi", new[] { "Serbia and Montenegro" });
                    glossMap.Add("en", en);
                }
                MaSopisi = new CompoundWord("ma-Sopisi");

                Dictionary.Add("ma-Sopisi", MaSopisi);
                Glosses.Add("ma-Sopisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sukosi", new[] { "Scotland" });
                    glossMap.Add("en", en);
                }
                MaSukosi = new CompoundWord("ma-Sukosi");

                Dictionary.Add("ma-Sukosi", MaSukosi);
                Glosses.Add("ma-Sukosi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sulija", new[] { "Syria" });
                    glossMap.Add("en", en);
                }
                MaSulija = new CompoundWord("ma-Sulija");

                Dictionary.Add("ma-Sulija", MaSulija);
                Glosses.Add("ma-Sulija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sumi", new[] { "Finland" });
                    glossMap.Add("en", en);
                }
                MaSumi = new CompoundWord("ma-Sumi");

                Dictionary.Add("ma-Sumi", MaSumi);
                Glosses.Add("ma-Sumi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sutan", new[] { "Sudan" });
                    glossMap.Add("en", en);
                }
                MaSutan = new CompoundWord("ma-Sutan");

                Dictionary.Add("ma-Sutan", MaSutan);
                Glosses.Add("ma-Sutan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Suwasi", new[] { "Switzerland" });
                    glossMap.Add("en", en);
                }
                MaSuwasi = new CompoundWord("ma-Suwasi");

                Dictionary.Add("ma-Suwasi", MaSuwasi);
                Glosses.Add("ma-Suwasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tansanija", new[] { "Tanzania" });
                    glossMap.Add("en", en);
                }
                MaTansanija = new CompoundWord("ma-Tansanija");

                Dictionary.Add("ma-Tansanija", MaTansanija);
                Glosses.Add("ma-Tansanija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tansi", new[] { "Denmark" });
                    glossMap.Add("en", en);
                }
                MaTansi = new CompoundWord("ma-Tansi");

                Dictionary.Add("ma-Tansi", MaTansi);
                Glosses.Add("ma-Tansi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tawi", new[] { "Thailand" });
                    glossMap.Add("en", en);
                }
                MaTawi = new CompoundWord("ma-Tawi");

                Dictionary.Add("ma-Tawi", MaTawi);
                Glosses.Add("ma-Tawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-toko", new[] { "Togo" });
                    glossMap.Add("en", en);
                }
                MaToko = new CompoundWord("ma-toko");

                Dictionary.Add("ma-toko", MaToko);
                Glosses.Add("ma-toko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tominika", new[] { "Dominican Republic" });
                    glossMap.Add("en", en);
                }
                MaTominika = new CompoundWord("ma-Tominika");

                Dictionary.Add("ma-Tominika", MaTominika);
                Glosses.Add("ma-Tominika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tona", new[] { "Tonga" });
                    glossMap.Add("en", en);
                }
                MaTona = new CompoundWord("ma-Tona");

                Dictionary.Add("ma-Tona", MaTona);
                Glosses.Add("ma-Tona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tosi", new[] { "Germany" });
                    glossMap.Add("en", en);
                }
                MaTosi = new CompoundWord("ma-Tosi");

                Dictionary.Add("ma-Tosi", MaTosi);
                Glosses.Add("ma-Tosi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tuki", new[] { "Turkey" });
                    glossMap.Add("en", en);
                }
                MaTuki = new CompoundWord("ma-Tuki");

                Dictionary.Add("ma-Tuki", MaTuki);
                Glosses.Add("ma-Tuki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tunisi", new[] { "Tunisia" });
                    glossMap.Add("en", en);
                }
                MaTunisi = new CompoundWord("ma-Tunisi");

                Dictionary.Add("ma-Tunisi", MaTunisi);
                Glosses.Add("ma-Tunisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tuwalu", new[] { "Tuvalu" });
                    glossMap.Add("en", en);
                }
                MaTuwalu = new CompoundWord("ma-Tuwalu");

                Dictionary.Add("ma-Tuwalu", MaTuwalu);
                Glosses.Add("ma-Tuwalu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Ukanta", new[] { "Uganda" });
                    glossMap.Add("en", en);
                }
                MaUkanta = new CompoundWord("ma-Ukanta");

                Dictionary.Add("ma-Ukanta", MaUkanta);
                Glosses.Add("ma-Ukanta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Ukawina", new[] { "Ukraine" });
                    glossMap.Add("en", en);
                }
                MaUkawina = new CompoundWord("ma-Ukawina");

                Dictionary.Add("ma-Ukawina", MaUkawina);
                Glosses.Add("ma-Ukawina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Ulukawi", new[] { "Uruguay" });
                    glossMap.Add("en", en);
                }
                MaUlukawi = new CompoundWord("ma-Ulukawi");

                Dictionary.Add("ma-Ulukawi", MaUlukawi);
                Glosses.Add("ma-Ulukawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Uman", new[] { "Oman" });
                    glossMap.Add("en", en);
                }
                MaUman = new CompoundWord("ma-Uman");

                Dictionary.Add("ma-Uman", MaUman);
                Glosses.Add("ma-Uman", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Utan", new[] { "Jordan" });
                    glossMap.Add("en", en);
                }
                MaUtan = new CompoundWord("ma-Utan");

                Dictionary.Add("ma-Utan", MaUtan);
                Glosses.Add("ma-Utan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Wanawatu", new[] { "Vanuatu" });
                    glossMap.Add("en", en);
                }
                MaWanawatu = new CompoundWord("ma-Wanawatu");

                Dictionary.Add("ma-Wanawatu", MaWanawatu);
                Glosses.Add("ma-Wanawatu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Wasikano", new[] { "Vatican" });
                    glossMap.Add("en", en);
                }
                MaWasikano = new CompoundWord("ma-Wasikano");

                Dictionary.Add("ma-Wasikano", MaWasikano);
                Glosses.Add("ma-Wasikano", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Watemala", new[] { "Guatemala" });
                    glossMap.Add("en", en);
                }
                MaWatemala = new CompoundWord("ma-Watemala");

                Dictionary.Add("ma-Watemala", MaWatemala);
                Glosses.Add("ma-Watemala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Wensa", new[] { "Sweden" });
                    glossMap.Add("en", en);
                }
                MaWensa = new CompoundWord("ma-Wensa");

                Dictionary.Add("ma-Wensa", MaWensa);
                Glosses.Add("ma-Wensa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Wije", new[] { "Viet Nam" });
                    glossMap.Add("en", en);
                }
                MaWije = new CompoundWord("ma-Wije");

                Dictionary.Add("ma-Wije", MaWije);
                Glosses.Add("ma-Wije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Ele", new[] { "Las Angeles" });
                    glossMap.Add("en", en);
                }
                MaTomoEle = new CompoundWord("ma-tomo-Ele");

                Dictionary.Add("ma-tomo-Ele", MaTomoEle);
                Glosses.Add("ma-tomo-Ele", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Esupo", new[] { "Espoo" });
                    glossMap.Add("en", en);
                }
                MaTomoEsupo = new CompoundWord("ma-tomo-Esupo");

                Dictionary.Add("ma-tomo-Esupo", MaTomoEsupo);
                Glosses.Add("ma-tomo-Esupo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Iwesun", new[] { "Hilversum" });
                    glossMap.Add("en", en);
                }
                MaTomoIwesun = new CompoundWord("ma-tomo-Iwesun");

                Dictionary.Add("ma-tomo-Iwesun", MaTomoIwesun);
                Glosses.Add("ma-tomo-Iwesun", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Kakawi", new[] { "Calgary" });
                    glossMap.Add("en", en);
                }
                MaTomoKakawi = new CompoundWord("ma-tomo-Kakawi");

                Dictionary.Add("ma-tomo-Kakawi", MaTomoKakawi);
                Glosses.Add("ma-tomo-Kakawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Kenpisi", new[] { "Cambridge" });
                    glossMap.Add("en", en);
                }
                MaTomoKenpisi = new CompoundWord("ma-tomo-Kenpisi");

                Dictionary.Add("ma-tomo-Kenpisi", MaTomoKenpisi);
                Glosses.Add("ma-tomo-Kenpisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Kinsasa", new[] { "Kinshasa" });
                    glossMap.Add("en", en);
                }
                MaTomoKinsasa = new CompoundWord("ma-tomo-Kinsasa");

                Dictionary.Add("ma-tomo-Kinsasa", MaTomoKinsasa);
                Glosses.Add("ma-tomo-Kinsasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Kunte", new[] { "Bangkok" });
                    glossMap.Add("en", en);
                }
                MaTomoKunte = new CompoundWord("ma-tomo-Kunte");

                Dictionary.Add("ma-tomo-Kunte", MaTomoKunte);
                Glosses.Add("ma-tomo-Kunte", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Lanten", new[] { "London" });
                    glossMap.Add("en", en);
                }
                MaTomoLanten = new CompoundWord("ma-tomo-Lanten");

                Dictionary.Add("ma-tomo-Lanten", MaTomoLanten);
                Glosses.Add("ma-tomo-Lanten", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Lesinki", new[] { "Helsinki" });
                    glossMap.Add("en", en);
                }
                MaTomoLesinki = new CompoundWord("ma-tomo-Lesinki");

                Dictionary.Add("ma-tomo-Lesinki", MaTomoLesinki);
                Glosses.Add("ma-tomo-Lesinki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Loma", new[] { "Rome" });
                    glossMap.Add("en", en);
                }
                MaTomoLoma = new CompoundWord("ma-tomo-Loma");

                Dictionary.Add("ma-tomo-Loma", MaTomoLoma);
                Glosses.Add("ma-tomo-Loma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Mansasa", new[] { "Mount shasta" });
                    glossMap.Add("en", en);
                }
                MaTomoMansasa = new CompoundWord("ma-tomo-Mansasa");

                Dictionary.Add("ma-tomo-Mansasa", MaTomoMansasa);
                Glosses.Add("ma-tomo-Mansasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Manten", new[] { "Moncton" });
                    glossMap.Add("en", en);
                }
                MaTomoManten = new CompoundWord("ma-tomo-Manten");

                Dictionary.Add("ma-tomo-Manten", MaTomoManten);
                Glosses.Add("ma-tomo-Manten", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Mesiko", new[] { "Mexico City" });
                    glossMap.Add("en", en);
                }
                MaTomoMesiko = new CompoundWord("ma-tomo-Mesiko");

                Dictionary.Add("ma-tomo-Mesiko", MaTomoMesiko);
                Glosses.Add("ma-tomo-Mesiko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Minsen", new[] { "Munich" });
                    glossMap.Add("en", en);
                }
                MaTomoMinsen = new CompoundWord("ma-tomo-Minsen");

                Dictionary.Add("ma-tomo-Minsen", MaTomoMinsen);
                Glosses.Add("ma-tomo-Minsen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Monkela", new[] { "Montreal" });
                    glossMap.Add("en", en);
                }
                MaTomoMonkela = new CompoundWord("ma-tomo-Monkela");

                Dictionary.Add("ma-tomo-Monkela", MaTomoMonkela);
                Glosses.Add("ma-tomo-Monkela", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Munpa", new[] { "Mumbai (Bombay)" });
                    glossMap.Add("en", en);
                }
                MaTomoMunpa = new CompoundWord("ma-tomo-Munpa");

                Dictionary.Add("ma-tomo-Munpa", MaTomoMunpa);
                Glosses.Add("ma-tomo-Munpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Napoli", new[] { "Naples" });
                    glossMap.Add("en", en);
                }
                MaTomoNapoli = new CompoundWord("ma-tomo-Napoli");

                Dictionary.Add("ma-tomo-Napoli", MaTomoNapoli);
                Glosses.Add("ma-tomo-Napoli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Nujoka", new[] { "New York city" });
                    glossMap.Add("en", en);
                }
                MaTomoNujoka = new CompoundWord("ma-tomo-Nujoka");

                Dictionary.Add("ma-tomo-Nujoka", MaTomoNujoka);
                Glosses.Add("ma-tomo-Nujoka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Nuwewen", new[] { "New Haven" });
                    glossMap.Add("en", en);
                }
                MaTomoNuwewen = new CompoundWord("ma-tomo-Nuwewen");

                Dictionary.Add("ma-tomo-Nuwewen", MaTomoNuwewen);
                Glosses.Add("ma-tomo-Nuwewen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Olanto", new[] { "Orlando" });
                    glossMap.Add("en", en);
                }
                MaTomoOlanto = new CompoundWord("ma-tomo-Olanto");

                Dictionary.Add("ma-tomo-Olanto", MaTomoOlanto);
                Glosses.Add("ma-tomo-Olanto", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Osaka", new[] { "Osaka" });
                    glossMap.Add("en", en);
                }
                MaTomoOsaka = new CompoundWord("ma-tomo-Osaka");

                Dictionary.Add("ma-tomo-Osaka", MaTomoOsaka);
                Glosses.Add("ma-tomo-Osaka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Pasen", new[] { "Boston" });
                    glossMap.Add("en", en);
                }
                MaTomoPasen = new CompoundWord("ma-tomo-Pasen");

                Dictionary.Add("ma-tomo-Pasen", MaTomoPasen);
                Glosses.Add("ma-tomo-Pasen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Pelin", new[] { "Berlin" });
                    glossMap.Add("en", en);
                }
                MaTomoPelin = new CompoundWord("ma-tomo-Pelin");

                Dictionary.Add("ma-tomo-Pelin", MaTomoPelin);
                Glosses.Add("ma-tomo-Pelin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Peminan", new[] { "Birmingham" });
                    glossMap.Add("en", en);
                }
                MaTomoPeminan = new CompoundWord("ma-tomo-Peminan");

                Dictionary.Add("ma-tomo-Peminan", MaTomoPeminan);
                Glosses.Add("ma-tomo-Peminan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Pankalo", new[] { "Bangalore" });
                    glossMap.Add("en", en);
                }
                MaTomoPankalo = new CompoundWord("ma-tomo-Pankalo");

                Dictionary.Add("ma-tomo-Pankalo", MaTomoPankalo);
                Glosses.Add("ma-tomo-Pankalo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Pesin", new[] { "Beijing" });
                    glossMap.Add("en", en);
                }
                MaTomoPesin = new CompoundWord("ma-tomo-Pesin");

                Dictionary.Add("ma-tomo-Pesin", MaTomoPesin);
                Glosses.Add("ma-tomo-Pesin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Petepuko", new[] { "St. Petersburg" });
                    glossMap.Add("en", en);
                }
                MaTomoPetepuko = new CompoundWord("ma-tomo-Petepuko");

                Dictionary.Add("ma-tomo-Petepuko", MaTomoPetepuko);
                Glosses.Add("ma-tomo-Petepuko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Pilense", new[] { "Florence" });
                    glossMap.Add("en", en);
                }
                MaTomoPilense = new CompoundWord("ma-tomo-Pilense");

                Dictionary.Add("ma-tomo-Pilense", MaTomoPilense);
                Glosses.Add("ma-tomo-Pilense", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Pisawi", new[] { "Brazaville" });
                    glossMap.Add("en", en);
                }
                MaTomoPisawi = new CompoundWord("ma-tomo-Pisawi");

                Dictionary.Add("ma-tomo-Pisawi", MaTomoPisawi);
                Glosses.Add("ma-tomo-Pisawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Polan", new[] { "Portland" });
                    glossMap.Add("en", en);
                }
                MaTomoPolan = new CompoundWord("ma-tomo-Polan");

                Dictionary.Add("ma-tomo-Polan", MaTomoPolan);
                Glosses.Add("ma-tomo-Polan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Putapesi", new[] { "Budapest" });
                    glossMap.Add("en", en);
                }
                MaTomoPutapesi = new CompoundWord("ma-tomo-Putapesi");

                Dictionary.Add("ma-tomo-Putapesi", MaTomoPutapesi);
                Glosses.Add("ma-tomo-Putapesi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Sakata", new[] { "Jakarta" });
                    glossMap.Add("en", en);
                }
                MaTomoSakata = new CompoundWord("ma-tomo-Sakata");

                Dictionary.Add("ma-tomo-Sakata", MaTomoSakata);
                Glosses.Add("ma-tomo-Sakata", glossMap);
            }


            //ILLEGAL!
            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("ma-tomo-Salajewo", new[] { "Sarajevo" });
            //        glossMap.Add("en", en);
            //    }
            //    MaTomoSalajewo = new CompoundWord("ma-tomo-Salajewo");

            //    Dictionary.Add("ma-tomo-Salajewo", MaTomoSalajewo);
            //    Glosses.Add("ma-tomo-Salajewo", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Sanpansiko", new[] { "San Francisco" });
                    glossMap.Add("en", en);
                }
                MaTomoSanpansiko = new CompoundWord("ma-tomo-Sanpansiko");

                Dictionary.Add("ma-tomo-Sanpansiko", MaTomoSanpansiko);
                Glosses.Add("ma-tomo-Sanpansiko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Satupu", new[] { "Strasbourg" });
                    glossMap.Add("en", en);
                }
                MaTomoSatupu = new CompoundWord("ma-tomo-Satupu");

                Dictionary.Add("ma-tomo-Satupu", MaTomoSatupu);
                Glosses.Add("ma-tomo-Satupu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Sawi", new[] { "Sackville" });
                    glossMap.Add("en", en);
                }
                MaTomoSawi = new CompoundWord("ma-tomo-Sawi");

                Dictionary.Add("ma-tomo-Sawi", MaTomoSawi);
                Glosses.Add("ma-tomo-Sawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Sene", new[] { "Geneva" });
                    glossMap.Add("en", en);
                }
                MaTomoSene = new CompoundWord("ma-tomo-Sene");

                Dictionary.Add("ma-tomo-Sene", MaTomoSene);
                Glosses.Add("ma-tomo-Sene", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Sensan", new[] { "St. John's" });
                    glossMap.Add("en", en);
                }
                MaTomoSensan = new CompoundWord("ma-tomo-Sensan");

                Dictionary.Add("ma-tomo-Sensan", MaTomoSensan);
                Glosses.Add("ma-tomo-Sensan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Sesija", new[] { "Shediac" });
                    glossMap.Add("en", en);
                }
                MaTomoSesija = new CompoundWord("ma-tomo-Sesija");

                Dictionary.Add("ma-tomo-Sesija", MaTomoSesija);
                Glosses.Add("ma-tomo-Sesija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Sije", new[] { "Dieppe" });
                    glossMap.Add("en", en);
                }
                MaTomoSije = new CompoundWord("ma-tomo-Sije");

                Dictionary.Add("ma-tomo-Sije", MaTomoSije);
                Glosses.Add("ma-tomo-Sije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Solu", new[] { "Seoul" });
                    glossMap.Add("en", en);
                }
                MaTomoSolu = new CompoundWord("ma-tomo-Solu");

                Dictionary.Add("ma-tomo-Solu", MaTomoSolu);
                Glosses.Add("ma-tomo-Solu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Tamen", new[] { "Drammen" });
                    glossMap.Add("en", en);
                }
                MaTomoTamen = new CompoundWord("ma-tomo-Tamen");

                Dictionary.Add("ma-tomo-Tamen", MaTomoTamen);
                Glosses.Add("ma-tomo-Tamen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Tanpele", new[] { "Tampere" });
                    glossMap.Add("en", en);
                }
                MaTomoTanpele = new CompoundWord("ma-tomo-Tanpele");

                Dictionary.Add("ma-tomo-Tanpele", MaTomoTanpele);
                Glosses.Add("ma-tomo-Tanpele", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Telawi", new[] { "Tel Aviv" });
                    glossMap.Add("en", en);
                }
                MaTomoTelawi = new CompoundWord("ma-tomo-Telawi");

                Dictionary.Add("ma-tomo-Telawi", MaTomoTelawi);
                Glosses.Add("ma-tomo-Telawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Tokijo", new[] { "Tokyo" });
                    glossMap.Add("en", en);
                }
                MaTomoTokijo = new CompoundWord("ma-tomo-Tokijo");

                Dictionary.Add("ma-tomo-Tokijo", MaTomoTokijo);
                Glosses.Add("ma-tomo-Tokijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Towano", new[] { "Toronto" });
                    glossMap.Add("en", en);
                }
                MaTomoTowano = new CompoundWord("ma-tomo-Towano");

                Dictionary.Add("ma-tomo-Towano", MaTomoTowano);
                Glosses.Add("ma-tomo-Towano", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Tuku", new[] { "Turku" });
                    glossMap.Add("en", en);
                }
                MaTomoTuku = new CompoundWord("ma-tomo-Tuku");

                Dictionary.Add("ma-tomo-Tuku", MaTomoTuku);
                Glosses.Add("ma-tomo-Tuku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Wankuwa", new[] { "Vancouver" });
                    glossMap.Add("en", en);
                }
                MaTomoWankuwa = new CompoundWord("ma-tomo-Wankuwa");

                Dictionary.Add("ma-tomo-Wankuwa", MaTomoWankuwa);
                Glosses.Add("ma-tomo-Wankuwa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Wenesija", new[] { "Venice" });
                    glossMap.Add("en", en);
                }
                MaTomoWenesija = new CompoundWord("ma-tomo-Wenesija");

                Dictionary.Add("ma-tomo-Wenesija", MaTomoWenesija);
                Glosses.Add("ma-tomo-Wenesija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pasiki", new[] { "fyksland" });
                    glossMap.Add("en", en);
                }
                MaPasiki = new CompoundWord("ma-Pasiki");

                Dictionary.Add("ma-Pasiki", MaPasiki);
                Glosses.Add("ma-Pasiki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Palisija", new[] { "Galicia" });
                    glossMap.Add("en", en);
                }
                MaPalisija = new CompoundWord("ma-Palisija");

                Dictionary.Add("ma-Palisija", MaPalisija);
                Glosses.Add("ma-Palisija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Pontepeta", new[] { "Pontevedra" });
                    glossMap.Add("en", en);
                }
                MaTomoPontepeta = new CompoundWord("ma-tomo-Pontepeta");

                Dictionary.Add("ma-tomo-Pontepeta", MaTomoPontepeta);
                Glosses.Add("ma-tomo-Pontepeta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Mapi", new[] { "Madrid" });
                    glossMap.Add("en", en);
                }
                MaTomoMapi = new CompoundWord("ma-tomo-Mapi");

                Dictionary.Add("ma-tomo-Mapi", MaTomoMapi);
                Glosses.Add("ma-tomo-Mapi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Kapulu", new[] { "Kabul" });
                    glossMap.Add("en", en);
                }
                MaTomoKapulu = new CompoundWord("ma-tomo-Kapulu");

                Dictionary.Add("ma-tomo-Kapulu", MaTomoKapulu);
                Glosses.Add("ma-tomo-Kapulu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Katepu", new[] { "Cardiff" });
                    glossMap.Add("en", en);
                }
                MaTomoKatepu = new CompoundWord("ma-tomo-Katepu");

                Dictionary.Add("ma-tomo-Katepu", MaTomoKatepu);
                Glosses.Add("ma-tomo-Katepu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Ofo", new[] { "Oxford" });
                    glossMap.Add("en", en);
                }
                MaTomoOfo = new CompoundWord("ma-tomo-Ofo");

                Dictionary.Add("ma-tomo-Ofo", MaTomoOfo);
                Glosses.Add("ma-tomo-Ofo", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("Mila", new[] { "Mira Anonen" });
            //        glossMap.Add("en", en);
            //    }
            //    Mila = new CompoundWord("Mila");

            //    Dictionary.Add("Mila", Mila);
            //    Glosses.Add("Mila", glossMap);
            //}


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("Tulo", new[] { "Tulio Flores" });
            //        glossMap.Add("en", en);
            //    }
            //    Tulo = new CompoundWord("Tulo");

            //    Dictionary.Add("Tulo", Tulo);
            //    Glosses.Add("Tulo", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-Tatesen", new[] { "Dao De Jing" });
                    glossMap.Add("en", en);
                }
                LipuTatesen = new CompoundWord("lipu-Tatesen");

                Dictionary.Add("lipu-Tatesen", LipuTatesen);
                Glosses.Add("lipu-Tatesen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-Pipija", new[] { "Bible" });
                    glossMap.Add("en", en);
                }
                LipuPipija = new CompoundWord("lipu-Pipija");

                Dictionary.Add("lipu-Pipija", LipuPipija);
                Glosses.Add("lipu-Pipija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-Pakawakita", new[] { "Bhagavadgita" });
                    glossMap.Add("en", en);
                }
                LipuPakawakita = new CompoundWord("lipu-Pakawakita");

                Dictionary.Add("lipu-Pakawakita", LipuPakawakita);
                Glosses.Add("lipu-Pakawakita", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sewi-Jawe", new[] { "Jehovah" });
                    glossMap.Add("en", en);
                }
                JanSewiJawe = new CompoundWord("jan-sewi-Jawe");

                Dictionary.Add("jan-sewi-Jawe", JanSewiJawe);
                Glosses.Add("jan-sewi-Jawe", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mama-Mewi", new[] { "Mary" });
                    glossMap.Add("en", en);
                }
                MamaMewi = new CompoundWord("mama-Mewi");

                Dictionary.Add("mama-Mewi", MamaMewi);
                Glosses.Add("mama-Mewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-Pison", new[] { "River Pishon" });
                    glossMap.Add("en", en);
                }
                TeloPison = new CompoundWord("telo-Pison");

                Dictionary.Add("telo-Pison", TeloPison);
                Glosses.Add("telo-Pison", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kevilatu", new[] { "Havilah" });
                    glossMap.Add("en", en);
                }
                MaKevilatu = new CompoundWord("ma-Kevilatu");

                Dictionary.Add("ma-Kevilatu", MaKevilatu);
                Glosses.Add("ma-Kevilatu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-Kekon", new[] { "Gihon" });
                    glossMap.Add("en", en);
                }
                TeloKekon = new CompoundWord("telo-Kekon");

                Dictionary.Add("telo-Kekon", TeloKekon);
                Glosses.Add("telo-Kekon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-Tikisu", new[] { "Tigris" });
                    glossMap.Add("en", en);
                }
                TeloTikisu = new CompoundWord("telo-Tikisu");

                Dictionary.Add("telo-Tikisu", TeloTikisu);
                Glosses.Add("telo-Tikisu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-Elupatu", new[] { "Euphrates" });
                    glossMap.Add("en", en);
                }
                TeloElupatu = new CompoundWord("telo-Elupatu");

                Dictionary.Add("telo-Elupatu", TeloElupatu);
                Glosses.Add("telo-Elupatu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-Son", new[] { "Psalms" });
                    glossMap.Add("en", en);
                }
                LipuSon = new CompoundWord("lipu-Son");

                Dictionary.Add("lipu-Son", LipuSon);
                Glosses.Add("lipu-Son", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-Pajaje", new[] { "Baha'i" });
                    glossMap.Add("en", en);
                }
                NasinPajaje = new CompoundWord("nasin-Pajaje");

                Dictionary.Add("nasin-Pajaje", NasinPajaje);
                Glosses.Add("nasin-Pajaje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Losupan", new[] { "Lojban" });
                    glossMap.Add("en", en);
                }
                TokiLosupan = new CompoundWord("toki-Losupan");

                Dictionary.Add("toki-Losupan", TokiLosupan);
                Glosses.Add("toki-Losupan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-kiwen-Pilene", new[] { "Pyrenese" });
                    glossMap.Add("en", en);
                }
                NenaKiwenPilene = new CompoundWord("nena-kiwen-Pilene");

                Dictionary.Add("nena-kiwen-Pilene", NenaKiwenPilene);
                Glosses.Add("nena-kiwen-Pilene", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nanpa-lili", new[] { "very few" });
                    glossMap.Add("en", en);
                }
                NanpaLili = new CompoundWord("nanpa-lili");

                Dictionary.Add("nanpa-lili", NanpaLili);
                Glosses.Add("nanpa-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nanpa-seme", new[] { "How many times" });
                    glossMap.Add("en", en);
                }
                NanpaSeme = new CompoundWord("nanpa-seme");

                Dictionary.Add("nanpa-seme", NanpaSeme);
                Glosses.Add("nanpa-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nanpa-weka", new[] { "zero" });
                    glossMap.Add("en", en);
                }
                NanpaWeka = new CompoundWord("nanpa-weka");

                Dictionary.Add("nanpa-weka", NanpaWeka);
                Glosses.Add("nanpa-weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nanpa-wile", new[] { "sufficient", " enough" });
                    glossMap.Add("en", en);
                }
                NanpaWile = new CompoundWord("nanpa-wile");

                Dictionary.Add("nanpa-wile", NanpaWile);
                Glosses.Add("nanpa-wile", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pi-nanpa-wan", new[] { "the first time", " first" });
                    glossMap.Add("en", en);
                }
                TenpoPiNanpaWan = new CompoundWord("tenpo-pi-nanpa-wan");

                Dictionary.Add("tenpo-pi-nanpa-wan", TenpoPiNanpaWan);
                Glosses.Add("tenpo-pi-nanpa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasa-ike", new[] { "raving mad", " demented" });
                    glossMap.Add("en", en);
                }
                NasaIke = new CompoundWord("nasa-ike");

                Dictionary.Add("nasa-ike", NasaIke);
                Glosses.Add("nasa-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasa-nanpa", new[] { "complexity" });
                    glossMap.Add("en", en);
                }
                NasaNanpa = new CompoundWord("nasa-nanpa");

                Dictionary.Add("nasa-nanpa", NasaNanpa);
                Glosses.Add("nasa-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasa-pona", new[] { "Party on!" });
                    glossMap.Add("en", en);
                }
                NasaPona = new CompoundWord("nasa-pona");

                Dictionary.Add("nasa-pona", NasaPona);
                Glosses.Add("nasa-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-nasa", new[] { "drunk", " high" });
                    glossMap.Add("en", en);
                }
                PilinNasa = new CompoundWord("pilin-nasa");

                Dictionary.Add("pilin-nasa", PilinNasa);
                Glosses.Add("pilin-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-nasa", new[] { "alcohol", " alcoholic beverage" });
                    glossMap.Add("en", en);
                }
                TeloNasa = new CompoundWord("telo-nasa");

                Dictionary.Add("telo-nasa", TeloNasa);
                Glosses.Add("telo-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("unpa-nasa", new[] { "kinky sex" });
                    glossMap.Add("en", en);
                }
                UnpaNasa = new CompoundWord("unpa-nasa");

                Dictionary.Add("unpa-nasa", UnpaNasa);
                Glosses.Add("unpa-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-kama", new[] { "means of travel", " right (side)" });
                    glossMap.Add("en", en);
                }
                NasinKama = new CompoundWord("nasin-kama");

                Dictionary.Add("nasin-kama", NasinKama);
                Glosses.Add("nasin-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-kama-pi-tawa-suno", new[] { "north" });
                    glossMap.Add("en", en);
                }
                NasinKamaPiTawaSuno = new CompoundWord("nasin-kama-pi-tawa-suno");

                Dictionary.Add("nasin-kama-pi-tawa-suno", NasinKamaPiTawaSuno);
                Glosses.Add("nasin-kama-pi-tawa-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-Katolike", new[] { "Catholicism" });
                    glossMap.Add("en", en);
                }
                NasinKatolike = new CompoundWord("nasin-Katolike");

                Dictionary.Add("nasin-Katolike", NasinKatolike);
                Glosses.Add("nasin-Katolike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-kulupu", new[] { "rules", " customs", " discipline" });
                    glossMap.Add("en", en);
                }
                NasinKulupu = new CompoundWord("nasin-kulupu");

                Dictionary.Add("nasin-kulupu", NasinKulupu);
                Glosses.Add("nasin-kulupu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-lawa", new[] { "rights", " law", " legislation", " law enforecemnt" });
                    glossMap.Add("en", en);
                }
                NasinLawa = new CompoundWord("nasin-lawa");

                Dictionary.Add("nasin-lawa", NasinLawa);
                Glosses.Add("nasin-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-lukin", new[] { "shape", " ways of looking/seeing", " stairway" });
                    glossMap.Add("en", en);
                }
                NasinLukin = new CompoundWord("nasin-lukin");

                Dictionary.Add("nasin-lukin", NasinLukin);
                Glosses.Add("nasin-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-lukin-pi-lipu-sona", new[] { "browser (the program)" });
                    glossMap.Add("en", en);
                }
                NasinLukinPiLipuSona = new CompoundWord("nasin-lukin-pi-lipu-sona");

                Dictionary.Add("nasin-lukin-pi-lipu-sona", NasinLukinPiLipuSona);
                Glosses.Add("nasin-lukin-pi-lipu-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-ma", new[] { "national agenda", " national habits" });
                    glossMap.Add("en", en);
                }
                NasinMa = new CompoundWord("nasin-ma");

                Dictionary.Add("nasin-ma", NasinMa);
                Glosses.Add("nasin-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-mani", new[] { "Capitalism", " capitalism" });
                    glossMap.Add("en", en);
                }
                NasinMani = new CompoundWord("nasin-mani");

                Dictionary.Add("nasin-mani", NasinMani);
                Glosses.Add("nasin-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-musi", new[] { "hedonism" });
                    glossMap.Add("en", en);
                }
                NasinMusi = new CompoundWord("nasin-musi");

                Dictionary.Add("nasin-musi", NasinMusi);
                Glosses.Add("nasin-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pali", new[] { "Communism", " Creativity" });
                    glossMap.Add("en", en);
                }
                NasinPali = new CompoundWord("nasin-pali");

                Dictionary.Add("nasin-pali", NasinPali);
                Glosses.Add("nasin-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pi-jan-Nijon-sama-nasin-pi-jan-ali", new[] { "Japanese ways are the same as those of everybody" });
                    glossMap.Add("en", en);
                }
                NasinPiJanNijonSamaNasinPiJanAli = new CompoundWord("nasin-pi-jan-Nijon-sama-nasin-pi-jan-ali");

                Dictionary.Add("nasin-pi-jan-Nijon-sama-nasin-pi-jan-ali", NasinPiJanNijonSamaNasinPiJanAli);
                Glosses.Add("nasin-pi-jan-Nijon-sama-nasin-pi-jan-ali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pi-jan-sewi-ala", new[] { "atheism" });
                    glossMap.Add("en", en);
                }
                NasinPiJanSewiAla = new CompoundWord("nasin-pi-jan-sewi-ala");

                Dictionary.Add("nasin-pi-jan-sewi-ala", NasinPiJanSewiAla);
                Glosses.Add("nasin-pi-jan-sewi-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pi-kama-suno", new[] { "east" });
                    glossMap.Add("en", en);
                }
                NasinPiKamaSuno = new CompoundWord("nasin-pi-kama-suno");

                Dictionary.Add("nasin-pi-kama-suno", NasinPiKamaSuno);
                Glosses.Add("nasin-pi-kama-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pi-lawa-ala", new[] { "Anarchhism" });
                    glossMap.Add("en", en);
                }
                NasinPiLawaAla = new CompoundWord("nasin-pi-lawa-ala");

                Dictionary.Add("nasin-pi-lawa-ala", NasinPiLawaAla);
                Glosses.Add("nasin-pi-lawa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pini", new[] { "left (side)" });
                    glossMap.Add("en", en);
                }
                NasinPini = new CompoundWord("nasin-pini");

                Dictionary.Add("nasin-pini", NasinPini);
                Glosses.Add("nasin-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pini-pi-tawa-suno", new[] { "south" });
                    glossMap.Add("en", en);
                }
                NasinPiniPiTawaSuno = new CompoundWord("nasin-pini-pi-tawa-suno");

                Dictionary.Add("nasin-pini-pi-tawa-suno", NasinPiniPiTawaSuno);
                Glosses.Add("nasin-pini-pi-tawa-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pona", new[] { "Tao", " Dao; simple or good path", " suitable means", " taoism" });
                    glossMap.Add("en", en);
                }
                NasinPona = new CompoundWord("nasin-pona");

                Dictionary.Add("nasin-pona", NasinPona);
                Glosses.Add("nasin-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pona-Juju", new[] { "Unitarian Universalism" });
                    glossMap.Add("en", en);
                }
                NasinPonaJuju = new CompoundWord("nasin-pona-Juju");

                Dictionary.Add("nasin-pona-Juju", NasinPonaJuju);
                Glosses.Add("nasin-pona-Juju", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pona-Lasapali", new[] { "Rastafarianism" });
                    glossMap.Add("en", en);
                }
                NasinPonaLasapali = new CompoundWord("nasin-pona-Lasapali");

                Dictionary.Add("nasin-pona-Lasapali", NasinPonaLasapali);
                Glosses.Add("nasin-pona-Lasapali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pona-pi-ilo-len", new[] { "good way …" });
                    glossMap.Add("en", en);
                }
                NasinPonaPiIloLen = new CompoundWord("nasin-pona-pi-ilo-len");

                Dictionary.Add("nasin-pona-pi-ilo-len", NasinPonaPiIloLen);
                Glosses.Add("nasin-pona-pi-ilo-len", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sewi", new[] { "religion", " spiritual path", " relgion", " path of righteousness" });
                    glossMap.Add("en", en);
                }
                NasinSewi = new CompoundWord("nasin-sewi");

                Dictionary.Add("nasin-sewi", NasinSewi);
                Glosses.Add("nasin-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sewi-Jawatu", new[] { "Judaism" });
                    glossMap.Add("en", en);
                }
                NasinSewiJawatu = new CompoundWord("nasin-sewi-Jawatu");

                Dictionary.Add("nasin-sewi-Jawatu", NasinSewiJawatu);
                Glosses.Add("nasin-sewi-Jawatu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sewi-Kolisu", new[] { "Christianity" });
                    glossMap.Add("en", en);
                }
                NasinSewiKolisu = new CompoundWord("nasin-sewi-Kolisu");

                Dictionary.Add("nasin-sewi-Kolisu", NasinSewiKolisu);
                Glosses.Add("nasin-sewi-Kolisu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sewi-ma", new[] { "Earth religions", " Native American religion" });
                    glossMap.Add("en", en);
                }
                NasinSewiMa = new CompoundWord("nasin-sewi-ma");

                Dictionary.Add("nasin-sewi-ma", NasinSewiMa);
                Glosses.Add("nasin-sewi-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sewi-Puta", new[] { "Buddhism" });
                    glossMap.Add("en", en);
                }
                NasinSewiPuta = new CompoundWord("nasin-sewi-Puta");

                Dictionary.Add("nasin-sewi-Puta", NasinSewiPuta);
                Glosses.Add("nasin-sewi-Puta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sewi-Silami", new[] { "Islam" });
                    glossMap.Add("en", en);
                }
                NasinSewiSilami = new CompoundWord("nasin-sewi-Silami");

                Dictionary.Add("nasin-sewi-Silami", NasinSewiSilami);
                Glosses.Add("nasin-sewi-Silami", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sinpin", new[] { "vertical" });
                    glossMap.Add("en", en);
                }
                NasinSinpin = new CompoundWord("nasin-sinpin");

                Dictionary.Add("nasin-sinpin", NasinSinpin);
                Glosses.Add("nasin-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sitelen", new[] { "(hand) writing (result not act)", " writing system (alphabet", " etc.)" });
                    glossMap.Add("en", en);
                }
                NasinSitelen = new CompoundWord("nasin-sitelen");

                Dictionary.Add("nasin-sitelen", NasinSitelen);
                Glosses.Add("nasin-sitelen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-suli", new[] { "street", " avenue", " boulevard", " Highway" });
                    glossMap.Add("en", en);
                }
                NasinSuli = new CompoundWord("nasin-suli");

                Dictionary.Add("nasin-suli", NasinSuli);
                Glosses.Add("nasin-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-supa", new[] { "horizontal" });
                    glossMap.Add("en", en);
                }
                NasinSupa = new CompoundWord("nasin-supa");

                Dictionary.Add("nasin-supa", NasinSupa);
                Glosses.Add("nasin-supa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-tawa", new[] { "reoa travelled" });
                    glossMap.Add("en", en);
                }
                NasinTawa = new CompoundWord("nasin-tawa");

                Dictionary.Add("nasin-tawa", NasinTawa);
                Glosses.Add("nasin-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-toki", new[] { "system of language", " grammar (phrase structure)", " idiom" });
                    glossMap.Add("en", en);
                }
                NasinToki = new CompoundWord("nasin-toki");

                Dictionary.Add("nasin-toki", NasinToki);
                Glosses.Add("nasin-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-wawa", new[] { "Shamanism", " White magic" });
                    glossMap.Add("en", en);
                }
                NasinWawa = new CompoundWord("nasin-wawa");

                Dictionary.Add("nasin-wawa", NasinWawa);
                Glosses.Add("nasin-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-weka", new[] { "straight", " direct path", "road" });
                    glossMap.Add("en", en);
                }
                NasinWeka = new CompoundWord("nasin-weka");

                Dictionary.Add("nasin-weka", NasinWeka);
                Glosses.Add("nasin-weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-weka-linja", new[] { "straight", " direct path", "road" });
                    glossMap.Add("en", en);
                }
                NasinWekaLinja = new CompoundWord("nasin-weka-linja");

                Dictionary.Add("nasin-weka-linja", NasinWekaLinja);
                Glosses.Add("nasin-weka-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-nasin-sewi", new[] { "church", " mosque", " temple", " etc." });
                    glossMap.Add("en", en);
                }
                TomoPiNasinSewi = new CompoundWord("tomo-pi-nasin-sewi");

                Dictionary.Add("tomo-pi-nasin-sewi", TomoPiNasinSewi);
                Glosses.Add("tomo-pi-nasin-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-lawa", new[] { "nose" });
                    glossMap.Add("en", en);
                }
                NenaLawa = new CompoundWord("nena-lawa");

                Dictionary.Add("nena-lawa", NenaLawa);
                Glosses.Add("nena-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-nena", new[] { "mountainous area", " the mountains" });
                    glossMap.Add("en", en);
                }
                MaNena = new CompoundWord("ma-nena");

                Dictionary.Add("ma-nena", MaNena);
                Glosses.Add("ma-nena", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-kute", new[] { "ear" });
                    glossMap.Add("en", en);
                }
                NenaKute = new CompoundWord("nena-kute");

                Dictionary.Add("nena-kute", NenaKute);
                Glosses.Add("nena-kute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-mama", new[] { "breasts" });
                    glossMap.Add("en", en);
                }
                NenaMama = new CompoundWord("nena-mama");

                Dictionary.Add("nena-mama", NenaMama);
                Glosses.Add("nena-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-meli", new[] { "breasts" });
                    glossMap.Add("en", en);
                }
                NenaMeli = new CompoundWord("nena-meli");

                Dictionary.Add("nena-meli", NenaMeli);
                Glosses.Add("nena-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-palisa", new[] { "trunk (of elephant)" });
                    glossMap.Add("en", en);
                }
                NenaPalisa = new CompoundWord("nena-palisa");

                Dictionary.Add("nena-palisa", NenaPalisa);
                Glosses.Add("nena-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-unpa-meli", new[] { "clitoris" });
                    glossMap.Add("en", en);
                }
                NenaUnpaMeli = new CompoundWord("nena-unpa-meli");

                Dictionary.Add("nena-unpa-meli", NenaUnpaMeli);
                Glosses.Add("nena-unpa-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pini-pi-nena-mama", new[] { "nipple" });
                    glossMap.Add("en", en);
                }
                PiniPiNenaMama = new CompoundWord("pini-pi-nena-mama");

                Dictionary.Add("pini-pi-nena-mama", PiniPiNenaMama);
                Glosses.Add("pini-pi-nena-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ni-ali", new[] { "all these here" });
                    glossMap.Add("en", en);
                }
                NiAli = new CompoundWord("ni-ali");

                Dictionary.Add("ni-ali", NiAli);
                Glosses.Add("ni-ali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-ni", new[] { "now", " the present", "at that time" });
                    glossMap.Add("en", en);
                }
                TenpoNi = new CompoundWord("tenpo-ni");

                Dictionary.Add("tenpo-ni", TenpoNi);
                Glosses.Add("tenpo-ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pimeja-ni", new[] { "tonight" });
                    glossMap.Add("en", en);
                }
                TenpoPimejaNi = new CompoundWord("tenpo-pimeja-ni");

                Dictionary.Add("tenpo-pimeja-ni", TenpoPimejaNi);
                Glosses.Add("tenpo-pimeja-ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-ante", new[] { "modifier", " adjective" });
                    glossMap.Add("en", en);
                }
                NimiAnte = new CompoundWord("nimi-ante");

                Dictionary.Add("nimi-ante", NimiAnte);
                Glosses.Add("nimi-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-ante-sinpin", new[] { "pseudo preposition" });
                    glossMap.Add("en", en);
                }
                NimiAnteSinpin = new CompoundWord("nimi-ante-sinpin");

                Dictionary.Add("nimi-ante-sinpin", NimiAnteSinpin);
                Glosses.Add("nimi-ante-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-jan", new[] { "first name" });
                    glossMap.Add("en", en);
                }
                NimiJan = new CompoundWord("nimi-jan");

                Dictionary.Add("nimi-jan", NimiJan);
                Glosses.Add("nimi-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-lili", new[] { "preposition" });
                    glossMap.Add("en", en);
                }
                NimiLili = new CompoundWord("nimi-lili");

                Dictionary.Add("nimi-lili", NimiLili);
                Glosses.Add("nimi-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-pali", new[] { "verb" });
                    glossMap.Add("en", en);
                }
                NimiPali = new CompoundWord("nimi-pali");

                Dictionary.Add("nimi-pali", NimiPali);
                Glosses.Add("nimi-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-pali-ante", new[] { "transitive verb" });
                    glossMap.Add("en", en);
                }
                NimiPaliAnte = new CompoundWord("nimi-pali-ante");

                Dictionary.Add("nimi-pali-ante", NimiPaliAnte);
                Glosses.Add("nimi-pali-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-pali-pi-ante-ala", new[] { "intransitive verb" });
                    glossMap.Add("en", en);
                }
                NimiPaliPiAnteAla = new CompoundWord("nimi-pali-pi-ante-ala");

                Dictionary.Add("nimi-pali-pi-ante-ala", NimiPaliPiAnteAla);
                Glosses.Add("nimi-pali-pi-ante-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-pi-pali-ala", new[] { "non verb", " other kind of word" });
                    glossMap.Add("en", en);
                }
                NimiPiPaliAla = new CompoundWord("nimi-pi-pali-ala");

                Dictionary.Add("nimi-pi-pali-ala", NimiPiPaliAla);
                Glosses.Add("nimi-pi-pali-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-sina-o-sewi", new[] { "Hallowed be your name" });
                    glossMap.Add("en", en);
                }
                NimiSinaOSewi = new CompoundWord("nimi-sina-o-sewi");

                Dictionary.Add("nimi-sina-o-sewi", NimiSinaOSewi);
                Glosses.Add("nimi-sina-o-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-sinpin", new[] { "preposition", " neologism" });
                    glossMap.Add("en", en);
                }
                NimiSinpin = new CompoundWord("nimi-sinpin");

                Dictionary.Add("nimi-sinpin", NimiSinpin);
                Glosses.Add("nimi-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-suli", new[] { "proper name" });
                    glossMap.Add("en", en);
                }
                NimiSuli = new CompoundWord("nimi-suli");

                Dictionary.Add("nimi-suli", NimiSuli);
                Glosses.Add("nimi-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-toki", new[] { "word spoken" });
                    glossMap.Add("en", en);
                }
                NimiToki = new CompoundWord("nimi-toki");

                Dictionary.Add("nimi-toki", NimiToki);
                Glosses.Add("nimi-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-olin", new[] { "wife", " girlfriend" });
                    glossMap.Add("en", en);
                }
                MeliOlin = new CompoundWord("meli-olin");

                Dictionary.Add("meli-olin", MeliOlin);
                Glosses.Add("meli-olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mije-olin", new[] { "husband", " boyfriend" });
                    glossMap.Add("en", en);
                }
                MijeOlin = new CompoundWord("mije-olin");

                Dictionary.Add("mije-olin", MijeOlin);
                Glosses.Add("mije-olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("olin-suli", new[] { "perpetual devotion" });
                    glossMap.Add("en", en);
                }
                OlinSuli = new CompoundWord("olin-suli");

                Dictionary.Add("olin-suli", OlinSuli);
                Glosses.Add("olin-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-olin", new[] { "adore", " be devoted to", " devotion" });
                    glossMap.Add("en", en);
                }
                PaliOlin = new CompoundWord("pali-olin");

                Dictionary.Add("pali-olin", PaliOlin);
                Glosses.Add("pali-olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("open-ala", new[] { "close", " seal", " close (vt)" });
                    glossMap.Add("en", en);
                }
                OpenAla = new CompoundWord("open-ala");

                Dictionary.Add("open-ala", OpenAla);
                Glosses.Add("open-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("open-pi-sike-suno-sin", new[] { "birthday" });
                    glossMap.Add("en", en);
                }
                OpenPiSikeSunoSin = new CompoundWord("open-pi-sike-suno-sin");

                Dictionary.Add("open-pi-sike-suno-sin", OpenPiSikeSunoSin);
                Glosses.Add("open-pi-sike-suno-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("open-sinpin", new[] { "door in the side" });
                    glossMap.Add("en", en);
                }
                OpenSinpin = new CompoundWord("open-sinpin");

                Dictionary.Add("open-sinpin", OpenSinpin);
                Glosses.Add("open-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("open-suno", new[] { "sunrise", " dawn daybreak; east; right" });
                    glossMap.Add("en", en);
                }
                OpenSuno = new CompoundWord("open-suno");

                Dictionary.Add("open-suno", OpenSuno);
                Glosses.Add("open-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pakala-ala", new[] { "help", " assistance" });
                    glossMap.Add("en", en);
                }
                PakalaAla = new CompoundWord("pakala-ala");

                Dictionary.Add("pakala-ala", PakalaAla);
                Glosses.Add("pakala-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palaka-seli", new[] { "burn up (or down)" });
                    glossMap.Add("en", en);
                }
                PalakaSeli = new CompoundWord("palaka-seli");

                Dictionary.Add("palaka-seli", PalakaSeli);
                Glosses.Add("palaka-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-awen", new[] { "job", " employment" });
                    glossMap.Add("en", en);
                }
                PaliAwen = new CompoundWord("pali-awen");

                Dictionary.Add("pali-awen", PaliAwen);
                Glosses.Add("pali-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-e-ijo-tawa", new[] { "help" });
                    glossMap.Add("en", en);
                }
                PaliEIjoTawa = new CompoundWord("pali-e-ijo-tawa");

                Dictionary.Add("pali-e-ijo-tawa", PaliEIjoTawa);
                Glosses.Add("pali-e-ijo-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-e-moku", new[] { "do the cooking" });
                    glossMap.Add("en", en);
                }
                PaliEMoku = new CompoundWord("pali-e-moku");

                Dictionary.Add("pali-e-moku", PaliEMoku);
                Glosses.Add("pali-e-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-e-sike-mama", new[] { "lay an egg" });
                    glossMap.Add("en", en);
                }
                PaliESikeMama = new CompoundWord("pali-e-sike-mama");

                Dictionary.Add("pali-e-sike-mama", PaliESikeMama);
                Glosses.Add("pali-e-sike-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-e-soweli", new[] { "tend flocks" });
                    glossMap.Add("en", en);
                }
                PaliESoweli = new CompoundWord("pali-e-soweli");

                Dictionary.Add("pali-e-soweli", PaliESoweli);
                Glosses.Add("pali-e-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-e-toki-linja", new[] { "spin a yarn","tell a tale" });
                    glossMap.Add("en", en);
                }
                PaliETokiLinja = new CompoundWord("pali-e-toki-linja");

                Dictionary.Add("pali-e-toki-linja", PaliETokiLinja);
                Glosses.Add("pali-e-toki-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-e-uta-suwi", new[] { "smile" });
                    glossMap.Add("en", en);
                }
                PaliEUtaSuwi = new CompoundWord("pali-e-uta-suwi");

                Dictionary.Add("pali-e-uta-suwi", PaliEUtaSuwi);
                Glosses.Add("pali-e-uta-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-ike", new[] { "sin", " bad act" });
                    glossMap.Add("en", en);
                }
                PaliIke = new CompoundWord("pali-ike");

                Dictionary.Add("pali-ike", PaliIke);
                Glosses.Add("pali-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-insa-ma", new[] { "work the land" });
                    glossMap.Add("en", en);
                }
                PaliInsaMa = new CompoundWord("pali-insa-ma");

                Dictionary.Add("pali-insa-ma", PaliInsaMa);
                Glosses.Add("pali-insa-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-kalama-musi", new[] { "make music" });
                    glossMap.Add("en", en);
                }
                PaliKalamaMusi = new CompoundWord("pali-kalama-musi");

                Dictionary.Add("pali-kalama-musi", PaliKalamaMusi);
                Glosses.Add("pali-kalama-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-musi", new[] { "sports", " athletics", " work of art" });
                    glossMap.Add("en", en);
                }
                PaliMusi = new CompoundWord("pali-musi");

                Dictionary.Add("pali-musi", PaliMusi);
                Glosses.Add("pali-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-mute", new[] { "multiply", " increase", " karma" });
                    glossMap.Add("en", en);
                }
                PaliMute = new CompoundWord("pali-mute");

                Dictionary.Add("pali-mute", PaliMute);
                Glosses.Add("pali-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-mute-nanpa", new[] { "multiplication", " multiplier" });
                    glossMap.Add("en", en);
                }
                PaliMuteNanpa = new CompoundWord("pali-mute-nanpa");

                Dictionary.Add("pali-mute-nanpa", PaliMuteNanpa);
                Glosses.Add("pali-mute-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-nanpa", new[] { "mathematical operation", " aritmetical operations", " formulae" });
                    glossMap.Add("en", en);
                }
                PaliNanpa = new CompoundWord("pali-nanpa");

                Dictionary.Add("pali-nanpa", PaliNanpa);
                Glosses.Add("pali-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-nanpa-poka", new[] { "addition " });
                    glossMap.Add("en", en);
                }
                PaliNanpaPoka = new CompoundWord("pali-nanpa-poka");

                Dictionary.Add("pali-nanpa-poka", PaliNanpaPoka);
                Glosses.Add("pali-nanpa-poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-nanpa-tenpo", new[] { "multiplication " });
                    glossMap.Add("en", en);
                }
                PaliNanpaTenpo = new CompoundWord("pali-nanpa-tenpo");

                Dictionary.Add("pali-nanpa-tenpo", PaliNanpaTenpo);
                Glosses.Add("pali-nanpa-tenpo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-olin-tawa", new[] { "be devoted to" });
                    glossMap.Add("en", en);
                }
                PaliOlinTawa = new CompoundWord("pali-olin-tawa");

                Dictionary.Add("pali-olin-tawa", PaliOlinTawa);
                Glosses.Add("pali-olin-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-pi-ilo-nanpa", new[] { "computer work" });
                    glossMap.Add("en", en);
                }
                PaliPiIloNanpa = new CompoundWord("pali-pi-ilo-nanpa");

                Dictionary.Add("pali-pi-ilo-nanpa", PaliPiIloNanpa);
                Glosses.Add("pali-pi-ilo-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-pi-tomo-pi-telo-nasa", new[] { "bartender" });
                    glossMap.Add("en", en);
                }
                PaliPiTomoPiTeloNasa = new CompoundWord("pali-pi-tomo-pi-telo-nasa");

                Dictionary.Add("pali-pi-tomo-pi-telo-nasa", PaliPiTomoPiTeloNasa);
                Glosses.Add("pali-pi-tomo-pi-telo-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-pona-a", new[] { "nicely done!" });
                    glossMap.Add("en", en);
                }
                PaliPonaA = new CompoundWord("pali-pona-a");

                Dictionary.Add("pali-pona-a", PaliPonaA);
                Glosses.Add("pali-pona-a", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-sewi", new[] { "worship" });
                    glossMap.Add("en", en);
                }
                PaliSewi = new CompoundWord("pali-sewi");

                Dictionary.Add("pali-sewi", PaliSewi);
                Glosses.Add("pali-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-sewi-tawa", new[] { "worship" });
                    glossMap.Add("en", en);
                }
                PaliSewiTawa = new CompoundWord("pali-sewi-tawa");

                Dictionary.Add("pali-sewi-tawa", PaliSewiTawa);
                Glosses.Add("pali-sewi-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-sitelen", new[] { "try to write" });
                    glossMap.Add("en", en);
                }
                PaliSitelen = new CompoundWord("pali-sitelen");

                Dictionary.Add("pali-sitelen", PaliSitelen);
                Glosses.Add("pali-sitelen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("paliI-e-toki-pi-jan-sewi", new[] { "did what the Lord said" });
                    glossMap.Add("en", en);
                }
                PaliiETokiPiJanSewi = new CompoundWord("paliI-e-toki-pi-jan-sewi");

                Dictionary.Add("paliI-e-toki-pi-jan-sewi", PaliiETokiPiJanSewi);
                Glosses.Add("paliI-e-toki-pi-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pi-pali-lili", new[] { "easy" });
                    glossMap.Add("en", en);
                }
                PiPaliLili = new CompoundWord("pi-pali-lili");

                Dictionary.Add("pi-pali-lili", PiPaliLili);
                Glosses.Add("pi-pali-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pi-pali-mute", new[] { "difficult" });
                    glossMap.Add("en", en);
                }
                PiPaliMute = new CompoundWord("pi-pali-mute");

                Dictionary.Add("pi-pali-mute", PiPaliMute);
                Glosses.Add("pi-pali-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-pali", new[] { "easy", " easy (to do)" });
                    glossMap.Add("en", en);
                }
                PonaPali = new CompoundWord("pona-pali");

                Dictionary.Add("pona-pali", PonaPali);
                Glosses.Add("pona-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pali", new[] { "work(place)", " office", " factory" });
                    glossMap.Add("en", en);
                }
                TomoPali = new CompoundWord("tomo-pali");

                Dictionary.Add("tomo-pali", TomoPali);
                Glosses.Add("tomo-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-kasi", new[] { "cigarette" });
                    glossMap.Add("en", en);
                }
                PalisaKasi = new CompoundWord("palisa-kasi");

                Dictionary.Add("palisa-kasi", PalisaKasi);
                Glosses.Add("palisa-kasi", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("palisa-mije", new[] { "penis" });
            //        glossMap.Add("en", en);
            //    }
            //    PalisaMije = new CompoundWord("palisa-mije");

            //    Dictionary.Add("palisa-mije", PalisaMije);
            //    Glosses.Add("palisa-mije", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-kiwen-walo", new[] { "(rib)bone" });
                    glossMap.Add("en", en);
                }
                PalisaKiwenWalo = new CompoundWord("palisa-kiwen-walo");

                Dictionary.Add("palisa-kiwen-walo", PalisaKiwenWalo);
                Glosses.Add("palisa-kiwen-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-lawa", new[] { "shepherd's crook", " crozier" });
                    glossMap.Add("en", en);
                }
                PalisaLawa = new CompoundWord("palisa-lawa");

                Dictionary.Add("palisa-lawa", PalisaLawa);
                Glosses.Add("palisa-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-moli", new[] { "arrow" });
                    glossMap.Add("en", en);
                }
                PalisaMoli = new CompoundWord("palisa-moli");

                Dictionary.Add("palisa-moli", PalisaMoli);
                Glosses.Add("palisa-moli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-moli-lili", new[] { "coffin" });
                    glossMap.Add("en", en);
                }
                PalisaMoliLili = new CompoundWord("palisa-moli-lili");

                Dictionary.Add("palisa-moli-lili", PalisaMoliLili);
                Glosses.Add("palisa-moli-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-pi-kama-jo-kala", new[] { "fishing pole" });
                    glossMap.Add("en", en);
                }
                PalisaPiKamaJoKala = new CompoundWord("palisa-pi-kama-jo-kala");

                Dictionary.Add("palisa-pi-kama-jo-kala", PalisaPiKamaJoKala);
                Glosses.Add("palisa-pi-kama-jo-kala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-seli", new[] { "flaming sword" });
                    glossMap.Add("en", en);
                }
                PalisaSeli = new CompoundWord("palisa-seli");

                Dictionary.Add("palisa-seli", PalisaSeli);
                Glosses.Add("palisa-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-suli-utala", new[] { "spear" });
                    glossMap.Add("en", en);
                }
                PalisaSuliUtala = new CompoundWord("palisa-suli-utala");

                Dictionary.Add("palisa-suli-utala", PalisaSuliUtala);
                Glosses.Add("palisa-suli-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-tawa", new[] { "vibrating dildo", " arrow" });
                    glossMap.Add("en", en);
                }
                PalisaTawa = new CompoundWord("palisa-tawa");

                Dictionary.Add("palisa-tawa", PalisaTawa);
                Glosses.Add("palisa-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-uta", new[] { "tongue" });
                    glossMap.Add("en", en);
                }
                PalisaUta = new CompoundWord("palisa-uta");

                Dictionary.Add("palisa-uta", PalisaUta);
                Glosses.Add("palisa-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-e-palisa-uta-lon", new[] { "lick" });
                    glossMap.Add("en", en);
                }
                PanaEPalisaUtaLon = new CompoundWord("pana-e-palisa-uta-lon");

                Dictionary.Add("pana-e-palisa-uta-lon", PanaEPalisaUtaLon);
                Glosses.Add("pana-e-palisa-uta-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-uta-lon-palisa", new[] { "fellate" });
                    glossMap.Add("en", en);
                }
                PanaUtaLonPalisa = new CompoundWord("pana-uta-lon-palisa");

                Dictionary.Add("pana-uta-lon-palisa", PanaUtaLonPalisa);
                Glosses.Add("pana-uta-lon-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pini-palisa", new[] { "glans", " head of penis" });
                    glossMap.Add("en", en);
                }
                PiniPalisa = new CompoundWord("pini-palisa");

                Dictionary.Add("pini-palisa", PiniPalisa);
                Glosses.Add("pini-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("selo-lon-pini-palisa", new[] { "foreskin" });
                    glossMap.Add("en", en);
                }
                SeloLonPiniPalisa = new CompoundWord("selo-lon-pini-palisa");

                Dictionary.Add("selo-lon-pini-palisa", SeloLonPiniPalisa);
                Glosses.Add("selo-lon-pini-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-awen", new[] { "attach", " tie", " bind", " affix" });
                    glossMap.Add("en", en);
                }
                PanaAwen = new CompoundWord("pana-awen");

                Dictionary.Add("pana-awen", PanaAwen);
                Glosses.Add("pana-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-lon", new[] { "rescue" });
                    glossMap.Add("en", en);
                }
                PanaLon = new CompoundWord("pana-lon");

                Dictionary.Add("pana-lon", PanaLon);
                Glosses.Add("pana-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-lukin", new[] { "touch" });
                    glossMap.Add("en", en);
                }
                PanaLukin = new CompoundWord("pana-lukin");

                Dictionary.Add("pana-lukin", PanaLukin);
                Glosses.Add("pana-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-nasin-pona-tawa", new[] { "bless" });
                    glossMap.Add("en", en);
                }
                PanaNasinPonaTawa = new CompoundWord("pana-nasin-pona-tawa");

                Dictionary.Add("pana-nasin-pona-tawa", PanaNasinPonaTawa);
                Glosses.Add("pana-nasin-pona-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-pi-toki-sewi", new[] { "praying, Preaching, prophesying" });
                    glossMap.Add("en", en);
                }
                PanaPiTokiSewi = new CompoundWord("pana-pi-toki-sewi");

                Dictionary.Add("pana-pi-toki-sewi", PanaPiTokiSewi);
                Glosses.Add("pana-pi-toki-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-poka", new[] { "bring together" });
                    glossMap.Add("en", en);
                }
                PanaPoka = new CompoundWord("pana-poka");

                Dictionary.Add("pana-poka", PanaPoka);
                Glosses.Add("pana-poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-sewi", new[] { "cleaning" });
                    glossMap.Add("en", en);
                }
                PanaSewi = new CompoundWord("pana-sewi");

                Dictionary.Add("pana-sewi", PanaSewi);
                Glosses.Add("pana-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-sina", new[] { "take" });
                    glossMap.Add("en", en);
                }
                PanaSina = new CompoundWord("pana-sina");

                Dictionary.Add("pana-sina", PanaSina);
                Glosses.Add("pana-sina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-tawa", new[] { "allot", " bring" });
                    glossMap.Add("en", en);
                }
                PanaTawa = new CompoundWord("pana-tawa");

                Dictionary.Add("pana-tawa", PanaTawa);
                Glosses.Add("pana-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-toki", new[] { "translate", " translation" });
                    glossMap.Add("en", en);
                }
                PanaToki = new CompoundWord("pana-toki");

                Dictionary.Add("pana-toki", PanaToki);
                Glosses.Add("pana-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-wawa", new[] { "sadomasochism" });
                    glossMap.Add("en", en);
                }
                PanaWawa = new CompoundWord("pana-wawa");

                Dictionary.Add("pana-wawa", PanaWawa);
                Glosses.Add("pana-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-ala", new[] { "invisible" });
                    glossMap.Add("en", en);
                }
                PiLukinAla = new CompoundWord("lukin-ala");

                Dictionary.Add("lukin-ala", PiLukinAla);
                Glosses.Add("lukin-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pi-mute-seme", new[] { "How much" });
                    glossMap.Add("en", en);
                }
                PiMuteSeme = new CompoundWord("pi-mute-seme");

                Dictionary.Add("pi-mute-seme", PiMuteSeme);
                Glosses.Add("pi-mute-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pi-pona-mute", new[] { "better" });
                    glossMap.Add("en", en);
                }
                PiPonaMute = new CompoundWord("pi-pona-mute");

                Dictionary.Add("pi-pona-mute", PiPonaMute);
                Glosses.Add("pi-pona-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ala-lon-ale", new[] { "subdue all senses" });
                    glossMap.Add("en", en);
                }
                PilinAlaLonAle = new CompoundWord("pilin-ala-lon-ale");

                Dictionary.Add("pilin-ala-lon-ale", PilinAlaLonAle);
                Glosses.Add("pilin-ala-lon-ale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ale", new[] { "heart", " mind", " spirit", " feelings", "sense", " concept" });
                    glossMap.Add("en", en);
                }
                PilinAle = new CompoundWord("pilin-ale");

                Dictionary.Add("pilin-ale", PilinAle);
                Glosses.Add("pilin-ale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ali", new[] { "heart", " mind", " spirit", " feelings" });
                    glossMap.Add("en", en);
                }
                PilinAli = new CompoundWord("pilin-ali");

                Dictionary.Add("pilin-ali", PilinAli);
                Glosses.Add("pilin-ali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ante", new[] { "magical" });
                    glossMap.Add("en", en);
                }
                PilinAnte = new CompoundWord("pilin-ante");

                Dictionary.Add("pilin-ante", PilinAnte);
                Glosses.Add("pilin-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ike-lon-kulupu", new[] { "be timid/shy","timidity" });
                    glossMap.Add("en", en);
                }
                PilinIkeLonKulupu = new CompoundWord("pilin-ike-lon-kulupu");

                Dictionary.Add("pilin-ike-lon-kulupu", PilinIkeLonKulupu);
                Glosses.Add("pilin-ike-lon-kulupu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ike-mute", new[] { "be seriously ill" });
                    glossMap.Add("en", en);
                }
                PilinIkeMute = new CompoundWord("pilin-ike-mute");

                Dictionary.Add("pilin-ike-mute", PilinIkeMute);
                Glosses.Add("pilin-ike-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-ike-nanpa-luka-tu", new[] { "feel bad 7 times over (be punished…)" });
                    glossMap.Add("en", en);
                }
                PilinIkeNanpaLukaTu = new CompoundWord("pilin-ike-nanpa-luka-tu");

                Dictionary.Add("pilin-ike-nanpa-luka-tu", PilinIkeNanpaLukaTu);
                Glosses.Add("pilin-ike-nanpa-luka-tu", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("pilin-ike-tan", new[] { "fear" });
            //        glossMap.Add("en", en);
            //    }
            //    PilinIkeTan = new CompoundWord("pilin-ike-tan");

            //    Dictionary.Add("pilin-ike-tan", PilinIkeTan);
            //    Glosses.Add("pilin-ike-tan", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-lon", new[] { "think about" });
                    glossMap.Add("en", en);
                }
                PilinLon = new CompoundWord("pilin-lon");

                Dictionary.Add("pilin-lon", PilinLon);
                Glosses.Add("pilin-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-nasa-lawa", new[] { "be confuswed" });
                    glossMap.Add("en", en);
                }
                PilinNasaLawa = new CompoundWord("pilin-nasa-lawa");

                Dictionary.Add("pilin-nasa-lawa", PilinNasaLawa);
                Glosses.Add("pilin-nasa-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-pi-pali-pini-pakala", new[] { "regret", "regrets" });
                    glossMap.Add("en", en);
                }
                PilinPiPaliPiniPakala = new CompoundWord("pilin-pi-pali-pini-pakala");

                Dictionary.Add("pilin-pi-pali-pini-pakala", PilinPiPaliPiniPakala);
                Glosses.Add("pilin-pi-pali-pini-pakala", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("pilin-pi-pali-pini-pakala", new[] { "regrets" });
            //        glossMap.Add("en", en);
            //    }
            //    PilinPiPaliPiniPakala = new CompoundWord("pilin-pi-pali-pini-pakala");

            //    Dictionary.Add("pilin-pi-pali-pini-pakala", PilinPiPaliPiniPakala);
            //    Glosses.Add("pilin-pi-pali-pini-pakala", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-pona", new[] { "feel glad", " happy", " freedom", " pleasure", " fidelity", " trustworthiness" });
                    glossMap.Add("en", en);
                }
                PilinPona = new CompoundWord("pilin-pona");

                Dictionary.Add("pilin-pona", PilinPona);
                Glosses.Add("pilin-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-sama", new[] { "agree" });
                    glossMap.Add("en", en);
                }
                PilinSama = new CompoundWord("pilin-sama");

                Dictionary.Add("pilin-sama", PilinSama);
                Glosses.Add("pilin-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-sitelen", new[] { "literalist" });
                    glossMap.Add("en", en);
                }
                PilinSitelen = new CompoundWord("pilin-sitelen");

                Dictionary.Add("pilin-sitelen", PilinSitelen);
                Glosses.Add("pilin-sitelen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-wawa", new[] { "feel proud", " excited" });
                    glossMap.Add("en", en);
                }
                PilinWawa = new CompoundWord("pilin-wawa");

                Dictionary.Add("pilin-wawa", PilinWawa);
                Glosses.Add("pilin-wawa", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("sina-pilin-seme", new[] { "How are you  How are you feeling" });
            //        glossMap.Add("en", en);
            //    }
            //    SinaPilinSeme = new CompoundWord("sina-pilin-seme");
            //
            //    Dictionary.Add("sina-pilin-seme", SinaPilinSeme);
            //    Glosses.Add("sina-pilin-seme", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pimeja-loje", new[] { "brown" });
                    glossMap.Add("en", en);
                }
                PimejaLoje = new CompoundWord("pimeja-loje");

                Dictionary.Add("pimeja-loje", PimejaLoje);
                Glosses.Add("pimeja-loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pimeja-seli", new[] { "shadow" });
                    glossMap.Add("en", en);
                }
                PimejaSeli = new CompoundWord("pimeja-seli");

                Dictionary.Add("pimeja-seli", PimejaSeli);
                Glosses.Add("pimeja-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-pimeja-wawa-pi-tomo-tawa", new[] { "gasoline" });
                    glossMap.Add("en", en);
                }
                TeloPimejaWawaPiTomoTawa = new CompoundWord("telo-pimeja-wawa-pi-tomo-tawa");

                Dictionary.Add("telo-pimeja-wawa-pi-tomo-tawa", TeloPimejaWawaPiTomoTawa);
                Glosses.Add("telo-pimeja-wawa-pi-tomo-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-wawa-pi-tomo-tawa", new[] { "gasoline" });
                    glossMap.Add("en", en);
                }
                TeloWawaPiTomoTawa = new CompoundWord("telo-wawa-pi-tomo-tawa");

                Dictionary.Add("telo-wawa-pi-tomo-tawa", TeloWawaPiTomoTawa);
                Glosses.Add("telo-wawa-pi-tomo-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pimeja", new[] { "night" });
                    glossMap.Add("en", en);
                }
                TenpoPimeja = new CompoundWord("tenpo-pimeja");

                Dictionary.Add("tenpo-pimeja", TenpoPimeja);
                Glosses.Add("tenpo-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pimeja-pini", new[] { "last night" });
                    glossMap.Add("en", en);
                }
                TenpoPimejaPini = new CompoundWord("tenpo-pimeja-pini");

                Dictionary.Add("tenpo-pimeja-pini", TenpoPimejaPini);
                Glosses.Add("tenpo-pimeja-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pini-ni", new[] { "after that" });
                    glossMap.Add("en", en);
                }
                PiniNi = new CompoundWord("pini-ni");

                Dictionary.Add("pini-ni", PiniNi);
                Glosses.Add("pini-ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pini-suno", new[] { "sunset", " dusk", " evening; west", " left" });
                    glossMap.Add("en", en);
                }
                PiniSuno = new CompoundWord("pini-suno");

                Dictionary.Add("pini-suno", PiniSuno);
                Glosses.Add("pini-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pini", new[] { "past", " history", " the past" });
                    glossMap.Add("en", en);
                }
                TenpoPini = new CompoundWord("tenpo-pini");

                Dictionary.Add("tenpo-pini", TenpoPini);
                Glosses.Add("tenpo-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-kule", new[] { "butterflly", " butterfly" });
                    glossMap.Add("en", en);
                }
                PipiKule = new CompoundWord("pipi-kule");

                Dictionary.Add("pipi-kule", PipiKule);
                Glosses.Add("pipi-kule", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-loje", new[] { "cockroach" });
                    glossMap.Add("en", en);
                }
                PipiLoje = new CompoundWord("pipi-loje");

                Dictionary.Add("pipi-loje", PipiLoje);
                Glosses.Add("pipi-loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-lon-kasi", new[] { "grasshopper", " locust" });
                    glossMap.Add("en", en);
                }
                PipiLonKasi = new CompoundWord("pipi-lon-kasi");

                Dictionary.Add("pipi-lon-kasi", PipiLonKasi);
                Glosses.Add("pipi-lon-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-mute", new[] { "ant" });
                    glossMap.Add("en", en);
                }
                PipiMute = new CompoundWord("pipi-mute");

                Dictionary.Add("pipi-mute", PipiMute);
                Glosses.Add("pipi-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-pimeja-en-loje", new[] { "ladybird.bug" });
                    glossMap.Add("en", en);
                }
                PipiPimejaEnLoje = new CompoundWord("pipi-pimeja-en-loje");

                Dictionary.Add("pipi-pimeja-en-loje", PipiPimejaEnLoje);
                Glosses.Add("pipi-pimeja-en-loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-suwi", new[] { "grasshopper" });
                    glossMap.Add("en", en);
                }
                PipiSuwi = new CompoundWord("pipi-suwi");

                Dictionary.Add("pipi-suwi", PipiSuwi);
                Glosses.Add("pipi-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-ala", new[] { "without", " far", " not with" });
                    glossMap.Add("en", en);
                }
                PokaAla = new CompoundWord("poka-ala");

                Dictionary.Add("poka-ala", PokaAla);
                Glosses.Add("poka-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pi-nanpa-tu", new[] { "right side" });
                    glossMap.Add("en", en);
                }
                PokaPiNanpaTu = new CompoundWord("poka-pi-nanpa-tu");

                Dictionary.Add("poka-pi-nanpa-tu", PokaPiNanpaTu);
                Glosses.Add("poka-pi-nanpa-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pi-nanpa-wan", new[] { "left side" });
                    glossMap.Add("en", en);
                }
                PokaPiNanpaWan = new CompoundWord("poka-pi-nanpa-wan");

                Dictionary.Add("poka-pi-nanpa-wan", PokaPiNanpaWan);
                Glosses.Add("poka-pi-nanpa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pi-suno-kama", new[] { "right (side)" });
                    glossMap.Add("en", en);
                }
                PokaPiSunoKama = new CompoundWord("poka-pi-suno-kama");

                Dictionary.Add("poka-pi-suno-kama", PokaPiSunoKama);
                Glosses.Add("poka-pi-suno-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pi-suno-weka", new[] { "left (side)" });
                    glossMap.Add("en", en);
                }
                PokaPiSunoWeka = new CompoundWord("poka-pi-suno-weka");

                Dictionary.Add("poka-pi-suno-weka", PokaPiSunoWeka);
                Glosses.Add("poka-pi-suno-weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pilin", new[] { "left" });
                    glossMap.Add("en", en);
                }
                PokaPilin = new CompoundWord("poka-pilin");

                Dictionary.Add("poka-pilin", PokaPilin);
                Glosses.Add("poka-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pilin-ala", new[] { "right" });
                    glossMap.Add("en", en);
                }
                PokaPilinAla = new CompoundWord("poka-pilin-ala");

                Dictionary.Add("poka-pilin-ala", PokaPilinAla);
                Glosses.Add("poka-pilin-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-tawa", new[] { "near" });
                    glossMap.Add("en", en);
                }
                PokaTawa = new CompoundWord("poka-tawa");

                Dictionary.Add("poka-tawa", PokaTawa);
                Glosses.Add("poka-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-telo", new[] { "beach", " seashore" });
                    glossMap.Add("en", en);
                }
                PokaTelo = new CompoundWord("poka-telo");

                Dictionary.Add("poka-telo", PokaTelo);
                Glosses.Add("poka-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poki-kiwen-suli", new[] { "ark" });
                    glossMap.Add("en", en);
                }
                PokiKiwenSuli = new CompoundWord("poki-kiwen-suli");

                Dictionary.Add("poki-kiwen-suli", PokiKiwenSuli);
                Glosses.Add("poki-kiwen-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poki-pi-telo-seli", new[] { "bathtub", " bath tub" });
                    glossMap.Add("en", en);
                }
                PokiPiTeloSeli = new CompoundWord("poki-pi-telo-seli");

                Dictionary.Add("poki-pi-telo-seli", PokiPiTeloSeli);
                Glosses.Add("poki-pi-telo-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poki-sama-lipu", new[] { "plate (dining)" });
                    glossMap.Add("en", en);
                }
                PokiSamaLipu = new CompoundWord("poki-sama-lipu");

                Dictionary.Add("poki-sama-lipu", PokiSamaLipu);
                Glosses.Add("poki-sama-lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-pona", new[] { "Enjoy your meal", " bon appe'tit" });
                    glossMap.Add("en", en);
                }
                MokuPona = new CompoundWord("moku-pona");

                Dictionary.Add("moku-pona", MokuPona);
                Glosses.Add("moku-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-a", new[] { "Good!", " Super!" });
                    glossMap.Add("en", en);
                }
                PonaA = new CompoundWord("pona-a");

                Dictionary.Add("pona-a", PonaA);
                Glosses.Add("pona-a", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-ala", new[] { "difficult" });
                    glossMap.Add("en", en);
                }
                PonaAla = new CompoundWord("pona-ala");

                Dictionary.Add("pona-ala", PonaAla);
                Glosses.Add("pona-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-moku", new[] { "tasty", " delicious" });
                    glossMap.Add("en", en);
                }
                PonaMoku = new CompoundWord("pona-moku");

                Dictionary.Add("pona-moku", PonaMoku);
                Glosses.Add("pona-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-mute", new[] { "very simple", " favor" });
                    glossMap.Add("en", en);
                }
                PonaMute = new CompoundWord("pona-mute");

                Dictionary.Add("pona-mute", PonaMute);
                Glosses.Add("pona-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-nasa", new[] { "magical", " strangely different" });
                    glossMap.Add("en", en);
                }
                PonaNasa = new CompoundWord("pona-nasa");

                Dictionary.Add("pona-nasa", PonaNasa);
                Glosses.Add("pona-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-pilin", new[] { "sweet", " pleasant", " agreeable" });
                    glossMap.Add("en", en);
                }
                PonaPilin = new CompoundWord("pona-pilin");

                Dictionary.Add("pona-pilin", PonaPilin);
                Glosses.Add("pona-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-tawa-ala", new[] { "superfluous " });
                    glossMap.Add("en", en);
                }
                PonaTawaAla = new CompoundWord("pona-tawa-ala");

                Dictionary.Add("pona-tawa-ala", PonaTawaAla);
                Glosses.Add("pona-tawa-ala", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("pona-tawa-sina", new[] { "Thank you" });
            //        glossMap.Add("en", en);
            //    }
            //    PonaTawaSina = new CompoundWord("pona-tawa-sina");

            //    Dictionary.Add("pona-tawa-sina", PonaTawaSina);
            //    Glosses.Add("pona-tawa-sina", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-unpa", new[] { "sexy", " good in bed", " good lay" });
                    glossMap.Add("en", en);
                }
                PonaUnpa = new CompoundWord("pona-unpa");

                Dictionary.Add("pona-unpa", PonaUnpa);
                Glosses.Add("pona-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-pona", new[] { "Good bye!" });
                    glossMap.Add("en", en);
                }
                TawaPona = new CompoundWord("tawa-pona");

                Dictionary.Add("tawa-pona", TawaPona);
                Glosses.Add("tawa-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-sama", new[] { "sister" });
                    glossMap.Add("en", en);
                }
                MeliSama = new CompoundWord("meli-sama");

                Dictionary.Add("meli-sama", MeliSama);
                Glosses.Add("meli-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mije-sama", new[] { "brother" });
                    glossMap.Add("en", en);
                }
                MijeSama = new CompoundWord("mije-sama");

                Dictionary.Add("mije-sama", MijeSama);
                Glosses.Add("mije-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sama-ala", new[] { "different", " not same" });
                    glossMap.Add("en", en);
                }
                SamaAla = new CompoundWord("sama-ala");

                Dictionary.Add("sama-ala", SamaAla);
                Glosses.Add("sama-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sama-poka-kalama-musi", new[] { "keep/be in time with the music" });
                    glossMap.Add("en", en);
                }
                SamaPokaKalamaMusi = new CompoundWord("sama-poka-kalama-musi");

                Dictionary.Add("sama-poka-kalama-musi", SamaPokaKalamaMusi);
                Glosses.Add("sama-poka-kalama-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("unpa-sama-soweli", new[] { "doggy style" });
                    glossMap.Add("en", en);
                }
                UnpaSamaSoweli = new CompoundWord("unpa-sama-soweli");

                Dictionary.Add("unpa-sama-soweli", UnpaSamaSoweli);
                Glosses.Add("unpa-sama-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("seli-lili", new[] { "warm" });
                    glossMap.Add("en", en);
                }
                SeliLili = new CompoundWord("seli-lili");

                Dictionary.Add("seli-lili", SeliLili);
                Glosses.Add("seli-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-seli-wawa", new[] { "coffee" });
                    glossMap.Add("en", en);
                }
                TeloSeliWawa = new CompoundWord("telo-seli-wawa");

                Dictionary.Add("telo-seli-wawa", TeloSeliWawa);
                Glosses.Add("telo-seli-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-seli", new[] { "summer", " Summer" });
                    glossMap.Add("en", en);
                }
                TenpoSeli = new CompoundWord("tenpo-seli");

                Dictionary.Add("tenpo-seli", TenpoSeli);
                Glosses.Add("tenpo-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-seme", new[] { "when" });
                    glossMap.Add("en", en);
                }
                TenpoSeme = new CompoundWord("tenpo-seme");

                Dictionary.Add("tenpo-seme", TenpoSeme);
                Glosses.Add("tenpo-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sewi-kon", new[] { "the heavens", " sky (heavens)", " heavens", " Heaven" });
                    glossMap.Add("en", en);
                }
                SewiKon = new CompoundWord("sewi-kon");

                Dictionary.Add("sewi-kon", SewiKon);
                Glosses.Add("sewi-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sewi-monsi", new[] { "upper back", " shoulders" });
                    glossMap.Add("en", en);
                }
                SewiMonsi = new CompoundWord("sewi-monsi");

                Dictionary.Add("sewi-monsi", SewiMonsi);
                Glosses.Add("sewi-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sewi-pona", new[] { "heaven" });
                    glossMap.Add("en", en);
                }
                SewiPona = new CompoundWord("sewi-pona");

                Dictionary.Add("sewi-pona", SewiPona);
                Glosses.Add("sewi-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sewi-sijelo", new[] { "top of the body" });
                    glossMap.Add("en", en);
                }
                SewiSijelo = new CompoundWord("sewi-sijelo");

                Dictionary.Add("sewi-sijelo", SewiSijelo);
                Glosses.Add("sewi-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sewi-tomo", new[] { "roof" });
                    glossMap.Add("en", en);
                }
                SewiTomo = new CompoundWord("sewi-tomo");

                Dictionary.Add("sewi-tomo", SewiTomo);
                Glosses.Add("sewi-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wawa-sewi", new[] { "god (Higher Power)" });
                    glossMap.Add("en", en);
                }
                WawaSewi = new CompoundWord("wawa-sewi");

                Dictionary.Add("wawa-sewi", WawaSewi);
                Glosses.Add("wawa-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sijelo-ali-insa-ma", new[] { "everybody in the world" });
                    glossMap.Add("en", en);
                }
                SijeloAliInsaMa = new CompoundWord("sijelo-ali-insa-ma");

                Dictionary.Add("sijelo-ali-insa-ma", SijeloAliInsaMa);
                Glosses.Add("sijelo-ali-insa-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sijelo-pona", new[] { "healthy" });
                    glossMap.Add("en", en);
                }
                SijeloPona = new CompoundWord("sijelo-pona");

                Dictionary.Add("sijelo-pona", SijeloPona);
                Glosses.Add("sijelo-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sijelo-toki", new[] { "corpus" });
                    glossMap.Add("en", en);
                }
                SijeloToki = new CompoundWord("sijelo-toki");

                Dictionary.Add("sijelo-toki", SijeloToki);
                Glosses.Add("sijelo-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-sijelo", new[] { "body part" });
                    glossMap.Add("en", en);
                }
                WanSijelo = new CompoundWord("wan-sijelo");

                Dictionary.Add("wan-sijelo", WanSijelo);
                Glosses.Add("wan-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-jan", new[] { "society", " company", " gathering" });
                    glossMap.Add("en", en);
                }
                SikeJan = new CompoundWord("sike-jan");

                Dictionary.Add("sike-jan", SikeJan);
                Glosses.Add("sike-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-kili", new[] { "coconut" });
                    glossMap.Add("en", en);
                }
                SikeKili = new CompoundWord("sike-kili");

                Dictionary.Add("sike-kili", SikeKili);
                Glosses.Add("sike-kili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-kiwen-mani", new[] { "coin" });
                    glossMap.Add("en", en);
                }
                SikeKiwenMani = new CompoundWord("sike-kiwen-mani");

                Dictionary.Add("sike-kiwen-mani", SikeKiwenMani);
                Glosses.Add("sike-kiwen-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-kon-suli", new[] { "sun", " sunshine" });
                    glossMap.Add("en", en);
                }
                SikeKonSuli = new CompoundWord("sike-kon-suli");

                Dictionary.Add("sike-kon-suli", SikeKonSuli);
                Glosses.Add("sike-kon-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-mama", new[] { "egg" });
                    glossMap.Add("en", en);
                }
                SikeMama = new CompoundWord("sike-mama");

                Dictionary.Add("sike-mama", SikeMama);
                Glosses.Add("sike-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-mije", new[] { "testicles", " balls" });
                    glossMap.Add("en", en);
                }
                SikeMije = new CompoundWord("sike-mije");

                Dictionary.Add("sike-mije", SikeMije);
                Glosses.Add("sike-mije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-mije-tu", new[] { "testicles", " balls" });
                    glossMap.Add("en", en);
                }
                SikeMijeTu = new CompoundWord("sike-mije-tu");

                Dictionary.Add("sike-mije-tu", SikeMijeTu);
                Glosses.Add("sike-mije-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-moli-wawa", new[] { "grenade", " bomb" });
                    glossMap.Add("en", en);
                }
                SikeMoliWawa = new CompoundWord("sike-moli-wawa");

                Dictionary.Add("sike-moli-wawa", SikeMoliWawa);
                Glosses.Add("sike-moli-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-nena", new[] { "crown" });
                    glossMap.Add("en", en);
                }
                SikeNena = new CompoundWord("sike-nena");

                Dictionary.Add("sike-nena", SikeNena);
                Glosses.Add("sike-nena", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-noka", new[] { "football (ball itself)", " football","soccer)" });
                    glossMap.Add("en", en);
                }
                SikeNoka = new CompoundWord("sike-noka");

                Dictionary.Add("sike-noka", SikeNoka);
                Glosses.Add("sike-noka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-selo", new[] { "football" });
                    glossMap.Add("en", en);
                }
                SikeSelo = new CompoundWord("sike-selo");

                Dictionary.Add("sike-selo", SikeSelo);
                Glosses.Add("sike-selo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-sewi-laso", new[] { "sky", " firmament" });
                    glossMap.Add("en", en);
                }
                SikeSewiLaso = new CompoundWord("sike-sewi-laso");

                Dictionary.Add("sike-sewi-laso", SikeSewiLaso);
                Glosses.Add("sike-sewi-laso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-suno-mute", new[] { "era", " epoch", " century" });
                    glossMap.Add("en", en);
                }
                SikeSunoMute = new CompoundWord("sike-suno-mute");

                Dictionary.Add("sike-suno-mute", SikeSunoMute);
                Glosses.Add("sike-suno-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-tu", new[] { "bicycle" });
                    glossMap.Add("en", en);
                }
                SikeTu = new CompoundWord("sike-tu");

                Dictionary.Add("sike-tu", SikeTu);
                Glosses.Add("sike-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-tu-supa", new[] { "recumbent bicyvle" });
                    glossMap.Add("en", en);
                }
                SikeTuSupa = new CompoundWord("sike-tu-supa");

                Dictionary.Add("sike-tu-supa", SikeTuSupa);
                Glosses.Add("sike-tu-supa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-sike", new[] { "year" });
                    glossMap.Add("en", en);
                }
                TenpoSike = new CompoundWord("tenpo-sike");

                Dictionary.Add("tenpo-sike", TenpoSike);
                Glosses.Add("tenpo-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sin-ala", new[] { "old", " out of date", " old-fashioned", " not new" });
                    glossMap.Add("en", en);
                }
                SinAla = new CompoundWord("sin-ala");

                Dictionary.Add("sin-ala", SinAla);
                Glosses.Add("sin-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sin-pona", new[] { "good news" });
                    glossMap.Add("en", en);
                }
                SinPona = new CompoundWord("sin-pona");

                Dictionary.Add("sin-pona", SinPona);
                Glosses.Add("sin-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-sin", new[] { "again", " then (later)" });
                    glossMap.Add("en", en);
                }
                TenpoSin = new CompoundWord("tenpo-sin");

                Dictionary.Add("tenpo-sin", TenpoSin);
                Glosses.Add("tenpo-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sinpin-lawa", new[] { "face" });
                    glossMap.Add("en", en);
                }
                SinpinLawa = new CompoundWord("sinpin-lawa");

                Dictionary.Add("sinpin-lawa", SinpinLawa);
                Glosses.Add("sinpin-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sinpin-sike", new[] { "shield" });
                    glossMap.Add("en", en);
                }
                SinpinSike = new CompoundWord("sinpin-sike");

                Dictionary.Add("sinpin-sike", SinpinSike);
                Glosses.Add("sinpin-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sinpin-suli", new[] { "wall" });
                    glossMap.Add("en", en);
                }
                SinpinSuli = new CompoundWord("sinpin-suli");

                Dictionary.Add("sinpin-suli", SinpinSuli);
                Glosses.Add("sinpin-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-kalama", new[] { "letter of the alphabet", " writing with connection to pronunciation" });
                    glossMap.Add("en", en);
                }
                SitelenKalama = new CompoundWord("sitelen-kalama");

                Dictionary.Add("sitelen-kalama", SitelenKalama);
                Glosses.Add("sitelen-kalama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-lili", new[] { "letter", " punctuation mark", " letter of alphabet", " character", " glyph" });
                    glossMap.Add("en", en);
                }
                SitelenLili = new CompoundWord("sitelen-lili");

                Dictionary.Add("sitelen-lili", SitelenLili);
                Glosses.Add("sitelen-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-ma", new[] { "map" });
                    glossMap.Add("en", en);
                }
                SitelenMa = new CompoundWord("sitelen-ma");

                Dictionary.Add("sitelen-ma", SitelenMa);
                Glosses.Add("sitelen-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-sama-lipu-sona", new[] { "web page" });
                    glossMap.Add("en", en);
                }
                SitelenSamaLipuSona = new CompoundWord("sitelen-sama-lipu-sona");

                Dictionary.Add("sitelen-sama-lipu-sona", SitelenSamaLipuSona);
                Glosses.Add("sitelen-sama-lipu-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-selo", new[] { "political meeting", " manifesto", " (ad)sign" });
                    glossMap.Add("en", en);
                }
                SitelenSelo = new CompoundWord("sitelen-selo");

                Dictionary.Add("sitelen-selo", SitelenSelo);
                Glosses.Add("sitelen-selo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-suli", new[] { "capital (upper case) letter" });
                    glossMap.Add("en", en);
                }
                SitelenSuli = new CompoundWord("sitelen-suli");

                Dictionary.Add("sitelen-suli", SitelenSuli);
                Glosses.Add("sitelen-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-tawa", new[] { "cartoon", " movie", " television show" });
                    glossMap.Add("en", en);
                }
                SitelenTawa = new CompoundWord("sitelen-tawa");

                Dictionary.Add("sitelen-tawa", SitelenTawa);
                Glosses.Add("sitelen-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-toki", new[] { "writing", " transcription", " written message", " writings", " text", " ideography", " picture books", " hiieroglyphics", " cave drawings", " writing system", " letter", " e-mail message", " etc." });
                    glossMap.Add("en", en);
                }
                SitelenToki = new CompoundWord("sitelen-toki");

                Dictionary.Add("sitelen-toki", SitelenToki);
                Glosses.Add("sitelen-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-tomo", new[] { "structure (how fit together)" });
                    glossMap.Add("en", en);
                }
                SitelenTomo = new CompoundWord("sitelen-tomo");

                Dictionary.Add("sitelen-tomo", SitelenTomo);
                Glosses.Add("sitelen-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-unpa", new[] { "visual erotica", " porn" });
                    glossMap.Add("en", en);
                }
                SitelenUnpa = new CompoundWord("sitelen-unpa");

                Dictionary.Add("sitelen-unpa", SitelenUnpa);
                Glosses.Add("sitelen-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-ale", new[] { "know completely" });
                    glossMap.Add("en", en);
                }
                SonaAle = new CompoundWord("sona-ale");

                Dictionary.Add("sona-ale", SonaAle);
                Glosses.Add("sona-ale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-ilo", new[] { "technology" });
                    glossMap.Add("en", en);
                }
                SonaIlo = new CompoundWord("sona-ilo");

                Dictionary.Add("sona-ilo", SonaIlo);
                Glosses.Add("sona-ilo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-lukin", new[] { "know by view", " picture to yourself", " imagine" });
                    glossMap.Add("en", en);
                }
                SonaLukin = new CompoundWord("sona-lukin");

                Dictionary.Add("sona-lukin", SonaLukin);
                Glosses.Add("sona-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-mute", new[] { "smart", " intelligent","wise" });
                    glossMap.Add("en", en);
                }
                SonaMute = new CompoundWord("sona-mute");

                Dictionary.Add("sona-mute", SonaMute);
                Glosses.Add("sona-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-nanpa", new[] { "mathematics" });
                    glossMap.Add("en", en);
                }
                SonaNanpa = new CompoundWord("sona-nanpa");

                Dictionary.Add("sona-nanpa", SonaNanpa);
                Glosses.Add("sona-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-nimi", new[] { "means" });
                    glossMap.Add("en", en);
                }
                SonaNimi = new CompoundWord("sona-nimi");

                Dictionary.Add("sona-nimi", SonaNimi);
                Glosses.Add("sona-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pi-kalama-toki", new[] { "phonology", " phonetics" });
                    glossMap.Add("en", en);
                }
                SonaPiKalamaToki = new CompoundWord("sona-pi-kalama-toki");

                Dictionary.Add("sona-pi-kalama-toki", SonaPiKalamaToki);
                Glosses.Add("sona-pi-kalama-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pi-lukin-ala", new[] { "cryptology" });
                    glossMap.Add("en", en);
                }
                SonaPiLukinAla = new CompoundWord("sona-pi-lukin-ala");

                Dictionary.Add("sona-pi-lukin-ala", SonaPiLukinAla);
                Glosses.Add("sona-pi-lukin-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pi-nasin-pona-en-ike", new[] { "knowledge of good and evil" });
                    glossMap.Add("en", en);
                }
                SonaPiNasinPonaEnIke = new CompoundWord("sona-pi-nasin-pona-en-ike");

                Dictionary.Add("sona-pi-nasin-pona-en-ike", SonaPiNasinPonaEnIke);
                Glosses.Add("sona-pi-nasin-pona-en-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pona", new[] { "explain", " conscience", " useful information" });
                    glossMap.Add("en", en);
                }
                SonaPona = new CompoundWord("sona-pona");

                Dictionary.Add("sona-pona", SonaPona);
                Glosses.Add("sona-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-toki", new[] { "linguistics" });
                    glossMap.Add("en", en);
                }
                SonaToki = new CompoundWord("sona-toki");

                Dictionary.Add("sona-toki", SonaToki);
                Glosses.Add("sona-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-sona", new[] { "school", " college", " university" });
                    glossMap.Add("en", en);
                }
                TomoSona = new CompoundWord("tomo-sona");

                Dictionary.Add("tomo-sona", TomoSona);
                Glosses.Add("tomo-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-sona-suli", new[] { "college", " university" });
                    glossMap.Add("en", en);
                }
                TomoSonaSuli = new CompoundWord("tomo-sona-suli");

                Dictionary.Add("tomo-sona-suli", TomoSonaSuli);
                Glosses.Add("tomo-sona-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-tomo-sona", new[] { "faculty of school (either sense)" });
                    glossMap.Add("en", en);
                }
                WanPiTomoSona = new CompoundWord("wan-pi-tomo-sona");

                Dictionary.Add("wan-pi-tomo-sona", WanPiTomoSona);
                Glosses.Add("wan-pi-tomo-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-jaki", new[] { "pig", " some wild beast: rat", " wolf", " fox", " etc." });
                    glossMap.Add("en", en);
                }
                SoweliJaki = new CompoundWord("soweli-jaki");

                Dictionary.Add("soweli-jaki", SoweliJaki);
                Glosses.Add("soweli-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-jaki-pi-ma-kasi", new[] { "wild boar" });
                    glossMap.Add("en", en);
                }
                SoweliJakiPiMaKasi = new CompoundWord("soweli-jaki-pi-ma-kasi");

                Dictionary.Add("soweli-jaki-pi-ma-kasi", SoweliJakiPiMaKasi);
                Glosses.Add("soweli-jaki-pi-ma-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-jan", new[] { "monkey", " ape" });
                    glossMap.Add("en", en);
                }
                SoweliJan = new CompoundWord("soweli-jan");

                Dictionary.Add("soweli-jan", SoweliJan);
                Glosses.Add("soweli-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-kala-suli", new[] { "whale" });
                    glossMap.Add("en", en);
                }
                SoweliKalaSuli = new CompoundWord("soweli-kala-suli");

                Dictionary.Add("soweli-kala-suli", SoweliKalaSuli);
                Glosses.Add("soweli-kala-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-lili-jaki", new[] { "rat" });
                    glossMap.Add("en", en);
                }
                SoweliLiliJaki = new CompoundWord("soweli-lili-jaki");

                Dictionary.Add("soweli-lili-jaki", SoweliLiliJaki);
                Glosses.Add("soweli-lili-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-lili-pi-linja-kiwen", new[] { "hedgehog", " porcupine" });
                    glossMap.Add("en", en);
                }
                SoweliLiliPiLinjaKiwen = new CompoundWord("soweli-lili-pi-linja-kiwen");

                Dictionary.Add("soweli-lili-pi-linja-kiwen", SoweliLiliPiLinjaKiwen);
                Glosses.Add("soweli-lili-pi-linja-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-lili-tomo", new[] { "hamster", " gerbil", " rat", " mouse", " etc." });
                    glossMap.Add("en", en);
                }
                SoweliLiliTomo = new CompoundWord("soweli-lili-tomo");

                Dictionary.Add("soweli-lili-tomo", SoweliLiliTomo);
                Glosses.Add("soweli-lili-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-loje-walo", new[] { "pig" });
                    glossMap.Add("en", en);
                }
                SoweliLojeWalo = new CompoundWord("soweli-loje-walo");

                Dictionary.Add("soweli-loje-walo", SoweliLojeWalo);
                Glosses.Add("soweli-loje-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-loje-walo-lon-ma", new[] { "wild boar" });
                    glossMap.Add("en", en);
                }
                SoweliLojeWaloLonMa = new CompoundWord("soweli-loje-walo-lon-ma");

                Dictionary.Add("soweli-loje-walo-lon-ma", SoweliLojeWaloLonMa);
                Glosses.Add("soweli-loje-walo-lon-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-loje-walo-seli", new[] { "roast pig" });
                    glossMap.Add("en", en);
                }
                SoweliLojeWaloSeli = new CompoundWord("soweli-loje-walo-seli");

                Dictionary.Add("soweli-loje-walo-seli", SoweliLojeWaloSeli);
                Glosses.Add("soweli-loje-walo-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-lukin-sama-jan", new[] { "monkey", " ape" });
                    glossMap.Add("en", en);
                }
                SoweliLukinSamaJan = new CompoundWord("soweli-lukin-sama-jan");

                Dictionary.Add("soweli-lukin-sama-jan", SoweliLukinSamaJan);
                Glosses.Add("soweli-lukin-sama-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-mani", new[] { "animal symbolizing wealth" });
                    glossMap.Add("en", en);
                }
                SoweliMani = new CompoundWord("soweli-mani");

                Dictionary.Add("soweli-mani", SoweliMani);
                Glosses.Add("soweli-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-meli", new[] { "cow" });
                    glossMap.Add("en", en);
                }
                SoweliMeli = new CompoundWord("soweli-meli");

                Dictionary.Add("soweli-meli", SoweliMeli);
                Glosses.Add("soweli-meli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-mu", new[] { "cow", " cattle" });
                    glossMap.Add("en", en);
                }
                SoweliMu = new CompoundWord("soweli-mu");

                Dictionary.Add("soweli-mu", SoweliMu);
                Glosses.Add("soweli-mu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-musi", new[] { "cat" });
                    glossMap.Add("en", en);
                }
                SoweliMusi = new CompoundWord("soweli-musi");

                Dictionary.Add("soweli-musi", SoweliMusi);
                Glosses.Add("soweli-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-nasa", new[] { "orangutan" });
                    glossMap.Add("en", en);
                }
                SoweliNasa = new CompoundWord("soweli-nasa");

                Dictionary.Add("soweli-nasa", SoweliNasa);
                Glosses.Add("soweli-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-awen-tomo", new[] { "dog" });
                    glossMap.Add("en", en);
                }
                SoweliPiAwenTomo = new CompoundWord("soweli-pi-awen-tomo");

                Dictionary.Add("soweli-pi-awen-tomo", SoweliPiAwenTomo);
                Glosses.Add("soweli-pi-awen-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-moku-pipi", new[] { "anteater" });
                    glossMap.Add("en", en);
                }
                SoweliPiMokuPipi = new CompoundWord("soweli-pi-moku-pipi");

                Dictionary.Add("soweli-pi-moku-pipi", SoweliPiMokuPipi);
                Glosses.Add("soweli-pi-moku-pipi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-palisa-lawa", new[] { "elepphant" });
                    glossMap.Add("en", en);
                }
                SoweliPiPalisaLawa = new CompoundWord("soweli-pi-palisa-lawa");

                Dictionary.Add("soweli-pi-palisa-lawa", SoweliPiPalisaLawa);
                Glosses.Add("soweli-pi-palisa-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-tawa-lon-tu", new[] { "bipedal" });
                    glossMap.Add("en", en);
                }
                SoweliPiTawaLonTu = new CompoundWord("soweli-pi-tawa-lon-tu");

                Dictionary.Add("soweli-pi-tawa-lon-tu", SoweliPiTawaLonTu);
                Glosses.Add("soweli-pi-tawa-lon-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suli", new[] { "elephant", " dog" });
                    glossMap.Add("en", en);
                }
                SoweliSuli = new CompoundWord("soweli-suli");

                Dictionary.Add("soweli-suli", SoweliSuli);
                Glosses.Add("soweli-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suli-ike", new[] { "bear" });
                    glossMap.Add("en", en);
                }
                SoweliSuliIke = new CompoundWord("soweli-suli-ike");

                Dictionary.Add("soweli-suli-ike", SoweliSuliIke);
                Glosses.Add("soweli-suli-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suli-lape-pi-kasi-suli", new[] { "koala" });
                    glossMap.Add("en", en);
                }
                SoweliSuliLapePiKasiSuli = new CompoundWord("soweli-suli-lape-pi-kasi-suli");

                Dictionary.Add("soweli-suli-lape-pi-kasi-suli", SoweliSuliLapePiKasiSuli);
                Glosses.Add("soweli-suli-lape-pi-kasi-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suli-palisa", new[] { "giraffe" });
                    glossMap.Add("en", en);
                }
                SoweliSuliPalisa = new CompoundWord("soweli-suli-palisa");

                Dictionary.Add("soweli-suli-palisa", SoweliSuliPalisa);
                Glosses.Add("soweli-suli-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suli-pi-nena-tu", new[] { "dromedary" });
                    glossMap.Add("en", en);
                }
                SoweliSuliPiNenaTu = new CompoundWord("soweli-suli-pi-nena-tu");

                Dictionary.Add("soweli-suli-pi-nena-tu", SoweliSuliPiNenaTu);
                Glosses.Add("soweli-suli-pi-nena-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suli-pi-nene-wan", new[] { "camel" });
                    glossMap.Add("en", en);
                }
                SoweliSuliPiNeneWan = new CompoundWord("soweli-suli-pi-nene-wan");

                Dictionary.Add("soweli-suli-pi-nene-wan", SoweliSuliPiNeneWan);
                Glosses.Add("soweli-suli-pi-nene-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suli-walo-en-pimeja", new[] { "big gray wolf" });
                    glossMap.Add("en", en);
                }
                SoweliSuliWaloEnPimeja = new CompoundWord("soweli-suli-walo-en-pimeja");

                Dictionary.Add("soweli-suli-walo-en-pimeja", SoweliSuliWaloEnPimeja);
                Glosses.Add("soweli-suli-walo-en-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suwi", new[] { "Rabbit", " pet" });
                    glossMap.Add("en", en);
                }
                SoweliSuwi = new CompoundWord("soweli-suwi");

                Dictionary.Add("soweli-suwi", SoweliSuwi);
                Glosses.Add("soweli-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suwi-tomo", new[] { "cat" });
                    glossMap.Add("en", en);
                }
                SoweliSuwiTomo = new CompoundWord("soweli-suwi-tomo");

                Dictionary.Add("soweli-suwi-tomo", SoweliSuwiTomo);
                Glosses.Add("soweli-suwi-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-tawa", new[] { "horse" });
                    glossMap.Add("en", en);
                }
                SoweliTawa = new CompoundWord("soweli-tawa");

                Dictionary.Add("soweli-tawa", SoweliTawa);
                Glosses.Add("soweli-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-tawa-pimeja-en-walo", new[] { "zebra" });
                    glossMap.Add("en", en);
                }
                SoweliTawaPimejaEnWalo = new CompoundWord("soweli-tawa-pimeja-en-walo");

                Dictionary.Add("soweli-tawa-pimeja-en-walo", SoweliTawaPimejaEnWalo);
                Glosses.Add("soweli-tawa-pimeja-en-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-tomo-pi-linja-uta", new[] { "cat" });
                    glossMap.Add("en", en);
                }
                SoweliTomoPiLinjaUta = new CompoundWord("soweli-tomo-pi-linja-uta");

                Dictionary.Add("soweli-tomo-pi-linja-uta", SoweliTomoPiLinjaUta);
                Glosses.Add("soweli-tomo-pi-linja-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-waso", new[] { "bat" });
                    glossMap.Add("en", en);
                }
                SoweliWaso = new CompoundWord("soweli-waso");

                Dictionary.Add("soweli-waso", SoweliWaso);
                Glosses.Add("soweli-waso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-wawa", new[] { "dog" });
                    glossMap.Add("en", en);
                }
                SoweliWawa = new CompoundWord("soweli-wawa");

                Dictionary.Add("soweli-wawa", SoweliWawa);
                Glosses.Add("soweli-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-wawa-pimeja", new[] { "brown bear", " black bear" });
                    glossMap.Add("en", en);
                }
                SoweliWawaPimeja = new CompoundWord("soweli-wawa-pimeja");

                Dictionary.Add("soweli-wawa-pimeja", SoweliWawaPimeja);
                Glosses.Add("soweli-wawa-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-wawa-tomo", new[] { "dog" });
                    glossMap.Add("en", en);
                }
                SoweliWawaTomo = new CompoundWord("soweli-wawa-tomo");

                Dictionary.Add("soweli-wawa-tomo", SoweliWawaTomo);
                Glosses.Add("soweli-wawa-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-mama-soweli", new[] { "dairy milk from cows (goats)" });
                    glossMap.Add("en", en);
                }
                TeloMamaSoweli = new CompoundWord("telo-mama-soweli");

                Dictionary.Add("telo-mama-soweli", TeloMamaSoweli);
                Glosses.Add("telo-mama-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-suli", new[] { "continent" });
                    glossMap.Add("en", en);
                }
                MaSuli = new CompoundWord("ma-suli");

                Dictionary.Add("ma-suli", MaSuli);
                Glosses.Add("ma-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("suli-pi-nanpa-wan", new[] { "first in size" });
                    glossMap.Add("en", en);
                }
                SuliPiNanpaWan = new CompoundWord("suli-pi-nanpa-wan");

                Dictionary.Add("suli-pi-nanpa-wan", SuliPiNanpaWan);
                Glosses.Add("suli-pi-nanpa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-suli", new[] { "ocean", " sea", " lake", " oean", " flood", " oil" });
                    glossMap.Add("en", en);
                }
                TeloSuli = new CompoundWord("telo-suli");

                Dictionary.Add("telo-suli", TeloSuli);
                Glosses.Add("telo-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suli", new[] { "long time" });
                    glossMap.Add("en", en);
                }
                TenpoSuli = new CompoundWord("tenpo-suli");

                Dictionary.Add("tenpo-suli", TenpoSuli);
                Glosses.Add("tenpo-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("suno-kama-ni", new[] { "tomorrow" });
                    glossMap.Add("en", en);
                }
                SunoKamaNi = new CompoundWord("suno-kama-ni");

                Dictionary.Add("suno-kama-ni", SunoKamaNi);
                Glosses.Add("suno-kama-ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno", new[] { "day"});
                    glossMap.Add("en", en);
                }
                TenpoSuno = new CompoundWord("tenpo-suno");

                Dictionary.Add("tenpo-suno", TenpoSuno);
                Glosses.Add("tenpo-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno-kama", new[] { "tomorrow" });
                    glossMap.Add("en", en);
                }
                TenpoSunoKama = new CompoundWord("tenpo-suno-kama");

                Dictionary.Add("tenpo-suno-kama", TenpoSunoKama);
                Glosses.Add("tenpo-suno-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno-ni", new[] { "today" });
                    glossMap.Add("en", en);
                }
                TenpoSunoNi = new CompoundWord("tenpo-suno-ni");

                Dictionary.Add("tenpo-suno-ni", TenpoSunoNi);
                Glosses.Add("tenpo-suno-ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno-pini", new[] { "yesterday" });
                    glossMap.Add("en", en);
                }
                TenpoSunoPini = new CompoundWord("tenpo-suno-pini");

                Dictionary.Add("tenpo-suno-pini", TenpoSunoPini);
                Glosses.Add("tenpo-suno-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("supa-moku", new[] { "dining table" });
                    glossMap.Add("en", en);
                }
                SupaMoku = new CompoundWord("supa-moku");

                Dictionary.Add("supa-moku", SupaMoku);
                Glosses.Add("supa-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("supa-monsi", new[] { "chair", " seat" });
                    glossMap.Add("en", en);
                }
                SupaMonsi = new CompoundWord("supa-monsi");

                Dictionary.Add("supa-monsi", SupaMonsi);
                Glosses.Add("supa-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("supa-pali", new[] { "work table/bench" });
                    glossMap.Add("en", en);
                }
                SupaPali = new CompoundWord("supa-pali");

                Dictionary.Add("supa-pali", SupaPali);
                Glosses.Add("supa-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-suwi", new[] { "soft drink", " uncaffinated" });
                    glossMap.Add("en", en);
                }
                TeloSuwi = new CompoundWord("telo-suwi");

                Dictionary.Add("telo-suwi", TeloSuwi);
                Glosses.Add("telo-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-wawa-suwi", new[] { "caffenated soft drink" });
                    glossMap.Add("en", en);
                }
                TeloWawaSuwi = new CompoundWord("telo-wawa-suwi");

                Dictionary.Add("telo-wawa-suwi", TeloWawaSuwi);
                Glosses.Add("telo-wawa-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tan-ali", new[] { "general purpose", " general prupose" });
                    glossMap.Add("en", en);
                }
                TanAli = new CompoundWord("tan-ali");

                Dictionary.Add("tan-ali", TanAli);
                Glosses.Add("tan-ali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tan-seme", new[] { "why" });
                    glossMap.Add("en", en);
                }
                TanSeme = new CompoundWord("tan-seme");

                Dictionary.Add("tan-seme", TanSeme);
                Glosses.Add("tan-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tan-sijelo", new[] { "origin of matter", " origina of matter" });
                    glossMap.Add("en", en);
                }
                TanSijelo = new CompoundWord("tan-sijelo");

                Dictionary.Add("tan-sijelo", TanSijelo);
                Glosses.Add("tan-sijelo", glossMap);
            }

            //Sentence!
            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("mi-tawa", new[] { "Good Bye!" });
            //        glossMap.Add("en", en);
            //    }
            //    MiTawa = new CompoundWord("mi-tawa");

            //    Dictionary.Add("mi-tawa", MiTawa);
            //    Glosses.Add("mi-tawa", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-anpa", new[] { "drop", " fall" });
                    glossMap.Add("en", en);
                }
                TawaAnpa = new CompoundWord("tawa-anpa");

                Dictionary.Add("tawa-anpa", TawaAnpa);
                Glosses.Add("tawa-anpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-anpa-telo", new[] { "sink" });
                    glossMap.Add("en", en);
                }
                TawaAnpaTelo = new CompoundWord("tawa-anpa-telo");

                Dictionary.Add("tawa-anpa-telo", TawaAnpaTelo);
                Glosses.Add("tawa-anpa-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-insa", new[] { "fill", " move into" });
                    glossMap.Add("en", en);
                }
                TawaInsa = new CompoundWord("tawa-insa");

                Dictionary.Add("tawa-insa", TawaInsa);
                Glosses.Add("tawa-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-insa-kon", new[] { "inhale" });
                    glossMap.Add("en", en);
                }
                TawaInsaKon = new CompoundWord("tawa-insa-kon");

                Dictionary.Add("tawa-insa-kon", TawaInsaKon);
                Glosses.Add("tawa-insa-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-jo", new[] { "find" });
                    glossMap.Add("en", en);
                }
                TawaJo = new CompoundWord("tawa-jo");

                Dictionary.Add("tawa-jo", TawaJo);
                Glosses.Add("tawa-jo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-kon", new[] { "fly" });
                    glossMap.Add("en", en);
                }
                TawaKon = new CompoundWord("tawa-kon");

                Dictionary.Add("tawa-kon", TawaKon);
                Glosses.Add("tawa-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-lon-kon", new[] { "fly" });
                    glossMap.Add("en", en);
                }
                TawaLonKon = new CompoundWord("tawa-lon-kon");

                Dictionary.Add("tawa-lon-kon", TawaLonKon);
                Glosses.Add("tawa-lon-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-lon-luka-pona", new[] { "move right" });
                    glossMap.Add("en", en);
                }
                TawaLonLukaPona = new CompoundWord("tawa-lon-luka-pona");

                Dictionary.Add("tawa-lon-luka-pona", TawaLonLukaPona);
                Glosses.Add("tawa-lon-luka-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-lon-luka-ike", new[] { "move left" });
                    glossMap.Add("en", en);
                }
                TawaLonLukaIke = new CompoundWord("tawa-lon-luka-ike");

                Dictionary.Add("tawa-lon-luka-ike", TawaLonLukaIke);
                Glosses.Add("tawa-lon-luka-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-moli", new[] { "dying", " moving toward death", " happen" });
                    glossMap.Add("en", en);
                }
                TawaMoli = new CompoundWord("tawa-moli");

                Dictionary.Add("tawa-moli", TawaMoli);
                Glosses.Add("tawa-moli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-musi", new[] { "dance" });
                    glossMap.Add("en", en);
                }
                TawaMusi = new CompoundWord("tawa-musi");

                Dictionary.Add("tawa-musi", TawaMusi);
                Glosses.Add("tawa-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-mute", new[] { "run", " fast" });
                    glossMap.Add("en", en);
                }
                TawaMute = new CompoundWord("tawa-mute");

                Dictionary.Add("tawa-mute", TawaMute);
                Glosses.Add("tawa-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-mute-lon-tempo-lili", new[] { "go rapidly" });
                    glossMap.Add("en", en);
                }
                TawaMuteLonTempoLili = new CompoundWord("tawa-mute-lon-tempo-lili");

                Dictionary.Add("tawa-mute-lon-tempo-lili", TawaMuteLonTempoLili);
                Glosses.Add("tawa-mute-lon-tempo-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-noka", new[] { "walk" });
                    glossMap.Add("en", en);
                }
                TawaNoka = new CompoundWord("tawa-noka");

                Dictionary.Add("tawa-noka", TawaNoka);
                Glosses.Add("tawa-noka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-noka-wawa", new[] { "run" });
                    glossMap.Add("en", en);
                }
                TawaNokaWawa = new CompoundWord("tawa-noka-wawa");

                Dictionary.Add("tawa-noka-wawa", TawaNokaWawa);
                Glosses.Add("tawa-noka-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-poka-ante", new[] { "traverse", " go over" });
                    glossMap.Add("en", en);
                }
                TawaPokaAnte = new CompoundWord("tawa-poka-ante");

                Dictionary.Add("tawa-poka-ante", TawaPokaAnte);
                Glosses.Add("tawa-poka-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-selo-kon", new[] { "exhale" });
                    glossMap.Add("en", en);
                }
                TawaSeloKon = new CompoundWord("tawa-selo-kon");

                Dictionary.Add("tawa-selo-kon", TawaSeloKon);
                Glosses.Add("tawa-selo-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-sewi", new[] { "resurrection Ascension" });
                    glossMap.Add("en", en);
                }
                TawaSewi = new CompoundWord("tawa-sewi");

                Dictionary.Add("tawa-sewi", TawaSewi);
                Glosses.Add("tawa-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-sike-lon", new[] { "circle" });
                    glossMap.Add("en", en);
                }
                TawaSikeLon = new CompoundWord("tawa-sike-lon");

                Dictionary.Add("tawa-sike-lon", TawaSikeLon);
                Glosses.Add("tawa-sike-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-wawa", new[] { "speed (vi)" });
                    glossMap.Add("en", en);
                }
                TawaWawa = new CompoundWord("tawa-wawa");

                Dictionary.Add("tawa-wawa", TawaWawa);
                Glosses.Add("tawa-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-wawa-noka", new[] { "run" });
                    glossMap.Add("en", en);
                }
                TawaWawaNoka = new CompoundWord("tawa-wawa-noka");

                Dictionary.Add("tawa-wawa-noka", TawaWawaNoka);
                Glosses.Add("tawa-wawa-noka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa", new[] { "vehicle", " automobile" });
                    glossMap.Add("en", en);
                }
                TomoTawa = new CompoundWord("tomo-tawa");

                Dictionary.Add("tomo-tawa", TomoTawa);
                Glosses.Add("tomo-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-telo", new[] { "boat", " ship" });
                    glossMap.Add("en", en);
                }
                TomoTawaTelo = new CompoundWord("tomo-tawa-telo");

                Dictionary.Add("tomo-tawa-telo", TomoTawaTelo);
                Glosses.Add("tomo-tawa-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-telo-anpa", new[] { "submarine" });
                    glossMap.Add("en", en);
                }
                TomoTawaTeloAnpa = new CompoundWord("tomo-tawa-telo-anpa");

                Dictionary.Add("tomo-tawa-telo-anpa", TomoTawaTeloAnpa);
                Glosses.Add("tomo-tawa-telo-anpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-telo", new[] { "soup" });
                    glossMap.Add("en", en);
                }
                MokuTelo = new CompoundWord("moku-telo");

                Dictionary.Add("moku-telo", MokuTelo);
                Glosses.Add("moku-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-insa", new[] { "pond" });
                    glossMap.Add("en", en);
                }
                TeloInsa = new CompoundWord("telo-insa");

                Dictionary.Add("telo-insa", TeloInsa);
                Glosses.Add("telo-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-moku", new[] { "tea", " wet" });
                    glossMap.Add("en", en);
                }
                TeloMoku = new CompoundWord("telo-moku");

                Dictionary.Add("telo-moku", TeloMoku);
                Glosses.Add("telo-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-moli", new[] { "poison", " venom" });
                    glossMap.Add("en", en);
                }
                TeloMoli = new CompoundWord("telo-moli");

                Dictionary.Add("telo-moli", TeloMoli);
                Glosses.Add("telo-moli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-nasa-kasi", new[] { "beer","grain alcohol" });
                    glossMap.Add("en", en);
                }
                TeloNasaKasi = new CompoundWord("telo-nasa-kasi");

                Dictionary.Add("telo-nasa-kasi", TeloNasaKasi);
                Glosses.Add("telo-nasa-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-nasa-kili", new[] { "wine" });
                    glossMap.Add("en", en);
                }
                TeloNasaKili = new CompoundWord("telo-nasa-kili");

                Dictionary.Add("telo-nasa-kili", TeloNasaKili);
                Glosses.Add("telo-nasa-kili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-nasa-pona", new[] { "[generic toast]" });
                    glossMap.Add("en", en);
                }
                TeloNasaPona = new CompoundWord("telo-nasa-pona");

                Dictionary.Add("telo-nasa-pona", TeloNasaPona);
                Glosses.Add("telo-nasa-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-pi-kon-suwi", new[] { "perfume" });
                    glossMap.Add("en", en);
                }
                TeloPiKonSuwi = new CompoundWord("telo-pi-kon-suwi");

                Dictionary.Add("telo-pi-kon-suwi", TeloPiKonSuwi);
                Glosses.Add("telo-pi-kon-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-pimeja-seli", new[] { "gasoline" });
                    glossMap.Add("en", en);
                }
                TeloPimejaSeli = new CompoundWord("telo-pimeja-seli");

                Dictionary.Add("telo-pimeja-seli", TeloPimejaSeli);
                Glosses.Add("telo-pimeja-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-seli", new[] { "soup" });
                    glossMap.Add("en", en);
                }
                TeloSeli = new CompoundWord("telo-seli");

                Dictionary.Add("telo-seli", TeloSeli);
                Glosses.Add("telo-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-selo", new[] { "sweat" });
                    glossMap.Add("en", en);
                }
                TeloSelo = new CompoundWord("telo-selo");

                Dictionary.Add("telo-selo", TeloSelo);
                Glosses.Add("telo-selo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-sewi", new[] { "holy water", " annointing oil", " rain", " ritual bath" });
                    glossMap.Add("en", en);
                }
                TeloSewi = new CompoundWord("telo-sewi");

                Dictionary.Add("telo-sewi", TeloSewi);
                Glosses.Add("telo-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-sijelo", new[] { "sweat", " urine" });
                    glossMap.Add("en", en);
                }
                TeloSijelo = new CompoundWord("telo-sijelo");

                Dictionary.Add("telo-sijelo", TeloSijelo);
                Glosses.Add("telo-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-suno", new[] { "oil for anointing" });
                    glossMap.Add("en", en);
                }
                TeloSuno = new CompoundWord("telo-suno");

                Dictionary.Add("telo-suno", TeloSuno);
                Glosses.Add("telo-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-tawa", new[] { "river", " stream", " running water", " brook" });
                    glossMap.Add("en", en);
                }
                TeloTawa = new CompoundWord("telo-tawa");

                Dictionary.Add("telo-tawa", TeloTawa);
                Glosses.Add("telo-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-walo", new[] { "milk" });
                    glossMap.Add("en", en);
                }
                TeloWalo = new CompoundWord("telo-walo");

                Dictionary.Add("telo-walo", TeloWalo);
                Glosses.Add("telo-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-walo-mama", new[] { "milk" });
                    glossMap.Add("en", en);
                }
                TeloWaloMama = new CompoundWord("telo-walo-mama");

                Dictionary.Add("telo-walo-mama", TeloWaloMama);
                Glosses.Add("telo-walo-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-mije", new[] { "semen", " sperm", " come" });
                    glossMap.Add("en", en);
                }
                TeloMije = new CompoundWord("telo-mije");

                Dictionary.Add("telo-mije", TeloMije);
                Glosses.Add("telo-mije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-walo-mije", new[] { "semen", " sperm", " come" });
                    glossMap.Add("en", en);
                }
                TeloWaloMije = new CompoundWord("telo-walo-mije");

                Dictionary.Add("telo-walo-mije", TeloWaloMije);
                Glosses.Add("telo-walo-mije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-wawa", new[] { "energy drink", " caffenated" });
                    glossMap.Add("en", en);
                }
                TeloWawa = new CompoundWord("telo-wawa");

                Dictionary.Add("telo-wawa", TeloWawa);
                Glosses.Add("telo-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-telo", new[] { "rainy season" });
                    glossMap.Add("en", en);
                }
                TenpoTelo = new CompoundWord("tenpo-telo");

                Dictionary.Add("tenpo-telo", TenpoTelo);
                Glosses.Add("tenpo-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-telo", new[] { "bathroom", " washroom", " toilet" });
                    glossMap.Add("en", en);
                }
                TomoTelo = new CompoundWord("tomo-telo");

                Dictionary.Add("tomo-telo", TomoTelo);
                Glosses.Add("tomo-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-ale-ala", new[] { "sometimes" });
                    glossMap.Add("en", en);
                }
                TenpoAleAla = new CompoundWord("tenpo-ale-ala");

                Dictionary.Add("tenpo-ale-ala", TenpoAleAla);
                Glosses.Add("tenpo-ale-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-ijo", new[] { "At some time", " Once upon a time", " at some time", " sometime(s)", " some (quantity of) time" });
                    glossMap.Add("en", en);
                }
                TenpoIjo = new CompoundWord("tenpo-ijo");

                Dictionary.Add("tenpo-ijo", TenpoIjo);
                Glosses.Add("tenpo-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-mun", new[] { "month" });
                    glossMap.Add("en", en);
                }
                TenpoMun = new CompoundWord("tenpo-mun");

                Dictionary.Add("tenpo-mun", TenpoMun);
                Glosses.Add("tenpo-mun", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-mute", new[] { "often", " many times", " era", " the times" });
                    glossMap.Add("en", en);
                }
                TenpoMute = new CompoundWord("tenpo-mute");

                Dictionary.Add("tenpo-mute", TenpoMute);
                Glosses.Add("tenpo-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-mute-lili", new[] { "sometimes" });
                    glossMap.Add("en", en);
                }
                TenpoMuteLili = new CompoundWord("tenpo-mute-lili");

                Dictionary.Add("tenpo-mute-lili", TenpoMuteLili);
                Glosses.Add("tenpo-mute-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-nasa", new[] { "party" });
                    glossMap.Add("en", en);
                }
                TenpoNasa = new CompoundWord("tenpo-nasa");

                Dictionary.Add("tenpo-nasa", TenpoNasa);
                Glosses.Add("tenpo-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-open", new[] { "in the beginning" });
                    glossMap.Add("en", en);
                }
                TenpoOpen = new CompoundWord("tenpo-open");

                Dictionary.Add("tenpo-open", TenpoOpen);
                Glosses.Add("tenpo-open", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pi-kama-seli", new[] { "spring", " Spring" });
                    glossMap.Add("en", en);
                }
                TenpoPiKamaSeli = new CompoundWord("tenpo-pi-kama-seli");

                Dictionary.Add("tenpo-pi-kama-seli", TenpoPiKamaSeli);
                Glosses.Add("tenpo-pi-kama-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pi-lete-lili", new[] { "Autumn", " Fall" });
                    glossMap.Add("en", en);
                }
                TenpoPiLeteLili = new CompoundWord("tenpo-pi-lete-lili");

                Dictionary.Add("tenpo-pi-lete-lili", TenpoPiLeteLili);
                Glosses.Add("tenpo-pi-lete-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pi-lete-mute", new[] { "Winter" });
                    glossMap.Add("en", en);
                }
                TenpoPiLeteMute = new CompoundWord("tenpo-pi-lete-mute");

                Dictionary.Add("tenpo-pi-lete-mute", TenpoPiLeteMute);
                Glosses.Add("tenpo-pi-lete-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pi-seli-lili", new[] { "Spring" });
                    glossMap.Add("en", en);
                }
                TenpoPiSeliLili = new CompoundWord("tenpo-pi-seli-lili");

                Dictionary.Add("tenpo-pi-seli-lili", TenpoPiSeliLili);
                Glosses.Add("tenpo-pi-seli-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pi-seli-mute", new[] { "Summer" });
                    glossMap.Add("en", en);
                }
                TenpoPiSeliMute = new CompoundWord("tenpo-pi-seli-mute");

                Dictionary.Add("tenpo-pi-seli-mute", TenpoPiSeliMute);
                Glosses.Add("tenpo-pi-seli-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pini-pi-kulupu-mama", new[] { "genealogy" });
                    glossMap.Add("en", en);
                }
                TenpoPiniPiKulupuMama = new CompoundWord("tenpo-pini-pi-kulupu-mama");

                Dictionary.Add("tenpo-pini-pi-kulupu-mama", TenpoPiniPiKulupuMama);
                Glosses.Add("tenpo-pini-pi-kulupu-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-sike-lili", new[] { "Spring" });
                    glossMap.Add("en", en);
                }
                TenpoSikeLili = new CompoundWord("tenpo-sike-lili");

                Dictionary.Add("tenpo-sike-lili", TenpoSikeLili);
                Glosses.Add("tenpo-sike-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-sinpin", new[] { "after that" });
                    glossMap.Add("en", en);
                }
                TenpoSinpin = new CompoundWord("tenpo-sinpin");

                Dictionary.Add("tenpo-sinpin", TenpoSinpin);
                Glosses.Add("tenpo-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-sinpin-ni", new[] { "after that" });
                    glossMap.Add("en", en);
                }
                TenpoSinpinNi = new CompoundWord("tenpo-sinpin-ni");

                Dictionary.Add("tenpo-sinpin-ni", TenpoSinpinNi);
                Glosses.Add("tenpo-sinpin-ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suli-monsi", new[] { "long ago" });
                    glossMap.Add("en", en);
                }
                TenpoSuliMonsi = new CompoundWord("tenpo-suli-monsi");

                Dictionary.Add("tenpo-suli-monsi", TenpoSuliMonsi);
                Glosses.Add("tenpo-suli-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno-pi-luka-tu", new[] { "week" });
                    glossMap.Add("en", en);
                }
                TenpoSunoPiLukaTu = new CompoundWord("tenpo-suno-pi-luka-tu");

                Dictionary.Add("tenpo-suno-pi-luka-tu", TenpoSunoPiLukaTu);
                Glosses.Add("tenpo-suno-pi-luka-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno-pi-moku-mute", new[] { "Christmas" });
                    glossMap.Add("en", en);
                }
                TenpoSunoPiMokuMute = new CompoundWord("tenpo-suno-pi-moku-mute");

                Dictionary.Add("tenpo-suno-pi-moku-mute", TenpoSunoPiMokuMute);
                Glosses.Add("tenpo-suno-pi-moku-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno-sewi", new[] { "Sunday" });
                    glossMap.Add("en", en);
                }
                TenpoSunoSewi = new CompoundWord("tenpo-suno-sewi");

                Dictionary.Add("tenpo-suno-sewi", TenpoSunoSewi);
                Glosses.Add("tenpo-suno-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno-sike", new[] { "year" });
                    glossMap.Add("en", en);
                }
                TenpoSunoSike = new CompoundWord("tenpo-suno-sike");

                Dictionary.Add("tenpo-suno-sike", TenpoSunoSike);
                Glosses.Add("tenpo-suno-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-ala", new[] { "Not at all", " think nothing of it (reply)" });
                    glossMap.Add("en", en);
                }
                TokiAla = new CompoundWord("toki-ala");

                Dictionary.Add("toki-ala", TokiAla);
                Glosses.Add("toki-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-akesi", new[] { "talking to Esperanto speakers in other than Esperanto (all this English about tp)  What is the Esperanto for this" });
                    glossMap.Add("en", en);
                }
                TokiAkesi = new CompoundWord("toki-akesi");

                Dictionary.Add("toki-akesi", TokiAkesi);
                Glosses.Add("toki-akesi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-ante", new[] { "translation", " translate" });
                    glossMap.Add("en", en);
                }
                TokiAnte = new CompoundWord("toki-ante");

                Dictionary.Add("toki-ante", TokiAnte);
                Glosses.Add("toki-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-e-toki-pona", new[] { "speak toki pona" });
                    glossMap.Add("en", en);
                }
                TokiETokiPona = new CompoundWord("toki-e-toki-pona");

                Dictionary.Add("toki-e-toki-pona", TokiETokiPona);
                Glosses.Add("toki-e-toki-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-ilo", new[] { "computer language" });
                    glossMap.Add("en", en);
                }
                TokiIlo = new CompoundWord("toki-ilo");

                Dictionary.Add("toki-ilo", TokiIlo);
                Glosses.Add("toki-ilo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-kepeken", new[] { "speak (a language)" });
                    glossMap.Add("en", en);
                }
                TokiKepeken = new CompoundWord("toki-kepeken");

                Dictionary.Add("toki-kepeken", TokiKepeken);
                Glosses.Add("toki-kepeken", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-kepeken-uta", new[] { "orally (talking", " rather than writing)" });
                    glossMap.Add("en", en);
                }
                TokiKepekenUta = new CompoundWord("toki-kepeken-uta");

                Dictionary.Add("toki-kepeken-uta", TokiKepekenUta);
                Glosses.Add("toki-kepeken-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-lon", new[] { "talk about" });
                    glossMap.Add("en", en);
                }
                TokiLon = new CompoundWord("toki-lon");

                Dictionary.Add("toki-lon", TokiLon);
                Glosses.Add("toki-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-musi", new[] { "sing", " song", " poem", " joke", " sing (with words)", " lyrics" });
                    glossMap.Add("en", en);
                }
                TokiMusi = new CompoundWord("toki-musi");

                Dictionary.Add("toki-musi", TokiMusi);
                Glosses.Add("toki-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-olin", new[] { "poetry", " poesy" });
                    glossMap.Add("en", en);
                }
                TokiOlin = new CompoundWord("toki-olin");

                Dictionary.Add("toki-olin", TokiOlin);
                Glosses.Add("toki-olin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pali", new[] { "program", " plan", " ", " constructd language" });
                    glossMap.Add("en", en);
                }
                TokiPali = new CompoundWord("toki-pali");

                Dictionary.Add("toki-pali", TokiPali);
                Glosses.Add("toki-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pi-kalama-musi", new[] { "poetry", " poesy", " lyrics" });
                    glossMap.Add("en", en);
                }
                TokiPiKalamaMusi = new CompoundWord("toki-pi-kalama-musi");

                Dictionary.Add("toki-pi-kalama-musi", TokiPiKalamaMusi);
                Glosses.Add("toki-pi-kalama-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pi-nimi-sama", new[] { "oratio recta" });
                    glossMap.Add("en", en);
                }
                TokiPiNimiSama = new CompoundWord("toki-pi-nimi-sama");

                Dictionary.Add("toki-pi-nimi-sama", TokiPiNimiSama);
                Glosses.Add("toki-pi-nimi-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pi-pilin-sama", new[] { "oratio obliqua" });
                    glossMap.Add("en", en);
                }
                TokiPiPilinSama = new CompoundWord("toki-pi-pilin-sama");

                Dictionary.Add("toki-pi-pilin-sama", TokiPiPilinSama);
                Glosses.Add("toki-pi-pilin-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pi-tenpo-mute", new[] { "current expressions", " popular expressions" });
                    glossMap.Add("en", en);
                }
                TokiPiTenpoMute = new CompoundWord("toki-pi-tenpo-mute");

                Dictionary.Add("toki-pi-tenpo-mute", TokiPiTenpoMute);
                Glosses.Add("toki-pi-tenpo-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pi-tenpo-suno", new[] { "diary" });
                    glossMap.Add("en", en);
                }
                TokiPiTenpoSuno = new CompoundWord("toki-pi-tenpo-suno");

                Dictionary.Add("toki-pi-tenpo-suno", TokiPiTenpoSuno);
                Glosses.Add("toki-pi-tenpo-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pilin", new[] { "suggest" });
                    glossMap.Add("en", en);
                }
                TokiPilin = new CompoundWord("toki-pilin");

                Dictionary.Add("toki-pilin", TokiPilin);
                Glosses.Add("toki-pilin", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("toki-awen", new[] { "text", " literature", " dictionary" });
            //        glossMap.Add("en", en);
            //    }
            //    TokiAwen = new CompoundWord("toki-awen");

            //    Dictionary.Add("toki-awen", TokiAwen);
            //    Glosses.Add("toki-awen", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-sewi", new[] { "prayer", " pray", " prayer Religious teachings" });
                    glossMap.Add("en", en);
                }
                TokiSewi = new CompoundWord("toki-sewi");

                Dictionary.Add("toki-sewi", TokiSewi);
                Glosses.Add("toki-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-sike", new[] { " hoax", " nonsense " });
                    glossMap.Add("en", en);
                }
                TokiSike = new CompoundWord("toki-sike");

                Dictionary.Add("toki-sike", TokiSike);
                Glosses.Add("toki-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-sona", new[] { "proverb", " teaching", " saying", " ", " moral (of story)", " fable" });
                    glossMap.Add("en", en);
                }
                TokiSona = new CompoundWord("toki-sona");

                Dictionary.Add("toki-sona", TokiSona);
                Glosses.Add("toki-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-tawa", new[] { "question", " request", " talk to" });
                    glossMap.Add("en", en);
                }
                TokiTawa = new CompoundWord("toki-tawa");

                Dictionary.Add("toki-tawa", TokiTawa);
                Glosses.Add("toki-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-utala", new[] { "argue/debate" });
                    glossMap.Add("en", en);
                }
                TokiUtala = new CompoundWord("toki-utala");

                Dictionary.Add("toki-utala", TokiUtala);
                Glosses.Add("toki-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-utala-lon", new[] { "argue about" });
                    glossMap.Add("en", en);
                }
                TokiUtalaLon = new CompoundWord("toki-utala-lon");

                Dictionary.Add("toki-utala-lon", TokiUtalaLon);
                Glosses.Add("toki-utala-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-wawa", new[] { "protest", " proclaim", " announce", " shout" });
                    glossMap.Add("en", en);
                }
                TokiWawa = new CompoundWord("toki-wawa");

                Dictionary.Add("toki-wawa", TokiWawa);
                Glosses.Add("toki-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo", new[] { "city", " town", " etc." });
                    glossMap.Add("en", en);
                }
                MaTomo = new CompoundWord("ma-tomo");

                Dictionary.Add("ma-tomo", MaTomo);
                Glosses.Add("ma-tomo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-len", new[] { "tent" });
                    glossMap.Add("en", en);
                }
                TomoLen = new CompoundWord("tomo-len");

                Dictionary.Add("tomo-len", TomoLen);
                Glosses.Add("tomo-len", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-mani", new[] { "bank" });
                    glossMap.Add("en", en);
                }
                TomoMani = new CompoundWord("tomo-mani");

                Dictionary.Add("tomo-mani", TomoMani);
                Glosses.Add("tomo-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-moku", new[] { "grocery store", " restaurant", " kitchen" });
                    glossMap.Add("en", en);
                }
                TomoMoku = new CompoundWord("tomo-moku");

                Dictionary.Add("tomo-moku", TomoMoku);
                Glosses.Add("tomo-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-nasa", new[] { "asylum" });
                    glossMap.Add("en", en);
                }
                TomoNasa = new CompoundWord("tomo-nasa");

                Dictionary.Add("tomo-nasa", TomoNasa);
                Glosses.Add("tomo-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-palisa", new[] { "tower" });
                    glossMap.Add("en", en);
                }
                TomoPalisa = new CompoundWord("tomo-palisa");

                Dictionary.Add("tomo-palisa", TomoPalisa);
                Glosses.Add("tomo-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-ijo-mani-mute", new[] { "store", " shop" });
                    glossMap.Add("en", en);
                }
                TomoPiIjoManiMute = new CompoundWord("tomo-pi-ijo-mani-mute");

                Dictionary.Add("tomo-pi-ijo-mani-mute", TomoPiIjoManiMute);
                Glosses.Add("tomo-pi-ijo-mani-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-ka-jo-ijo-mute", new[] { "convenience store" });
                    glossMap.Add("en", en);
                }
                TomoPiKaJoIjoMute = new CompoundWord("tomo-pi-ka-jo-ijo-mute");

                Dictionary.Add("tomo-pi-ka-jo-ijo-mute", TomoPiKaJoIjoMute);
                Glosses.Add("tomo-pi-ka-jo-ijo-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-kama-sona", new[] { "school" });
                    glossMap.Add("en", en);
                }
                TomoPiKamaSona = new CompoundWord("tomo-pi-kama-sona");

                Dictionary.Add("tomo-pi-kama-sona", TomoPiKamaSona);
                Glosses.Add("tomo-pi-kama-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-kili-moku", new[] { "greengrocer", " produce stand" });
                    glossMap.Add("en", en);
                }
                TomoPiKiliMoku = new CompoundWord("tomo-pi-kili-moku");

                Dictionary.Add("tomo-pi-kili-moku", TomoPiKiliMoku);
                Glosses.Add("tomo-pi-kili-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-moku-kili", new[] { "greengrocer", " produce stand" });
                    glossMap.Add("en", en);
                }
                TomoPiMokuKili = new CompoundWord("tomo-pi-moku-kili");

                Dictionary.Add("tomo-pi-moku-kili", TomoPiMokuKili);
                Glosses.Add("tomo-pi-moku-kili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-moku-soweli", new[] { "butchery" });
                    glossMap.Add("en", en);
                }
                TomoPiMokuSoweli = new CompoundWord("tomo-pi-moku-soweli");

                Dictionary.Add("tomo-pi-moku-soweli", TomoPiMokuSoweli);
                Glosses.Add("tomo-pi-moku-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-moku-suwi", new[] { "bakery", " pastry shop", " confectioner", " …" });
                    glossMap.Add("en", en);
                }
                TomoPiMokuSuwi = new CompoundWord("tomo-pi-moku-suwi");

                Dictionary.Add("tomo-pi-moku-suwi", TomoPiMokuSuwi);
                Glosses.Add("tomo-pi-moku-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-pona-sijelo", new[] { "hospital" });
                    glossMap.Add("en", en);
                }
                TomoPiPonaSijelo = new CompoundWord("tomo-pi-pona-sijelo");

                Dictionary.Add("tomo-pi-pona-sijelo", TomoPiPonaSijelo);
                Glosses.Add("tomo-pi-pona-sijelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-soweli-mu-moku", new[] { "butchery" });
                    glossMap.Add("en", en);
                }
                TomoPiSoweliMuMoku = new CompoundWord("tomo-pi-soweli-mu-moku");

                Dictionary.Add("tomo-pi-soweli-mu-moku", TomoPiSoweliMuMoku);
                Glosses.Add("tomo-pi-soweli-mu-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-suwi-moku", new[] { "bakery", " pastry shop", " confectioner", " …" });
                    glossMap.Add("en", en);
                }
                TomoPiSuwiMoku = new CompoundWord("tomo-pi-suwi-moku");

                Dictionary.Add("tomo-pi-suwi-moku", TomoPiSuwiMoku);
                Glosses.Add("tomo-pi-suwi-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-telo-nasa", new[] { "bar", " saloon" });
                    glossMap.Add("en", en);
                }
                TomoPiTeloNasa = new CompoundWord("tomo-pi-telo-nasa");

                Dictionary.Add("tomo-pi-telo-nasa", TomoPiTeloNasa);
                Glosses.Add("tomo-pi-telo-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-seme", new[] { "where" });
                    glossMap.Add("en", en);
                }
                TomoSeme = new CompoundWord("tomo-seme");

                Dictionary.Add("tomo-seme", TomoSeme);
                Glosses.Add("tomo-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-sewi", new[] { "church","Religious house", " skyscraper" });
                    glossMap.Add("en", en);
                }
                TomoSewi = new CompoundWord("tomo-sewi");

                Dictionary.Add("tomo-sewi", TomoSewi);
                Glosses.Add("tomo-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-suli-pi-kama-jo-ijo-mute", new[] { "castle", " palace", " department store" });
                    glossMap.Add("en", en);
                }
                TomoSuliPiKamaJoIjoMute = new CompoundWord("tomo-suli-pi-kama-jo-ijo-mute");

                Dictionary.Add("tomo-suli-pi-kama-jo-ijo-mute", TomoSuliPiKamaJoIjoMute);
                Glosses.Add("tomo-suli-pi-kama-jo-ijo-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-kulupu-pi-anpa-ma", new[] { "subway" });
                    glossMap.Add("en", en);
                }
                TomoTawaKulupuPiAnpaMa = new CompoundWord("tomo-tawa-kulupu-pi-anpa-ma");

                Dictionary.Add("tomo-tawa-kulupu-pi-anpa-ma", TomoTawaKulupuPiAnpaMa);
                Glosses.Add("tomo-tawa-kulupu-pi-anpa-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-kulupu-pi-sike-mute", new[] { "train" });
                    glossMap.Add("en", en);
                }
                TomoTawaKulupuPiSikeMute = new CompoundWord("tomo-tawa-kulupu-pi-sike-mute");

                Dictionary.Add("tomo-tawa-kulupu-pi-sike-mute", TomoTawaKulupuPiSikeMute);
                Glosses.Add("tomo-tawa-kulupu-pi-sike-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-kulupu-pi-sike-tu-tu", new[] { "bus", " auto bus", " pullman", " …" });
                    glossMap.Add("en", en);
                }
                TomoTawaKulupuPiSikeTuTu = new CompoundWord("tomo-tawa-kulupu-pi-sike-tu-tu");

                Dictionary.Add("tomo-tawa-kulupu-pi-sike-tu-tu", TomoTawaKulupuPiSikeTuTu);
                Glosses.Add("tomo-tawa-kulupu-pi-sike-tu-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-pi-jan-mute", new[] { "public transit", " public transportation", " bus" });
                    glossMap.Add("en", en);
                }
                TomoTawaPiJanMute = new CompoundWord("tomo-tawa-pi-jan-mute");

                Dictionary.Add("tomo-tawa-pi-jan-mute", TomoTawaPiJanMute);
                Glosses.Add("tomo-tawa-pi-jan-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-pi-kulupu-jan", new[] { "public transportation" });
                    glossMap.Add("en", en);
                }
                TomoTawaPiKulupuJan = new CompoundWord("tomo-tawa-pi-kulupu-jan");

                Dictionary.Add("tomo-tawa-pi-kulupu-jan", TomoTawaPiKulupuJan);
                Glosses.Add("tomo-tawa-pi-kulupu-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-toki", new[] { "chat room", " IRC" });
                    glossMap.Add("en", en);
                }
                TomoToki = new CompoundWord("tomo-toki");

                Dictionary.Add("tomo-toki", TomoToki);
                Glosses.Add("tomo-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-unpa", new[] { "brothel", " sex house", " bedroom", " place for sex" });
                    glossMap.Add("en", en);
                }
                TomoUnpa = new CompoundWord("tomo-unpa");

                Dictionary.Add("tomo-unpa", TomoUnpa);
                Glosses.Add("tomo-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-utala", new[] { "fortress" });
                    glossMap.Add("en", en);
                }
                TomoUtala = new CompoundWord("tomo-utala");

                Dictionary.Add("tomo-utala", TomoUtala);
                Glosses.Add("tomo-utala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Elena", new[] { "Greek" });
                    glossMap.Add("en", en);
                }
                TokiElena = new CompoundWord("toki-Elena");

                Dictionary.Add("toki-Elena", TokiElena);
                Glosses.Add("toki-Elena", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Epanja", new[] { "Spanish" });
                    glossMap.Add("en", en);
                }
                TokiEpanja = new CompoundWord("toki-Epanja");

                Dictionary.Add("toki-Epanja", TokiEpanja);
                Glosses.Add("toki-Epanja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Epelanto", new[] { "Esperanto" });
                    glossMap.Add("en", en);
                }
                TokiEpelanto = new CompoundWord("toki-Epelanto");

                Dictionary.Add("toki-Epelanto", TokiEpelanto);
                Glosses.Add("toki-Epelanto", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Esi", new[] { "Estonian" });
                    glossMap.Add("en", en);
                }
                TokiEsi = new CompoundWord("toki-Esi");

                Dictionary.Add("toki-Esi", TokiEsi);
                Glosses.Add("toki-Esi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Esuka", new[] { "Basque" });
                    glossMap.Add("en", en);
                }
                TokiEsuka = new CompoundWord("toki-Esuka");

                Dictionary.Add("toki-Esuka", TokiEsuka);
                Glosses.Add("toki-Esuka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Ilan", new[] { "Iranian", " Irish (Gaelge)" });
                    glossMap.Add("en", en);
                }
                TokiIlan = new CompoundWord("toki-Ilan");

                Dictionary.Add("toki-Ilan", TokiIlan);
                Glosses.Add("toki-Ilan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Ingilisi", new[] { "English" });
                    glossMap.Add("en", en);
                }
                TokiIngilisi = new CompoundWord("toki-Ingilisi");

                Dictionary.Add("toki-Ingilisi", TokiIngilisi);
                Glosses.Add("toki-Ingilisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Intelinka", new[] { "Interlingua" });
                    glossMap.Add("en", en);
                }
                TokiIntelinka = new CompoundWord("toki-Intelinka");

                Dictionary.Add("toki-Intelinka", TokiIntelinka);
                Glosses.Add("toki-Intelinka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Intonesija", new[] { "Indonesian" });
                    glossMap.Add("en", en);
                }
                TokiIntonesija = new CompoundWord("toki-Intonesija");

                Dictionary.Add("toki-Intonesija", TokiIntonesija);
                Glosses.Add("toki-Intonesija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Isilan", new[] { "Icelandic" });
                    glossMap.Add("en", en);
                }
                TokiIsilan = new CompoundWord("toki-Isilan");

                Dictionary.Add("toki-Isilan", TokiIsilan);
                Glosses.Add("toki-Isilan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Italija", new[] { "Italian" });
                    glossMap.Add("en", en);
                }
                TokiItalija = new CompoundWord("toki-Italija");

                Dictionary.Add("toki-Italija", TokiItalija);
                Glosses.Add("toki-Italija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Ito", new[] { "Ido" });
                    glossMap.Add("en", en);
                }
                TokiIto = new CompoundWord("toki-Ito");

                Dictionary.Add("toki-Ito", TokiIto);
                Glosses.Add("toki-Ito", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Iwisi", new[] { "Hebrew" });
                    glossMap.Add("en", en);
                }
                TokiIwisi = new CompoundWord("toki-Iwisi");

                Dictionary.Add("toki-Iwisi", TokiIwisi);
                Glosses.Add("toki-Iwisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Kalika", new[] { "Scots" });
                    glossMap.Add("en", en);
                }
                TokiKalika = new CompoundWord("toki-Kalika");

                Dictionary.Add("toki-Kalika", TokiKalika);
                Glosses.Add("toki-Kalika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Kanse", new[] { "French" });
                    glossMap.Add("en", en);
                }
                TokiKanse = new CompoundWord("toki-Kanse");

                Dictionary.Add("toki-Kanse", TokiKanse);
                Glosses.Add("toki-Kanse", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Katala", new[] { "Catalan" });
                    glossMap.Add("en", en);
                }
                TokiKatala = new CompoundWord("toki-Katala");

                Dictionary.Add("toki-Katala", TokiKatala);
                Glosses.Add("toki-Katala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Katelo", new[] { "Georgian" });
                    glossMap.Add("en", en);
                }
                TokiKatelo = new CompoundWord("toki-Katelo");

                Dictionary.Add("toki-Katelo", TokiKatelo);
                Glosses.Add("toki-Katelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Kinla", new[] { "Welsh" });
                    glossMap.Add("en", en);
                }
                TokiKinla = new CompoundWord("toki-Kinla");

                Dictionary.Add("toki-Kinla", TokiKinla);
                Glosses.Add("toki-Kinla", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Kuli", new[] { "Kurdish" });
                    glossMap.Add("en", en);
                }
                TokiKuli = new CompoundWord("toki-Kuli");

                Dictionary.Add("toki-Kuli", TokiKuli);
                Glosses.Add("toki-Kuli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Lasina", new[] { "Latin" });
                    glossMap.Add("en", en);
                }
                TokiLasina = new CompoundWord("toki-Lasina");

                Dictionary.Add("toki-Lasina", TokiLasina);
                Glosses.Add("toki-Lasina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Lawi", new[] { "Latvian" });
                    glossMap.Add("en", en);
                }
                TokiLawi = new CompoundWord("toki-Lawi");

                Dictionary.Add("toki-Lawi", TokiLawi);
                Glosses.Add("toki-Lawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Lijatuwa", new[] { "Lithuanian" });
                    glossMap.Add("en", en);
                }
                TokiLijatuwa = new CompoundWord("toki-Lijatuwa");

                Dictionary.Add("toki-Lijatuwa", TokiLijatuwa);
                Glosses.Add("toki-Lijatuwa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Lomani", new[] { "Romanian" });
                    glossMap.Add("en", en);
                }
                TokiLomani = new CompoundWord("toki-Lomani");

                Dictionary.Add("toki-Lomani", TokiLomani);
                Glosses.Add("toki-Lomani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Losi", new[] { "Russian" });
                    glossMap.Add("en", en);
                }
                TokiLosi = new CompoundWord("toki-Losi");

                Dictionary.Add("toki-Losi", TokiLosi);
                Glosses.Add("toki-Losi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Lowasi", new[] { "Croatian" });
                    glossMap.Add("en", en);
                }
                TokiLowasi = new CompoundWord("toki-Lowasi");

                Dictionary.Add("toki-Lowasi", TokiLowasi);
                Glosses.Add("toki-Lowasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Lowenki", new[] { "Slovakian" });
                    glossMap.Add("en", en);
                }
                TokiLowenki = new CompoundWord("toki-Lowenki");

                Dictionary.Add("toki-Lowenki", TokiLowenki);
                Glosses.Add("toki-Lowenki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Lowensina", new[] { "Slovenian" });
                    glossMap.Add("en", en);
                }
                TokiLowensina = new CompoundWord("toki-Lowensina");

                Dictionary.Add("toki-Lowensina", TokiLowensina);
                Glosses.Add("toki-Lowensina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Malasi", new[] { "Marathi" });
                    glossMap.Add("en", en);
                }
                TokiMalasi = new CompoundWord("toki-Malasi");

                Dictionary.Add("toki-Malasi", TokiMalasi);
                Glosses.Add("toki-Malasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Malasija", new[] { "Malaysian" });
                    glossMap.Add("en", en);
                }
                TokiMalasija = new CompoundWord("toki-Malasija");

                Dictionary.Add("toki-Malasija", TokiMalasija);
                Glosses.Add("toki-Malasija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Mosijo", new[] { "Hungarian" });
                    glossMap.Add("en", en);
                }
                TokiMosijo = new CompoundWord("toki-Mosijo");

                Dictionary.Add("toki-Mosijo", TokiMosijo);
                Glosses.Add("toki-Mosijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Netelan", new[] { "Dutch" });
                    glossMap.Add("en", en);
                }
                TokiNetelan = new CompoundWord("toki-Netelan");

                Dictionary.Add("toki-Netelan", TokiNetelan);
                Glosses.Add("toki-Netelan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Nijon", new[] { "Japanese" });
                    glossMap.Add("en", en);
                }
                TokiNijon = new CompoundWord("toki-Nijon");

                Dictionary.Add("toki-Nijon", TokiNijon);
                Glosses.Add("toki-Nijon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Nosiki", new[] { "Norwegian" });
                    glossMap.Add("en", en);
                }
                TokiNosiki = new CompoundWord("toki-Nosiki");

                Dictionary.Add("toki-Nosiki", TokiNosiki);
                Glosses.Add("toki-Nosiki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Nosiki-sin", new[] { "Nynorsk" });
                    glossMap.Add("en", en);
                }
                TokiNosikiSin = new CompoundWord("toki-Nosiki-sin");

                Dictionary.Add("toki-Nosiki-sin", TokiNosikiSin);
                Glosses.Add("toki-Nosiki-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Palata-elopa", new[] { "Indo-European" });
                    glossMap.Add("en", en);
                }
                TokiPalataElopa = new CompoundWord("toki-Palata-elopa");

                Dictionary.Add("toki-Palata-elopa", TokiPalataElopa);
                Glosses.Add("toki-Palata-elopa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Pelalusi", new[] { "Belarusian" });
                    glossMap.Add("en", en);
                }
                TokiPelalusi = new CompoundWord("toki-Pelalusi");

                Dictionary.Add("toki-Pelalusi", TokiPelalusi);
                Glosses.Add("toki-Pelalusi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Pilipina", new[] { "Tagalog" });
                    glossMap.Add("en", en);
                }
                TokiPilipina = new CompoundWord("toki-Pilipina");

                Dictionary.Add("toki-Pilipina", TokiPilipina);
                Glosses.Add("toki-Pilipina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Pokasi", new[] { "Bulgarian" });
                    glossMap.Add("en", en);
                }
                TokiPokasi = new CompoundWord("toki-Pokasi");

                Dictionary.Add("toki-Pokasi", TokiPokasi);
                Glosses.Add("toki-Pokasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Posan", new[] { "Bosnia" });
                    glossMap.Add("en", en);
                }
                TokiPosan = new CompoundWord("toki-Posan");

                Dictionary.Add("toki-Posan", TokiPosan);
                Glosses.Add("toki-Posan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Posuka", new[] { "Polish" });
                    glossMap.Add("en", en);
                }
                TokiPosuka = new CompoundWord("toki-Posuka");

                Dictionary.Add("toki-Posuka", TokiPosuka);
                Glosses.Add("toki-Posuka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Potuka", new[] { "Portugese" });
                    glossMap.Add("en", en);
                }
                TokiPotuka = new CompoundWord("toki-Potuka");

                Dictionary.Add("toki-Potuka", TokiPotuka);
                Glosses.Add("toki-Potuka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Sankitu", new[] { "Sanskrit" });
                    glossMap.Add("en", en);
                }
                TokiSankitu = new CompoundWord("toki-Sankitu");

                Dictionary.Add("toki-Sankitu", TokiSankitu);
                Glosses.Add("toki-Sankitu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Sanko", new[] { "Chinese" });
                    glossMap.Add("en", en);
                }
                TokiSanko = new CompoundWord("toki-Sanko");

                Dictionary.Add("toki-Sanko", TokiSanko);
                Glosses.Add("toki-Sanko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Sawa", new[] { "Javanese" });
                    glossMap.Add("en", en);
                }
                TokiSawa = new CompoundWord("toki-Sawa");

                Dictionary.Add("toki-Sawa", TokiSawa);
                Glosses.Add("toki-Sawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Seki", new[] { "Czech" });
                    glossMap.Add("en", en);
                }
                TokiSeki = new CompoundWord("toki-Seki");

                Dictionary.Add("toki-Seki", TokiSeki);
                Glosses.Add("toki-Seki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Sinan", new[] { "Klingon" });
                    glossMap.Add("en", en);
                }
                TokiSinan = new CompoundWord("toki-Sinan");

                Dictionary.Add("toki-Sinan", TokiSinan);
                Glosses.Add("toki-Sinan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Sipe", new[] { "Albanian" });
                    glossMap.Add("en", en);
                }
                TokiSipe = new CompoundWord("toki-Sipe");

                Dictionary.Add("toki-Sipe", TokiSipe);
                Glosses.Add("toki-Sipe", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-sonwen", new[] { "Chinese`" });
                    glossMap.Add("en", en);
                }
                TokiSonwen = new CompoundWord("toki-sonwen");

                Dictionary.Add("toki-sonwen", TokiSonwen);
                Glosses.Add("toki-sonwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Sopisi", new[] { "Sebian" });
                    glossMap.Add("en", en);
                }
                TokiSopisi = new CompoundWord("toki-Sopisi");

                Dictionary.Add("toki-Sopisi", TokiSopisi);
                Glosses.Add("toki-Sopisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Sumi", new[] { "Finnish" });
                    glossMap.Add("en", en);
                }
                TokiSumi = new CompoundWord("toki-Sumi");

                Dictionary.Add("toki-Sumi", TokiSumi);
                Glosses.Add("toki-Sumi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Tansi", new[] { "Danish" });
                    glossMap.Add("en", en);
                }
                TokiTansi = new CompoundWord("toki-Tansi");

                Dictionary.Add("toki-Tansi", TokiTansi);
                Glosses.Add("toki-Tansi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Tawi", new[] { "Thai" });
                    glossMap.Add("en", en);
                }
                TokiTawi = new CompoundWord("toki-Tawi");

                Dictionary.Add("toki-Tawi", TokiTawi);
                Glosses.Add("toki-Tawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Tosi", new[] { "German" });
                    glossMap.Add("en", en);
                }
                TokiTosi = new CompoundWord("toki-Tosi");

                Dictionary.Add("toki-Tosi", TokiTosi);
                Glosses.Add("toki-Tosi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Tuku", new[] { "Turkish" });
                    glossMap.Add("en", en);
                }
                TokiTuku = new CompoundWord("toki-Tuku");

                Dictionary.Add("toki-Tuku", TokiTuku);
                Glosses.Add("toki-Tuku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Ukawina", new[] { "Ukrainian" });
                    glossMap.Add("en", en);
                }
                TokiUkawina = new CompoundWord("toki-Ukawina");

                Dictionary.Add("toki-Ukawina", TokiUkawina);
                Glosses.Add("toki-Ukawina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Wensa", new[] { "Swedish" });
                    glossMap.Add("en", en);
                }
                TokiWensa = new CompoundWord("toki-Wensa");

                Dictionary.Add("toki-Wensa", TokiWensa);
                Glosses.Add("toki-Wensa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-Wije", new[] { "Vietnamese" });
                    glossMap.Add("en", en);
                }
                TokiWije = new CompoundWord("toki-Wije");

                Dictionary.Add("toki-Wije", TokiWije);
                Glosses.Add("toki-Wije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-unpa", new[] { "female sexual partner" });
                    glossMap.Add("en", en);
                }
                MeliUnpa = new CompoundWord("meli-unpa");

                Dictionary.Add("meli-unpa", MeliUnpa);
                Glosses.Add("meli-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mije-unpa", new[] { "male sexual partner" });
                    glossMap.Add("en", en);
                }
                MijeUnpa = new CompoundWord("mije-unpa");

                Dictionary.Add("mije-unpa", MijeUnpa);
                Glosses.Add("mije-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("unpa-pilin", new[] { "sexy" });
                    glossMap.Add("en", en);
                }
                UnpaPilin = new CompoundWord("unpa-pilin");

                Dictionary.Add("unpa-pilin", UnpaPilin);
                Glosses.Add("unpa-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("unpa-uta", new[] { "oral sex", " fellatio" });
                    glossMap.Add("en", en);
                }
                UnpaUta = new CompoundWord("unpa-uta");

                Dictionary.Add("unpa-uta", UnpaUta);
                Glosses.Add("unpa-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wile-unpa", new[] { "horny" });
                    glossMap.Add("en", en);
                }
                WileUnpa = new CompoundWord("wile-unpa");

                Dictionary.Add("wile-unpa", WileUnpa);
                Glosses.Add("wile-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("utala-ala", new[] { "peace", " ahimsa" });
                    glossMap.Add("en", en);
                }
                UtalaAla = new CompoundWord("utala-ala");

                Dictionary.Add("utala-ala", UtalaAla);
                Glosses.Add("utala-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("utala-musi", new[] { "game", " competition", " match" });
                    glossMap.Add("en", en);
                }
                UtalaMusi = new CompoundWord("utala-musi");

                Dictionary.Add("utala-musi", UtalaMusi);
                Glosses.Add("utala-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("utala-sewi", new[] { "Holy War" });
                    glossMap.Add("en", en);
                }
                UtalaSewi = new CompoundWord("utala-sewi");

                Dictionary.Add("utala-sewi", UtalaSewi);
                Glosses.Add("utala-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("utala-suli", new[] { "World War" });
                    glossMap.Add("en", en);
                }
                UtalaSuli = new CompoundWord("utala-suli");

                Dictionary.Add("utala-suli", UtalaSuli);
                Glosses.Add("utala-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("utala-toki", new[] { "argue" });
                    glossMap.Add("en", en);
                }
                UtalaToki = new CompoundWord("utala-toki");

                Dictionary.Add("utala-toki", UtalaToki);
                Glosses.Add("utala-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("walo-en-pimeja", new[] { "gray" });
                    glossMap.Add("en", en);
                }
                WaloEnPimeja = new CompoundWord("walo-en-pimeja");

                Dictionary.Add("walo-en-pimeja", WaloEnPimeja);
                Glosses.Add("walo-en-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("walo-uta", new[] { "teeth" });
                    glossMap.Add("en", en);
                }
                WaloUta = new CompoundWord("walo-uta");

                Dictionary.Add("walo-uta", WaloUta);
                Glosses.Add("walo-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-nimi", new[] { "syllable" });
                    glossMap.Add("en", en);
                }
                WanNimi = new CompoundWord("wan-nimi");

                Dictionary.Add("wan-nimi", WanNimi);
                Glosses.Add("wan-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pali-pi-kulupu-nimi-pini", new[] { "predicate" });
                    glossMap.Add("en", en);
                }
                WanPaliPiKulupuNimiPini = new CompoundWord("wan-pali-pi-kulupu-nimi-pini");

                Dictionary.Add("wan-pali-pi-kulupu-nimi-pini", WanPaliPiKulupuNimiPini);
                Glosses.Add("wan-pali-pi-kulupu-nimi-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-nanpa-tu-pi-kulupu-nimi-pini", new[] { "predicate" });
                    glossMap.Add("en", en);
                }
                WanPiNanpaTuPiKulupuNimiPini = new CompoundWord("wan-pi-nanpa-tu-pi-kulupu-nimi-pini");

                Dictionary.Add("wan-pi-nanpa-tu-pi-kulupu-nimi-pini", WanPiNanpaTuPiKulupuNimiPini);
                Glosses.Add("wan-pi-nanpa-tu-pi-kulupu-nimi-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-nanpa-wan-pi-kulupu-nimi-pini", new[] { "subject" });
                    glossMap.Add("en", en);
                }
                WanPiNanpaWanPiKulupuNimiPini = new CompoundWord("wan-pi-nanpa-wan-pi-kulupu-nimi-pini");

                Dictionary.Add("wan-pi-nanpa-wan-pi-kulupu-nimi-pini", WanPiNanpaWanPiKulupuNimiPini);
                Glosses.Add("wan-pi-nanpa-wan-pi-kulupu-nimi-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-pali-ala-pi-kulupu-nimi-pini", new[] { "subject" });
                    glossMap.Add("en", en);
                }
                WanPiPaliAlaPiKulupuNimiPini = new CompoundWord("wan-pi-pali-ala-pi-kulupu-nimi-pini");

                Dictionary.Add("wan-pi-pali-ala-pi-kulupu-nimi-pini", WanPiPaliAlaPiKulupuNimiPini);
                Glosses.Add("wan-pi-pali-ala-pi-kulupu-nimi-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-tenpo-sike", new[] { "season of the year" });
                    glossMap.Add("en", en);
                }
                WanPiTenpoSike = new CompoundWord("wan-pi-tenpo-sike");

                Dictionary.Add("wan-pi-tenpo-sike", WanPiTenpoSike);
                Glosses.Add("wan-pi-tenpo-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-wan-nimi", new[] { "letter", " letter (of alphabet)" });
                    glossMap.Add("en", en);
                }
                WanPiWanNimi = new CompoundWord("wan-pi-wan-nimi");

                Dictionary.Add("wan-pi-wan-nimi", WanPiWanNimi);
                Glosses.Add("wan-pi-wan-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-poka", new[] { "married to" });
                    glossMap.Add("en", en);
                }
                WanPoka = new CompoundWord("wan-poka");

                Dictionary.Add("wan-poka", WanPoka);
                Glosses.Add("wan-poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-suli", new[] { "important part","large part", " big part" });
                    glossMap.Add("en", en);
                }
                WanSuli = new CompoundWord("wan-suli");

                Dictionary.Add("wan-suli", WanSuli);
                Glosses.Add("wan-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-akesi", new[] { "pterodactyl" });
                    glossMap.Add("en", en);
                }
                WasoAkesi = new CompoundWord("waso-akesi");

                Dictionary.Add("waso-akesi", WasoAkesi);
                Glosses.Add("waso-akesi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-kule-toki", new[] { "parrot" });
                    glossMap.Add("en", en);
                }
                WasoKuleToki = new CompoundWord("waso-kule-toki");

                Dictionary.Add("waso-kule-toki", WasoKuleToki);
                Glosses.Add("waso-kule-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-ma", new[] { "ostrich" });
                    glossMap.Add("en", en);
                }
                WasoMa = new CompoundWord("waso-ma");

                Dictionary.Add("waso-ma", WasoMa);
                Glosses.Add("waso-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-ma-pi-tawa-mute", new[] { "ostrich" });
                    glossMap.Add("en", en);
                }
                WasoMaPiTawaMute = new CompoundWord("waso-ma-pi-tawa-mute");

                Dictionary.Add("waso-ma-pi-tawa-mute", WasoMaPiTawaMute);
                Glosses.Add("waso-ma-pi-tawa-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-pi-ma-lete", new[] { "penguin" });
                    glossMap.Add("en", en);
                }
                WasoPiMaLete = new CompoundWord("waso-pi-ma-lete");

                Dictionary.Add("waso-pi-ma-lete", WasoPiMaLete);
                Glosses.Add("waso-pi-ma-lete", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-soweli", new[] { "bat" });
                    glossMap.Add("en", en);
                }
                WasoSoweli = new CompoundWord("waso-soweli");

                Dictionary.Add("waso-soweli", WasoSoweli);
                Glosses.Add("waso-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-walo-telo", new[] { "seagull" });
                    glossMap.Add("en", en);
                }
                WasoWaloTelo = new CompoundWord("waso-walo-telo");

                Dictionary.Add("waso-walo-telo", WasoWaloTelo);
                Glosses.Add("waso-walo-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wawa--sin", new[] { "stronger" });
                    glossMap.Add("en", en);
                }
                WawaSin = new CompoundWord("wawa--sin");

                Dictionary.Add("wawa--sin", WawaSin);
                Glosses.Add("wawa--sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wawa-ala", new[] { "weak", " weak(ly)" });
                    glossMap.Add("en", en);
                }
                WawaAla = new CompoundWord("wawa-ala");

                Dictionary.Add("wawa-ala", WawaAla);
                Glosses.Add("wawa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wawa-ala-sin", new[] { "weaker" });
                    glossMap.Add("en", en);
                }
                WawaAlaSin = new CompoundWord("wawa-ala-sin");

                Dictionary.Add("wawa-ala-sin", WawaAlaSin);
                Glosses.Add("wawa-ala-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wawa-lili", new[] { "impotent" });
                    glossMap.Add("en", en);
                }
                WawaLili = new CompoundWord("wawa-lili");

                Dictionary.Add("wawa-lili", WawaLili);
                Glosses.Add("wawa-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("weka-e-lipu-tan-kulupu-lipu", new[] { "remove a card" });
                    glossMap.Add("en", en);
                }
                WekaELipuTanKulupuLipu = new CompoundWord("weka-e-lipu-tan-kulupu-lipu");

                Dictionary.Add("weka-e-lipu-tan-kulupu-lipu", WekaELipuTanKulupuLipu);
                Glosses.Add("weka-e-lipu-tan-kulupu-lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("weka-lon", new[] { "throw/stay out" });
                    glossMap.Add("en", en);
                }
                WekaLon = new CompoundWord("weka-lon");

                Dictionary.Add("weka-lon", WekaLon);
                Glosses.Add("weka-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("weka-tan", new[] { "far from", " far" });
                    glossMap.Add("en", en);
                }
                WekaTan = new CompoundWord("weka-tan");

                Dictionary.Add("weka-tan", WekaTan);
                Glosses.Add("weka-tan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wile-pona", new[] { "hope" });
                    glossMap.Add("en", en);
                }
                WilePona = new CompoundWord("wile-pona");

                Dictionary.Add("wile-pona", WilePona);
                Glosses.Add("wile-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wile-e-sona", new[] { "wonder" });
                    glossMap.Add("en", en);
                }
                WileESona = new CompoundWord("wile-e-sona");

                Dictionary.Add("wile-e-sona", WileESona);
                Glosses.Add("wile-e-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wile-moku", new[] { "hungry" });
                    glossMap.Add("en", en);
                }
                WileMoku = new CompoundWord("wile-moku");

                Dictionary.Add("wile-moku", WileMoku);
                Glosses.Add("wile-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wile-pali", new[] { "try" });
                    glossMap.Add("en", en);
                }
                WilePali = new CompoundWord("wile-pali");

                Dictionary.Add("wile-pali", WilePali);
                Glosses.Add("wile-pali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wile-sona", new[] { "curiosity", " question" });
                    glossMap.Add("en", en);
                }
                WileSona = new CompoundWord("wile-sona");

                Dictionary.Add("wile-sona", WileSona);
                Glosses.Add("wile-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wile-soweli", new[] { "instinct" });
                    glossMap.Add("en", en);
                }
                WileSoweli = new CompoundWord("wile-soweli");

                Dictionary.Add("wile-soweli", WileSoweli);
                Glosses.Add("wile-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kan-ala", new[] { "with out (not accompanying)" });
                    glossMap.Add("en", en);
                }
                KanAla = new CompoundWord("kan-ala");

                Dictionary.Add("kan-ala", KanAla);
                Glosses.Add("kan-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ali-ala", new[] { "some (not all)" });
                    glossMap.Add("en", en);
                }
                AliAla = new CompoundWord("ali-ala");

                Dictionary.Add("ali-ala", AliAla);
                Glosses.Add("ali-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-unpa", new[] { "seeds" });
                    glossMap.Add("en", en);
                }
                KiwenUnpa = new CompoundWord("kiwen-unpa");

                Dictionary.Add("kiwen-unpa", KiwenUnpa);
                Glosses.Add("kiwen-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-ali", new[] { "the earth", " the world" });
                    glossMap.Add("en", en);
                }
                MaAli = new CompoundWord("ma-ali");

                Dictionary.Add("ma-ali", MaAli);
                Glosses.Add("ma-ali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-kasi", new[] { "garden", " forest", " park", " meadow", " field" });
                    glossMap.Add("en", en);
                }
                MaKasi = new CompoundWord("ma-kasi");

                Dictionary.Add("ma-kasi", MaKasi);
                Glosses.Add("ma-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kina", new[] { "China" });
                    glossMap.Add("en", en);
                }
                MaKina = new CompoundWord("ma-Kina");

                Dictionary.Add("ma-Kina", MaKina);
                Glosses.Add("ma-Kina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pelija", new[] { "Belize" });
                    glossMap.Add("en", en);
                }
                MaPelija = new CompoundWord("ma-Pelija");

                Dictionary.Add("ma-Pelija", MaPelija);
                Glosses.Add("ma-Pelija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-ike-ale", new[] { "hell" });
                    glossMap.Add("en", en);
                }
                MaPiIkeAle = new CompoundWord("ma-pi-ike-ale");

                Dictionary.Add("ma-pi-ike-ale", MaPiIkeAle);
                Glosses.Add("ma-pi-ike-ale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-kama-jo-ijo-mute", new[] { "market" });
                    glossMap.Add("en", en);
                }
                MaPiKamaJoIjoMute = new CompoundWord("ma-pi-kama-jo-ijo-mute");

                Dictionary.Add("ma-pi-kama-jo-ijo-mute", MaPiKamaJoIjoMute);
                Glosses.Add("ma-pi-kama-jo-ijo-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-kasi-moku", new[] { "orchard" });
                    glossMap.Add("en", en);
                }
                MaPiKasiMoku = new CompoundWord("ma-pi-kasi-moku");

                Dictionary.Add("ma-pi-kasi-moku", MaPiKasiMoku);
                Glosses.Add("ma-pi-kasi-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-pona-ale", new[] { "heaven" });
                    glossMap.Add("en", en);
                }
                MaPiPonaAle = new CompoundWord("ma-pi-pona-ale");

                Dictionary.Add("ma-pi-pona-ale", MaPiPonaAle);
                Glosses.Add("ma-pi-pona-ale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-sona-tawa", new[] { "internet" });
                    glossMap.Add("en", en);
                }
                MaPiSonaTawa = new CompoundWord("ma-pi-sona-tawa");

                Dictionary.Add("ma-pi-sona-tawa", MaPiSonaTawa);
                Glosses.Add("ma-pi-sona-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-sewi", new[] { "Heaven" });
                    glossMap.Add("en", en);
                }
                MaSewi = new CompoundWord("ma-sewi");

                Dictionary.Add("ma-sewi", MaSewi);
                Glosses.Add("ma-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-supa", new[] { "plains" });
                    glossMap.Add("en", en);
                }
                MaSupa = new CompoundWord("ma-supa");

                Dictionary.Add("ma-supa", MaSupa);
                Glosses.Add("ma-supa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-telo", new[] { "swamp tar" });
                    glossMap.Add("en", en);
                }
                MaTelo = new CompoundWord("ma-telo");

                Dictionary.Add("ma-telo", MaTelo);
                Glosses.Add("ma-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-telo-jaki", new[] { "mud", " slops" });
                    glossMap.Add("en", en);
                }
                MaTeloJaki = new CompoundWord("ma-telo-jaki");

                Dictionary.Add("ma-telo-jaki", MaTeloJaki);
                Glosses.Add("ma-telo-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-telo", new[] { "harbor", " port" });
                    glossMap.Add("en", en);
                }
                MaTomoTelo = new CompoundWord("ma-tomo-telo");

                Dictionary.Add("ma-tomo-telo", MaTomoTelo);
                Glosses.Add("ma-tomo-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mama-ma", new[] { "Nature (personified)" });
                    glossMap.Add("en", en);
                }
                MamaMa = new CompoundWord("mama-ma");

                Dictionary.Add("mama-ma", MamaMa);
                Glosses.Add("mama-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-suwi", new[] { "dear lady" });
                    glossMap.Add("en", en);
                }
                MeliSuwi = new CompoundWord("meli-suwi");

                Dictionary.Add("meli-suwi", MeliSuwi);
                Glosses.Add("meli-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-pi-telo-mama", new[] { "cheese" });
                    glossMap.Add("en", en);
                }
                MokuPiTeloMama = new CompoundWord("moku-pi-telo-mama");

                Dictionary.Add("moku-pi-telo-mama", MokuPiTeloMama);
                Glosses.Add("moku-pi-telo-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-kiwen-pi-telo-mama", new[] { "cheese" });
                    glossMap.Add("en", en);
                }
                MokuKiwenPiTeloMama = new CompoundWord("moku-kiwen-pi-telo-mama");

                Dictionary.Add("moku-kiwen-pi-telo-mama", MokuKiwenPiTeloMama);
                Glosses.Add("moku-kiwen-pi-telo-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-kiwen", new[] { "bread" });
                    glossMap.Add("en", en);
                }
                MokuKiwen = new CompoundWord("moku-kiwen");

                Dictionary.Add("moku-kiwen", MokuKiwen);
                Glosses.Add("moku-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-lete-suwi", new[] { "ice cream (etc.)" });
                    glossMap.Add("en", en);
                }
                MokuLeteSuwi = new CompoundWord("moku-lete-suwi");

                Dictionary.Add("moku-lete-suwi", MokuLeteSuwi);
                Glosses.Add("moku-lete-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-linja", new[] { "noodles" });
                    glossMap.Add("en", en);
                }
                MokuLinja = new CompoundWord("moku-linja");

                Dictionary.Add("moku-linja", MokuLinja);
                Glosses.Add("moku-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-pimeja-suwi", new[] { "chocolate" });
                    glossMap.Add("en", en);
                }
                MokuPimejaSuwi = new CompoundWord("moku-pimeja-suwi");

                Dictionary.Add("moku-pimeja-suwi", MokuPimejaSuwi);
                Glosses.Add("moku-pimeja-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moli-ala", new[] { "life" });
                    glossMap.Add("en", en);
                }
                MoliAla = new CompoundWord("moli-ala");

                Dictionary.Add("moli-ala", MoliAla);
                Glosses.Add("moli-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("musi-ike", new[] { "cheat" });
                    glossMap.Add("en", en);
                }
                MusiIke = new CompoundWord("musi-ike");

                Dictionary.Add("musi-ike", MusiIke);
                Glosses.Add("musi-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("musi-pona", new[] { "game", " hobby", " " });
                    glossMap.Add("en", en);
                }
                MusiPona = new CompoundWord("musi-pona");

                Dictionary.Add("musi-pona", MusiPona);
                Glosses.Add("musi-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("musi-toki", new[] { "joke" });
                    glossMap.Add("en", en);
                }
                MusiToki = new CompoundWord("musi-toki");

                Dictionary.Add("musi-toki", MusiToki);
                Glosses.Add("musi-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mute-lili-lili", new[] { "very few" });
                    glossMap.Add("en", en);
                }
                MuteLiliLili = new CompoundWord("mute-lili-lili");

                Dictionary.Add("mute-lili-lili", MuteLiliLili);
                Glosses.Add("mute-lili-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mute-pona", new[] { "sufficient", " enough" });
                    glossMap.Add("en", en);
                }
                MutePona = new CompoundWord("mute-pona");

                Dictionary.Add("mute-pona", MutePona);
                Glosses.Add("mute-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mute-seme", new[] { "how many" });
                    glossMap.Add("en", en);
                }
                MuteSeme = new CompoundWord("mute-seme");

                Dictionary.Add("mute-seme", MuteSeme);
                Glosses.Add("mute-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo--toki", new[] { " some communication device" });
                    glossMap.Add("en", en);
                }
                TomoToki = new CompoundWord("tomo--toki");

                Dictionary.Add("tomo--toki", TomoToki);
                Glosses.Add("tomo--toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wike-e-sona", new[] { "wonder" });
                    glossMap.Add("en", en);
                }
                WikeESona = new CompoundWord("wike-e-sona");

                Dictionary.Add("wike-e-sona", WikeESona);
                Glosses.Add("wike-e-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-nasa", new[] { "drug pills" });
                    glossMap.Add("en", en);
                }
                SikeNasa = new CompoundWord("sike-nasa");

                Dictionary.Add("sike-nasa", SikeNasa);
                Glosses.Add("sike-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-sike-nasa", new[] { "drug pills" });
                    glossMap.Add("en", en);
                }
                MokuSikeNasa = new CompoundWord("moku-sike-nasa");

                Dictionary.Add("moku-sike-nasa", MokuSikeNasa);
                Glosses.Add("moku-sike-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-kiwen-pi-jan-sewi", new[] { "statue of a god" });
                    glossMap.Add("en", en);
                }
                SitelenKiwenPiJanSewi = new CompoundWord("sitelen-kiwen-pi-jan-sewi");

                Dictionary.Add("sitelen-kiwen-pi-jan-sewi", SitelenKiwenPiJanSewi);
                Glosses.Add("sitelen-kiwen-pi-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-pi-jan-sewi", new[] { "statue of a god" });
                    glossMap.Add("en", en);
                }
                KiwenPiJanSewi = new CompoundWord("kiwen-pi-jan-sewi");

                Dictionary.Add("kiwen-pi-jan-sewi", KiwenPiJanSewi);
                Glosses.Add("kiwen-pi-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("a-soweli", new[] { "yelp" });
                    glossMap.Add("en", en);
                }
                ASoweli = new CompoundWord("a-soweli");

                Dictionary.Add("a-soweli", ASoweli);
                Glosses.Add("a-soweli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-pi-uta-suli", new[] { "alligator" });
                    glossMap.Add("en", en);
                }
                AkesiPiUtaSuli = new CompoundWord("akesi-pi-uta-suli");

                Dictionary.Add("akesi-pi-uta-suli", AkesiPiUtaSuli);
                Glosses.Add("akesi-pi-uta-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("akesi-telo-wawa", new[] { "alligator" });
                    glossMap.Add("en", en);
                }
                AkesiTeloWawa = new CompoundWord("akesi-telo-wawa");

                Dictionary.Add("akesi-telo-wawa", AkesiTeloWawa);
                Glosses.Add("akesi-telo-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("awen-tawa", new[] { "keep on going", " stop going" });
                    glossMap.Add("en", en);
                }
                AwenTawa = new CompoundWord("awen-tawa");

                Dictionary.Add("awen-tawa", AwenTawa);
                Glosses.Add("awen-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("awen-weka", new[] { "keep away", " delay" });
                    glossMap.Add("en", en);
                }
                AwenWeka = new CompoundWord("awen-weka");

                Dictionary.Add("awen-weka", AwenWeka);
                Glosses.Add("awen-weka", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("en-tenpo-suno-en-tenpo-pimeja", new[] { "day and night" });
            //        glossMap.Add("en", en);
            //    }
            //    EnTenpoSunoEnTenpoPimeja = new CompoundWord("en-tenpo-suno-en-tenpo-pimeja");

            //    Dictionary.Add("en-tenpo-suno-en-tenpo-pimeja", EnTenpoSunoEnTenpoPimeja);
            //    Glosses.Add("en-tenpo-suno-en-tenpo-pimeja", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-nanpa-wan", new[] { "first thing" });
                    glossMap.Add("en", en);
                }
                IjoNanpaWan = new CompoundWord("ijo-nanpa-wan");

                Dictionary.Add("ijo-nanpa-wan", IjoNanpaWan);
                Glosses.Add("ijo-nanpa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-pi-anpa-selo", new[] { "hidden thing" });
                    glossMap.Add("en", en);
                }
                IjoPiAnpaSelo = new CompoundWord("ijo-pi-anpa-selo");

                Dictionary.Add("ijo-pi-anpa-selo", IjoPiAnpaSelo);
                Glosses.Add("ijo-pi-anpa-selo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-pi-awen-ijo", new[] { "file (computer)" });
                    glossMap.Add("en", en);
                }
                IjoPiAwenIjo = new CompoundWord("ijo-pi-awen-ijo");

                Dictionary.Add("ijo-pi-awen-ijo", IjoPiAwenIjo);
                Glosses.Add("ijo-pi-awen-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-pi-lukin-ala", new[] { "invisble3 thing" });
                    glossMap.Add("en", en);
                }
                IjoPiLukinAla = new CompoundWord("ijo-pi-lukin-ala");

                Dictionary.Add("ijo-pi-lukin-ala", IjoPiLukinAla);
                Glosses.Add("ijo-pi-lukin-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-selo", new[] { "concealed thing" });
                    glossMap.Add("en", en);
                }
                IjoSelo = new CompoundWord("ijo-selo");

                Dictionary.Add("ijo-selo", IjoSelo);
                Glosses.Add("ijo-selo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ijo-tawa-jan-sewi", new[] { "sacrifice", " offering" });
                    glossMap.Add("en", en);
                }
                IjoTawaJanSewi = new CompoundWord("ijo-tawa-jan-sewi");

                Dictionary.Add("ijo-tawa-jan-sewi", IjoTawaJanSewi);
                Glosses.Add("ijo-tawa-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-len", new[] { "washing machine", " loom" });
                    glossMap.Add("en", en);
                }
                IloLen = new CompoundWord("ilo-len");

                Dictionary.Add("ilo-len", IloLen);
                Glosses.Add("ilo-len", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-kalama-sewi", new[] { "ritual horn (conch", " ram", " etc.)" });
                    glossMap.Add("en", en);
                }
                IloPiKalamaSewi = new CompoundWord("ilo-pi-kalama-sewi");

                Dictionary.Add("ilo-pi-kalama-sewi", IloPiKalamaSewi);
                Glosses.Add("ilo-pi-kalama-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-tawa-pi-telo-loje", new[] { "heart (organ)" });
                    glossMap.Add("en", en);
                }
                IloPiTawaPiTeloLoje = new CompoundWord("ilo-pi-tawa-pi-telo-loje");

                Dictionary.Add("ilo-pi-tawa-pi-telo-loje", IloPiTawaPiTeloLoje);
                Glosses.Add("ilo-pi-tawa-pi-telo-loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-pi-toki-suli", new[] { "microphone", " loudspeaker" });
                    glossMap.Add("en", en);
                }
                IloPiTokiSuli = new CompoundWord("ilo-pi-toki-suli");

                Dictionary.Add("ilo-pi-toki-suli", IloPiTokiSuli);
                Glosses.Add("ilo-pi-toki-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-sewi", new[] { "ritual device", " spec.mala", " rosary" });
                    glossMap.Add("en", en);
                }
                IloSewi = new CompoundWord("ilo-sewi");

                Dictionary.Add("ilo-sewi", IloSewi);
                Glosses.Add("ilo-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ilo-utala-palisa-kasi", new[] { "bow and arrow" });
                    glossMap.Add("en", en);
                }
                IloUtalaPalisaKasi = new CompoundWord("ilo-utala-palisa-kasi");

                Dictionary.Add("ilo-utala-palisa-kasi", IloUtalaPalisaKasi);
                Glosses.Add("ilo-utala-palisa-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("insa-loje", new[] { "liver" });
                    glossMap.Add("en", en);
                }
                InsaLoje = new CompoundWord("insa-loje");

                Dictionary.Add("insa-loje", InsaLoje);
                Glosses.Add("insa-loje", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-mi", new[] { "atman", " self" });
                    glossMap.Add("en", en);
                }
                JanMi = new CompoundWord("jan-mi");

                Dictionary.Add("jan-mi", JanMi);
                Glosses.Add("jan-mi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-ilo", new[] { "robot" });
                    glossMap.Add("en", en);
                }
                JanIlo = new CompoundWord("jan-ilo");

                Dictionary.Add("jan-ilo", JanIlo);
                Glosses.Add("jan-ilo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-jaki", new[] { "infected person (plague)" });
                    glossMap.Add("en", en);
                }
                JanJaki = new CompoundWord("jan-jaki");

                Dictionary.Add("jan-jaki", JanJaki);
                Glosses.Add("jan-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-kiwen", new[] { "statue (of a person)" });
                    glossMap.Add("en", en);
                }
                JanKiwen = new CompoundWord("jan-kiwen");

                Dictionary.Add("jan-kiwen", JanKiwen);
                Glosses.Add("jan-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-lawa-sewi", new[] { "priest", " shaman", " Pope" });
                    glossMap.Add("en", en);
                }
                JanLawaSewi = new CompoundWord("jan-lawa-sewi");

                Dictionary.Add("jan-lawa-sewi", JanLawaSewi);
                Glosses.Add("jan-lawa-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pali-pi-ko-ma", new[] { "potter" });
                    glossMap.Add("en", en);
                }
                JanPaliPiKoMa = new CompoundWord("jan-pali-pi-ko-ma");

                Dictionary.Add("jan-pali-pi-ko-ma", JanPaliPiKoMa);
                Glosses.Add("jan-pali-pi-ko-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-pona-ijo", new[] { "repairman" });
                    glossMap.Add("en", en);
                }
                JanPiPonaIjo = new CompoundWord("jan-pi-pona-ijo");

                Dictionary.Add("jan-pi-pona-ijo", JanPiPonaIjo);
                Glosses.Add("jan-pi-pona-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-pona-ike", new[] { "repairman" });
                    glossMap.Add("en", en);
                }
                JanPiPonaIke = new CompoundWord("jan-pi-pona-ike");

                Dictionary.Add("jan-pi-pona-ike", JanPiPonaIke);
                Glosses.Add("jan-pi-pona-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-tenpo-kama", new[] { "posterity" });
                    glossMap.Add("en", en);
                }
                JanPiTenpoKama = new CompoundWord("jan-pi-tenpo-kama");

                Dictionary.Add("jan-pi-tenpo-kama", JanPiTenpoKama);
                Glosses.Add("jan-pi-tenpo-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-tenpo-kama-sama", new[] { "posterity" });
                    glossMap.Add("en", en);
                }
                JanPiTenpoKamaSama = new CompoundWord("jan-pi-tenpo-kama-sama");

                Dictionary.Add("jan-pi-tenpo-kama-sama", JanPiTenpoKamaSama);
                Glosses.Add("jan-pi-tenpo-kama-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-pi-weka-lipu", new[] { "person who removes web pages" });
                    glossMap.Add("en", en);
                }
                JanPiWekaLipu = new CompoundWord("jan-pi-weka-lipu");

                Dictionary.Add("jan-pi-weka-lipu", JanPiWekaLipu);
                Glosses.Add("jan-pi-weka-lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sewi-pi-sijelo-ala", new[] { "atman", " self" });
                    glossMap.Add("en", en);
                }
                JanSewiPiSijeloAla = new CompoundWord("jan-sewi-pi-sijelo-ala");

                Dictionary.Add("jan-sewi-pi-sijelo-ala", JanSewiPiSijeloAla);
                Glosses.Add("jan-sewi-pi-sijelo-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sewi-ale", new[] { "god" });
                    glossMap.Add("en", en);
                }
                JanSewiAle = new CompoundWord("jan-sewi-ale");

                Dictionary.Add("jan-sewi-ale", JanSewiAle);
                Glosses.Add("jan-sewi-ale", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-sewi-lili", new[] { "priest" });
                    glossMap.Add("en", en);
                }
                JanSewiLili = new CompoundWord("jan-sewi-lili");

                Dictionary.Add("jan-sewi-lili", JanSewiLili);
                Glosses.Add("jan-sewi-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-suli-lili", new[] { "teenager", " dwarf" });
                    glossMap.Add("en", en);
                }
                JanSuliLili = new CompoundWord("jan-suli-lili");

                Dictionary.Add("jan-suli-lili", JanSuliLili);
                Glosses.Add("jan-suli-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-suli-pi-nasin-lawa", new[] { "pokiceman" });
                    glossMap.Add("en", en);
                }
                JanSuliPiNasinLawa = new CompoundWord("jan-suli-pi-nasin-lawa");

                Dictionary.Add("jan-suli-pi-nasin-lawa", JanSuliPiNasinLawa);
                Glosses.Add("jan-suli-pi-nasin-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-tawa-awen", new[] { "settler" });
                    glossMap.Add("en", en);
                }
                JanTawaAwen = new CompoundWord("jan-tawa-awen");

                Dictionary.Add("jan-tawa-awen", JanTawaAwen);
                Glosses.Add("jan-tawa-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-utala-lawa", new[] { "General" });
                    glossMap.Add("en", en);
                }
                JanUtalaLawa = new CompoundWord("jan-utala-lawa");

                Dictionary.Add("jan-utala-lawa", JanUtalaLawa);
                Glosses.Add("jan-utala-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jan-weka", new[] { "editor Person in charge of getting rid of things" });
                    glossMap.Add("en", en);
                }
                JanWeka = new CompoundWord("jan-weka");

                Dictionary.Add("jan-weka", JanWeka);
                Glosses.Add("jan-weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jelo-wawa", new[] { "strong","intense yellow-green" });
                    glossMap.Add("en", en);
                }
                JeloWawa = new CompoundWord("jelo-wawa");

                Dictionary.Add("jelo-wawa", JeloWawa);
                Glosses.Add("jelo-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("jo-wawa", new[] { "grasp", " grip", " clutch" });
                    glossMap.Add("en", en);
                }
                JoWawa = new CompoundWord("jo-wawa");

                Dictionary.Add("jo-wawa", JoWawa);
                Glosses.Add("jo-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kala-kiwen", new[] { "submarine" });
                    glossMap.Add("en", en);
                }
                KalaKiwen = new CompoundWord("kala-kiwen");

                Dictionary.Add("kala-kiwen", KalaKiwen);
                Glosses.Add("kala-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-musi-pi-pona-tawa-Pakawan", new[] { "kirtan" });
                    glossMap.Add("en", en);
                }
                KalamaMusiPiPonaTawaPakawan = new CompoundWord("kalama-musi-pi-pona-tawa-Pakawan");

                Dictionary.Add("kalama-musi-pi-pona-tawa-Pakawan", KalamaMusiPiPonaTawaPakawan);
                Glosses.Add("kalama-musi-pi-pona-tawa-Pakawan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-musi-sewi", new[] { "kirtan", " ritual dance" });
                    glossMap.Add("en", en);
                }
                KalamaMusiSewi = new CompoundWord("kalama-musi-sewi");

                Dictionary.Add("kalama-musi-sewi", KalamaMusiSewi);
                Glosses.Add("kalama-musi-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-musi-toki", new[] { "opera" });
                    glossMap.Add("en", en);
                }
                KalamaMusiToki = new CompoundWord("kalama-musi-toki");

                Dictionary.Add("kalama-musi-toki", KalamaMusiToki);
                Glosses.Add("kalama-musi-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-nimi", new[] { "syllable", " phoneme" });
                    glossMap.Add("en", en);
                }
                KalamaNimi = new CompoundWord("kalama-nimi");

                Dictionary.Add("kalama-nimi", KalamaNimi);
                Glosses.Add("kalama-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-pi-kon-ante", new[] { "consonant" });
                    glossMap.Add("en", en);
                }
                KalamaPiKonAnte = new CompoundWord("kalama-pi-kon-ante");

                Dictionary.Add("kalama-pi-kon-ante", KalamaPiKonAnte);
                Glosses.Add("kalama-pi-kon-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-pi-kon-awen", new[] { "vowel" });
                    glossMap.Add("en", en);
                }
                KalamaPiKonAwen = new CompoundWord("kalama-pi-kon-awen");

                Dictionary.Add("kalama-pi-kon-awen", KalamaPiKonAwen);
                Glosses.Add("kalama-pi-kon-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-jo-wawa", new[] { "snatch", " grab", " steal", " rob of" });
                    glossMap.Add("en", en);
                }
                KamaJoWawa = new CompoundWord("kama-jo-wawa");

                Dictionary.Add("kama-jo-wawa", KamaJoWawa);
                Glosses.Add("kama-jo-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-lon", new[] { "try to" });
                    glossMap.Add("en", en);
                }
                KamaLon = new CompoundWord("kama-lon");

                Dictionary.Add("kama-lon", KamaLon);
                Glosses.Add("kama-lon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-lon-ona", new[] { "come to where he was" });
                    glossMap.Add("en", en);
                }
                KamaLonOna = new CompoundWord("kama-lon-ona");

                Dictionary.Add("kama-lon-ona", KamaLonOna);
                Glosses.Add("kama-lon-ona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-lukin", new[] { "find" });
                    glossMap.Add("en", en);
                }
                KamaLukin = new CompoundWord("kama-lukin");

                Dictionary.Add("kama-lukin", KamaLukin);
                Glosses.Add("kama-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-musi", new[] { "party" });
                    glossMap.Add("en", en);
                }
                KamaMusi = new CompoundWord("kama-musi");

                Dictionary.Add("kama-musi", KamaMusi);
                Glosses.Add("kama-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-nasa", new[] { "go crazy" });
                    glossMap.Add("en", en);
                }
                KamaNasa = new CompoundWord("kama-nasa");

                Dictionary.Add("kama-nasa", KamaNasa);
                Glosses.Add("kama-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-pi-tenpo-suno", new[] { "diary" });
                    glossMap.Add("en", en);
                }
                KamaPiTenpoSuno = new CompoundWord("kama-pi-tenpo-suno");

                Dictionary.Add("kama-pi-tenpo-suno", KamaPiTenpoSuno);
                Glosses.Add("kama-pi-tenpo-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-sona-ala", new[] { "become confused", " forget" });
                    glossMap.Add("en", en);
                }
                KamaSonaAla = new CompoundWord("kama-sona-ala");

                Dictionary.Add("kama-sona-ala", KamaSonaAla);
                Glosses.Add("kama-sona-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kama-wawa-ijo", new[] { "run into things" });
                    glossMap.Add("en", en);
                }
                KamaWawaIjo = new CompoundWord("kama-wawa-ijo");

                Dictionary.Add("kama-wawa-ijo", KamaWawaIjo);
                Glosses.Add("kama-wawa-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-lili-nasa", new[] { "some recreational plant" });
                    glossMap.Add("en", en);
                }
                KasiLiliNasa = new CompoundWord("kasi-lili-nasa");

                Dictionary.Add("kasi-lili-nasa", KasiLiliNasa);
                Glosses.Add("kasi-lili-nasa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-loje-pi-len-lawa", new[] { "tulip" });
                    glossMap.Add("en", en);
                }
                KasiLojePiLenLawa = new CompoundWord("kasi-loje-pi-len-lawa");

                Dictionary.Add("kasi-loje-pi-len-lawa", KasiLojePiLenLawa);
                Glosses.Add("kasi-loje-pi-len-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-mute-insa-tomo-mute", new[] { "park" });
                    glossMap.Add("en", en);
                }
                KasiMuteInsaTomoMute = new CompoundWord("kasi-mute-insa-tomo-mute");

                Dictionary.Add("kasi-mute-insa-tomo-mute", KasiMuteInsaTomoMute);
                Glosses.Add("kasi-mute-insa-tomo-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kasi-sewi", new[] { "ritual plant", " tulsi (holy basil)" });
                    glossMap.Add("en", en);
                }
                KasiSewi = new CompoundWord("kasi-sewi");

                Dictionary.Add("kasi-sewi", KasiSewi);
                Glosses.Add("kasi-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ken-kama", new[] { "invitation" });
                    glossMap.Add("en", en);
                }
                KenKama = new CompoundWord("ken-kama");

                Dictionary.Add("ken-kama", KenKama);
                Glosses.Add("ken-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ken-toki", new[] { "freedom of speech" });
                    glossMap.Add("en", en);
                }
                KenToki = new CompoundWord("ken-toki");

                Dictionary.Add("ken-toki", KenToki);
                Glosses.Add("ken-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kepeken-pona-lili", new[] { "with difficulty" });
                    glossMap.Add("en", en);
                }
                KepekenPonaLili = new CompoundWord("kepeken-pona-lili");

                Dictionary.Add("kepeken-pona-lili", KepekenPonaLili);
                Glosses.Add("kepeken-pona-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-linja", new[] { "corn" });
                    glossMap.Add("en", en);
                }
                KiliLinja = new CompoundWord("kili-linja");

                Dictionary.Add("kili-linja", KiliLinja);
                Glosses.Add("kili-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kili-suwi-jelo", new[] { "banana" });
                    glossMap.Add("en", en);
                }
                KiliSuwiJelo = new CompoundWord("kili-suwi-jelo");

                Dictionary.Add("kili-suwi-jelo", KiliSuwiJelo);
                Glosses.Add("kili-suwi-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-kule", new[] { "gem jewel" });
                    glossMap.Add("en", en);
                }
                KiwenKule = new CompoundWord("kiwen-kule");

                Dictionary.Add("kiwen-kule", KiwenKule);
                Glosses.Add("kiwen-kule", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kiwen-wawa-pimeja", new[] { "coal" });
                    glossMap.Add("en", en);
                }
                KiwenWawaPimeja = new CompoundWord("kiwen-wawa-pimeja");

                Dictionary.Add("kiwen-wawa-pimeja", KiwenWawaPimeja);
                Glosses.Add("kiwen-wawa-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-kili", new[] { "(olive) oil", " jam", " puree", " much" });
                    glossMap.Add("en", en);
                }
                KoKili = new CompoundWord("ko-kili");

                Dictionary.Add("ko-kili", KoKili);
                Glosses.Add("ko-kili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-mama", new[] { "pollen" });
                    glossMap.Add("en", en);
                }
                KoMama = new CompoundWord("ko-mama");

                Dictionary.Add("ko-mama", KoMama);
                Glosses.Add("ko-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-pi-telo-lete", new[] { "snow" });
                    glossMap.Add("en", en);
                }
                KoPiTeloLete = new CompoundWord("ko-pi-telo-lete");

                Dictionary.Add("ko-pi-telo-lete", KoPiTeloLete);
                Glosses.Add("ko-pi-telo-lete", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-pimeja", new[] { "petroleum" });
                    glossMap.Add("en", en);
                }
                KoPimeja = new CompoundWord("ko-pimeja");

                Dictionary.Add("ko-pimeja", KoPimeja);
                Glosses.Add("ko-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ko-wawa-walo", new[] { "cocaine" });
                    glossMap.Add("en", en);
                }
                KoWawaWalo = new CompoundWord("ko-wawa-walo");

                Dictionary.Add("ko-wawa-walo", KoWawaWalo);
                Glosses.Add("ko-wawa-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kon-pakala", new[] { "a cold" });
                    glossMap.Add("en", en);
                }
                KonPakala = new CompoundWord("kon-pakala");

                Dictionary.Add("kon-pakala", KonPakala);
                Glosses.Add("kon-pakala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-ma", new[] { "earth color", " brown" });
                    glossMap.Add("en", en);
                }
                KuleMa = new CompoundWord("kule-ma");

                Dictionary.Add("kule-ma", KuleMa);
                Glosses.Add("kule-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kule-telo", new[] { "paint" });
                    glossMap.Add("en", en);
                }
                KuleTelo = new CompoundWord("kule-telo");

                Dictionary.Add("kule-telo", KuleTelo);
                Glosses.Add("kule-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-jan-pi-ma-suli", new[] { "race" });
                    glossMap.Add("en", en);
                }
                KulupuJanPiMaSuli = new CompoundWord("kulupu-jan-pi-ma-suli");

                Dictionary.Add("kulupu-jan-pi-ma-suli", KulupuJanPiMaSuli);
                Glosses.Add("kulupu-jan-pi-ma-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-lipu-sitelen", new[] { "group list" });
                    glossMap.Add("en", en);
                }
                KulupuLipuSitelen = new CompoundWord("kulupu-lipu-sitelen");

                Dictionary.Add("kulupu-lipu-sitelen", KulupuLipuSitelen);
                Glosses.Add("kulupu-lipu-sitelen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-monsi", new[] { "predicate" });
                    glossMap.Add("en", en);
                }
                KulupuMonsi = new CompoundWord("kulupu-monsi");

                Dictionary.Add("kulupu-monsi", KulupuMonsi);
                Glosses.Add("kulupu-monsi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-open", new[] { "head phrase" });
                    glossMap.Add("en", en);
                }
                KulupuOpen = new CompoundWord("kulupu-open");

                Dictionary.Add("kulupu-open", KulupuOpen);
                Glosses.Add("kulupu-open", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-pi-jan-ma", new[] { "nation" });
                    glossMap.Add("en", en);
                }
                KulupuPiJanMa = new CompoundWord("kulupu-pi-jan-ma");

                Dictionary.Add("kulupu-pi-jan-ma", KulupuPiJanMa);
                Glosses.Add("kulupu-pi-jan-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-pi-nimi-ante", new[] { "adverbial phrase" });
                    glossMap.Add("en", en);
                }
                KulupuPiNimiAnte = new CompoundWord("kulupu-pi-nimi-ante");

                Dictionary.Add("kulupu-pi-nimi-ante", KulupuPiNimiAnte);
                Glosses.Add("kulupu-pi-nimi-ante", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-pini", new[] { "predicate" });
                    glossMap.Add("en", en);
                }
                KulupuPini = new CompoundWord("kulupu-pini");

                Dictionary.Add("kulupu-pini", KulupuPini);
                Glosses.Add("kulupu-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kulupu-sinpin", new[] { "head phrase" });
                    glossMap.Add("en", en);
                }
                KulupuSinpin = new CompoundWord("kulupu-sinpin");

                Dictionary.Add("kulupu-sinpin", KulupuSinpin);
                Glosses.Add("kulupu-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lawa-nim", new[] { "grammar" });
                    glossMap.Add("en", en);
                }
                LawaNim = new CompoundWord("lawa-nim");

                Dictionary.Add("lawa-nim", LawaNim);
                Glosses.Add("lawa-nim", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lawa-pi-kalama-nimi", new[] { "phometics" });
                    glossMap.Add("en", en);
                }
                LawaPiKalamaNimi = new CompoundWord("lawa-pi-kalama-nimi");

                Dictionary.Add("lawa-pi-kalama-nimi", LawaPiKalamaNimi);
                Glosses.Add("lawa-pi-kalama-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-ilo-nanpa", new[] { "internet" });
                    glossMap.Add("en", en);
                }
                LenIloNanpa = new CompoundWord("len-ilo-nanpa");

                Dictionary.Add("len-ilo-nanpa", LenIloNanpa);
                Glosses.Add("len-ilo-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-linja", new[] { "dhoti", " lava-lava and the like" });
                    glossMap.Add("en", en);
                }
                LenLinja = new CompoundWord("len-linja");

                Dictionary.Add("len-linja", LenLinja);
                Glosses.Add("len-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("len-sewi", new[] { "(dhoti as) ritual dress" });
                    glossMap.Add("en", en);
                }
                LenSewi = new CompoundWord("len-sewi");

                Dictionary.Add("len-sewi", LenSewi);
                Glosses.Add("len-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-pi-ma-seli", new[] { "equator" });
                    glossMap.Add("en", en);
                }
                LinjaPiMaSeli = new CompoundWord("linja-pi-ma-seli");

                Dictionary.Add("linja-pi-ma-seli", LinjaPiMaSeli);
                Glosses.Add("linja-pi-ma-seli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("linja-pilin", new[] { "nerve (wires)" });
                    glossMap.Add("en", en);
                }
                LinjaPilin = new CompoundWord("linja-pilin");

                Dictionary.Add("linja-pilin", LinjaPilin);
                Glosses.Add("linja-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-lipu", new[] { "book" });
                    glossMap.Add("en", en);
                }
                LipuLipu = new CompoundWord("lipu-lipu");

                Dictionary.Add("lipu-lipu", LipuLipu);
                Glosses.Add("lipu-lipu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pana", new[] { "messages", " letters" });
                    glossMap.Add("en", en);
                }
                LipuPana = new CompoundWord("lipu-pana");

                Dictionary.Add("lipu-pana", LipuPana);
                Glosses.Add("lipu-pana", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-pi-kama-sin", new[] { "newspaper" });
                    glossMap.Add("en", en);
                }
                LipuPiKamaSin = new CompoundWord("lipu-pi-kama-sin");

                Dictionary.Add("lipu-pi-kama-sin", LipuPiKamaSin);
                Glosses.Add("lipu-pi-kama-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-suli-pi-telo-kiwen", new[] { "ice shelf" });
                    glossMap.Add("en", en);
                }
                LipuSuliPiTeloKiwen = new CompoundWord("lipu-suli-pi-telo-kiwen");

                Dictionary.Add("lipu-suli-pi-telo-kiwen", LipuSuliPiTeloKiwen);
                Glosses.Add("lipu-suli-pi-telo-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-toki-sewi", new[] { "holy books", " rweligious book" });
                    glossMap.Add("en", en);
                }
                LipuTokiSewi = new CompoundWord("lipu-toki-sewi");

                Dictionary.Add("lipu-toki-sewi", LipuTokiSewi);
                Glosses.Add("lipu-toki-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-toki-sewi-Kolan", new[] { "Quran" });
                    glossMap.Add("en", en);
                }
                LipuTokiSewiKolan = new CompoundWord("lipu-toki-sewi-Kolan");

                Dictionary.Add("lipu-toki-sewi-Kolan", LipuTokiSewiKolan);
                Glosses.Add("lipu-toki-sewi-Kolan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-toki-sewi-Pipija", new[] { "Bible" });
                    glossMap.Add("en", en);
                }
                LipuTokiSewiPipija = new CompoundWord("lipu-toki-sewi-Pipija");

                Dictionary.Add("lipu-toki-sewi-Pipija", LipuTokiSewiPipija);
                Glosses.Add("lipu-toki-sewi-Pipija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lipu-toki-sewi-Tola", new[] { "Torah" });
                    glossMap.Add("en", en);
                }
                LipuTokiSewiTola = new CompoundWord("lipu-toki-sewi-Tola");

                Dictionary.Add("lipu-toki-sewi-Tola", LipuTokiSewiTola);
                Glosses.Add("lipu-toki-sewi-Tola", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("loje-jelo", new[] { "orange" });
                    glossMap.Add("en", en);
                }
                LojeJelo = new CompoundWord("loje-jelo");

                Dictionary.Add("loje-jelo", LojeJelo);
                Glosses.Add("loje-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-lawa-mi", new[] { "occur to me" });
                    glossMap.Add("en", en);
                }
                LonLawaMi = new CompoundWord("lon-lawa-mi");

                Dictionary.Add("lon-lawa-mi", LonLawaMi);
                Glosses.Add("lon-lawa-mi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-monsi-tenpo-mute", new[] { "after much time" });
                    glossMap.Add("en", en);
                }
                LonMonsiTenpoMute = new CompoundWord("lon-monsi-tenpo-mute");

                Dictionary.Add("lon-monsi-tenpo-mute", LonMonsiTenpoMute);
                Glosses.Add("lon-monsi-tenpo-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-poki", new[] { "categorize" });
                    glossMap.Add("en", en);
                }
                LonPoki = new CompoundWord("lon-poki");

                Dictionary.Add("lon-poki", LonPoki);
                Glosses.Add("lon-poki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-pona-lili", new[] { "with difficulty" });
                    glossMap.Add("en", en);
                }
                LonPonaLili = new CompoundWord("lon-pona-lili");

                Dictionary.Add("lon-pona-lili", LonPonaLili);
                Glosses.Add("lon-pona-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-sina", new[] { "your life", " your world" });
                    glossMap.Add("en", en);
                }
                LonSina = new CompoundWord("lon-sina");

                Dictionary.Add("lon-sina", LonSina);
                Glosses.Add("lon-sina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lon-weka", new[] { "be absent" });
                    glossMap.Add("en", en);
                }
                LonWeka = new CompoundWord("lon-weka");

                Dictionary.Add("lon-weka", LonWeka);
                Glosses.Add("lon-weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-sike", new[] { "embrace", " hug" });
                    glossMap.Add("en", en);
                }
                LukaSike = new CompoundWord("luka-sike");

                Dictionary.Add("luka-sike", LukaSike);
                Glosses.Add("luka-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-tawa", new[] { "cradle", " lull" });
                    glossMap.Add("en", en);
                }
                LukaTawa = new CompoundWord("luka-tawa");

                Dictionary.Add("luka-tawa", LukaTawa);
                Glosses.Add("luka-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-e-sina", new[] { "see you", " look at you" });
                    glossMap.Add("en", en);
                }
                LukinESina = new CompoundWord("lukin-e-sina");

                Dictionary.Add("lukin-e-sina", LukinESina);
                Glosses.Add("lukin-e-sina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-pi-tomo-poka", new[] { "views of nearby buildings" });
                    glossMap.Add("en", en);
                }
                LukinPiTomoPoka = new CompoundWord("lukin-pi-tomo-poka");

                Dictionary.Add("lukin-pi-tomo-poka", LukinPiTomoPoka);
                Glosses.Add("lukin-pi-tomo-poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-tawa-sina", new[] { "look for (seek) you", " look in your direction", " look in your behalf" });
                    glossMap.Add("en", en);
                }
                LukinTawaSina = new CompoundWord("lukin-tawa-sina");

                Dictionary.Add("lukin-tawa-sina", LukinTawaSina);
                Glosses.Add("lukin-tawa-sina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("lukin-toki", new[] { "read" });
                    glossMap.Add("en", en);
                }
                LukinToki = new CompoundWord("lukin-toki");

                Dictionary.Add("lukin-toki", LukinToki);
                Glosses.Add("lukin-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-kama-anpa-suno", new[] { "Occident", " West" });
                    glossMap.Add("en", en);
                }
                MaKamaAnpaSuno = new CompoundWord("ma-kama-anpa-suno");

                Dictionary.Add("ma-kama-anpa-suno", MaKamaAnpaSuno);
                Glosses.Add("ma-kama-anpa-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-kama-sewi-suno", new[] { "Orient", " East" });
                    glossMap.Add("en", en);
                }
                MaKamaSewiSuno = new CompoundWord("ma-kama-sewi-suno");

                Dictionary.Add("ma-kama-sewi-suno", MaKamaSewiSuno);
                Glosses.Add("ma-kama-sewi-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lawa", new[] { "nation" });
                    glossMap.Add("en", en);
                }
                MaLawa = new CompoundWord("ma-lawa");

                Dictionary.Add("ma-lawa", MaLawa);
                Glosses.Add("ma-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-musi", new[] { "theme park" });
                    glossMap.Add("en", en);
                }
                MaMusi = new CompoundWord("ma-musi");

                Dictionary.Add("ma-musi", MaMusi);
                Glosses.Add("ma-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pan", new[] { "cornfield" });
                    glossMap.Add("en", en);
                }
                MaPan = new CompoundWord("ma-pan");

                Dictionary.Add("ma-pan", MaPan);
                Glosses.Add("ma-pan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-kasi-palisa", new[] { "forest" });
                    glossMap.Add("en", en);
                }
                MaPiKasiPalisa = new CompoundWord("ma-pi-kasi-palisa");

                Dictionary.Add("ma-pi-kasi-palisa", MaPiKasiPalisa);
                Glosses.Add("ma-pi-kasi-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-suno-kama", new[] { "east" });
                    glossMap.Add("en", en);
                }
                MaPiSunoKama = new CompoundWord("ma-pi-suno-kama");

                Dictionary.Add("ma-pi-suno-kama", MaPiSunoKama);
                Glosses.Add("ma-pi-suno-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-suno-sewi", new[] { "equatorial regions", " east" });
                    glossMap.Add("en", en);
                }
                MaPiSunoSewi = new CompoundWord("ma-pi-suno-sewi");

                Dictionary.Add("ma-pi-suno-sewi", MaPiSunoSewi);
                Glosses.Add("ma-pi-suno-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-suno-weka", new[] { "west" });
                    glossMap.Add("en", en);
                }
                MaPiSunoWeka = new CompoundWord("ma-pi-suno-weka");

                Dictionary.Add("ma-pi-suno-weka", MaPiSunoWeka);
                Glosses.Add("ma-pi-suno-weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-sike", new[] { "the world (physical/political)" });
                    glossMap.Add("en", en);
                }
                MaSike = new CompoundWord("ma-sike");

                Dictionary.Add("ma-sike", MaSike);
                Glosses.Add("ma-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-mute-pona", new[] { "park" });
                    glossMap.Add("en", en);
                }
                MaTomoMutePona = new CompoundWord("ma-tomo-mute-pona");

                Dictionary.Add("ma-tomo-mute-pona", MaTomoMutePona);
                Glosses.Add("ma-tomo-mute-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mi-pana-e-tomo-tawa-sina", new[] { "I give you a houzse/ I brought your car" });
                    glossMap.Add("en", en);
                }
                MiPanaETomoTawaSina = new CompoundWord("mi-pana-e-tomo-tawa-sina");

                Dictionary.Add("mi-pana-e-tomo-tawa-sina", MiPanaETomoTawaSina);
                Glosses.Add("mi-pana-e-tomo-tawa-sina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mije-pona-en-mije--ike", new[] { "good men and bad ones", " good and bad men" });
                    glossMap.Add("en", en);
                }
                MijePonaEnMijeIke = new CompoundWord("mije-pona-en-mije--ike");

                Dictionary.Add("mije-pona-en-mije--ike", MijePonaEnMijeIke);
                Glosses.Add("mije-pona-en-mije--ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mije-pona-en-ona-ike", new[] { "good men and bad ones", " good and bad men" });
                    glossMap.Add("en", en);
                }
                MijePonaEnOnaIke = new CompoundWord("mije-pona-en-ona-ike");

                Dictionary.Add("mije-pona-en-ona-ike", MijePonaEnOnaIke);
                Glosses.Add("mije-pona-en-ona-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-ali", new[] { "devour", " eat completely" });
                    glossMap.Add("en", en);
                }
                MokuAli = new CompoundWord("moku-ali");

                Dictionary.Add("moku-ali", MokuAli);
                Glosses.Add("moku-ali", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moku-pi-moli-ala", new[] { "amrit", " ambrosia" });
                    glossMap.Add("en", en);
                }
                MokuPiMoliAla = new CompoundWord("moku-pi-moli-ala");

                Dictionary.Add("moku-pi-moli-ala", MokuPiMoliAla);
                Glosses.Add("moku-pi-moli-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("moli-tawa-jan-sewi", new[] { "sacrifice" });
                    glossMap.Add("en", en);
                }
                MoliTawaJanSewi = new CompoundWord("moli-tawa-jan-sewi");

                Dictionary.Add("moli-tawa-jan-sewi", MoliTawaJanSewi);
                Glosses.Add("moli-tawa-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("monsi-linja", new[] { "tail" });
                    glossMap.Add("en", en);
                }
                MonsiLinja = new CompoundWord("monsi-linja");

                Dictionary.Add("monsi-linja", MonsiLinja);
                Glosses.Add("monsi-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mu-jan", new[] { "gibber" });
                    glossMap.Add("en", en);
                }
                MuJan = new CompoundWord("mu-jan");

                Dictionary.Add("mu-jan", MuJan);
                Glosses.Add("mu-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mun-nanpa-luka-luka-wan", new[] { "November" });
                    glossMap.Add("en", en);
                }
                MunNanpaLukaLukaWan = new CompoundWord("mun-nanpa-luka-luka-wan");

                Dictionary.Add("mun-nanpa-luka-luka-wan", MunNanpaLukaLukaWan);
                Glosses.Add("mun-nanpa-luka-luka-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mun-tenp-wan", new[] { "January" });
                    glossMap.Add("en", en);
                }
                MunTenpWan = new CompoundWord("mun-tenp-wan");

                Dictionary.Add("mun-tenp-wan", MunTenpWan);
                Glosses.Add("mun-tenp-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mun-tenpo", new[] { "month" });
                    glossMap.Add("en", en);
                }
                MunTenpo = new CompoundWord("mun-tenpo");

                Dictionary.Add("mun-tenpo", MunTenpo);
                Glosses.Add("mun-tenpo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("musi-mani", new[] { "gambling" });
                    glossMap.Add("en", en);
                }
                MusiMani = new CompoundWord("musi-mani");

                Dictionary.Add("musi-mani", MusiMani);
                Glosses.Add("musi-mani", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mute-ike", new[] { "too much" });
                    glossMap.Add("en", en);
                }
                MuteIke = new CompoundWord("mute-ike");

                Dictionary.Add("mute-ike", MuteIke);
                Glosses.Add("mute-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mute-lon-tenpo-lili", new[] { "rapidly" });
                    glossMap.Add("en", en);
                }
                MuteLonTenpoLili = new CompoundWord("mute-lon-tenpo-lili");

                Dictionary.Add("mute-lon-tenpo-lili", MuteLonTenpoLili);
                Glosses.Add("mute-lon-tenpo-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-anpa-luka-luka", new[] { "in base ten" });
                    glossMap.Add("en", en);
                }
                NasinAnpaLukaLuka = new CompoundWord("nasin-anpa-luka-luka");

                Dictionary.Add("nasin-anpa-luka-luka", NasinAnpaLukaLuka);
                Glosses.Add("nasin-anpa-luka-luka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-anpa-pi-nanpa-tu-wan", new[] { "in base 3" });
                    glossMap.Add("en", en);
                }
                NasinAnpaPiNanpaTuWan = new CompoundWord("nasin-anpa-pi-nanpa-tu-wan");

                Dictionary.Add("nasin-anpa-pi-nanpa-tu-wan", NasinAnpaPiNanpaTuWan);
                Glosses.Add("nasin-anpa-pi-nanpa-tu-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-linja", new[] { "orthodix" });
                    glossMap.Add("en", en);
                }
                NasinLinja = new CompoundWord("nasin-linja");

                Dictionary.Add("nasin-linja", NasinLinja);
                Glosses.Add("nasin-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-Pajawi", new[] { "Baha'i" });
                    glossMap.Add("en", en);
                }
                NasinPajawi = new CompoundWord("nasin-Pajawi");

                Dictionary.Add("nasin-Pajawi", NasinPajawi);
                Glosses.Add("nasin-Pajawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pi-anpa-suno", new[] { "west" });
                    glossMap.Add("en", en);
                }
                NasinPiAnpaSuno = new CompoundWord("nasin-pi-anpa-suno");

                Dictionary.Add("nasin-pi-anpa-suno", NasinPiAnpaSuno);
                Glosses.Add("nasin-pi-anpa-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pi-kalama-toki", new[] { "phonology" });
                    glossMap.Add("en", en);
                }
                NasinPiKalamaToki = new CompoundWord("nasin-pi-kalama-toki");

                Dictionary.Add("nasin-pi-kalama-toki", NasinPiKalamaToki);
                Glosses.Add("nasin-pi-kalama-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pi-sewi-suno", new[] { "east" });
                    glossMap.Add("en", en);
                }
                NasinPiSewiSuno = new CompoundWord("nasin-pi-sewi-suno");

                Dictionary.Add("nasin-pi-sewi-suno", NasinPiSewiSuno);
                Glosses.Add("nasin-pi-sewi-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pi-supa-mute", new[] { "stairway" });
                    glossMap.Add("en", en);
                }
                NasinPiSupaMute = new CompoundWord("nasin-pi-supa-mute");

                Dictionary.Add("nasin-pi-supa-mute", NasinPiSupaMute);
                Glosses.Add("nasin-pi-supa-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-pilin", new[] { "philosophy", " way of thinking" });
                    glossMap.Add("en", en);
                }
                NasinPilin = new CompoundWord("nasin-pilin");

                Dictionary.Add("nasin-pilin", NasinPilin);
                Glosses.Add("nasin-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-Santelija", new[] { "Santeria" });
                    glossMap.Add("en", en);
                }
                NasinSantelija = new CompoundWord("nasin-Santelija");

                Dictionary.Add("nasin-Santelija", NasinSantelija);
                Glosses.Add("nasin-Santelija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-Satan", new[] { "Satanism" });
                    glossMap.Add("en", en);
                }
                NasinSatan = new CompoundWord("nasin-Satan");

                Dictionary.Add("nasin-Satan", NasinSatan);
                Glosses.Add("nasin-Satan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-sona", new[] { "epistemology" });
                    glossMap.Add("en", en);
                }
                NasinSona = new CompoundWord("nasin-sona");

                Dictionary.Add("nasin-sona", NasinSona);
                Glosses.Add("nasin-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-toki-tenpo", new[] { "grammatical tense" });
                    glossMap.Add("en", en);
                }
                NasinTokiTenpo = new CompoundWord("nasin-toki-tenpo");

                Dictionary.Add("nasin-toki-tenpo", NasinTokiTenpo);
                Glosses.Add("nasin-toki-tenpo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nasin-Wika", new[] { "Wicca" });
                    glossMap.Add("en", en);
                }
                NasinWika = new CompoundWord("nasin-Wika");

                Dictionary.Add("nasin-Wika", NasinWika);
                Glosses.Add("nasin-Wika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-ma", new[] { "mountain" });
                    glossMap.Add("en", en);
                }
                NenaMa = new CompoundWord("nena-ma");

                Dictionary.Add("nena-ma", NenaMa);
                Glosses.Add("nena-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-sinpin", new[] { "tip of the nose" });
                    glossMap.Add("en", en);
                }
                NenaSinpin = new CompoundWord("nena-sinpin");

                Dictionary.Add("nena-sinpin", NenaSinpin);
                Glosses.Add("nena-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nena-uta", new[] { "teeth" });
                    glossMap.Add("en", en);
                }
                NenaUta = new CompoundWord("nena-uta");

                Dictionary.Add("nena-uta", NenaUta);
                Glosses.Add("nena-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-ante-nimi", new[] { "adjective" });
                    glossMap.Add("en", en);
                }
                NimiAnteNimi = new CompoundWord("nimi-ante-nimi");

                Dictionary.Add("nimi-ante-nimi", NimiAnteNimi);
                Glosses.Add("nimi-ante-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-ante-pi-nimi-kama", new[] { "adverb" });
                    glossMap.Add("en", en);
                }
                NimiAntePiNimiKama = new CompoundWord("nimi-ante-pi-nimi-kama");

                Dictionary.Add("nimi-ante-pi-nimi-kama", NimiAntePiNimiKama);
                Glosses.Add("nimi-ante-pi-nimi-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-ijo", new[] { "noun" });
                    glossMap.Add("en", en);
                }
                NimiIjo = new CompoundWord("nimi-ijo");

                Dictionary.Add("nimi-ijo", NimiIjo);
                Glosses.Add("nimi-ijo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-kama", new[] { "verb" });
                    glossMap.Add("en", en);
                }
                NimiKama = new CompoundWord("nimi-kama");

                Dictionary.Add("nimi-kama", NimiKama);
                Glosses.Add("nimi-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-kama-jo", new[] { "object (direct", " indirect)" });
                    glossMap.Add("en", en);
                }
                NimiKamaJo = new CompoundWord("nimi-kama-jo");

                Dictionary.Add("nimi-kama-jo", NimiKamaJo);
                Glosses.Add("nimi-kama-jo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-lawa", new[] { "keywords", " head word (in a phrase)", " subject (gram)" });
                    glossMap.Add("en", en);
                }
                NimiLawa = new CompoundWord("nimi-lawa");

                Dictionary.Add("nimi-lawa", NimiLawa);
                Glosses.Add("nimi-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-lupa", new[] { "hyperlink" });
                    glossMap.Add("en", en);
                }
                NimiLupa = new CompoundWord("nimi-lupa");

                Dictionary.Add("nimi-lupa", NimiLupa);
                Glosses.Add("nimi-lupa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-mi-seme", new[] { "What words of mine" });
                    glossMap.Add("en", en);
                }
                NimiMiSeme = new CompoundWord("nimi-mi-seme");

                Dictionary.Add("nimi-mi-seme", NimiMiSeme);
                Glosses.Add("nimi-mi-seme", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-nimi", new[] { "noun" });
                    glossMap.Add("en", en);
                }
                NimiNimi = new CompoundWord("nimi-nimi");

                Dictionary.Add("nimi-nimi", NimiNimi);
                Glosses.Add("nimi-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-open", new[] { "hyperlink", " url" });
                    glossMap.Add("en", en);
                }
                NimiOpen = new CompoundWord("nimi-open");

                Dictionary.Add("nimi-open", NimiOpen);
                Glosses.Add("nimi-open", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-pali-pini", new[] { "intransitive verb" });
                    glossMap.Add("en", en);
                }
                NimiPaliPini = new CompoundWord("nimi-pali-pini");

                Dictionary.Add("nimi-pali-pini", NimiPaliPini);
                Glosses.Add("nimi-pali-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-pi-poka-lawa", new[] { "unofficial words (e.g. name adj)" });
                    glossMap.Add("en", en);
                }
                NimiPiPokaLawa = new CompoundWord("nimi-pi-poka-lawa");

                Dictionary.Add("nimi-pi-poka-lawa", NimiPiPokaLawa);
                Glosses.Add("nimi-pi-poka-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-poka", new[] { "modifier" });
                    glossMap.Add("en", en);
                }
                NimiPoka = new CompoundWord("nimi-poka");

                Dictionary.Add("nimi-poka", NimiPoka);
                Glosses.Add("nimi-poka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-poki-", new[] { "grammatical particle" });
                    glossMap.Add("en", en);
                }
                NimiPoki = new CompoundWord("nimi-poki-");

                Dictionary.Add("nimi-poki-", NimiPoki);
                Glosses.Add("nimi-poki-", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-poki-lili", new[] { "grammatical particle" });
                    glossMap.Add("en", en);
                }
                NimiPokiLili = new CompoundWord("nimi-poki-lili");

                Dictionary.Add("nimi-poki-lili", NimiPokiLili);
                Glosses.Add("nimi-poki-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-tawa", new[] { "hyperlink" });
                    glossMap.Add("en", en);
                }
                NimiTawa = new CompoundWord("nimi-tawa");

                Dictionary.Add("nimi-tawa", NimiTawa);
                Glosses.Add("nimi-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-toki-lili", new[] { "abbreviated language names" });
                    glossMap.Add("en", en);
                }
                NimiTokiLili = new CompoundWord("nimi-toki-lili");

                Dictionary.Add("nimi-toki-lili", NimiTokiLili);
                Glosses.Add("nimi-toki-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("nimi-wan", new[] { "conjunction" });
                    glossMap.Add("en", en);
                }
                NimiWan = new CompoundWord("nimi-wan");

                Dictionary.Add("nimi-wan", NimiWan);
                Glosses.Add("nimi-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("olin-pi-unpa-ala", new[] { "platonic love" });
                    glossMap.Add("en", en);
                }
                OlinPiUnpaAla = new CompoundWord("olin-pi-unpa-ala");

                Dictionary.Add("olin-pi-unpa-ala", OlinPiUnpaAla);
                Glosses.Add("olin-pi-unpa-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("olin-unpa", new[] { "sexual attraction" });
                    glossMap.Add("en", en);
                }
                OlinUnpa = new CompoundWord("olin-unpa");

                Dictionary.Add("olin-unpa", OlinUnpa);
                Glosses.Add("olin-unpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ona-sama", new[] { "him self", " his own" });
                    glossMap.Add("en", en);
                }
                OnaSama = new CompoundWord("ona-sama");

                Dictionary.Add("ona-sama", OnaSama);
                Glosses.Add("ona-sama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-ala-pi-pali-mute", new[] { "karma" });
                    glossMap.Add("en", en);
                }
                PaliAlaPiPaliMute = new CompoundWord("pali-ala-pi-pali-mute");

                Dictionary.Add("pali-ala-pi-pali-mute", PaliAlaPiPaliMute);
                Glosses.Add("pali-ala-pi-pali-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-musi-kiwen", new[] { "statue" });
                    glossMap.Add("en", en);
                }
                PaliMusiKiwen = new CompoundWord("pali-musi-kiwen");

                Dictionary.Add("pali-musi-kiwen", PaliMusiKiwen);
                Glosses.Add("pali-musi-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-suli", new[] { "adventure" });
                    glossMap.Add("en", en);
                }
                PaliSuli = new CompoundWord("pali-suli");

                Dictionary.Add("pali-suli", PaliSuli);
                Glosses.Add("pali-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-tawa", new[] { "care for", " attend to", " try to" });
                    glossMap.Add("en", en);
                }
                PaliTawa = new CompoundWord("pali-tawa");

                Dictionary.Add("pali-tawa", PaliTawa);
                Glosses.Add("pali-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pali-weka", new[] { "try to get away" });
                    glossMap.Add("en", en);
                }
                PaliWeka = new CompoundWord("pali-weka");

                Dictionary.Add("pali-weka", PaliWeka);
                Glosses.Add("pali-weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-mije", new[] { "penis" });
                    glossMap.Add("en", en);
                }
                PalisaMije = new CompoundWord("palisa-mije");

                Dictionary.Add("palisa-mije", PalisaMije);
                Glosses.Add("palisa-mije", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("palisa-sike", new[] { "helicopter" });
                    glossMap.Add("en", en);
                }
                PalisaSike = new CompoundWord("palisa-sike");

                Dictionary.Add("palisa-sike", PalisaSike);
                Glosses.Add("palisa-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pan-pi-sike-mama-waso", new[] { "waffles" });
                    glossMap.Add("en", en);
                }
                PanPiSikeMamaWaso = new CompoundWord("pan-pi-sike-mama-waso");

                Dictionary.Add("pan-pi-sike-mama-waso", PanPiSikeMamaWaso);
                Glosses.Add("pan-pi-sike-mama-waso", glossMap);
            }

            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-pi-wile-jan-tawa-jan-sewi", new[] { "Islam" });
                    glossMap.Add("en", en);
                }
                PanaPiWileJanTawaJanSewi = new CompoundWord("pana-pi-wile-jan-tawa-jan-sewi");

                Dictionary.Add("pana-pi-wile-jan-tawa-jan-sewi", PanaPiWileJanTawaJanSewi);
                Glosses.Add("pana-pi-wile-jan-tawa-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pana-wile-ala", new[] { "copyright" });
                    glossMap.Add("en", en);
                }
                PanaWileAla = new CompoundWord("pana-wile-ala");

                Dictionary.Add("pana-wile-ala", PanaWileAla);
                Glosses.Add("pana-wile-ala", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("pilin-ale", new[] { "sense", " concept" });
            //        glossMap.Add("en", en);
            //    }
            //    PilinAle = new CompoundWord("pilin-ale");

            //    Dictionary.Add("pilin-ale", PilinAle);
            //    Glosses.Add("pilin-ale", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-e-nena-mama-kepeken-uta", new[] { "kiss breasts" });
                    glossMap.Add("en", en);
                }
                PilinENenaMamaKepekenUta = new CompoundWord("pilin-e-nena-mama-kepeken-uta");

                Dictionary.Add("pilin-e-nena-mama-kepeken-uta", PilinENenaMamaKepekenUta);
                Glosses.Add("pilin-e-nena-mama-kepeken-uta", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-e-pona-insa", new[] { "meditate" });
                    glossMap.Add("en", en);
                }
                PilinEPonaInsa = new CompoundWord("pilin-e-pona-insa");

                Dictionary.Add("pilin-e-pona-insa", PilinEPonaInsa);
                Glosses.Add("pilin-e-pona-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-insa", new[] { "intuition" });
                    glossMap.Add("en", en);
                }
                PilinInsa = new CompoundWord("pilin-insa");

                Dictionary.Add("pilin-insa", PilinInsa);
                Glosses.Add("pilin-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pilin-sijelo-pi-jan-sewi", new[] { "salat" });
                    glossMap.Add("en", en);
                }
                PilinSijeloPiJanSewi = new CompoundWord("pilin-sijelo-pi-jan-sewi");

                Dictionary.Add("pilin-sijelo-pi-jan-sewi", PilinSijeloPiJanSewi);
                Glosses.Add("pilin-sijelo-pi-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pini-a", new[] { "at last", " finally" });
                    glossMap.Add("en", en);
                }
                PiniA = new CompoundWord("pini-a");

                Dictionary.Add("pini-a", PiniA);
                Glosses.Add("pini-a", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pini-e-insa", new[] { "fill" });
                    glossMap.Add("en", en);
                }
                PiniEInsa = new CompoundWord("pini-e-insa");

                Dictionary.Add("pini-e-insa", PiniEInsa);
                Glosses.Add("pini-e-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pini-kalama", new[] { "glottal stop" });
                    glossMap.Add("en", en);
                }
                PiniKalama = new CompoundWord("pini-kalama");

                Dictionary.Add("pini-kalama", PiniKalama);
                Glosses.Add("pini-kalama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pini-sona", new[] { "forget" });
                    glossMap.Add("en", en);
                }
                PiniSona = new CompoundWord("pini-sona");

                Dictionary.Add("pini-sona", PiniSona);
                Glosses.Add("pini-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-jaki", new[] { "cockroach" });
                    glossMap.Add("en", en);
                }
                PipiJaki = new CompoundWord("pipi-jaki");

                Dictionary.Add("pipi-jaki", PipiJaki);
                Glosses.Add("pipi-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-kon-pi-ko-suwi", new[] { "bee" });
                    glossMap.Add("en", en);
                }
                PipiKonPiKoSuwi = new CompoundWord("pipi-kon-pi-ko-suwi");

                Dictionary.Add("pipi-kon-pi-ko-suwi", PipiKonPiKoSuwi);
                Glosses.Add("pipi-kon-pi-ko-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-lili", new[] { "germ" });
                    glossMap.Add("en", en);
                }
                PipiLili = new CompoundWord("pipi-lili");

                Dictionary.Add("pipi-lili", PipiLili);
                Glosses.Add("pipi-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-linja", new[] { "lice" });
                    glossMap.Add("en", en);
                }
                PipiLinja = new CompoundWord("pipi-linja");

                Dictionary.Add("pipi-linja", PipiLinja);
                Glosses.Add("pipi-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-pi-kalama-musi", new[] { "grasshopper", " cicada" });
                    glossMap.Add("en", en);
                }
                PipiPiKalamaMusi = new CompoundWord("pipi-pi-kalama-musi");

                Dictionary.Add("pipi-pi-kalama-musi", PipiPiKalamaMusi);
                Glosses.Add("pipi-pi-kalama-musi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-pi-pali-mute", new[] { "ant" });
                    glossMap.Add("en", en);
                }
                PipiPiPaliMute = new CompoundWord("pipi-pi-pali-mute");

                Dictionary.Add("pipi-pi-pali-mute", PipiPiPaliMute);
                Glosses.Add("pipi-pi-pali-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-pi-tomo-nena", new[] { "ant" });
                    glossMap.Add("en", en);
                }
                PipiPiTomoNena = new CompoundWord("pipi-pi-tomo-nena");

                Dictionary.Add("pipi-pi-tomo-nena", PipiPiTomoNena);
                Glosses.Add("pipi-pi-tomo-nena", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-pi-tomo-nena-kiwen", new[] { "termite" });
                    glossMap.Add("en", en);
                }
                PipiPiTomoNenaKiwen = new CompoundWord("pipi-pi-tomo-nena-kiwen");

                Dictionary.Add("pipi-pi-tomo-nena-kiwen", PipiPiTomoNenaKiwen);
                Glosses.Add("pipi-pi-tomo-nena-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pipi-pona-lukin-lon-kon", new[] { "butterfly" });
                    glossMap.Add("en", en);
                }
                PipiPonaLukinLonKon = new CompoundWord("pipi-pona-lukin-lon-kon");

                Dictionary.Add("pipi-pona-lukin-lon-kon", PipiPonaLukinLonKon);
                Glosses.Add("pipi-pona-lukin-lon-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pi-kama-suno", new[] { "east" });
                    glossMap.Add("en", en);
                }
                PokaPiKamaSuno = new CompoundWord("poka-pi-kama-suno");

                Dictionary.Add("poka-pi-kama-suno", PokaPiKamaSuno);
                Glosses.Add("poka-pi-kama-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pi-sinpin-lawa", new[] { "cheek" });
                    glossMap.Add("en", en);
                }
                PokaPiSinpinLawa = new CompoundWord("poka-pi-sinpin-lawa");

                Dictionary.Add("poka-pi-sinpin-lawa", PokaPiSinpinLawa);
                Glosses.Add("poka-pi-sinpin-lawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pi-weka-suno", new[] { "west" });
                    glossMap.Add("en", en);
                }
                PokaPiWekaSuno = new CompoundWord("poka-pi-weka-suno");

                Dictionary.Add("poka-pi-weka-suno", PokaPiWekaSuno);
                Glosses.Add("poka-pi-weka-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poki-kama", new[] { "categorize" });
                    glossMap.Add("en", en);
                }
                PokiKama = new CompoundWord("poki-kama");

                Dictionary.Add("poki-kama", PokiKama);
                Glosses.Add("poki-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poki-wawa", new[] { "(electric) battery" });
                    glossMap.Add("en", en);
                }
                PokiWawa = new CompoundWord("poki-wawa");

                Dictionary.Add("poki-wawa", PokiWawa);
                Glosses.Add("poki-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("pona-suwi", new[] { "mild", " gentle" });
                    glossMap.Add("en", en);
                }
                PonaSuwi = new CompoundWord("pona-suwi");

                Dictionary.Add("pona-suwi", PonaSuwi);
                Glosses.Add("pona-suwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sama-pi-soweli-Sukosi", new[] { "like Scottish animals" });
                    glossMap.Add("en", en);
                }
                SamaPiSoweliSukosi = new CompoundWord("sama-pi-soweli-Sukosi");

                Dictionary.Add("sama-pi-soweli-Sukosi", SamaPiSoweliSukosi);
                Glosses.Add("sama-pi-soweli-Sukosi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("selo-kasi", new[] { "bark (of tree)", " straw" });
                    glossMap.Add("en", en);
                }
                SeloKasi = new CompoundWord("selo-kasi");

                Dictionary.Add("selo-kasi", SeloKasi);
                Glosses.Add("selo-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("selo-pi-poka-tu-tu", new[] { "square" });
                    glossMap.Add("en", en);
                }
                SeloPiPokaTuTu = new CompoundWord("selo-pi-poka-tu-tu");

                Dictionary.Add("selo-pi-poka-tu-tu", SeloPiPokaTuTu);
                Glosses.Add("selo-pi-poka-tu-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("seslo-oko", new[] { "eyelid" });
                    glossMap.Add("en", en);
                }
                SesloOko = new CompoundWord("seslo-oko");

                Dictionary.Add("seslo-oko", SesloOko);
                Glosses.Add("seslo-oko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-luka", new[] { "embrace", " hug" });
                    glossMap.Add("en", en);
                }
                SikeLuka = new CompoundWord("sike-luka");

                Dictionary.Add("sike-luka", SikeLuka);
                Glosses.Add("sike-luka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-pi-pipi-linja", new[] { "NITS" });
                    glossMap.Add("en", en);
                }
                SikePiPipiLinja = new CompoundWord("sike-pi-pipi-linja");

                Dictionary.Add("sike-pi-pipi-linja", SikePiPipiLinja);
                Glosses.Add("sike-pi-pipi-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-supa", new[] { "disk" });
                    glossMap.Add("en", en);
                }
                SikeSupa = new CompoundWord("sike-supa");

                Dictionary.Add("sike-supa", SikeSupa);
                Glosses.Add("sike-supa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-walo", new[] { "egg" });
                    glossMap.Add("en", en);
                }
                SikeWalo = new CompoundWord("sike-walo");

                Dictionary.Add("sike-walo", SikeWalo);
                Glosses.Add("sike-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sinpin-suno", new[] { "computer (tv) screen", " screen (tv)``" });
                    glossMap.Add("en", en);
                }
                SinpinSuno = new CompoundWord("sinpin-suno");

                Dictionary.Add("sinpin-suno", SinpinSuno);
                Glosses.Add("sinpin-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-e-linja", new[] { "draw a lone (make a distinction)", " draw a line", " make a distinction" });
                    glossMap.Add("en", en);
                }
                SitelenELinja = new CompoundWord("sitelen-e-linja");

                Dictionary.Add("sitelen-e-linja", SitelenELinja);
                Glosses.Add("sitelen-e-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-ike", new[] { "spam" });
                    glossMap.Add("en", en);
                }
                SitelenIke = new CompoundWord("sitelen-ike");

                Dictionary.Add("sitelen-ike", SitelenIke);
                Glosses.Add("sitelen-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-jan-sewi-tu-wan-lon-jan-sewi-wan", new[] { "Trinity" });
                    glossMap.Add("en", en);
                }
                SitelenJanSewiTuWanLonJanSewiWan = new CompoundWord("sitelen-jan-sewi-tu-wan-lon-jan-sewi-wan");

                Dictionary.Add("sitelen-jan-sewi-tu-wan-lon-jan-sewi-wan", SitelenJanSewiTuWanLonJanSewiWan);
                Glosses.Add("sitelen-jan-sewi-tu-wan-lon-jan-sewi-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-lape-ike", new[] { "nightmare" });
                    glossMap.Add("en", en);
                }
                SitelenLapeIke = new CompoundWord("sitelen-lape-ike");

                Dictionary.Add("sitelen-lape-ike", SitelenLapeIke);
                Glosses.Add("sitelen-lape-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-lili-lili", new[] { "lower case letters" });
                    glossMap.Add("en", en);
                }
                SitelenLiliLili = new CompoundWord("sitelen-lili-lili");

                Dictionary.Add("sitelen-lili-lili", SitelenLiliLili);
                Glosses.Add("sitelen-lili-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-lili-nanpa", new[] { "numeral" });
                    glossMap.Add("en", en);
                }
                SitelenLiliNanpa = new CompoundWord("sitelen-lili-nanpa");

                Dictionary.Add("sitelen-lili-nanpa", SitelenLiliNanpa);
                Glosses.Add("sitelen-lili-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-lili-sin", new[] { "punctuation marks" });
                    glossMap.Add("en", en);
                }
                SitelenLiliSin = new CompoundWord("sitelen-lili-sin");

                Dictionary.Add("sitelen-lili-sin", SitelenLiliSin);
                Glosses.Add("sitelen-lili-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-lili-suli", new[] { "captal letters" });
                    glossMap.Add("en", en);
                }
                SitelenLiliSuli = new CompoundWord("sitelen-lili-suli");

                Dictionary.Add("sitelen-lili-suli", SitelenLiliSuli);
                Glosses.Add("sitelen-lili-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-lili-toki", new[] { "letter (alphabet)" });
                    glossMap.Add("en", en);
                }
                SitelenLiliToki = new CompoundWord("sitelen-lili-toki");

                Dictionary.Add("sitelen-lili-toki", SitelenLiliToki);
                Glosses.Add("sitelen-lili-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-moku", new[] { "spam" });
                    glossMap.Add("en", en);
                }
                SitelenMoku = new CompoundWord("sitelen-moku");

                Dictionary.Add("sitelen-moku", SitelenMoku);
                Glosses.Add("sitelen-moku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-nanpa", new[] { "numerals" });
                    glossMap.Add("en", en);
                }
                SitelenNanpa = new CompoundWord("sitelen-nanpa");

                Dictionary.Add("sitelen-nanpa", SitelenNanpa);
                Glosses.Add("sitelen-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-pi-jan-sewi", new[] { "idol", " statue of god" });
                    glossMap.Add("en", en);
                }
                SitelenPiJanSewi = new CompoundWord("sitelen-pi-jan-sewi");

                Dictionary.Add("sitelen-pi-jan-sewi", SitelenPiJanSewi);
                Glosses.Add("sitelen-pi-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-sinpin", new[] { "previous writing/message" });
                    glossMap.Add("en", en);
                }
                SitelenSinpin = new CompoundWord("sitelen-sinpin");

                Dictionary.Add("sitelen-sinpin", SitelenSinpin);
                Glosses.Add("sitelen-sinpin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-suno", new[] { "photograph" });
                    glossMap.Add("en", en);
                }
                SitelenSuno = new CompoundWord("sitelen-suno");

                Dictionary.Add("sitelen-suno", SitelenSuno);
                Glosses.Add("sitelen-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-kama", new[] { "lesson (text)" });
                    glossMap.Add("en", en);
                }
                SonaKama = new CompoundWord("sona-kama");

                Dictionary.Add("sona-kama", SonaKama);
                Glosses.Add("sona-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pi-ante-toki", new[] { "comparative linguisrics" });
                    glossMap.Add("en", en);
                }
                SonaPiAnteToki = new CompoundWord("sona-pi-ante-toki");

                Dictionary.Add("sona-pi-ante-toki", SonaPiAnteToki);
                Glosses.Add("sona-pi-ante-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pi-insa-toki", new[] { "syntax" });
                    glossMap.Add("en", en);
                }
                SonaPiInsaToki = new CompoundWord("sona-pi-insa-toki");

                Dictionary.Add("sona-pi-insa-toki", SonaPiInsaToki);
                Glosses.Add("sona-pi-insa-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pi-kalama-nimi", new[] { "phonetics" });
                    glossMap.Add("en", en);
                }
                SonaPiKalamaNimi = new CompoundWord("sona-pi-kalama-nimi");

                Dictionary.Add("sona-pi-kalama-nimi", SonaPiKalamaNimi);
                Glosses.Add("sona-pi-kalama-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pi-tenpo-kama", new[] { "omen" });
                    glossMap.Add("en", en);
                }
                SonaPiTenpoKama = new CompoundWord("sona-pi-tenpo-kama");

                Dictionary.Add("sona-pi-tenpo-kama", SonaPiTenpoKama);
                Glosses.Add("sona-pi-tenpo-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-pilin", new[] { "believe" });
                    glossMap.Add("en", en);
                }
                SonaPilin = new CompoundWord("sona-pilin");

                Dictionary.Add("sona-pilin", SonaPilin);
                Glosses.Add("sona-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-tawa", new[] { "laptop" });
                    glossMap.Add("en", en);
                }
                SonaTawa = new CompoundWord("sona-tawa");

                Dictionary.Add("sona-tawa", SonaTawa);
                Glosses.Add("sona-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sona-toki-pi-tenpo-pini", new[] { "classical phililogy" });
                    glossMap.Add("en", en);
                }
                SonaTokiPiTenpoPini = new CompoundWord("sona-toki-pi-tenpo-pini");

                Dictionary.Add("sona-toki-pi-tenpo-pini", SonaTokiPiTenpoPini);
                Glosses.Add("sona-toki-pi-tenpo-pini", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sons-pi-sona-toki", new[] { "semantics" });
                    glossMap.Add("en", en);
                }
                SonsPiSonaToki = new CompoundWord("sons-pi-sona-toki");

                Dictionary.Add("sons-pi-sona-toki", SonsPiSonaToki);
                Glosses.Add("sons-pi-sona-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-ike", new[] { "rat" });
                    glossMap.Add("en", en);
                }
                SoweliIke = new CompoundWord("soweli-ike");

                Dictionary.Add("soweli-ike", SoweliIke);
                Glosses.Add("soweli-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-kasi-linja", new[] { "zebra" });
                    glossMap.Add("en", en);
                }
                SoweliKasiLinja = new CompoundWord("soweli-kasi-linja");

                Dictionary.Add("soweli-kasi-linja", SoweliKasiLinja);
                Glosses.Add("soweli-kasi-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-kiwen", new[] { "automobile or train", " salami","Armadillo", " statue of animal" });
                    glossMap.Add("en", en);
                }
                SoweliKiwen = new CompoundWord("soweli-kiwen");

                Dictionary.Add("soweli-kiwen", SoweliKiwen);
                Glosses.Add("soweli-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-lape-ma", new[] { "groundhog" });
                    glossMap.Add("en", en);
                }
                SoweliLapeMa = new CompoundWord("soweli-lape-ma");

                Dictionary.Add("soweli-lape-ma", SoweliLapeMa);
                Glosses.Add("soweli-lape-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-lili", new[] { "cat" });
                    glossMap.Add("en", en);
                }
                SoweliLili = new CompoundWord("soweli-lili");

                Dictionary.Add("soweli-lili", SoweliLili);
                Glosses.Add("soweli-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-lili-lili", new[] { "mouse" });
                    glossMap.Add("en", en);
                }
                SoweliLiliLili = new CompoundWord("soweli-lili-lili");

                Dictionary.Add("soweli-lili-lili", SoweliLiliLili);
                Glosses.Add("soweli-lili-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-linja-wawa", new[] { "tiger" });
                    glossMap.Add("en", en);
                }
                SoweliLinjaWawa = new CompoundWord("soweli-linja-wawa");

                Dictionary.Add("soweli-linja-wawa", SoweliLinjaWawa);
                Glosses.Add("soweli-linja-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-moku-kili-kiwen", new[] { "chipmunk" });
                    glossMap.Add("en", en);
                }
                SoweliPiMokuKiliKiwen = new CompoundWord("soweli-pi-moku-kili-kiwen");

                Dictionary.Add("soweli-pi-moku-kili-kiwen", SoweliPiMokuKiliKiwen);
                Glosses.Add("soweli-pi-moku-kili-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-nena-kiwen", new[] { "rhinoceros" });
                    glossMap.Add("en", en);
                }
                SoweliPiNenaKiwen = new CompoundWord("soweli-pi-nena-kiwen");

                Dictionary.Add("soweli-pi-nena-kiwen", SoweliPiNenaKiwen);
                Glosses.Add("soweli-pi-nena-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-nena-palisa", new[] { "unicorn" });
                    glossMap.Add("en", en);
                }
                SoweliPiNenaPalisa = new CompoundWord("soweli-pi-nena-palisa");

                Dictionary.Add("soweli-pi-nena-palisa", SoweliPiNenaPalisa);
                Glosses.Add("soweli-pi-nena-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-pi-nene-linja", new[] { "elephant" });
                    glossMap.Add("en", en);
                }
                SoweliPiNeneLinja = new CompoundWord("soweli-pi-nene-linja");

                Dictionary.Add("soweli-pi-nene-linja", SoweliPiNeneLinja);
                Glosses.Add("soweli-pi-nene-linja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-suli-pi-lupa-nena-pi-ma-lete", new[] { "bear" });
                    glossMap.Add("en", en);
                }
                SoweliSuliPiLupaNenaPiMaLete = new CompoundWord("soweli-suli-pi-lupa-nena-pi-ma-lete");

                Dictionary.Add("soweli-suli-pi-lupa-nena-pi-ma-lete", SoweliSuliPiLupaNenaPiMaLete);
                Glosses.Add("soweli-suli-pi-lupa-nena-pi-ma-lete", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-tomo-ko", new[] { "cat" });
                    glossMap.Add("en", en);
                }
                SoweliTomoKo = new CompoundWord("soweli-tomo-ko");

                Dictionary.Add("soweli-tomo-ko", SoweliTomoKo);
                Glosses.Add("soweli-tomo-ko", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("soweli-tomo-wawa", new[] { "dog" });
                    glossMap.Add("en", en);
                }
                SoweliTomoWawa = new CompoundWord("soweli-tomo-wawa");

                Dictionary.Add("soweli-tomo-wawa", SoweliTomoWawa);
                Glosses.Add("soweli-tomo-wawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("suli-ala", new[] { "not old", " young" });
                    glossMap.Add("en", en);
                }
                SuliAla = new CompoundWord("suli-ala");

                Dictionary.Add("suli-ala", SuliAla);
                Glosses.Add("suli-ala", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("suli-mute", new[] { "very important" });
                    glossMap.Add("en", en);
                }
                SuliMute = new CompoundWord("suli-mute");

                Dictionary.Add("suli-mute", SuliMute);
                Glosses.Add("suli-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-awen", new[] { "keep on going" });
                    glossMap.Add("en", en);
                }
                TawaAwen = new CompoundWord("tawa-awen");

                Dictionary.Add("tawa-awen", TawaAwen);
                Glosses.Add("tawa-awen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-kama", new[] { "return trip" });
                    glossMap.Add("en", en);
                }
                TawaKama = new CompoundWord("tawa-kama");

                Dictionary.Add("tawa-kama", TawaKama);
                Glosses.Add("tawa-kama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-kepeken-noka-tu", new[] { "walk" });
                    glossMap.Add("en", en);
                }
                TawaKepekenNokaTu = new CompoundWord("tawa-kepeken-noka-tu");

                Dictionary.Add("tawa-kepeken-noka-tu", TawaKepekenNokaTu);
                Glosses.Add("tawa-kepeken-noka-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-kon-weka", new[] { "fly away" });
                    glossMap.Add("en", en);
                }
                TawaKonWeka = new CompoundWord("tawa-kon-weka");

                Dictionary.Add("tawa-kon-weka", TawaKonWeka);
                Glosses.Add("tawa-kon-weka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tawa-lon-selo-telo", new[] { "floated on the surface of the water" });
                    glossMap.Add("en", en);
                }
                TawaLonSeloTelo = new CompoundWord("tawa-lon-selo-telo");

                Dictionary.Add("tawa-lon-selo-telo", TawaLonSeloTelo);
                Glosses.Add("tawa-lon-selo-telo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-jaki", new[] { "nicotine water", " slime", " mucus -- snail grease" });
                    glossMap.Add("en", en);
                }
                TeloJaki = new CompoundWord("telo-jaki");

                Dictionary.Add("telo-jaki", TeloJaki);
                Glosses.Add("telo-jaki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-kiwen", new[] { "gasoline Coal" });
                    glossMap.Add("en", en);
                }
                TeloKiwen = new CompoundWord("telo-kiwen");

                Dictionary.Add("telo-kiwen", TeloKiwen);
                Glosses.Add("telo-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-kon", new[] { "(sea)foam" });
                    glossMap.Add("en", en);
                }
                TeloKon = new CompoundWord("telo-kon");

                Dictionary.Add("telo-kon", TeloKon);
                Glosses.Add("telo-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-mama-soweli-kon", new[] { "whipped cream" });
                    glossMap.Add("en", en);
                }
                TeloMamaSoweliKon = new CompoundWord("telo-mama-soweli-kon");

                Dictionary.Add("telo-mama-soweli-kon", TeloMamaSoweliKon);
                Glosses.Add("telo-mama-soweli-kon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-nasa-jelo", new[] { "beer" });
                    glossMap.Add("en", en);
                }
                TeloNasaJelo = new CompoundWord("telo-nasa-jelo");

                Dictionary.Add("telo-nasa-jelo", TeloNasaJelo);
                Glosses.Add("telo-nasa-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-nasa-pi-lawa-walo", new[] { "beer" });
                    glossMap.Add("en", en);
                }
                TeloNasaPiLawaWalo = new CompoundWord("telo-nasa-pi-lawa-walo");

                Dictionary.Add("telo-nasa-pi-lawa-walo", TeloNasaPiLawaWalo);
                Glosses.Add("telo-nasa-pi-lawa-walo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("telo-pi-suli-mute", new[] { "ocean" });
                    glossMap.Add("en", en);
                }
                TeloPiSuliMute = new CompoundWord("telo-pi-suli-mute");

                Dictionary.Add("telo-pi-suli-mute", TeloPiSuliMute);
                Glosses.Add("telo-pi-suli-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenp-lili", new[] { "minute" });
                    glossMap.Add("en", en);
                }
                TenpLili = new CompoundWord("tenp-lili");

                Dictionary.Add("tenp-lili", TenpLili);
                Glosses.Add("tenp-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-laso", new[] { "Spring" });
                    glossMap.Add("en", en);
                }
                TenpoLaso = new CompoundWord("tenpo-laso");

                Dictionary.Add("tenpo-laso", TenpoLaso);
                Glosses.Add("tenpo-laso", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-laso-jelo", new[] { "Spring" });
                    glossMap.Add("en", en);
                }
                TenpoLasoJelo = new CompoundWord("tenpo-laso-jelo");

                Dictionary.Add("tenpo-laso-jelo", TenpoLasoJelo);
                Glosses.Add("tenpo-laso-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-lili-mute", new[] { "second" });
                    glossMap.Add("en", en);
                }
                TenpoLiliMute = new CompoundWord("tenpo-lili-mute");

                Dictionary.Add("tenpo-lili-mute", TenpoLiliMute);
                Glosses.Add("tenpo-lili-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-loje", new[] { "Summer" , "Fall"});
                    glossMap.Add("en", en);
                }
                TenpoLoje = new CompoundWord("tenpo-loje");

                Dictionary.Add("tenpo-loje", TenpoLoje);
                Glosses.Add("tenpo-loje", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("tenpo-loje", new[] { "Fall" });
            //        glossMap.Add("en", en);
            //    }
            //    TenpoLoje = new CompoundWord("tenpo-loje");

            //    Dictionary.Add("tenpo-loje", TenpoLoje);
            //    Glosses.Add("tenpo-loje", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-loje-jelo", new[] { "Fall" });
                    glossMap.Add("en", en);
                }
                TenpoLojeJelo = new CompoundWord("tenpo-loje-jelo");

                Dictionary.Add("tenpo-loje-jelo", TenpoLojeJelo);
                Glosses.Add("tenpo-loje-jelo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pi-selo-oko-tawa", new[] { "the blink of an eye", " instant" });
                    glossMap.Add("en", en);
                }
                TenpoPiSeloOkoTawa = new CompoundWord("tenpo-pi-selo-oko-tawa");

                Dictionary.Add("tenpo-pi-selo-oko-tawa", TenpoPiSeloOkoTawa);
                Glosses.Add("tenpo-pi-selo-oko-tawa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pimeja-la-mi-lukin-e-sina", new[] { "Let's meet after dark" });
                    glossMap.Add("en", en);
                }
                TenpoPimejaLaMiLukinESina = new CompoundWord("tenpo-pimeja-la-mi-lukin-e-sina");

                Dictionary.Add("tenpo-pimeja-la-mi-lukin-e-sina", TenpoPimejaLaMiLukinESina);
                Glosses.Add("tenpo-pimeja-la-mi-lukin-e-sina", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-pona-suno", new[] { "summer holiday" });
                    glossMap.Add("en", en);
                }
                TenpoPonaSuno = new CompoundWord("tenpo-pona-suno");

                Dictionary.Add("tenpo-pona-suno", TenpoPonaSuno);
                Glosses.Add("tenpo-pona-suno", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno--pali-ala-pi-nanpa-wan", new[] { "Sunday" });
                    glossMap.Add("en", en);
                }
                TenpoSunoPaliAlaPiNanpaWan = new CompoundWord("tenpo-suno--pali-ala-pi-nanpa-wan");

                Dictionary.Add("tenpo-suno--pali-ala-pi-nanpa-wan", TenpoSunoPaliAlaPiNanpaWan);
                Glosses.Add("tenpo-suno--pali-ala-pi-nanpa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tenpo-suno-pali-pi-nanpa-wan", new[] { "Monday" });
                    glossMap.Add("en", en);
                }
                TenpoSunoPaliPiNanpaWan = new CompoundWord("tenpo-suno-pali-pi-nanpa-wan");

                Dictionary.Add("tenpo-suno-pali-pi-nanpa-wan", TenpoSunoPaliPiNanpaWan);
                Glosses.Add("tenpo-suno-pali-pi-nanpa-wan", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("toki-sewi", new[] { "prayer" });
            //        glossMap.Add("en", en);
            //    }
            //    TokiSewi = new CompoundWord("toki-sewi");

            //    Dictionary.Add("toki-sewi", TokiSewi);
            //    Glosses.Add("toki-sewi", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pona-sewi", new[] { "prayer" });
                    glossMap.Add("en", en);
                }
                TokiPonaSewi = new CompoundWord("toki-pona-sewi");

                Dictionary.Add("toki-pona-sewi", TokiPonaSewi);
                Glosses.Add("toki-pona-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-kama-en-toki-tawa", new[] { "context" });
                    glossMap.Add("en", en);
                }
                TokiKamaEnTokiTawa = new CompoundWord("toki-kama-en-toki-tawa");

                Dictionary.Add("toki-kama-en-toki-tawa", TokiKamaEnTokiTawa);
                Glosses.Add("toki-kama-en-toki-tawa", glossMap);
            }


//            {
//                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
//                {
//                    var en = new Dictionary<string, string[]>();
//                    en.Add("toki-kepeken-toki", new[] { "speak in tongues" });
//                    glossMap.Add("en", en);
//                }
//                TokiKepekenToki = new CompoundWord("toki-kepeken-toki");
//
//                Dictionary.Add("toki-kepeken-toki", TokiKepekenToki);
//                Glosses.Add("toki-kepeken-toki", glossMap);
//            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("kalama-sewi", new[] { "speak in tongues" });
                    glossMap.Add("en", en);
                }
                KalamaSewi = new CompoundWord("kalama-sewi");

                Dictionary.Add("kalama-sewi", KalamaSewi);
                Glosses.Add("kalama-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-lon-nanpa", new[] { "talk about numbers" });
                    glossMap.Add("en", en);
                }
                TokiLonNanpa = new CompoundWord("toki-lon-nanpa");

                Dictionary.Add("toki-lon-nanpa", TokiLonNanpa);
                Glosses.Add("toki-lon-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-lukin", new[] { "written word", " text", " books", " etc" });
                    glossMap.Add("en", en);
                }
                TokiLukin = new CompoundWord("toki-lukin");

                Dictionary.Add("toki-lukin", TokiLukin);
                Glosses.Add("toki-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-nanpa", new[] { "computer language" });
                    glossMap.Add("en", en);
                }
                TokiNanpa = new CompoundWord("toki-nanpa");

                Dictionary.Add("toki-nanpa", TokiNanpa);
                Glosses.Add("toki-nanpa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pi-jo-ike", new[] { "language which has bad things" });
                    glossMap.Add("en", en);
                }
                TokiPiJoIke = new CompoundWord("toki-pi-jo-ike");

                Dictionary.Add("toki-pi-jo-ike", TokiPiJoIke);
                Glosses.Add("toki-pi-jo-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pi-nanpa-suli", new[] { "language about large numbers" });
                    glossMap.Add("en", en);
                }
                TokiPiNanpaSuli = new CompoundWord("toki-pi-nanpa-suli");

                Dictionary.Add("toki-pi-nanpa-suli", TokiPiNanpaSuli);
                Glosses.Add("toki-pi-nanpa-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-pi-tenpo-ni", new[] { "current language" });
                    glossMap.Add("en", en);
                }
                TokiPiTenpoNi = new CompoundWord("toki-pi-tenpo-ni");

                Dictionary.Add("toki-pi-tenpo-ni", TokiPiTenpoNi);
                Glosses.Add("toki-pi-tenpo-ni", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-sin", new[] { "reply", " constructed language" });
                    glossMap.Add("en", en);
                }
                TokiSin = new CompoundWord("toki-sin");

                Dictionary.Add("toki-sin", TokiSin);
                Glosses.Add("toki-sin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-suli", new[] { "article (in newspaper", " etc", " )``", " official language of a country" });
                    glossMap.Add("en", en);
                }
                TokiSuli = new CompoundWord("toki-suli");

                Dictionary.Add("toki-suli", TokiSuli);
                Glosses.Add("toki-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-tawa-ja-sewi", new[] { "pray (Christian)" });
                    glossMap.Add("en", en);
                }
                TokiTawaJaSewi = new CompoundWord("toki-tawa-ja-sewi");

                Dictionary.Add("toki-tawa-ja-sewi", TokiTawaJaSewi);
                Glosses.Add("toki-tawa-ja-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-tawa-jan-sewi", new[] { "pray" });
                    glossMap.Add("en", en);
                }
                TokiTawaJanSewi = new CompoundWord("toki-tawa-jan-sewi");

                Dictionary.Add("toki-tawa-jan-sewi", TokiTawaJanSewi);
                Glosses.Add("toki-tawa-jan-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-wile", new[] { "vote" });
                    glossMap.Add("en", en);
                }
                TokiWile = new CompoundWord("toki-wile");

                Dictionary.Add("toki-wile", TokiWile);
                Glosses.Add("toki-wile", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("tomo-awen", new[] { "prison" } );
            //        glossMap.Add("en", en);
            //    }
            //    TomoAwen = new CompoundWord("tomo-awen");

            //    Dictionary.Add("tomo-awen", TomoAwen);
            //    Glosses.Add("tomo-awen", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-kiwen", new[] { "brick house" });
                    glossMap.Add("en", en);
                }
                TomoKiwen = new CompoundWord("tomo-kiwen");

                Dictionary.Add("tomo-kiwen", TomoKiwen);
                Glosses.Add("tomo-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-moli", new[] { "death camp" });
                    glossMap.Add("en", en);
                }
                TomoMoli = new CompoundWord("tomo-moli");

                Dictionary.Add("tomo-moli", TomoMoli);
                Glosses.Add("tomo-moli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-nanpa-wan", new[] { "first house" });
                    glossMap.Add("en", en);
                }
                TomoNanpaWan = new CompoundWord("tomo-nanpa-wan");

                Dictionary.Add("tomo-nanpa-wan", TomoNanpaWan);
                Glosses.Add("tomo-nanpa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-kasi-palisa", new[] { "stick house" });
                    glossMap.Add("en", en);
                }
                TomoPiKasiPalisa = new CompoundWord("tomo-pi-kasi-palisa");

                Dictionary.Add("tomo-pi-kasi-palisa", TomoPiKasiPalisa);
                Glosses.Add("tomo-pi-kasi-palisa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-lipu-kasi", new[] { "straw house" });
                    glossMap.Add("en", en);
                }
                TomoPiLipuKasi = new CompoundWord("tomo-pi-lipu-kasi");

                Dictionary.Add("tomo-pi-lipu-kasi", TomoPiLipuKasi);
                Glosses.Add("tomo-pi-lipu-kasi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-pi-lon-tenpo", new[] { "inn", " hotel", " boarding house" });
                    glossMap.Add("en", en);
                }
                TomoPiLonTenpo = new CompoundWord("tomo-pi-lon-tenpo");

                Dictionary.Add("tomo-pi-lon-tenpo", TomoPiLonTenpo);
                Glosses.Add("tomo-pi-lon-tenpo", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-pi-insa-ma", new[] { "subway" });
                    glossMap.Add("en", en);
                }
                TomoTawaPiInsaMa = new CompoundWord("tomo-tawa-pi-insa-ma");

                Dictionary.Add("tomo-tawa-pi-insa-ma", TomoTawaPiInsaMa);
                Glosses.Add("tomo-tawa-pi-insa-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tomo-tawa-pi-linja-tu", new[] { "trolley" });
                    glossMap.Add("en", en);
                }
                TomoTawaPiLinjaTu = new CompoundWord("tomo-tawa-pi-linja-tu");

                Dictionary.Add("tomo-tawa-pi-linja-tu", TomoTawaPiLinjaTu);
                Glosses.Add("tomo-tawa-pi-linja-tu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("trenpo-suno-pi-moku-mute", new[] { "Thanksgiving Day (USA)" });
                    glossMap.Add("en", en);
                }
                TrenpoSunoPiMokuMute = new CompoundWord("trenpo-suno-pi-moku-mute");

                Dictionary.Add("trenpo-suno-pi-moku-mute", TrenpoSunoPiMokuMute);
                Glosses.Add("trenpo-suno-pi-moku-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("uta-kiwen", new[] { "beak", "  bill" });
                    glossMap.Add("en", en);
                }
                UtaKiwen = new CompoundWord("uta-kiwen");

                Dictionary.Add("uta-kiwen", UtaKiwen);
                Glosses.Add("uta-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wab-pi-kama-sona", new[] { "credit hour" });
                    glossMap.Add("en", en);
                }
                WabPiKamaSona = new CompoundWord("wab-pi-kama-sona");

                Dictionary.Add("wab-pi-kama-sona", WabPiKamaSona);
                Glosses.Add("wab-pi-kama-sona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-kalama", new[] { "syllable" });
                    glossMap.Add("en", en);
                }
                WanKalama = new CompoundWord("wan-kalama");

                Dictionary.Add("wan-kalama", WanKalama);
                Glosses.Add("wan-kalama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-lete-pi-sike-ma", new[] { "Arctic" });
                    glossMap.Add("en", en);
                }
                WanLetePiSikeMa = new CompoundWord("wan-lete-pi-sike-ma");

                Dictionary.Add("wan-lete-pi-sike-ma", WanLetePiSikeMa);
                Glosses.Add("wan-lete-pi-sike-ma", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-ma-lili-Mewika", new[] { "USA" });
                    glossMap.Add("en", en);
                }
                WanPiMaLiliMewika = new CompoundWord("wan-pi-ma-lili-Mewika");

                Dictionary.Add("wan-pi-ma-lili-Mewika", WanPiMaLiliMewika);
                Glosses.Add("wan-pi-ma-lili-Mewika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-ma-lili-mute", new[] { "USA" });
                    glossMap.Add("en", en);
                }
                WanPiMaLiliMute = new CompoundWord("wan-pi-ma-lili-mute");

                Dictionary.Add("wan-pi-ma-lili-mute", WanPiMaLiliMute);
                Glosses.Add("wan-pi-ma-lili-mute", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-ma-lili-mute-Mewika", new[] { "USA" });
                    glossMap.Add("en", en);
                }
                WanPiMaLiliMuteMewika = new CompoundWord("wan-pi-ma-lili-mute-Mewika");

                Dictionary.Add("wan-pi-ma-lili-mute-Mewika", WanPiMaLiliMuteMewika);
                Glosses.Add("wan-pi-ma-lili-mute-Mewika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-pi-sona-toki", new[] { "language lesson" });
                    glossMap.Add("en", en);
                }
                WanPiSonaToki = new CompoundWord("wan-pi-sona-toki");

                Dictionary.Add("wan-pi-sona-toki", WanPiSonaToki);
                Glosses.Add("wan-pi-sona-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-sona-toki", new[] { "language lesson" });
                    glossMap.Add("en", en);
                }
                WanSonaToki = new CompoundWord("wan-sona-toki");

                Dictionary.Add("wan-sona-toki", WanSonaToki);
                Glosses.Add("wan-sona-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-kiwen", new[] { "airplane" });
                    glossMap.Add("en", en);
                }
                WasoKiwen = new CompoundWord("waso-kiwen");

                Dictionary.Add("waso-kiwen", WasoKiwen);
                Glosses.Add("waso-kiwen", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-pimeja", new[] { "crow", " raven" });
                    glossMap.Add("en", en);
                }
                WasoPimeja = new CompoundWord("waso-pimeja");

                Dictionary.Add("waso-pimeja", WasoPimeja);
                Glosses.Add("waso-pimeja", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("waso-toki", new[] { "parrot" });
                    glossMap.Add("en", en);
                }
                WasoToki = new CompoundWord("waso-toki");

                Dictionary.Add("waso-toki", WasoToki);
                Glosses.Add("waso-toki", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wawa-pi-tu-wan", new[] { "power of three" });
                    glossMap.Add("en", en);
                }
                WawaPiTuWan = new CompoundWord("wawa-pi-tu-wan");

                Dictionary.Add("wawa-pi-tu-wan", WawaPiTuWan);
                Glosses.Add("wawa-pi-tu-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("weka-pi-jan-jaku", new[] { "quarantine" });
                    glossMap.Add("en", en);
                }
                WekaPiJanJaku = new CompoundWord("weka-pi-jan-jaku");

                Dictionary.Add("weka-pi-jan-jaku", WekaPiJanJaku);
                Glosses.Add("weka-pi-jan-jaku", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("weka-tan-kama-sin-en-kama-moli", new[] { "moksha" });
                    glossMap.Add("en", en);
                }
                WekaTanKamaSinEnKamaMoli = new CompoundWord("weka-tan-kama-sin-en-kama-moli");

                Dictionary.Add("weka-tan-kama-sin-en-kama-moli", WekaTanKamaSinEnKamaMoli);
                Glosses.Add("weka-tan-kama-sin-en-kama-moli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("tepo-mute-lili", new[] { "sometimes" });
                    glossMap.Add("en", en);
                }
                TepoMuteLili = new CompoundWord("tepo-mute-lili");

                Dictionary.Add("tepo-mute-lili", TepoMuteLili);
                Glosses.Add("tepo-mute-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("unpa-lukin", new[] { "sexy looking" });
                    glossMap.Add("en", en);
                }
                UnpaLukin = new CompoundWord("unpa-lukin");

                Dictionary.Add("unpa-lukin", UnpaLukin);
                Glosses.Add("unpa-lukin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-nimi", new[] { "comics", " cartoons", " logogram (words wriitten with single character)" });
                    glossMap.Add("en", en);
                }
                SitelenNimi = new CompoundWord("sitelen-nimi");

                Dictionary.Add("sitelen-nimi", SitelenNimi);
                Glosses.Add("sitelen-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sike-lon-lili-pi-insa-wan", new[] { "cancer" });
                    glossMap.Add("en", en);
                }
                SikeLonLiliPiInsaWan = new CompoundWord("sike-lon-lili-pi-insa-wan");

                Dictionary.Add("sike-lon-lili-pi-insa-wan", SikeLonLiliPiInsaWan);
                Glosses.Add("sike-lon-lili-pi-insa-wan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("wan-insa", new[] { "organ" });
                    glossMap.Add("en", en);
                }
                WanInsa = new CompoundWord("wan-insa");

                Dictionary.Add("wan-insa", WanInsa);
                Glosses.Add("wan-insa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("toki-luka", new[] { "sign language" });
                    glossMap.Add("en", en);
                }
                TokiLuka = new CompoundWord("toki-luka");

                Dictionary.Add("toki-luka", TokiLuka);
                Glosses.Add("toki-luka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("luka-nimi", new[] { "sign in sign language" });
                    glossMap.Add("en", en);
                }
                LukaNimi = new CompoundWord("luka-nimi");

                Dictionary.Add("luka-nimi", LukaNimi);
                Glosses.Add("luka-nimi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-pona", new[] { "right side" });
                    glossMap.Add("en", en);
                }
                PokaPona = new CompoundWord("poka-pona");

                Dictionary.Add("poka-pona", PokaPona);
                Glosses.Add("poka-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("poka-ike", new[] { "left side" });
                    glossMap.Add("en", en);
                }
                PokaIke = new CompoundWord("poka-ike");

                Dictionary.Add("poka-ike", PokaIke);
                Glosses.Add("poka-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-sewi", new[] { "hieroglyph (logogram)" });
                    glossMap.Add("en", en);
                }
                SitelenSewi = new CompoundWord("sitelen-sewi");

                Dictionary.Add("sitelen-sewi", SitelenSewi);
                Glosses.Add("sitelen-sewi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("sitelen-wan", new[] { "logogram (words wriitten with single character)" });
                    glossMap.Add("en", en);
                }
                SitelenWan = new CompoundWord("sitelen-wan");

                Dictionary.Add("sitelen-wan", SitelenWan);
                Glosses.Add("sitelen-wan", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("mi-sewi", new[] { "I win" });
            //        glossMap.Add("en", en);
            //    }
            //    MiSewi = new CompoundWord("mi-sewi");

            //    Dictionary.Add("mi-sewi", MiSewi);
            //    Glosses.Add("mi-sewi", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("musi-sike", new[] { "ball game","soccer" });
                    glossMap.Add("en", en);
                }
                MusiSike = new CompoundWord("musi-sike");

                Dictionary.Add("musi-sike", MusiSike);
                Glosses.Add("musi-sike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-pi-kasi-lili", new[] { "field", " yard", " lawn" });
                    glossMap.Add("en", en);
                }
                MaPiKasiLili = new CompoundWord("ma-pi-kasi-lili");

                Dictionary.Add("ma-pi-kasi-lili", MaPiKasiLili);
                Glosses.Add("ma-pi-kasi-lili", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-sewi-pona", new[] { "Heaven" });
                    glossMap.Add("en", en);
                }
                MaSewiPona = new CompoundWord("ma-sewi-pona");

                Dictionary.Add("ma-sewi-pona", MaSewiPona);
                Glosses.Add("ma-sewi-pona", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-ike", new[] { "Hell" });
                    glossMap.Add("en", en);
                }
                MaIke = new CompoundWord("ma-ike");

                Dictionary.Add("ma-ike", MaIke);
                Glosses.Add("ma-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("musi-pilin", new[] { "interesting" });
                    glossMap.Add("en", en);
                }
                MusiPilin = new CompoundWord("musi-pilin");

                Dictionary.Add("musi-pilin", MusiPilin);
                Glosses.Add("musi-pilin", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mije-lawa-olin-mi", new[] { "my man" });
                    glossMap.Add("en", en);
                }
                MijeLawaOlinMi = new CompoundWord("mije-lawa-olin-mi");

                Dictionary.Add("mije-lawa-olin-mi", MijeLawaOlinMi);
                Glosses.Add("mije-lawa-olin-mi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-lawa-olin-mi", new[] { "my sweetheart" });
                    glossMap.Add("en", en);
                }
                MeliLawaOlinMi = new CompoundWord("meli-lawa-olin-mi");

                Dictionary.Add("meli-lawa-olin-mi", MeliLawaOlinMi);
                Glosses.Add("meli-lawa-olin-mi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-mama", new[] { "Nature" });
                    glossMap.Add("en", en);
                }
                MaMama = new CompoundWord("ma-mama");

                Dictionary.Add("ma-mama", MaMama);
                Glosses.Add("ma-mama", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mute-ala-ike", new[] { "not enough", " insufficient" });
                    glossMap.Add("en", en);
                }
                MuteAlaIke = new CompoundWord("mute-ala-ike");

                Dictionary.Add("mute-ala-ike", MuteAlaIke);
                Glosses.Add("mute-ala-ike", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-suli", new[] { "old woman" });
                    glossMap.Add("en", en);
                }
                MeliSuli = new CompoundWord("meli-suli");

                Dictionary.Add("meli-suli", MeliSuli);
                Glosses.Add("meli-suli", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("mun-lili", new[] { "parentheses" });
                    glossMap.Add("en", en);
                }
                MunLili = new CompoundWord("mun-lili");

                Dictionary.Add("mun-lili", MunLili);
                Glosses.Add("mun-lili", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("mije-insa", new[] { "transexual" });
            //        glossMap.Add("en", en);
            //    }
            //    MijeInsa = new CompoundWord("mije-insa");

            //    Dictionary.Add("mije-insa", MijeInsa);
            //    Glosses.Add("mije-insa", glossMap);
            //}


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("meli-insa", new[] { "transexual" });
            //        glossMap.Add("en", en);
            //    }
            //    MeliInsa = new CompoundWord("meli-insa");

            //    Dictionary.Add("meli-insa", MeliInsa);
            //    Glosses.Add("meli-insa", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("meli-jan", new[] { "Woman" });
                    glossMap.Add("en", en);
                }
                MeliJan = new CompoundWord("meli-jan");

                Dictionary.Add("meli-jan", MeliJan);
                Glosses.Add("meli-jan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Pijawi", new[] { "Prince Edward Island" });
                    glossMap.Add("en", en);
                }
                MaPijawi = new CompoundWord("ma-Pijawi");

                Dictionary.Add("ma-Pijawi", MaPijawi);
                Glosses.Add("ma-Pijawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Jukan", new[] { "Yukon" });
                    glossMap.Add("en", en);
                }
                MaJukan = new CompoundWord("ma-Jukan");

                Dictionary.Add("ma-Jukan", MaJukan);
                Glosses.Add("ma-Jukan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kaliponija", new[] { "California" });
                    glossMap.Add("en", en);
                }
                MaKaliponija = new CompoundWord("ma-Kaliponija");

                Dictionary.Add("ma-Kaliponija", MaKaliponija);
                Glosses.Add("ma-Kaliponija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kanesika", new[] { "Connecticut" });
                    glossMap.Add("en", en);
                }
                MaKanesika = new CompoundWord("ma-Kanesika");

                Dictionary.Add("ma-Kanesika", MaKanesika);
                Glosses.Add("ma-Kanesika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Kepeka", new[] { "Quebec" });
                    glossMap.Add("en", en);
                }
                MaKepeka = new CompoundWord("ma-Kepeka");

                Dictionary.Add("ma-Kepeka", MaKepeka);
                Glosses.Add("ma-Kepeka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Luwisijana", new[] { "Louisiana" });
                    glossMap.Add("en", en);
                }
                MaLuwisijana = new CompoundWord("ma-Luwisijana");

                Dictionary.Add("ma-Luwisijana", MaLuwisijana);
                Glosses.Add("ma-Luwisijana", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Manitopa", new[] { "Manitoba" });
                    glossMap.Add("en", en);
                }
                MaManitopa = new CompoundWord("ma-Manitopa");

                Dictionary.Add("ma-Manitopa", MaManitopa);
                Glosses.Add("ma-Manitopa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Masasusi", new[] { "Massachusetts" });
                    glossMap.Add("en", en);
                }
                MaMasasusi = new CompoundWord("ma-Masasusi");

                Dictionary.Add("ma-Masasusi", MaMasasusi);
                Glosses.Add("ma-Masasusi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Misikan", new[] { "Michigan" });
                    glossMap.Add("en", en);
                }
                MaMisikan = new CompoundWord("ma-Misikan");

                Dictionary.Add("ma-Misikan", MaMisikan);
                Glosses.Add("ma-Misikan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nowasosa", new[] { "Nova Scotia" });
                    glossMap.Add("en", en);
                }
                MaNowasosa = new CompoundWord("ma-Nowasosa");

                Dictionary.Add("ma-Nowasosa", MaNowasosa);
                Glosses.Add("ma-Nowasosa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nowetewetowi", new[] { "Northwest Territories" });
                    glossMap.Add("en", en);
                }
                MaNowetewetowi = new CompoundWord("ma-Nowetewetowi");

                Dictionary.Add("ma-Nowetewetowi", MaNowetewetowi);
                Glosses.Add("ma-Nowetewetowi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nujoka", new[] { "New York" });
                    glossMap.Add("en", en);
                }
                MaNujoka = new CompoundWord("ma-Nujoka");

                Dictionary.Add("ma-Nujoka", MaNujoka);
                Glosses.Add("ma-Nujoka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nunanu", new[] { "Nunavut" });
                    glossMap.Add("en", en);
                }
                MaNunanu = new CompoundWord("ma-Nunanu");

                Dictionary.Add("ma-Nunanu", MaNunanu);
                Glosses.Add("ma-Nunanu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nupansuwi", new[] { "New Brunswick" });
                    glossMap.Add("en", en);
                }
                MaNupansuwi = new CompoundWord("ma-Nupansuwi");

                Dictionary.Add("ma-Nupansuwi", MaNupansuwi);
                Glosses.Add("ma-Nupansuwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nupenlan", new[] { "Newfoundland" });
                    glossMap.Add("en", en);
                }
                MaNupenlan = new CompoundWord("ma-Nupenlan");

                Dictionary.Add("ma-Nupenlan", MaNupenlan);
                Glosses.Add("ma-Nupenlan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Nuwansa", new[] { "New Hampashire" });
                    glossMap.Add("en", en);
                }
                MaNuwansa = new CompoundWord("ma-Nuwansa");

                Dictionary.Add("ma-Nuwansa", MaNuwansa);
                Glosses.Add("ma-Nuwansa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Owekan", new[] { "Oregon" });
                    glossMap.Add("en", en);
                }
                MaOwekan = new CompoundWord("ma-Owekan");

                Dictionary.Add("ma-Owekan", MaOwekan);
                Glosses.Add("ma-Owekan", glossMap);
            }


            //{
            //    var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
            //    {
            //        var en = new Dictionary<string, string[]>();
            //        en.Add("ma-Pisi", new[] { "British Columbia" });
            //        glossMap.Add("en", en);
            //    }
            //    MaPisi = new CompoundWord("ma-Pisi");

            //    Dictionary.Add("ma-Pisi", MaPisi);
            //    Glosses.Add("ma-Pisi", glossMap);
            //}


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Powita", new[] { "Florida" });
                    glossMap.Add("en", en);
                }
                MaPowita = new CompoundWord("ma-Powita");

                Dictionary.Add("ma-Powita", MaPowita);
                Glosses.Add("ma-Powita", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sakasuwan", new[] { "Saskatchewan" });
                    glossMap.Add("en", en);
                }
                MaSakasuwan = new CompoundWord("ma-Sakasuwan");

                Dictionary.Add("ma-Sakasuwan", MaSakasuwan);
                Glosses.Add("ma-Sakasuwan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Sosa", new[] { "Georgia" });
                    glossMap.Add("en", en);
                }
                MaSosa = new CompoundWord("ma-Sosa");

                Dictionary.Add("ma-Sosa", MaSosa);
                Glosses.Add("ma-Sosa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Tesa", new[] { "Texas" });
                    glossMap.Add("en", en);
                }
                MaTesa = new CompoundWord("ma-Tesa");

                Dictionary.Add("ma-Tesa", MaTesa);
                Glosses.Add("ma-Tesa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Elopa", new[] { "Europe" });
                    glossMap.Add("en", en);
                }
                MaElopa = new CompoundWord("ma-Elopa");

                Dictionary.Add("ma-Elopa", MaElopa);
                Glosses.Add("ma-Elopa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-Enkon", new[] { "Hong Kong" });
                    glossMap.Add("en", en);
                }
                MaEnkon = new CompoundWord("ma-Enkon");

                Dictionary.Add("ma-Enkon", MaEnkon);
                Glosses.Add("ma-Enkon", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Pijawi", new[] { "Prince Edward Island" });
                    glossMap.Add("en", en);
                }
                MaLiliPijawi = new CompoundWord("ma-lili-Pijawi");

                Dictionary.Add("ma-lili-Pijawi", MaLiliPijawi);
                Glosses.Add("ma-lili-Pijawi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Jukan", new[] { "Yukon" });
                    glossMap.Add("en", en);
                }
                MaLiliJukan = new CompoundWord("ma-lili-Jukan");

                Dictionary.Add("ma-lili-Jukan", MaLiliJukan);
                Glosses.Add("ma-lili-Jukan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Kaliponija", new[] { "California" });
                    glossMap.Add("en", en);
                }
                MaLiliKaliponija = new CompoundWord("ma-lili-Kaliponija");

                Dictionary.Add("ma-lili-Kaliponija", MaLiliKaliponija);
                Glosses.Add("ma-lili-Kaliponija", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Kanesika", new[] { "Connecticut" });
                    glossMap.Add("en", en);
                }
                MaLiliKanesika = new CompoundWord("ma-lili-Kanesika");

                Dictionary.Add("ma-lili-Kanesika", MaLiliKanesika);
                Glosses.Add("ma-lili-Kanesika", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Kepeka", new[] { "Quebec" });
                    glossMap.Add("en", en);
                }
                MaLiliKepeka = new CompoundWord("ma-lili-Kepeka");

                Dictionary.Add("ma-lili-Kepeka", MaLiliKepeka);
                Glosses.Add("ma-lili-Kepeka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Luwisijana", new[] { "Louisiana" });
                    glossMap.Add("en", en);
                }
                MaLiliLuwisijana = new CompoundWord("ma-lili-Luwisijana");

                Dictionary.Add("ma-lili-Luwisijana", MaLiliLuwisijana);
                Glosses.Add("ma-lili-Luwisijana", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Manitopa", new[] { "Manitoba" });
                    glossMap.Add("en", en);
                }
                MaLiliManitopa = new CompoundWord("ma-lili-Manitopa");

                Dictionary.Add("ma-lili-Manitopa", MaLiliManitopa);
                Glosses.Add("ma-lili-Manitopa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Masasusi", new[] { "Massachusetts" });
                    glossMap.Add("en", en);
                }
                MaLiliMasasusi = new CompoundWord("ma-lili-Masasusi");

                Dictionary.Add("ma-lili-Masasusi", MaLiliMasasusi);
                Glosses.Add("ma-lili-Masasusi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Misikan", new[] { "Michigan" });
                    glossMap.Add("en", en);
                }
                MaLiliMisikan = new CompoundWord("ma-lili-Misikan");

                Dictionary.Add("ma-lili-Misikan", MaLiliMisikan);
                Glosses.Add("ma-lili-Misikan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Nowasosa", new[] { "Nova Scotia" });
                    glossMap.Add("en", en);
                }
                MaLiliNowasosa = new CompoundWord("ma-lili-Nowasosa");

                Dictionary.Add("ma-lili-Nowasosa", MaLiliNowasosa);
                Glosses.Add("ma-lili-Nowasosa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Nowetewetowi", new[] { "Northwest Territories" });
                    glossMap.Add("en", en);
                }
                MaLiliNowetewetowi = new CompoundWord("ma-lili-Nowetewetowi");

                Dictionary.Add("ma-lili-Nowetewetowi", MaLiliNowetewetowi);
                Glosses.Add("ma-lili-Nowetewetowi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Nujoka", new[] { "New York" });
                    glossMap.Add("en", en);
                }
                MaLiliNujoka = new CompoundWord("ma-lili-Nujoka");

                Dictionary.Add("ma-lili-Nujoka", MaLiliNujoka);
                Glosses.Add("ma-lili-Nujoka", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Nunanu", new[] { "Nunavut" });
                    glossMap.Add("en", en);
                }
                MaLiliNunanu = new CompoundWord("ma-lili-Nunanu");

                Dictionary.Add("ma-lili-Nunanu", MaLiliNunanu);
                Glosses.Add("ma-lili-Nunanu", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Nupansuwi", new[] { "New Brunswick" });
                    glossMap.Add("en", en);
                }
                MaLiliNupansuwi = new CompoundWord("ma-lili-Nupansuwi");

                Dictionary.Add("ma-lili-Nupansuwi", MaLiliNupansuwi);
                Glosses.Add("ma-lili-Nupansuwi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Nupenlan", new[] { "Newfoundland" });
                    glossMap.Add("en", en);
                }
                MaLiliNupenlan = new CompoundWord("ma-lili-Nupenlan");

                Dictionary.Add("ma-lili-Nupenlan", MaLiliNupenlan);
                Glosses.Add("ma-lili-Nupenlan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Nuwansa", new[] { "New Hampashire" });
                    glossMap.Add("en", en);
                }
                MaLiliNuwansa = new CompoundWord("ma-lili-Nuwansa");

                Dictionary.Add("ma-lili-Nuwansa", MaLiliNuwansa);
                Glosses.Add("ma-lili-Nuwansa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Owekan", new[] { "Oregon" });
                    glossMap.Add("en", en);
                }
                MaLiliOwekan = new CompoundWord("ma-lili-Owekan");

                Dictionary.Add("ma-lili-Owekan", MaLiliOwekan);
                Glosses.Add("ma-lili-Owekan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Pisi", new[] { "British Columbia" });
                    glossMap.Add("en", en);
                }
                MaLiliPisi = new CompoundWord("ma-lili-Pisi");

                Dictionary.Add("ma-lili-Pisi", MaLiliPisi);
                Glosses.Add("ma-lili-Pisi", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Powita", new[] { "Florida" });
                    glossMap.Add("en", en);
                }
                MaLiliPowita = new CompoundWord("ma-lili-Powita");

                Dictionary.Add("ma-lili-Powita", MaLiliPowita);
                Glosses.Add("ma-lili-Powita", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Sakasuwan", new[] { "Saskatchewan" });
                    glossMap.Add("en", en);
                }
                MaLiliSakasuwan = new CompoundWord("ma-lili-Sakasuwan");

                Dictionary.Add("ma-lili-Sakasuwan", MaLiliSakasuwan);
                Glosses.Add("ma-lili-Sakasuwan", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Sosa", new[] { "Georgia" });
                    glossMap.Add("en", en);
                }
                MaLiliSosa = new CompoundWord("ma-lili-Sosa");

                Dictionary.Add("ma-lili-Sosa", MaLiliSosa);
                Glosses.Add("ma-lili-Sosa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-lili-Tesa", new[] { "Texas" });
                    glossMap.Add("en", en);
                }
                MaLiliTesa = new CompoundWord("ma-lili-Tesa");

                Dictionary.Add("ma-lili-Tesa", MaLiliTesa);
                Glosses.Add("ma-lili-Tesa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-suli-Elopa", new[] { "Europe" });
                    glossMap.Add("en", en);
                }
                MaSuliElopa = new CompoundWord("ma-suli-Elopa");

                Dictionary.Add("ma-suli-Elopa", MaSuliElopa);
                Glosses.Add("ma-suli-Elopa", glossMap);
            }


            {
                var glossMap = new Dictionary<string, Dictionary<string, string[]>>();
                {
                    var en = new Dictionary<string, string[]>();
                    en.Add("ma-tomo-Enkon", new[] { "Hong Kong" });
                    glossMap.Add("en", en);
                }
                MaTomoEnkon = new CompoundWord("ma-tomo-Enkon");

                Dictionary.Add("ma-tomo-Enkon", MaTomoEnkon);
                Glosses.Add("ma-tomo-Enkon", glossMap);
            }
        }
    }
}
