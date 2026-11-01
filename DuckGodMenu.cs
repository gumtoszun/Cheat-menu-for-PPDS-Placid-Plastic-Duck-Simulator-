// 0.9.74 (javítás a 0.9.68-hoz: Szabad Kamera hiba + 4 új funkció + lenyitható menüszakaszok)
// Változtatások a 0.9.68-hoz képest:
//  - NEW: Kacsa Klónozó: a "Kacsaválasztó" bekapcsolva bal klikkel kijelölhető egy kacsa (ha nem találja el a sugár, a kurzorhoz
//           képernyőn legközelebbi, 60 pixelen belüli kacsát választja), a "Kijelölt kacsa klónozása" gombbal egy ugyanolyan kacsa
//           jelenik meg fölötte. A klón az eredeti (nem szorzott) méretet kapja, így a Testméret csúszkával sem szorzódik kétszer
//  - NEW: Időjárás: Tiszta ég / Eső / Hó / Köd / Minden időjárás törlése gombok. Klónozás a játék saját spawnolásával (nem süllyed le).
//           Ha az Enviro nem érhető el, a Köd és a Tiszta ég a RenderSettings ködjére esik vissza. Az elérhető időjárás-típusok és
//           metódusok a naplóba kerülnek ([WEATHER-DIAG])
//  - NEW: Gravitációs Fegyver: bekapcsolva a jobb klikk a legközelebbi kacsát a kurzor alatti pontra teleportálja (sebesség nullázva).
//           Repülés közben (Szabad Kamera) nem működik, mert a jobb egérgomb ott a nézelődés. A teleport az "első helyzetet" is átírja,
//           így az Eltűnt Kacsák Visszahozása nem dobja vissza a kacsát
//  - NEW: Útmutató ablak: a menü tetején lévő gombbal nyílik, oldalanként lapozható, magyarázza az összes gombot (két nyelven)
//  - CHANGED: a menü szakaszai lenyithatók (egyszerre egy nyitva), mert a bővülő menü már nem fért volna ki a képernyőre
//           (a BeginScrollView ebben a játékban ki van vágva). A telemetria panel alapból zárva indul
//  - FIXED: Szabad Kamera: repülés után a kamera furcsa lett. Okok: a játék egérkamerája (SmoothMouseLook a CameraRig-en) repülés közben
//           is forgatta a rigot, és a mod csak a kamerát állította vissza. Most a kamera szülőin lévő szkriptek repülés alatt ki vannak
//           kapcsolva (és újra kikapcsolódnak, ha a játék visszakapcsolná őket), a rig helyzete is mentődik/visszaáll, és a visszaállítás
//           10 képkockán át ismétlődik. A megjelenítési effektek (Enviro, Suimono, post-process) és a LookAtCamera érintetlenek maradnak
//
// 0.9.68 (javítás a 0.9.42-höz: fordítási hibák, GUI, spawn, mentés, gravitáció + 3 új funkció)
// Változtatások a 0.9.42-höz képest:
//  - NEW: "Globális Hápogás" (Global Quack) gomb: az összes kacsa egyszerre hápog (DuckManager.DuckQuack)
//  - NEW: Szabad Kamera: a menüben bekapcsolva a Space be/ki kapcsolja a repülést; WASD mozgás, Q/E le-fel, Shift gyors,
//           jobb egérgomb = nézelődés; kilépéskor visszaáll az eredeti kamera. A Kamera Követés a repülés idejére szünetel
//  - NEW: Eltűnt Kacsák Visszahozása: ha egy kacsa a pályán kívülre kerül (az első helyzeténél 60 egységgel mélyebbre esik,
//           300 egységnél messzebb jut, vagy érvénytelen a pozíciója), a mod visszateszi az első látott helyére (sebesség nullázva).
//           Alapból be van kapcsolva, a menüben kikapcsolható
//  - NEW: Kényszerített Mentés: az első megnyomáskor szabad save slotot választ (és eltárolja), utána mindig abba ment;
//           3 másodperc múlva ellenőrzi, hogy a slot tényleg létrejött-e
//  - CHANGED: a Súlytalanság kapcsoló helyett Gravitáció csúszka (0x-10x, 0,1-es lépések), csak a kacsákra hat
//  - REMOVED: Szem méret csúszka (a kacsák szemei nem külön objektumok, így nem méretezhetők)
//  - FIXED: fordítási hibák: hiányzó "using Il2Cpp;", a nem létező Duck és Spawner típusok helyett DuckManager és DebugButton
//  - FIXED: a menü nem jelent meg ("Method unstripping failed"): a játékból kivágott Unity GUI hívások (BeginScrollView,
//           GUILayout.Space stb.) biztonságos burkolókon keresztül futnak, tartalék megoldásokkal
//  - FIXED: a menü háttere eltűnt és az egér nem látszott: a textúrák HideAndDontSave jelzőt kaptak, a backgroundColor már
//           nem sötétít, saját kurzor rajzolódik az ablak fölé, a GUI.depth előrébb hozza a menüt
//  - FIXED: a latest.log 25 MB fölé nőtt (képkockánként ismétlődő hibák) -> minden hiba csak egyszer kerül a naplóba
//  - FIXED: Gyors Spawn / Káosz Özön / Kacsaágyú nem működött (a DebugButton nincs a jelenetben)
//           -> GeneralManager.I.DebugSpawnDuckRandom(), tartaléknak a DebugButton
//  - FIXED: Gejzír mód nem hatott (a közép a világ origója volt) -> a közép a kacsák súlypontja, tömegfüggetlen erő
//  - IMPROVED: a menüablak magassága a képernyőhöz igazodik; [SPAWN-DIAG] és [SAVE-DIAG] diagnosztikai naplósorok
//
// 0.9.42 (javítás a 0.9.41-hez: Force Cache Rebuild megőrzi az eredeti értékeket, megbízhatóbb Káosz-limit)
// Változások a 0.9.41-hez képest:
//  - FIXED: a "Force Cache Rebuild" gomb törölte az ismert kacsák adatait, így az újraépítés az aktuális (már módosított) értékeket
//           mentette el eredetiként -> most helyben, az eredeti értékek megőrzésével építi újra a kacsákat
//  - FIXED: a Káosz mód limitje: a még nem regisztrált spawnok nem nullázódnak minden szkennelésnél, hanem az újonnan talált
//           kacsák számával csökkennek (a 5 másodpercnél régebbi, el nem tűnő spawn eldobódik)
//
// 0.9.41 (javítás a 0.9.40-hez: méretszorzók, eredeti renderer-állapotok, megőrzött fizikai értékek, Disco property block mentése)
// Változások a 0.9.40-hez képest:
//  - FIXED: a Testméret és a Szem csúszka az EREDETI méret szorzója (origScale * érték), nem abszolút méret; az új kacsákra is így érvényes
//  - FIXED: a Ghost mód és a Reset renderereként az eredeti enabled állapotot állítja vissza (az eleve kikapcsolt rendererek nem kapcsolódnak be)
//  - FIXED: a sérültként újraépülő kacsa megőrzi az eredeti fizikai értékeit (drag / angularDrag / gravitáció) és az eredeti méreteit
//  - FIXED: Disco mód: a kacsák eredeti MaterialPropertyBlock-ja el van mentve és kikapcsoláskor visszaáll; a játék más property-jei a Disco alatt sem vesznek el
//  - FIXED: a Mágnes nem Vector3.zero-hoz hasonlít, hanem külön bool jelzi, hogy van-e érvényes egérpozíció
//  - IMPROVED: a menü stílusain a richText explicit be van kapcsolva
//
// 0.9.40 (javítás a 0.9.39-hez: kamera-visszaállítás jelenetváltás után, Disco MaterialPropertyBlock-kal, kevesebb Unity-hívás)
// Változások a 0.9.39-hez képest:
//  - FIXED: Kamera Követés + jelenetváltás: az eltárolt eredeti kamerapozíció az előző pályáé maradt, kikapcsoláskor rossz helyre ugrott
//           -> ha új kamera példány kerül elő, az eredeti pozíció mentése újraindul
//  - IMPROVED: Disco mód MaterialPropertyBlock-kal működik: nem klónozza a materialokat (nincs külön material-példány kacsánként,
//              nincs felszabadítandó klón, a kikapcsolás az eredeti színt adja vissza)
//  - IMPROVED: BuildDuckData egyetlen GetComponentsInChildren hívást használ (a külön GetComponentInChildren elmaradt)
//
// 0.9.39 változásai:
//  - FIXED: az új kacsákra a mod mindig ráerőltette a drag/angularDrag/useGravity/renderer értékeket, még ha a felhasználó semmit sem állított át
//           -> most csak akkor írja felül, ha a kapcsoló/csúszka tényleg át lett állítva
//  - FIXED: a méret/szem csúszka visszaállítása 1.0-ra nem az eredeti méretet hozta vissza -> minden kacsa eredeti értékei el vannak tárolva
//  - NEW: "Minden módosítás visszaállítása" (Reset) gomb
//  - FIXED: Ghost mód csak az első Renderert kapcsolta ki, a többi látszott -> most az összes Renderer kikapcsol
//  - FIXED: Social Distancing túl erős (Impulse) volt -> ForceMode.Acceleration, tömegfüggetlen és szelídebb
//  - FIXED: a DebugButton keresése (FindObjectOfType) most legfeljebb másodpercenként egyszer fut, ha nincs DebugButton a jelenetben
//  - FIXED: a Kacsaágyú coroutine nem akadt el 0-s timeScale esetén (1 képkockát vár a WaitForSeconds helyett)
//  - FIXED: a Mágnes és a Kacsaágyú nem reagál, ha az egér a menü fölött van
//  - FIXED: az F9-cel elrejtett menü már nem állítja le a Kamera Követést
//  - IMPROVED: ESP csak Repaint eseménynél rajzol (kevesebb GC és CPU terhelés)
//  - IMPROVED: "MINDEN KACSA TÖRLÉSE" két kattintásos megerősítéssel (véletlen törlés ellen)
using MelonLoader;
using UnityEngine;
using Il2CppInterop.Runtime;
using Il2Cpp;
using System.Collections.Generic;

[assembly: MelonInfo(typeof(DuckGodMenu.Main), "Kacsa Sandbox Ultimate Menü", DuckGodMenu.Main.ModVersion, "gumtoszun (másnéven Janidani)")]
[assembly: MelonGame("Turbolento Games", "Placid Plastic Duck Simulator")]

namespace DuckGodMenu
{
    public class Main : MelonMod
    {
        public const string ModVersion = "6.9.0";
        private const string DebugVersion = "0.9.75";

        private struct DuckData
        {
            public GameObject gameObject;
            public Rigidbody rigidbody;
            public Renderer renderer;            // elsődleges renderer (Disco módhoz)
            public List<Renderer> allRenderers;  // minden renderer (Ghost módhoz)
            public List<bool> origRendEnabled;   // a rendererek eredeti enabled állapota (azonos indexek)
            public Transform transform;
            public DuckManager manager;          // a hápoláshoz (DuckQuack)
            public Vector3 firstPos;             // az első látott helyzet (Eltűnt Kacsák Visszahozása)
            public string duckName;
            public int id;
            public bool corrupted;

            // Eredeti értékek (a módosítások előtt eltárolva, a Reset gombhoz)
            public float origDrag;
            public float origAngDrag;
            public bool origGravity;
            public Vector3 origScale;
        }

        // UI ablak méretei és stílus
        private bool _showMenu = true;
        private bool _langLoaded = false;
        private bool _hu = false; // false = English (alapértelmezett), true = Magyar
        private const string LangPrefKey = "DuckGodMenu_Lang";
        private Rect _windowRect = new Rect(20, 20, 420, 980);
        private Vector2 _scrollPosition = Vector2.zero;
        private GUIStyle _customWinStyle;
        private GUIStyle _customBtnStyle;
        private GUIStyle _headerStyle;
        private GUIStyle _debugStyle;
        private GUI.WindowFunction _winFunc; // az ablakfüggvény delegate-je, egyszer jön létre

        // Egyszeri diagnosztikai jelzések: nem írnak tele minden képkockánként a logot.
        private bool _diagOnGuiLogged = false;
        private bool _diagStylesLogged = false;
        private bool _diagWindowBeforeLogged = false;
        private bool _diagWindowAfterLogged = false;

        // Rendszer és Telemetria változók
        private float _fps = 0f;
        private float _fpsTimer = 0f;
        private int _fpsFrameCount = 0;
        private float _nextCacheUpdateTime = 0f;
        private int _corruptedDucksCount = 0;
        private int _totalCacheAttempts = 0;
        private string _lastErrorMessage = "";
        private bool _showDebugPanel = false;

        // Beállítások & Csúszkák
        private float _gameSpeed = 1.0f;
        private float _waterFriction = 0.1f;
        private bool _frictionTouched = false; // csak akkor írjuk felül a játék drag értékét, ha a felhasználó a csúszkához nyúlt
        private float _duckScale = 1.0f;

        // Módok (Toggles)
        private bool _chaosModeActive = false;
        private int _chaosLimit = 50;
        private float _nextChaosSpawnTime = 0f;
        private bool _geyserMode = false;
        private bool _ghostMode = false;
        private bool _discoMode = false;
        private float _nextDiscoTime = 0f;
        private bool _socialDistancing = false;
        private bool _blackHoleMode = false;
        private int _distancingTickCounter = 0;

        // Eszközök & Funkciók
        private bool _vortexMode = false;
        private float _vortexSpeed = 5.0f;
        private bool _duckCannonActive = false;
        private bool _duckMagnetActive = false;
        private bool _cameraFollowActive = false;
        private int _cameraTargetIndex = 0;
        private float _gravityMultiplier = 1.0f; // a kacsákra ható gravitáció szorzója (0 = súlytalan, 1 = normál, 10 = tízszeres)
        private bool _duckEspActive = false;
        private float _deleteConfirmUntil = 0f;

        // A medence közepe (Vortex / Gejzír). Ha a játékban a medence nem a világ origójában van, itt kell átírni.
        private static readonly Vector3 PoolCenter = Vector3.zero;
        private const float GeyserRadius = 6f; // a gejzír hatósugara a kacsák súlypontja körül

        // Referencia tárolók
        private List<DuckData> _cachedDucks = new List<DuckData>();
        private readonly Dictionary<int, DuckData> _duckById = new Dictionary<int, DuckData>();
        private readonly HashSet<int> _seenIds = new HashSet<int>();
        private readonly Queue<float> _pendingSpawnTimes = new Queue<float>(); // spawnolt, de még nem regisztrált kacsák időpontjai (Káosz mód limitjéhez)
        private const float CacheInterval = 2.0f;
        private DebugButton _cachedSpawner = null;
        private float _nextSpawnerSearch = 0f;
        private Light _mainSunLight = null;
        private Camera _cachedMainCamera = null;
        private Vector3 _originalCameraPosition;
        private Quaternion _originalCameraRotation;
        private bool _hasSavedCamera = false;

        // Szabad Kamera: a menüben be kell kapcsolni, utána a Space ki/be kapcsolja a repülést
        private bool _freeCamEnabled = false;
        private bool _freeCamFlying = false;
        private bool _freeCamLooking = false;     // a jobb egérgomb nézelődés épp tart
        private float _freeCamSpeed = 10f;        // egység / másodperc (Shiftel 4x)
        private const float FreeCamFastMultiplier = 4f;
        private const float FreeCamLookSensitivity = 3f;
        private float _freeCamYaw = 0f;
        private float _freeCamPitch = 0f;
        private Vector3 _freeCamSavedPos;
        private Quaternion _freeCamSavedRot;
        private bool _freeCamHasSaved = false;
        private Vector3 _freeCamLastMouse;

        // Eltűnt Kacsák Visszahozása
        private bool _rescueLostDucks = true;     // alapból be van kapcsolva
        private const float RescueDepth = 60f;    // ennyivel mélyebbre esve az első helyzeténél
        private const float RescueDistance = 300f;// ennél messzebb jutva az első helyzetétől
        private int _rescueTickCounter = 0;
        private int _rescuedCount = 0;
        private int _rescueLogCount = 0;
        private bool _despawnDiagLogged = false;

        private const float WindowDesiredHeight = 1100f; // a képernyő magasságához igazítva kicsinyedik

        // Kacsa Klónozó
        private bool _clonePickerActive = false;
        private DuckManager _selectedDuck = null;
        private int _selectedDuckId = 0;

        // Gravitációs Fegyver
        private bool _gravityGunActive = false;

        // Időjárás és Évszak
        private string _weatherStatus = "";
        private float _nextEnviroSearch = 0f;
        private object _enviroWeatherModule = null;
        private object _enviroEnvModule = null;
        private readonly List<string> _weatherNames = new List<string>();
        private readonly List<ScriptableObject> _weatherObjs = new List<ScriptableObject>();
        private bool _origFogSaved = false;
        private bool _origFog;
        private FogMode _origFogMode;
        private float _origFogDensity;
        private Color _origFogColor;

        // Lenyitható menüszakaszok (egyszerre egy nyitva; a kirajzolás eleji pillanatkép tartja egyben az IMGUI vezérlők számát)
        private int _openSection = 1;
        private int _secSnapshot = 1;

        // Útmutató ablak
        private bool _showGuide = false;
        private int _guidePage = 0;
        private Rect _guideRect = new Rect(460, 20, 480, 640);
        private GUI.WindowFunction _guideFunc;
        private GUIStyle _guideTextStyle;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg($"Duck Sandbox Ultimate v{ModVersion} [DEBUG V{DebugVersion} ACTIVE] started! Menu: F9");
        }

        // A DebugButton keresése: a talált példányt cache-eli, ha nincs, legfeljebb másodpercenként egyszer keres újra
        // Egy véletlen kacsa spawnolása. Elsődlegesen a GeneralManager singleton debug metódusát használja
        // (mindig elérhető a játékban), tartalékként a jelenetben keresett DebugButton-t.
        private int _spawnDiagCount = 0;

        private bool TrySpawnRandomDuck()
        {
            try
            {
                GeneralManager gm = GeneralManager.I;
                if (gm != null)
                {
                    if (_spawnDiagCount < 6)
                    {
                        _spawnDiagCount++;
                        string state;
                        try { state = $"GetDucksCounter={gm.GetDucksCounter()}, MaxDucksLimit={gm.MaxDucksLimit}, IsSpawnStop={gm.IsSpawnStop()}"; }
                        catch (System.Exception dex) { state = "állapot nem olvasható: " + dex.Message; }
                        LoggerInstance.Msg($"[SPAWN-DIAG {_spawnDiagCount}/6] GeneralManager.I elérhető. {state}, mod cache={_cachedDucks.Count}. DebugSpawnDuckRandom() hívása...");
                    }
                    gm.DebugSpawnDuckRandom();
                    return true;
                }
                if (_spawnDiagCount < 6)
                {
                    _spawnDiagCount++;
                    LoggerInstance.Msg($"[SPAWN-DIAG {_spawnDiagCount}/6] GeneralManager.I == null, tartalék (DebugButton) jön.");
                }
            }
            catch (System.Exception ex)
            {
                LogErrorOnce($"[SPAWN] GeneralManager.DebugSpawnDuckRandom hiba: {ex.GetType().Name}: {ex.Message}");
            }

            try
            {
                DebugButton spawner = GetSpawner();
                if (spawner != null)
                {
                    spawner.SpawnRandomDuck();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                LogErrorOnce($"[SPAWN] DebugButton.SpawnRandomDuck hiba: {ex.GetType().Name}: {ex.Message}");
            }

            LogErrorOnce("[SPAWN] Nem sikerült kacsát spawnolni: sem a GeneralManager, sem a DebugButton nem érhető el.");
            return false;
        }

        private DebugButton GetSpawner()
        {
            if (_cachedSpawner != null) return _cachedSpawner;
            if (Time.unscaledTime < _nextSpawnerSearch) return null;
            _nextSpawnerSearch = Time.unscaledTime + 1f;
            _cachedSpawner = Object.FindObjectOfType<DebugButton>();
            return _cachedSpawner;
        }

        // Az egér a menüablak fölött van-e (hogy a játékbeli eszközök ne reagáljanak a menü kattintásaira)
        private bool MouseOverMenu()
        {
            if (!_showMenu || _screenshotMode) return false;
            Vector2 p = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
            return _windowRect.Contains(p) || (_showGuide && _guideRect.Contains(p));
        }

        // ================= v9: kamera-szkriptek kezelése + erősebb optimalizálás =================
        private int _physPhase = 0;
        // Optimization Mode szint: ennyiedével ritkítjuk a kacsánkénti fizikai munkát (az erőket ugyanennyiszeresre növelve)
        private int OptStride()
        {
            if (!_optimizationMode) return 1;
            int n = _cachedDucks.Count;
            return n > 240 ? 4 : (n > 160 ? 3 : (n > 80 ? 2 : 1));
        }

        // ================= v8: menü-billentyű, Rescue javítás, Respawn All, kacsa-védelem, Opt/Camera extrák =================
        private KeyCode _menuKey = KeyCode.F9;
        private bool _rebindingMenuKey = false;
        private const string PrefMenuKey = "DuckGodMenu_MenuKey";

        private void LoadMenuKey()
        {
            try
            {
                int v = PlayerPrefs.GetInt(PrefMenuKey, (int)KeyCode.F9);
                _menuKey = System.Enum.IsDefined(typeof(KeyCode), v) ? (KeyCode)v : KeyCode.F9;
            }
            catch { _menuKey = KeyCode.F9; }
        }

        // Az új menü-billentyű rögzítése az IMGUI KeyDown eseményből (OnGUI)
        private void CaptureMenuKey()
        {
            if (!_rebindingMenuKey) return;
            Event e = Event.current;
            if (e == null || e.type != EventType.KeyDown) return;
            KeyCode kc = e.keyCode;
            if (kc == KeyCode.None) return;
            e.Use();
            _rebindingMenuKey = false;
            if (kc == KeyCode.Escape) return; // mégse
            if (kc == KeyCode.F8 || kc == KeyCode.Space || kc >= KeyCode.Mouse0)
            {
                LoggerInstance.Msg($"[KEY] A(z) {kc} nem használható menü-billentyűnek (foglalt vagy egérgomb).");
                return;
            }
            _menuKey = kc;
            try { PlayerPrefs.SetInt(PrefMenuKey, (int)kc); PlayerPrefs.Save(); } catch { }
            LoggerInstance.Msg($"[KEY] Új menü-billentyű: {kc}");
        }

        // ---- Rescue Lost Ducks (javított) ----
        // Okok, amiért régen az összes kacsát újra és újra visszadobta: a tó nagy (a kacsák 300+ egységet sodródnak az első helyzetüktől),
        // a repülő kacsák (Propeller, HatProp) magasra szállnak, a levegőben spawnolt kacsák lezuhannak a vízre, és a
        // más területeken (Hippospace, tető, romok...) lévő kacsák is "elveszettnek" látszottak.
        private const float LakeLevelGuess = -20f;       // a napló szerint a víz kb. ebben a magasságban van
        private const float RescueCooldown = 10f;        // ugyanazt a kacsát ennyi másodpercenként legfeljebb egyszer
        private const float RescueMassFraction = 0.3f;   // ha egyszerre ennyi kacsa "elveszett", a szabály hibás: nem nyúlunk hozzájuk
        private readonly Dictionary<int, float> _lastRescueTime = new Dictionary<int, float>();
        private bool _rescueMassLogged = false;
        private float _rescueDespawnSq = 0f;             // a játék saját despawn-távolsága (négyzet)

        private bool IsInOtherZone(DuckData d)
        {
            // más területen (Hippospace, tető, romok, téli jelenet, évszak-konténer) lévő kacsa nem elveszett
            string[] flags = { "isInHippospace", "isInRooftop", "isInRuins", "isInWinterScene", "isInInfinityCool", "IsInSeasonContainer" };
            foreach (var f in flags)
            {
                object v = GetMemberValue(d.manager, typeof(DuckManager), f);
                if (v is bool b && b) return true;
            }
            return false;
        }

        // Respawn All Ducks: minden kezelhető kacsa a játék saját spawn-pontjára kerül (megerősítéssel)
        private float _respawnArmedUntil = 0f;
        private string _respawnStatus = "";

        private void RespawnAllDucks()
        {
            try
            {
                if (Time.unscaledTime > _respawnArmedUntil)
                {
                    _respawnArmedUntil = Time.unscaledTime + 4f;
                    _respawnStatus = T("Click again within 4 s to confirm.", "Kattints újra 4 mp-en belül a megerősítéshez.");
                    return;
                }
                _respawnArmedUntil = 0f;

                GeneralManager gm = GeneralManager.I;
                int n = 0;
                for (int i = 0; i < _cachedDucks.Count; i++)
                {
                    DuckData d = _cachedDucks[i];
                    if (d.gameObject == null || d.transform == null) continue;

                    bool moved = false;
                    if (gm != null)
                    {
                        try { gm.MoveDuckToSpawnPoint(d.gameObject); moved = true; }
                        catch (System.Exception ex) { LogErrorOnce($"[RESPAWN] MoveDuckToSpawnPoint hiba: {ex.GetType().Name}: {ex.Message}"); }
                    }
                    if (!moved && !IsInvalid(d.firstPos)) d.transform.position = d.firstPos;

                    // kis szórás, hogy ne ugyanabba a pontba kerüljön az összes kacsa
                    d.transform.position += new Vector3(Random.Range(-2f, 2f), Random.Range(0f, 3f), Random.Range(-2f, 2f));
                    if (d.rigidbody != null && !d.rigidbody.isKinematic)
                    {
                        d.rigidbody.velocity = Vector3.zero;
                        d.rigidbody.angularVelocity = Vector3.zero;
                    }
                    d.firstPos = d.transform.position;
                    _cachedDucks[i] = d;
                    _duckById[d.id] = d;
                    n++;
                }
                _respawnStatus = T("Respawned: ", "Visszahelyezve: ") + n;
                LoggerInstance.Msg($"[RESPAWN] {n} kacsa a spawn-pontra került.");
            }
            catch (System.Exception ex)
            {
                _respawnStatus = T("Respawn failed: ", "Respawn sikertelen: ") + ex.Message;
                LogErrorOnce($"[RESPAWN] Hiba: {ex.GetType().Name}: {ex.Message}");
            }
        }

        // ---- Kacsa-védelem (csak egyjátékos módban) ----
        // A védett kacsát a mod nem látja (a cache-ből kimarad), és a játék saját despawn-távolsága is hatalmasra van állítva.
        private readonly HashSet<int> _protectedIds = new HashSet<int>();
        private readonly Dictionary<int, float> _protectedOrigDespawn = new Dictionary<int, float>();
        private readonly Dictionary<int, DuckManager> _protectedDucks = new Dictionary<int, DuckManager>();
        private string _protectStatus = "";

        private void RestoreDuckDefaults(DuckData d)
        {
            if (d.gameObject == null) return;
            if (d.rigidbody != null)
            {
                d.rigidbody.drag = d.origDrag;
                d.rigidbody.angularDrag = d.origAngDrag;
                d.rigidbody.useGravity = d.origGravity;
            }
            ApplyGhost(d, false);
            if (d.transform != null) d.transform.localScale = d.origScale;
            if (d.renderer != null && _discoStates.TryGetValue(d.id, out DiscoState st))
            {
                d.renderer.SetPropertyBlock(st.orig);
                _discoStates.Remove(d.id);
            }
        }

        private void ToggleProtectSelected()
        {
            try
            {
                if (_isMultiplayer) { _protectStatus = T("Singleplayer only.", "Csak egyjátékos módban."); return; }
                if (_selectedDuck == null) { _protectStatus = T("Select a duck with the Duck Picker first.", "Előbb válassz egy kacsát a Kacsaválasztóval."); return; }

                int id = _selectedDuck.GetInstanceID();
                if (_protectedIds.Contains(id)) { Unprotect(id); _protectStatus = T("Protection removed: ", "Védelem levéve: ") + _selectedDuck.name; return; }

                if (_duckById.TryGetValue(id, out DuckData d)) RestoreDuckDefaults(d); // a mod eddigi módosításai lekerülnek róla
                _protectedIds.Add(id);
                _protectedDucks[id] = _selectedDuck;
                try
                {
                    object orig = GetMemberValue(_selectedDuck, typeof(DuckManager), "squareDistanceToDespawn");
                    if (orig != null && !_protectedOrigDespawn.ContainsKey(id)) _protectedOrigDespawn[id] = System.Convert.ToSingle(orig);
                    SetMemberValue(_selectedDuck, "squareDistanceToDespawn", 1e12f); // a játék ne despawnolja
                }
                catch { }
                _cachedDucks.RemoveAll(x => x.id == id);
                _duckById.Remove(id);
                _protectStatus = T("Protected: ", "Védett: ") + _selectedDuck.name;
                LoggerInstance.Msg($"[PROTECT] Védett kacsa: {_selectedDuck.name}");
            }
            catch (System.Exception ex) { _protectStatus = T("Protect failed: ", "Védelem sikertelen: ") + ex.Message; LogErrorOnce($"[PROTECT] Hiba: {ex.Message}"); }
        }

        private void Unprotect(int id)
        {
            try
            {
                if (_protectedDucks.TryGetValue(id, out DuckManager dm) && dm != null && _protectedOrigDespawn.TryGetValue(id, out float orig))
                    SetMemberValue(dm, "squareDistanceToDespawn", orig);
            }
            catch { }
            _protectedIds.Remove(id);
            _protectedDucks.Remove(id);
            _protectedOrigDespawn.Remove(id);
            _nextCacheUpdateTime = 0f; // a kacsa a következő képkockában visszakerül a cache-be
        }

        private void UnprotectAll()
        {
            var ids = new List<int>(_protectedIds);
            foreach (int id in ids) Unprotect(id);
        }

        // ---- Optimization Mode extrák ----
        private float CurrentCacheInterval()
        {
            if (!_optimizationMode) return CacheInterval;
            if (_chaosModeActive || _pendingSpawnTimes.Count > 0) return CacheInterval; // spawnolás közben pontos darabszám kell
            int n = _cachedDucks.Count;
            return n > 120 ? 5f : (n > 60 ? 3.5f : CacheInterval); // sok kacsánál ritkábban fut a (drága) teljes keresés
        }

        // ---- Képernyőkép mód billentyű (F8) ----
        // Kétféle úton érkezik: Input.GetKeyDown (OnUpdate) és IMGUI KeyDown esemény (OnGUI), így ha az egyik nem működik a játékban,
        // a másik átveszi. A 0,2 mp-es tiltás megakadályozza, hogy ugyanaz a lenyomás kétszer számítson (vagy az OS billentyű-ismétlése pörgesse).
        private float _lastScreenshotKeyTime = -10f;

        private void ScreenshotKey()
        {
            if (Time.unscaledTime - _lastScreenshotKeyTime < 0.2f) return;
            _lastScreenshotKeyTime = Time.unscaledTime;
            SetScreenshotMode(!_screenshotMode);
        }

        private void HandleCamKeyEvent()
        {
            Event e = Event.current;
            if (e == null || e.type != EventType.KeyDown || _rebindingMenuKey) return;
            if (e.keyCode == KeyCode.F8) ScreenshotKey();
        }

        private void UpdateCameraExtras()
        {
            if (!_rebindingMenuKey && Input.GetKeyDown(KeyCode.F8)) ScreenshotKey();
        }

        // Képernyőkép mód: a mod menüje és ESP-je mellett a játék saját felületét (minden Canvas) is elrejti, kilépéskor visszaállítja
        private readonly List<Canvas> _hiddenCanvases = new List<Canvas>();

        private void SetScreenshotMode(bool on)
        {
            if (on == _screenshotMode) return;
            _screenshotMode = on;
            try
            {
                if (on)
                {
                    _hiddenCanvases.Clear();
                    var cs = Object.FindObjectsOfType<Canvas>();
                    if (cs != null)
                    {
                        foreach (var c in cs)
                        {
                            if (c == null || !c.enabled) continue;
                            c.enabled = false;
                            _hiddenCanvases.Add(c);
                        }
                    }
                    LoggerInstance.Msg($"[SCREENSHOT] Képernyőkép mód be: {_hiddenCanvases.Count} játék-Canvas elrejtve. Kilépés: F8 vagy a menü-billentyű.");
                }
                else RestoreHiddenCanvases();
            }
            catch (System.Exception ex) { LogErrorOnce($"[SCREENSHOT] Hiba: {ex.GetType().Name}: {ex.Message}"); }
        }

        private void RestoreHiddenCanvases()
        {
            for (int i = 0; i < _hiddenCanvases.Count; i++)
            {
                try { if (_hiddenCanvases[i] != null) _hiddenCanvases[i].enabled = true; }
                catch (System.Exception ex) { LogErrorOnce($"[SCREENSHOT] Canvas visszakapcsolása sikertelen: {ex.Message}"); }
            }
            _hiddenCanvases.Clear();
        }

        // ================= v7: Optimization Mode, Spawner, Formációk, Multiplayer védelem =================
        private bool _optimizationMode = false;
        private bool _collectionSpawner = false;
        private bool _screenshotMode = false;
        private bool _mpUi = false;                 // az _isMultiplayer másolata, csak OnUpdate-ben frissül (stabil IMGUI elrendezés)
        private string _optStatus = "";
        private string _spawnerStatus = "";
        private string _formationStatus = "";
        private float _lowFpsSince = -1f;
        private int _discoSlice = 0;
        private const float OptMinFps = 25f;        // ez alatt (3 mp-ig) a Káosz Özön leáll
        private const string PrefOpt = "DuckGodMenu_Opt";

        private void LoadModeSettings()
        {
            try
            {
                _optimizationMode = PlayerPrefs.GetInt(PrefOpt, 0) == 1;
            }
            catch { }
        }

        private void SaveModeSettings()
        {
            try
            {
                PlayerPrefs.SetInt(PrefOpt, _optimizationMode ? 1 : 0);
                PlayerPrefs.Save();
            }
            catch { }
        }

        // Optimization Mode: FPS-védelem (a Disco-gyorsítás az ApplyDiscoColor-ban van)
        private void UpdateOptimization()
        {
            if (_optimizationMode && _chaosModeActive && _fps > 0f && _fps < OptMinFps)
            {
                if (_lowFpsSince < 0f) _lowFpsSince = Time.unscaledTime;
                else if (Time.unscaledTime - _lowFpsSince > 3f)
                {
                    _chaosModeActive = false;
                    _lowFpsSince = -1f;
                    _optStatus = T($"FPS dropped below {OptMinFps:F0}: Chaos Flood stopped.", $"Az FPS {OptMinFps:F0} alá esett: a Káosz Özön leállt.");
                    LoggerInstance.Msg($"[OPT] FPS-védelem: a Káosz Özön leállt ({_fps:F0} FPS, {_cachedDucks.Count} kacsa).");
                }
            }
            else _lowFpsSince = -1f;
        }

        // ---- Collection Spawner: a Collection menüben rákattintott kacsa lespawnolása ----
        private void TrySpawnFromCollection()
        {
            try
            {
                var uis = Object.FindObjectsOfType<DuckUI>();
                if (uis == null) return;
                Vector3 mp = Input.mousePosition;
                DuckUI hit = null;
                foreach (var ui in uis)
                {
                    if (ui == null || !ui.gameObject.activeInHierarchy) continue;
                    var rt = ui.GetComponent<RectTransform>();
                    if (rt == null) continue;
                    bool inside = RectTransformUtility.RectangleContainsScreenPoint(rt, mp, null)
                                  || (_cachedMainCamera != null && RectTransformUtility.RectangleContainsScreenPoint(rt, mp, _cachedMainCamera));
                    if (inside) hit = ui;
                }
                if (hit == null) return; // nem kacsa-ikonra kattintott

                string id = (GetMemberValue(hit, typeof(DuckUI), "ID") ?? GetMemberValue(hit, typeof(DuckUI), "duckID"))?.ToString();
                if (string.IsNullOrEmpty(id)) { _spawnerStatus = T("Duck ID not readable (see the log).", "A kacsa azonosítója nem olvasható (lásd a naplót)."); LogErrorOnce("[SPAWNER] A DuckUI ID/duckID nem olvasható."); return; }

                GeneralManager gm = GeneralManager.I;
                if (gm == null) { _spawnerStatus = T("GeneralManager not available.", "A GeneralManager nem elérhető."); return; }
                gm.DebugSpawnDuck(id);
                _nextCacheUpdateTime = 0f;
                _spawnerStatus = T("Spawned: ", "Lespawnolva: ") + id;
                LoggerInstance.Msg($"[SPAWNER] Collection kacsa lespawnolva: {id}");
            }
            catch (System.Exception ex)
            {
                _spawnerStatus = T("Spawn failed: ", "Spawn sikertelen: ") + ex.Message;
                LogErrorOnce($"[SPAWNER] Hiba: {ex.GetType().Name}: {ex.Message}");
            }
        }

        // ---- Formációk ----
        private static Vector3 Flat(Vector3 v, Vector3 fallback)
        {
            v.y = 0f;
            return v.sqrMagnitude < 0.0001f ? fallback : v.normalized;
        }

        private void ArrangeDucks(string kind)
        {
            try
            {
                var idx = new List<int>();
                for (int i = 0; i < _cachedDucks.Count; i++)
                    if (_cachedDucks[i].gameObject != null && _cachedDucks[i].transform != null) idx.Add(i);
                int n = idx.Count;
                if (n == 0) { _formationStatus = T("No ducks found.", "Nincs kacsa."); return; }

                Vector3 center = PoolCenter + new Vector3(0f, 1f, 0f);
                Vector3 right = Vector3.right, fwd = Vector3.forward;
                if (_cachedMainCamera == null) UpdateCameraCache();
                if (_cachedMainCamera != null)
                {
                    Transform ct = _cachedMainCamera.transform;
                    Ray ray = new Ray(ct.position, ct.forward);
                    if (Physics.Raycast(ray, out RaycastHit hit, 200f)) center = hit.point + new Vector3(0f, 1f, 0f);
                    else center = ct.position + ct.forward * 12f;
                    right = Flat(ct.right, Vector3.right);
                    fwd = Flat(ct.forward, Vector3.forward);
                }

                float circleR = Mathf.Max(2f, n * 1.2f / (2f * Mathf.PI));
                for (int k = 0; k < n; k++)
                {
                    Vector3 off;
                    switch (kind)
                    {
                        case "circle":
                        {
                            float a = k * 2f * Mathf.PI / n;
                            off = right * (Mathf.Cos(a) * circleR) + fwd * (Mathf.Sin(a) * circleR);
                            break;
                        }
                        case "line":
                            off = right * ((k - (n - 1) / 2f) * 1.3f);
                            break;
                        case "spiral":
                        {
                            float a = k * 0.55f;
                            float r = 1.2f + 0.22f * k;
                            off = right * (Mathf.Cos(a) * r) + fwd * (Mathf.Sin(a) * r);
                            break;
                        }
                        default: // tower
                            off = new Vector3(0f, k * 0.8f, 0f);
                            break;
                    }

                    int i = idx[k];
                    DuckData d = _cachedDucks[i];
                    Vector3 pos = center + off;
                    d.transform.position = pos;
                    if (d.rigidbody != null && !d.rigidbody.isKinematic)
                    {
                        d.rigidbody.velocity = Vector3.zero;
                        d.rigidbody.angularVelocity = Vector3.zero;
                    }
                    d.firstPos = pos; // különben az Eltűnt Kacsák Visszahozása visszadobná
                    _cachedDucks[i] = d;
                    _duckById[d.id] = d;
                }
                _formationStatus = T("Formation: ", "Formáció: ") + kind + $" ({n})";
                LoggerInstance.Msg($"[FORMATION] {kind}: {n} kacsa elrendezve.");
            }
            catch (System.Exception ex)
            {
                _formationStatus = T("Formation failed: ", "Formáció sikertelen: ") + ex.Message;
                LogErrorOnce($"[FORMATION] Hiba: {ex.GetType().Name}: {ex.Message}");
            }
        }

        // ---- Multiplayer: más játékosok kacsái védettek, a játékoslista a kacsák tulajdonosaiból épül ----
        private readonly Dictionary<string, int> _playerDuckCounts = new Dictionary<string, int>();
        private bool _ownerReadLogged = false;

        // A kacsák tulajdonosának megállapítása. 1) a játék saját GetPlayerIdByDuck-ja (a játék játékos-kacsa térképe),
        // 2) tartalékként a Fusion InputAuthority. Eredmény: _ownerOther = más játékosok kacsái, _playerDuckCounts = a lista.
        private readonly HashSet<int> _ownerOther = new HashSet<int>();
        private string _lastOwnerSummary = "";

        private void PrepareOwnerInfo(IEnumerable<DuckManager> rawDucks)
        {
            _ownerOther.Clear();
            _playerDuckCounts.Clear();
            if (rawDucks == null) return;

            GeneralManager gm = null;
            int localId = int.MinValue;
            try
            {
                gm = GeneralManager.I;
                object lp = gm != null ? GetMemberValue(gm, typeof(GeneralManager), "LocalPlayer") : null;
                object lid = lp != null ? GetMemberValue(lp, lp.GetType(), "ID") : null;
                if (lid != null) localId = System.Convert.ToInt32(lid);
            }
            catch { }

            var ids = new Dictionary<int, int>();
            int total = 0, withId = 0;
            foreach (var raw in rawDucks)
            {
                if (raw == null) continue;
                total++;
                int pid = -1;
                try { if (gm != null) pid = gm.GetPlayerIdByDuck(raw); } catch { pid = -1; }
                ids[raw.GetInstanceID()] = pid;
                if (pid >= 0) withId++;
            }
            // A naplók alapján a játék a nem-játékos (világ) kacsákra negatív azonosítót ad, így az azonosító önmagában megbízható
            bool idTrusted = gm != null;

            int other = 0, mine = 0;
            foreach (var raw in rawDucks)
            {
                if (raw == null) continue;
                int inst = raw.GetInstanceID();
                string label;
                bool isOther;
                if (idTrusted && ids[inst] >= 0)
                {
                    if (ids[inst] == localId) { label = T("you", "te"); isOther = false; }
                    else { label = T("player ", "játékos ") + ids[inst]; isOther = true; }
                }
                else isOther = IsOtherPlayersDuck(raw, out label);

                _playerDuckCounts[label] = (_playerDuckCounts.TryGetValue(label, out int oc) ? oc : 0) + 1;
                if (isOther) { _ownerOther.Add(inst); other++; } else mine++;
            }

            string summary = $"id-módszer megbízható={idTrusted}, helyi játékos ID={localId}, kacsák={total}, azonosítóval={withId}, védett (más játékosé)={other}, kezelhető={mine}";
            if (summary != _lastOwnerSummary)
            {
                _lastOwnerSummary = summary;
                LoggerInstance.Msg("[NET] Tulajdonos-ellenőrzés: " + summary);
            }
        }

        // true, ha a kacsa egy MÁSIK játékosé (input authority-ja érvényes és nem a helyi játékos)
        private bool IsOtherPlayersDuck(DuckManager duck, out string label)
        {
            label = T("world / host", "világ / host");
            try
            {
                object no = GetMemberValue(duck, typeof(DuckManager), "Object");
                if (no == null)
                {
                    if (!_ownerReadLogged) { _ownerReadLogged = true; LoggerInstance.Msg("[NET] A kacsa NetworkObject-je nem olvasható: a tulajdonos nem állapítható meg (a kacsa nem védett)."); }
                    return false;
                }
                var nt = no.GetType();
                object hasInput = GetMemberValue(no, nt, "HasInputAuthority");
                if (hasInput is bool hb && hb) { label = T("you", "te"); return false; }

                object ia = GetMemberValue(no, nt, "InputAuthority");
                if (ia == null) return false;
                object isNone = GetMemberValue(ia, ia.GetType(), "IsNone");
                if (isNone is bool nb && !nb)
                {
                    label = T("player ", "játékos ") + ia;
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                if (!_ownerReadLogged) { _ownerReadLogged = true; LoggerInstance.Msg("[NET] Tulajdonos-ellenőrzés hiba: " + ex.Message); }
                return false;
            }
        }

        // ---- Multiplayer védelem ----
        // Multiplayerben a mod csak a hosztnál (vagy egyjátékos módban) működik: kliensként nem jelenik meg a menü,
        // és semmilyen funkció nem fut, hogy ne nyúljunk bele más játékosok hálózati objektumaiba.
        private bool _isHostOrSolo = true;
        private float _nextHostCheck = 0f;
        private bool _hostStateKnown = false;
        private string _lastHostStateKey = "";
        private bool _isMultiplayer = false; // a hálózati munkamenet nem egyjátékos

        private bool IsHostOrSolo()
        {
            if (Time.unscaledTime < _nextHostCheck) return _isHostOrSolo;
            _nextHostCheck = Time.unscaledTime + 1f;

            bool allowed = true;
            bool multi = false;
            string why = "nincs GeneralManager (főmenü vagy betöltés)";
            try
            {
                GeneralManager gm = GeneralManager.I;
                if (gm != null)
                {
                    object runner = GetMemberValue(gm, typeof(GeneralManager), "Runner");
                    if (runner == null) why = "nincs NetworkRunner (egyjátékos)";
                    else
                    {
                        var rt = runner.GetType();
                        object running = GetMemberValue(runner, rt, "IsRunning");
                        object single = GetMemberValue(runner, rt, "IsSinglePlayer");
                        object server = GetMemberValue(runner, rt, "IsServer");
                        object master = GetMemberValue(runner, rt, "IsSharedModeMasterClient");

                        if (running is bool rb && !rb) why = "a NetworkRunner nem fut";
                        else if (single == null && server == null && master == null) why = "a host-állapot nem olvasható (engedélyezve)";
                        else
                        {
                            multi = single is bool sg && !sg && !(running is bool rg && !rg);
                            allowed = (single is bool sb && sb) || (server is bool vb && vb) || (master is bool mb && mb);
                            why = $"IsSinglePlayer={single}, IsServer={server}, IsSharedModeMasterClient={master}";
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                allowed = true; // hiba esetén nem zárjuk ki az egyjátékos módot
                why = "hiba az ellenőrzésnél: " + ex.Message;
            }

            string stateKey = $"{allowed}|{multi}|{why}";
            if (!_hostStateKnown || stateKey != _lastHostStateKey)
            {
                _lastHostStateKey = stateKey;
                LoggerInstance.Msg($"[NET] Host/egyjátékos: {(allowed ? "IGEN - a menü elérhető" : "NEM - a menü le van tiltva")}, multiplayer: {multi} ({why})");
            }
            _hostStateKnown = true;
            _isHostOrSolo = allowed;
            _isMultiplayer = multi;
            return allowed;
        }

        // ---- Multiplayer jelzés: a szerver moddal fut ----
        // A többi játékosnál nincs mod, ezért a jelzésnek a játék saját hálózatán kell eljutnia hozzájuk: a host kacsájának
        // neve elé "[MOD] " kerül (a név hálózati érték, így mindenki látja a kacsa fölött). Kilépéskor / egyjátékos módba váltáskor visszaáll.
        private const string ModTag = "[MOD] ";
        private const bool _modNoticeEnabled = true; // szándékosan nem kapcsolható ki a menüből
        private DuckManager _modNoticeDuck = null;
        private string _modNoticeOrigName = null;
        private float _nextModNotice = 0f;

        private void RestoreModNotice()
        {
            try
            {
                if (_modNoticeDuck != null && _modNoticeOrigName != null)
                {
                    SetMemberValue(_modNoticeDuck, "DisplayName", _modNoticeOrigName);
                    LoggerInstance.Msg($"[NET] [MOD] jelzés levéve a kacsáról, név visszaállítva: {_modNoticeOrigName}");
                }
            }
            catch (System.Exception ex) { LogErrorOnce($"[NET] Név visszaállítása sikertelen: {ex.Message}"); }
            _modNoticeDuck = null;
            _modNoticeOrigName = null;
        }

        private string _lastNoticeReason = "";
        private void NoticeReason(string r)
        {
            if (r == _lastNoticeReason) return;
            _lastNoticeReason = r;
            LoggerInstance.Msg("[NET] Mod-jelzés: " + r);
        }

        private static DuckManager AsDuckManager(object o)
        {
            if (o == null) return null;
            if (o is DuckManager dm) return dm;
            if (o is GameObject go) return go.GetComponent<DuckManager>();
            if (o is Component c) return c.GetComponent<DuckManager>();
            return null;
        }

        private void UpdateModNotice()
        {
            if (Time.unscaledTime < _nextModNotice) return;
            _nextModNotice = Time.unscaledTime + 2f;
            try
            {
                if (!_modNoticeEnabled || !_isMultiplayer)
                {
                    if (_modNoticeDuck != null) RestoreModNotice();
                    NoticeReason("nem multiplayer (vagy még nincs hálózati munkamenet), nincs mit jelezni.");
                    return;
                }

                GeneralManager gm = GeneralManager.I;
                if (gm == null) { NoticeReason("GeneralManager.I == null"); return; }

                DuckManager mine = null;
                var tried = new List<string>();
                foreach (var name in new[] { "playerDuck", "CurrentDuck", "currentDuck", "LocalPlayer", "_playerGame" })
                {
                    object v = GetMemberValue(gm, typeof(GeneralManager), name);
                    mine = AsDuckManager(v);
                    tried.Add($"{name}={(v == null ? "null" : v.GetType().Name)}{(mine != null ? "(OK)" : "")}");
                    if (mine != null) break;
                }
                if (mine == null) { NoticeReason("nem találom a host kacsáját: " + string.Join(", ", tried)); return; }

                if (_modNoticeDuck != null && _modNoticeDuck.Pointer != mine.Pointer) RestoreModNotice(); // másik kacsára váltottál

                string cur = GetMemberValue(mine, typeof(DuckManager), "DisplayName")?.ToString();
                if (cur == null) { NoticeReason("a kacsa DisplayName értéke nem olvasható."); return; }
                if (cur.StartsWith(ModTag)) { NoticeReason("a jelzés rajta van: " + cur); return; }

                _modNoticeDuck = mine;
                _modNoticeOrigName = cur;
                if (SetMemberValue(mine, "DisplayName", ModTag + cur))
                {
                    string after = GetMemberValue(mine, typeof(DuckManager), "DisplayName")?.ToString();
                    NoticeReason($"jelzés kitéve: '{cur}' -> '{after}' (kacsa: {mine.name}, találat: {string.Join(", ", tried)})");
                }
                else { NoticeReason("a kacsa DisplayName értéke nem írható."); _modNoticeDuck = null; _modNoticeOrigName = null; }
            }
            catch (System.Exception ex) { LogErrorOnce($"[NET] Mod-jelzés hiba: {ex.GetType().Name}: {ex.Message}"); }
        }

        public override void OnApplicationQuit()
        {
            RestoreModNotice();
            RestoreHiddenCanvases();
        }

        public override void OnUpdate()
        {
            if (!IsHostOrSolo()) return;
            UpdateModNotice();
            CheckSaveResult();
            try
            {
                if (!_langLoaded)
                {
                    _langLoaded = true;
                    try { _hu = PlayerPrefs.GetInt(LangPrefKey, 0) == 1; } catch { _hu = false; }
                    LoadModeSettings();
                    LoadMenuKey();
                }

                if (!_rebindingMenuKey && Input.GetKeyDown(_menuKey))
                {
                    if (_screenshotMode) { SetScreenshotMode(false); _showMenu = true; } // kilépés a képernyőkép módból: a menü visszajön
                    else _showMenu = !_showMenu;
                    if (_showMenu) UpdateCameraCache();
                }

                _mpUi = _isMultiplayer;
                if (_isMultiplayer && !Mathf.Approximately(_gameSpeed, 1f)) { _gameSpeed = 1f; Time.timeScale = 1f; } // a játék sebessége mindenkit érint
                if (_collectionSpawner && Input.GetMouseButtonDown(0) && !MouseOverMenu()) TrySpawnFromCollection();
                UpdateOptimization();
                UpdateCameraExtras();
                if (_isMultiplayer && _protectedIds.Count > 0) { UnprotectAll(); _protectStatus = ""; } // a védelem csak egyjátékos módban él

                // Szabad Kamera: a Space be/ki kapcsolja a repülést (csak ha a menüben be van kapcsolva a funkció)
                if (_freeCamEnabled && Input.GetKeyDown(KeyCode.Space)) SetFlight(!_freeCamFlying);

                _fpsFrameCount++;
                _fpsTimer += Time.unscaledDeltaTime; // unscaled, hogy a játék sebessége ne torzítsa az FPS-t
                if (_fpsTimer >= 0.5f)
                {
                    _fps = _fpsFrameCount / _fpsTimer;
                    _fpsFrameCount = 0;
                    _fpsTimer = 0f;
                }

                // A cache időzítése unscaledTime-mal megy, így a játék sebességétől vagy szünetelésétől független
                if (Time.unscaledTime > _nextCacheUpdateTime)
                {
                    _nextCacheUpdateTime = Time.unscaledTime + CurrentCacheInterval();
                    if (_cachedMainCamera == null) UpdateCameraCache(); // jelenetváltás után is újra megkeresi
                    UpdateDuckCache();
                }
                ProcessPendingClone();

                if (_chaosModeActive && Time.time > _nextChaosSpawnTime)
                {
                    _nextChaosSpawnTime = Time.time + 0.15f;
                    if (_cachedDucks.Count + _pendingSpawnTimes.Count < _chaosLimit)
                    {
                        if (TrySpawnRandomDuck())
                            _pendingSpawnTimes.Enqueue(Time.unscaledTime); // a szkennelés az újonnan talált kacsák számával csökkenti
                        else
                            _chaosModeActive = false; // nincs mivel spawnolni: ne próbálkozzon végtelenül
                    }
                    else _chaosModeActive = false;
                }

                if (_discoMode && Time.time > _nextDiscoTime)
                {
                    _nextDiscoTime = Time.time + (_optimizationMode ? 0.05f : 0.1f);
                    ApplyDiscoColor(Color.HSVToRGB(Random.value, 1f, 1f));
                }

                if (_clonePickerActive && !_freeCamFlying && Input.GetMouseButtonDown(0) && !MouseOverMenu())
                    PickDuckUnderMouse();

                if (_gravityGunActive && !_freeCamFlying && Input.GetMouseButtonDown(1) && !MouseOverMenu())
                    GravityGunPull();

                if (_duckCannonActive && Input.GetMouseButtonDown(0))
                {
                    if (MouseOverMenu()) return;

                    var knownBefore = new HashSet<int>(_duckById.Keys);
                    if (TrySpawnRandomDuck())
                        MelonCoroutines.Start(FireNewDuckCoroutine(knownBefore));
                }
            }
            catch (System.Exception ex)
            {
                _lastErrorMessage = $"Error in OnUpdate: {ex.Message}";
                LogErrorOnce(_lastErrorMessage);
            }
        }

        public override void OnLateUpdate()
        {
            if (!IsHostOrSolo()) return;
            try
            {
                // Repülés közben a Kamera Követés szünetel
                if (_freeCamFlying)
                {
                    UpdateFreeCamera();
                    return;
                }

                // Kilépés után: pár képkockán át újra az eredeti helyzet, hogy a játék kamerája ne írhassa felül
                if (_freeCamRestoreFrames > 0)
                {
                    _freeCamRestoreFrames--;
                    if (_cachedMainCamera != null && _freeCamHasSaved) RestoreSavedCamera();
                    if (_freeCamRestoreFrames == 0) _freeCamHasSaved = false;
                }

                if (_cameraFollowActive && _cachedDucks.Count > 0)
                {
                    if (_cachedMainCamera == null) UpdateCameraCache();
                    if (_cachedMainCamera == null) return;

                    if (!_hasSavedCamera)
                    {
                        _originalCameraPosition = _cachedMainCamera.transform.position;
                        _originalCameraRotation = _cachedMainCamera.transform.rotation;
                        _hasSavedCamera = true;
                    }

                    if (_cameraTargetIndex >= _cachedDucks.Count) _cameraTargetIndex = 0;
                    var targetDuck = _cachedDucks[_cameraTargetIndex];

                    if (targetDuck.gameObject != null)
                    {
                        _cachedMainCamera.transform.position = targetDuck.transform.position + new Vector3(0, 2.5f, -4f);
                        _cachedMainCamera.transform.LookAt(targetDuck.transform);
                    }
                }
            }
            catch (System.Exception ex)
            {
                _lastErrorMessage = $"Error in LateUpdate (Camera): {ex.Message}";
                LogErrorOnce(_lastErrorMessage);
            }
        }

        public override void OnFixedUpdate()
        {
            if (!IsHostOrSolo()) return;
            try
            {
                if (_cachedDucks.Count == 0) return;

                Vector3 poolCenter = PoolCenter;
                Vector3 mouseWorldPos = Vector3.zero;
                bool hasMouseWorldPos = false;

                if (_duckMagnetActive && !MouseOverMenu())
                {
                    if (_cachedMainCamera == null) UpdateCameraCache();
                    if (_cachedMainCamera != null)
                    {
                        Ray ray = _cachedMainCamera.ScreenPointToRay(Input.mousePosition);
                        if (Physics.Raycast(ray, out RaycastHit hit)) mouseWorldPos = hit.point;
                        else mouseWorldPos = ray.GetPoint(15f);
                        hasMouseWorldPos = true;
                    }
                }

                // Fekete lyuk: az első kacsa a középpont
                bool isBlackHoleValid = _blackHoleMode && _cachedDucks[0].gameObject != null;
                Vector3 blackHolePosition = isBlackHoleValid ? _cachedDucks[0].transform.position : Vector3.zero;

                // Gravitáció-szorzó: a Unity saját gravitációja marad, a különbözetet gyorsulásként adjuk hozzá
                // (0x = a gravitáció kioltva, 10x = tízszeres). Csak a kacsákat érinti, a világ többi részét nem.
                bool gravityActive = !Mathf.Approximately(_gravityMultiplier, 1f);
                Vector3 worldGravity = new Vector3(0f, -9.81f, 0f);
                if (gravityActive)
                {
                    try { worldGravity = Physics.gravity; }
                    catch (System.Exception gex) { LogErrorOnce($"[GRAVITY] Physics.gravity nem olvasható, 9,81-et használok: {gex.Message}"); }
                }

                // Gejzír: a közép a kacsák súlypontja (a medence nem a világ origójában van)
                Vector3 geyserCenter = poolCenter;
                if (_geyserMode)
                {
                    Vector3 sum = Vector3.zero;
                    int n = 0;
                    for (int g = 0; g < _cachedDucks.Count; g++)
                    {
                        if (_cachedDucks[g].gameObject == null) continue;
                        sum += _cachedDucks[g].transform.position;
                        n++;
                    }
                    if (n > 0) geyserCenter = sum / n;
                }

                // Optimization Mode: a kacsáknak csak minden stride-adik része kap erőt egy fizikai lépésben (körbeforgó szeletek),
                // az erő stride-szoros, így az átlagos hatás ugyanaz, de töredék annyi Il2Cpp-hívás fut.
                int stride = OptStride();
                _physPhase = (_physPhase + 1) % 100000;
                float fmul = stride;
                bool needPos = _vortexMode || (_duckMagnetActive && hasMouseWorldPos) || _geyserMode || isBlackHoleValid;

                for (int i = 0; i < _cachedDucks.Count; i++)
                {
                    DuckData duck = _cachedDucks[i];
                    if (duck.gameObject == null || duck.rigidbody == null) continue;
                    if (stride > 1 && ((i + _physPhase) % stride) != 0) continue;

                    Vector3 dpos = needPos ? duck.transform.position : Vector3.zero; // egyszer olvassuk ki (Il2Cpp-hívás)

                    if (gravityActive)
                    {
                        // ha a kacsán eredetileg is be volt kapcsolva a gravitáció, csak a különbözetet adjuk hozzá
                        float k = duck.origGravity ? _gravityMultiplier - 1f : _gravityMultiplier;
                        duck.rigidbody.AddForce(worldGravity * (k * fmul), ForceMode.Acceleration);
                    }

                    if (_vortexMode)
                    {
                        Vector3 directionToCenter = poolCenter - dpos;
                        directionToCenter.y = 0;
                        Vector3 tangent = Vector3.Cross(directionToCenter, Vector3.up).normalized;
                        duck.rigidbody.AddForce(((tangent * _vortexSpeed) + (directionToCenter.normalized * 2f)) * fmul, ForceMode.Acceleration);
                    }

                    if (_duckMagnetActive && hasMouseWorldPos)
                    {
                        Vector3 dirToMouse = mouseWorldPos - dpos;
                        duck.rigidbody.AddForce(dirToMouse.normalized * (18f * fmul), ForceMode.Force);
                    }

                    if (_geyserMode)
                    {
                        float distFromCenter = Vector3.Distance(new Vector3(dpos.x, 0, dpos.z), new Vector3(geyserCenter.x, 0, geyserCenter.z));
                        // Acceleration: a tömegtől független, és a gravitációnál (9,8) erősebb
                        if (distFromCenter < GeyserRadius) duck.rigidbody.AddForce(Vector3.up * (22f * fmul), ForceMode.Acceleration);
                    }

                    if (isBlackHoleValid && i > 0)
                    {
                        Vector3 dirToBlackHole = blackHolePosition - dpos;
                        duck.rigidbody.AddForce(dirToBlackHole.normalized * (20f * fmul), ForceMode.Force);
                    }
                }

                // Eltűnt kacsák visszahozása (minden 5. fizikai lépésben)
                if (_rescueLostDucks)
                {
                    _rescueTickCounter++;
                    if (_rescueTickCounter >= (stride > 1 ? 25 : 5))
                    {
                        _rescueTickCounter = 0;
                        RescueLostDucks();
                    }
                }

                // Közösségi távolságtartás (minden 3. fizikai lépésben)
                if (_socialDistancing)
                {
                    _distancingTickCounter++;
                    int distEvery = stride > 1 ? 6 : 3; // Optimization Mode: ritkábban, arányosan erősebb lökéssel
                    if (_distancingTickCounter >= distEvery)
                    {
                        _distancingTickCounter = 0;
                        ApplySocialDistancing(distEvery / 3f);
                    }
                }
            }
            catch (System.Exception ex)
            {
                _lastErrorMessage = $"Error in FixedUpdate (Physics): {ex.Message}";
                LogErrorOnce(_lastErrorMessage);
            }
        }

        // Térbeli rács a távolságtartáshoz (újrahasznosított listák, nincs GC-terhelés)
        private const float DistancingRadius = 1.6f;
        private readonly Dictionary<long, List<int>> _grid = new Dictionary<long, List<int>>();
        private readonly List<List<int>> _listPool = new List<List<int>>();

        private static long CellKey(int x, int y, int z)
        {
            return ((long)(x & 0x1FFFFF) << 42) | ((long)(y & 0x1FFFFF) << 21) | (long)(z & 0x1FFFFF);
        }

        private void ApplySocialDistancing(float accelMul = 1f)
        {
            // Rács ürítése, a listák visszakerülnek a készletbe
            foreach (var kv in _grid)
            {
                kv.Value.Clear();
                _listPool.Add(kv.Value);
            }
            _grid.Clear();

            // Kacsák cellákba sorolása
            for (int i = 0; i < _cachedDucks.Count; i++)
            {
                DuckData d = _cachedDucks[i];
                if (d.gameObject == null || d.rigidbody == null) continue;

                Vector3 p = d.transform.position;
                long key = CellKey(
                    Mathf.FloorToInt(p.x / DistancingRadius),
                    Mathf.FloorToInt(p.y / DistancingRadius),
                    Mathf.FloorToInt(p.z / DistancingRadius));

                if (!_grid.TryGetValue(key, out List<int> cell))
                {
                    if (_listPool.Count > 0)
                    {
                        cell = _listPool[_listPool.Count - 1];
                        _listPool.RemoveAt(_listPool.Count - 1);
                    }
                    else cell = new List<int>();
                    _grid[key] = cell;
                }
                cell.Add(i);
            }

            // Minden kacsánál csak a saját és a 26 szomszédos cellát vizsgáljuk
            const float sqrRadius = DistancingRadius * DistancingRadius;
            for (int i = 0; i < _cachedDucks.Count; i++)
            {
                DuckData a = _cachedDucks[i];
                if (a.gameObject == null || a.rigidbody == null) continue;

                Vector3 pa = a.transform.position;
                int cx = Mathf.FloorToInt(pa.x / DistancingRadius);
                int cy = Mathf.FloorToInt(pa.y / DistancingRadius);
                int cz = Mathf.FloorToInt(pa.z / DistancingRadius);

                for (int dx = -1; dx <= 1; dx++)
                for (int dy = -1; dy <= 1; dy++)
                for (int dz = -1; dz <= 1; dz++)
                {
                    if (!_grid.TryGetValue(CellKey(cx + dx, cy + dy, cz + dz), out List<int> cell)) continue;

                    for (int n = 0; n < cell.Count; n++)
                    {
                        int j = cell[n];
                        if (j <= i) continue; // minden pár csak egyszer

                        DuckData b = _cachedDucks[j];
                        if (b.gameObject == null || b.rigidbody == null) continue;

                        Vector3 delta = pa - b.transform.position;
                        float sqrDist = delta.sqrMagnitude;
                        if (sqrDist < sqrRadius && sqrDist > 0.01f)
                        {
                            float dist = Mathf.Sqrt(sqrDist);
                            Vector3 pushDir = delta / dist;
                            // Acceleration: tömegfüggetlen, és az Impulse-nál jóval szelídebb (a hívás minden 3. fizikai lépésben történik)
                            float accel = (DistancingRadius - dist) * 25f * accelMul;
                            a.rigidbody.AddForce(pushDir * accel, ForceMode.Acceleration);
                            b.rigidbody.AddForce(-pushDir * accel, ForceMode.Acceleration);
                        }
                    }
                }
            }
        }

        // Disco: MaterialPropertyBlock (nem klónozza a materialt). Kacsánként el van mentve az eredeti blokk,
        // és a Disco ebből indulva csak a színeket írja felül, így a játék más property-jei nem vesznek el.
        private class DiscoState
        {
            public MaterialPropertyBlock orig; // a Disco előtti állapot
            public MaterialPropertyBlock work; // az eredeti + a Disco színei
        }
        private readonly Dictionary<int, DiscoState> _discoStates = new Dictionary<int, DiscoState>();
        private readonly List<int> _discoRemoveBuffer = new List<int>();
        private int _baseColorId = -1; // URP/HDRP shaderek
        private int _colorId = -1;     // régi shaderek
        private bool _discoApplied = false;

        private void ApplyDiscoColor(Color c)
        {
            if (_baseColorId < 0)
            {
                _baseColorId = Shader.PropertyToID("_BaseColor");
                _colorId = Shader.PropertyToID("_Color");
            }

            // Optimization Mode: körönként csak a kacsák negyede frissül, és csak a látható rendererek
            int stride = _optimizationMode ? 4 : 1;
            int slice = stride > 1 ? (_discoSlice++ % stride) : 0;
            for (int i = 0; i < _cachedDucks.Count; i++)
            {
                if (stride > 1 && (i % stride) != slice) continue;
                DuckData d = _cachedDucks[i];
                Renderer r = d.renderer;
                if (r == null) continue;
                if (_optimizationMode && !r.isVisible) continue;

                if (!_discoStates.TryGetValue(d.id, out DiscoState st))
                {
                    st = new DiscoState { orig = new MaterialPropertyBlock(), work = new MaterialPropertyBlock() };
                    r.GetPropertyBlock(st.orig); // a játék saját blokkja (üres, ha nincs)
                    r.GetPropertyBlock(st.work);
                    _discoStates[d.id] = st;
                }

                // a nem létező tulajdonság beállítása ártalmatlan, így mindkét shader-típus működik
                st.work.SetColor(_baseColorId, c);
                st.work.SetColor(_colorId, c);
                r.SetPropertyBlock(st.work);
            }
            _discoApplied = true;
        }

        private void RestoreDiscoColors()
        {
            if (!_discoApplied) return; // ha a Disco soha nem futott, nem nyúlunk a játék saját property blockjaihoz
            for (int i = 0; i < _cachedDucks.Count; i++)
            {
                DuckData d = _cachedDucks[i];
                if (d.renderer != null && _discoStates.TryGetValue(d.id, out DiscoState st))
                    d.renderer.SetPropertyBlock(st.orig);
            }
            _discoStates.Clear();
            _discoApplied = false;
        }

        // Eltűnt kacsák Disco-állapotának eldobása
        private void PruneDiscoStates()
        {
            if (_discoStates.Count == 0) return;
            _discoRemoveBuffer.Clear();
            foreach (var kv in _discoStates)
                if (!_seenIds.Contains(kv.Key)) _discoRemoveBuffer.Add(kv.Key);
            for (int i = 0; i < _discoRemoveBuffer.Count; i++)
                _discoStates.Remove(_discoRemoveBuffer[i]);
        }

        // Nyelv: T("English", "Magyar") -> az aktuális nyelv szövegét adja vissza
        private string T(string en, string hu)
        {
            return _hu ? hu : en;
        }

        private void SetLanguage(bool hungarian)
        {
            _hu = hungarian;
            try
            {
                PlayerPrefs.SetInt(LangPrefKey, _hu ? 1 : 0);
                PlayerPrefs.Save();
            }
            catch { }
        }

        // A nap = RenderSettings.sun, ennek hiányában az első Directional fény (nem akármelyik lámpa)
        private Light FindSunLight()
        {
            Light sun = RenderSettings.sun;
            if (sun != null) return sun;

            var lights = Object.FindObjectsOfType<Light>();
            if (lights != null)
            {
                foreach (var l in lights)
                    if (l != null && l.type == LightType.Directional) return l;
            }
            return null;
        }

        private void UpdateCameraCache()
        {
            Camera cam = Camera.main;
            if (cam == null) return; // átmeneti null: a régi referencia marad, az eredeti pozíciót nem dobjuk el
            if (cam != _cachedMainCamera)
            {
                // új kamera példány (pl. jelenetváltás): a régi jelenet mentett pozíciója érvénytelen
                _hasSavedCamera = false;
                _freeCamFlying = false; // a szabad kamera repülése is véget ér (a régi kamera már nem létezik)
                _freeCamLooking = false;
                _freeCamHasSaved = false;
                _freeCamDisabled.Clear(); // a régi kamera szkriptjei már nem léteznek
                _freeCamRigScripts.Clear();
                _freeCamRigWasEnabled.Clear();
                _freeCamRigSaved = false;
                _freeCamRig = null;
                _cachedMainCamera = cam;
            }
        }

        // Ghost mód: bekapcsolva minden renderer ki, kikapcsolva mindegyik az EREDETI enabled állapotába kerül vissza
        private static void ApplyGhost(DuckData d, bool ghost)
        {
            if (d.allRenderers == null) return;
            for (int i = 0; i < d.allRenderers.Count; i++)
            {
                Renderer r = d.allRenderers[i];
                if (r == null) continue;
                bool orig = (d.origRendEnabled != null && i < d.origRendEnabled.Count) ? d.origRendEnabled[i] : true;
                r.enabled = ghost ? false : orig;
            }
        }

        // Inkrementális cache: csak az új kacsákat dolgozza fel, az ismerteket nem
        private void UpdateDuckCache(bool forceRebuild = false)
        {
            _totalCacheAttempts++;
            int newDucks = 0;

            var rawDucks = Object.FindObjectsOfType<DuckManager>();
            _seenIds.Clear();
            if (_isMultiplayer) PrepareOwnerInfo(rawDucks); else { _ownerOther.Clear(); _playerDuckCounts.Clear(); }

            if (rawDucks != null)
            {
                foreach (var rawDuck in rawDucks)
                {
                    if (rawDuck == null) continue;
                    try
                    {
                        // Multiplayer: más játékosok kacsáit a mod nem látja és nem módosítja
                        if (_isMultiplayer && _ownerOther.Contains(rawDuck.GetInstanceID())) continue; // nem kerül a _seenIds-be, így a cache-ből is kikerül
                        if (_protectedIds.Count > 0 && _protectedIds.Contains(rawDuck.GetInstanceID())) continue; // védett kacsa

                        int id = rawDuck.GetInstanceID();
                        _seenIds.Add(id);

                        bool known = _duckById.TryGetValue(id, out DuckData old);
                        if (known && !old.corrupted && !forceRebuild) continue; // ismert és rendben van: nincs több interop hívás

                        // újraépítésnél az első felépítés eredeti értékeit örökli (azóta már módosíthattuk őket)
                        DuckData data = BuildDuckData(rawDuck, id, known, old);

                        if (data.corrupted && !known)
                            LogErrorOnce($"[DEBUG v{DebugVersion}] Corrupted duck detected! Name: {data.duckName} | Rigidbody: {data.rigidbody != null} | Renderer: {data.renderer != null}");

                        if (known)
                        {
                            // korábban sérült volt (pl. még nem töltött be teljesen): helyben újraépítjük
                            for (int k = 0; k < _cachedDucks.Count; k++)
                            {
                                if (_cachedDucks[k].id == id) { _cachedDucks[k] = data; break; }
                            }
                        }
                        else { _cachedDucks.Add(data); newDucks++; } // az újak a lista végére kerülnek -> a "legutolsó" valóban a legújabb

                        _duckById[id] = data;
                    }
                    catch (System.Exception ex)
                    {
                        _lastErrorMessage = $"Critical error while processing {rawDuck.name}: {ex.Message}";
                        LogErrorOnce(_lastErrorMessage);
                    }
                }
            }

            // Eltűnt kacsák eltávolítása (a sorrend stabil marad) + sérültek számolása
            int corrupted = 0;
            for (int i = _cachedDucks.Count - 1; i >= 0; i--)
            {
                DuckData d = _cachedDucks[i];
                if (!_seenIds.Contains(d.id))
                {
                    _cachedDucks.RemoveAt(i);
                    _duckById.Remove(d.id);
                }
                else if (d.corrupted) corrupted++;
            }
            _corruptedDucksCount = corrupted;

            PruneDiscoStates();

            // Folyamatban lévő spawnok: az újonnan talált kacsák "beváltják" őket, a túl régiek (sikertelen spawn) eldobódnak
            for (int n = 0; n < newDucks && _pendingSpawnTimes.Count > 0; n++) _pendingSpawnTimes.Dequeue();
            while (_pendingSpawnTimes.Count > 0 && Time.unscaledTime - _pendingSpawnTimes.Peek() > 5f) _pendingSpawnTimes.Dequeue();
        }

        private DuckData BuildDuckData(DuckManager rawDuck, int id, bool hasOld, DuckData old)
        {
            var rb = rawDuck.GetComponent<Rigidbody>();

            var renderers = new List<Renderer>();
            var allRend = rawDuck.GetComponentsInChildren<Renderer>();
            if (allRend != null)
            {
                foreach (var r in allRend)
                    if (r != null) renderers.Add(r);
            }
            Renderer rend = renderers.Count > 0 ? renderers[0] : null; // elsődleges renderer (Disco / sérültség-ellenőrzés)

            // A rendererek eredeti enabled állapota (újraépítésnél a korábban eltárolt marad, ha ugyanannyi renderer van)
            List<bool> rendEnabled;
            if (hasOld && old.origRendEnabled != null && old.origRendEnabled.Count == renderers.Count)
                rendEnabled = old.origRendEnabled;
            else
            {
                rendEnabled = new List<bool>();
                for (int i = 0; i < renderers.Count; i++) rendEnabled.Add(renderers[i].enabled);
            }

            // Eredeti fizikai értékek: újraépítésnél a korábban eltároltak maradnak, ha akkor már volt Rigidbody
            bool keepPhys = hasOld && old.rigidbody != null;

            // Az eredeti értékek eltárolása még a módosítások ELŐTT
            DuckData data = new DuckData
            {
                gameObject = rawDuck.gameObject,
                transform = rawDuck.transform,
                rigidbody = rb,
                renderer = rend,
                allRenderers = renderers,
                origRendEnabled = rendEnabled,
                duckName = rawDuck.name,
                id = id,
                corrupted = (rb == null || rend == null),
                origDrag = keepPhys ? old.origDrag : (rb != null ? rb.drag : 0f),
                origAngDrag = keepPhys ? old.origAngDrag : (rb != null ? rb.angularDrag : 0f),
                origGravity = keepPhys ? old.origGravity : (rb != null ? rb.useGravity : true),
                origScale = hasOld ? old.origScale : rawDuck.transform.localScale,
                manager = rawDuck,
                firstPos = hasOld ? old.firstPos : rawDuck.transform.position
            };

            if (!hasOld && !_despawnDiagLogged)
            {
                _despawnDiagLogged = true;
                try
                {
                    float sq = rawDuck.squareDistanceToDespawn;
                    if (sq > 1f && sq < 1e11f) _rescueDespawnSq = sq;
                    LoggerInstance.Msg($"[RESCUE-DIAG] DuckManager.squareDistanceToDespawn = {sq} (kb. {Mathf.Sqrt(sq):F0} egység). A visszahozás határai: {RescueDepth} egység mélység, {RescueDistance} egység távolság.");
                }
                catch (System.Exception dex) { LogErrorOnce($"[RESCUE-DIAG] squareDistanceToDespawn nem olvasható: {dex.Message}"); }
            }

            // Az aktuális beállítások alkalmazása az új kacsára - CSAK azokat, amiket a felhasználó tényleg átállított
            if (rb != null)
            {
                if (_frictionTouched)
                {
                    rb.drag = _waterFriction;
                    rb.angularDrag = _waterFriction * 2f;
                }
            }
            if (_ghostMode) ApplyGhost(data, true);

            // A méret az EREDETI méret szorzója
            if (!Mathf.Approximately(_duckScale, 1f))
                rawDuck.transform.localScale = data.origScale * _duckScale;

            return data;
        }

        // Teljes újraépítés (a menü "Kényszerített Cache Újraépítés" gombjához)
        private void RebuildDuckCache()
        {
            // Nem töröljük a cache-t: az ismert kacsák helyben épülnek újra, az eredeti értékeik (méret, fizika, renderer-állapot) megmaradnak
            UpdateDuckCache(true);
        }

        // Minden kacsa visszaállítása az eltárolt eredeti értékekre + a módosító kapcsolók kikapcsolása
        private void ResetAllToDefaults()
        {
            for (int i = 0; i < _cachedDucks.Count; i++)
            {
                DuckData d = _cachedDucks[i];
                if (d.gameObject == null) continue;

                if (d.rigidbody != null)
                {
                    d.rigidbody.drag = d.origDrag;
                    d.rigidbody.angularDrag = d.origAngDrag;
                    d.rigidbody.useGravity = d.origGravity;
                }
                ApplyGhost(d, false);
                d.transform.localScale = d.origScale;
            }
            RestoreDiscoColors();

            _ghostMode = false;
            _discoMode = false;
            _gravityMultiplier = 1.0f;
            _frictionTouched = false;
            _waterFriction = 0.1f;
            _duckScale = 1.0f;
        }

        private Texture2D MakeStyleTexture(Color color)
        {
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.Apply();
            texture.hideFlags = HideFlags.HideAndDontSave; // különben a Unity törölheti, és eltűnik a háttér
            return texture;
        }

        private void InitStyles()
        {
            if (_debugStyle != null) return; // az utolsónak létrehozott stílus: félig sikerült inicializálás esetén újrapróbálja

            // Saját színű hátterek, hogy a menü ne az alapértelmezett, színtelen Unity-stílusokat használja.
            Texture2D windowTexture = MakeStyleTexture(new Color(0.30f, 0.36f, 0.46f, 0.97f));
            Texture2D buttonTexture = MakeStyleTexture(new Color(0.16f, 0.20f, 0.25f, 1f));
            Texture2D buttonHoverTexture = MakeStyleTexture(new Color(0.48f, 0.08f, 0.12f, 1f));
            Texture2D headerTexture = MakeStyleTexture(new Color(0.24f, 0.055f, 0.09f, 1f));
            Texture2D debugTexture = MakeStyleTexture(new Color(0.12f, 0.035f, 0.045f, 0.96f));

            _customWinStyle = new GUIStyle(GUI.skin.window);
            _customWinStyle.normal.background = windowTexture;
            _customWinStyle.focused.background = windowTexture;
            _customWinStyle.onNormal.background = windowTexture;
            _customWinStyle.onFocused.background = windowTexture;

            _customBtnStyle = new GUIStyle(GUI.skin.button);
            _customBtnStyle.normal.background = buttonTexture;
            _customBtnStyle.hover.background = buttonHoverTexture;
            _customBtnStyle.active.background = buttonHoverTexture;
            _customBtnStyle.focused.background = buttonTexture;
            _customBtnStyle.normal.textColor = Color.white;
            _customBtnStyle.hover.textColor = Color.yellow;
            _customBtnStyle.fontStyle = FontStyle.Bold;

            _headerStyle = new GUIStyle(GUI.skin.box);
            _headerStyle.normal.background = headerTexture;
            _headerStyle.normal.textColor = Color.yellow;
            _headerStyle.fontStyle = FontStyle.Bold;
            _headerStyle.alignment = TextAnchor.MiddleCenter;

            _debugStyle = new GUIStyle(GUI.skin.box);
            _debugStyle.normal.background = debugTexture;
            _debugStyle.normal.textColor = new Color(1f, 0.3f, 0.3f);
            _debugStyle.fontStyle = FontStyle.Bold;
            _customWinStyle.richText = true;
            _customBtnStyle.richText = true;
            _headerStyle.richText = true;
            _debugStyle.richText = true;
        }

        public override void OnGUI()
        {
            if (!IsHostOrSolo()) return;
            CaptureMenuKey();
            HandleCamKeyEvent();
            if (_screenshotMode) return;
            try
            {
                if (!_diagOnGuiLogged)
                {
                    LoggerInstance.Msg("[GUI-DIAG 1/3] OnGUI() meghívódott.");
                    _diagOnGuiLogged = true;
                }

                InitStyles();
                try { GUI.depth = -1000; } // kisebb érték = előrébb rajzolódik
                catch (System.Exception ex) { GuiFail("GUI.depth", ex); }
                if (!_diagStylesLogged)
                {
                    LoggerInstance.Msg("[GUI-DIAG 2/3] InitStyles() sikeresen lefutott.");
                    _diagStylesLogged = true;
                }

                // Az ESP csak a Repaint eseménynél rajzol (az OnGUI képkockánként többször is lefut)
                if (_duckEspActive && _cachedMainCamera != null && Event.current.type == EventType.Repaint)
                {
                    string duckLabel = T("Duck", "Kacsa");
                    GUI.color = Color.yellow;
                    int espDrawn = 0;
                    for (int i = 0; i < _cachedDucks.Count; i++)
                    {
                        if (_optimizationMode && espDrawn >= 80) break; // Optimization Mode: legfeljebb 80 címke
                        var d = _cachedDucks[i];
                        if (d.gameObject == null) continue;
                        Vector3 screenPos = _cachedMainCamera.WorldToScreenPoint(d.transform.position);
                        if (screenPos.z > 0)
                        {
                            float guiY = Screen.height - screenPos.y;
                            GUI.Label(new Rect(screenPos.x - 25, guiY - 20, 60, 20), duckLabel + $" [{i + 1}]");
                            espDrawn++;
                        }
                    }
                    GUI.color = Color.white;
                }

                if (!_showMenu) return;
                GUI.backgroundColor = Color.white; // nem sötétítjük el a stílusok saját színét
                if (_winFunc == null)
                    _winFunc = (GUI.WindowFunction)new System.Action<int>(DrawMenuWindow); // Il2Cpp delegate: method group-ból közvetlenül nem konvertálható

                if (!_diagWindowBeforeLogged)
                {
                    LoggerInstance.Msg($"[GUI-DIAG 3/3] GUI.Window() előtt. Screen: {Screen.width}x{Screen.height}, ablak: {_windowRect}");
                    _diagWindowBeforeLogged = true;
                }

                // A menüablak magassága a képernyőhöz igazodik
                float maxHeight = Mathf.Max(200f, Screen.height - 20f);
                _windowRect.height = Mathf.Min(WindowDesiredHeight, maxHeight);
                if (_windowRect.y + _windowRect.height > Screen.height) _windowRect.y = Mathf.Max(0f, Screen.height - _windowRect.height);

                // GUI.Window elkerüli a GUILayout.Window IL2CPP alatt hibázó LayoutedWindow konstruktorát.
                _windowRect = GUI.Window(0, _windowRect, _winFunc, $"DUCK GOD SANDBOX v{ModVersion}", _customWinStyle);

                if (_showGuide)
                {
                    if (_guideFunc == null)
                        _guideFunc = (GUI.WindowFunction)new System.Action<int>(DrawGuideWindow);
                    _guideRect.height = Mathf.Min(640f, Mathf.Max(200f, Screen.height - 40f));
                    _guideRect = GUI.Window(1, _guideRect, _guideFunc, T("GUIDE", "ÚTMUTATÓ"), _customWinStyle);
                }

                if (!_diagWindowAfterLogged)
                {
                    LoggerInstance.Msg($"[GUI-DIAG 3/3] GUI.Window() lefutott. Ablak: {_windowRect}");
                    _diagWindowAfterLogged = true;
                }

                GUI.backgroundColor = Color.white;
            }
            catch (System.Exception ex)
            {
                LogErrorOnce($"[GUI-DIAG HIBA] OnGUI: {ex}");
            }
        }

        // Ugyanazt a hibaüzenetet csak egyszer írjuk a naplóba, különben a latest.log
        // képkockánként újra és újra megtelik (korábban ez több tíz MB-ra hízott).
        private readonly System.Collections.Generic.HashSet<string> _loggedErrors = new System.Collections.Generic.HashSet<string>();

        private void LogErrorOnce(string message)
        {
            if (_loggedErrors.Count >= 100) return; // véd a végtelen sok, mindig más szövegű üzenet ellen
            if (_loggedErrors.Add(message)) LoggerInstance.Error(message);
        }

        // ---- Biztonságos IMGUI hívások ----
        // Az Il2Cpp játékokban a Unity egyes GUI metódusait a build kivágja ("Method unstripping failed").
        // Ezek a burkolók elkapják a hibát, így egy rossz hívás nem viszi el a menü többi részét,
        // és a konzolba egyszer kiírják, PONTOSAN melyik hívás nem működik ([GUI-STRIP]).
        private readonly System.Collections.Generic.HashSet<string> _failedGuiCalls = new System.Collections.Generic.HashSet<string>();

        // Csak a ténylegesen kivágott (stripped) metódusokat tiltjuk le végleg. Más hiba (pl. IMGUI vezérlőszám-eltérés egy
        // képkockában) átmeneti: naplózzuk, de a vezérlőtípus a továbbiakban is működik.
        private static bool IsStripError(System.Exception ex)
        {
            string m = ex.Message ?? "";
            return m.IndexOf("unstripping", System.StringComparison.OrdinalIgnoreCase) >= 0
                || ex is System.NotSupportedException
                || ex is System.MissingMethodException;
        }

        // true = véglegesen letiltva (kivágott metódus), false = átmeneti hiba
        private bool GuiFail(string name, System.Exception ex)
        {
            if (!IsStripError(ex))
            {
                LogErrorOnce($"[GUI] {name} átmeneti hiba (nem tiltva le): {ex.GetType().Name}: {ex.Message}");
                return false;
            }
            if (_failedGuiCalls.Add(name))
                LoggerInstance.Error($"[GUI-STRIP] {name} nem működik ebben a játékban: {ex.GetType().Name}: {ex.Message}");
            return true;
        }

        // Saját kurzor: fehér négyzet fekete kerettel, hogy a menü fölött mindig látszódjon,
        // akkor is, ha a játék kurzora sötét. A csúcsa az egér pozíciójánál van.
        private GUIStyle _cursorDarkStyle;
        private GUIStyle _cursorLightStyle;

        private void DrawMenuCursor()
        {
            try
            {
                if (_failedGuiCalls.Contains("DrawMenuCursor")) return;
                if (Event.current.type != EventType.Repaint) return;
                if (_cursorDarkStyle == null)
                {
                    _cursorDarkStyle = new GUIStyle(GUI.skin.label);
                    _cursorDarkStyle.normal.background = MakeStyleTexture(Color.black);
                    _cursorLightStyle = new GUIStyle(GUI.skin.label);
                    _cursorLightStyle.normal.background = MakeStyleTexture(Color.white);
                }
                Vector2 m = Event.current.mousePosition;
                GUI.Label(new Rect(m.x, m.y, 14, 14), "", _cursorDarkStyle);
                GUI.Label(new Rect(m.x + 2, m.y + 2, 10, 10), "", _cursorLightStyle);
            }
            catch (System.Exception ex) { GuiFail("DrawMenuCursor", ex); }
        }

        private void SetContentColor(Color c)
        {
            if (_failedGuiCalls.Contains("GUI.contentColor")) return;
            try { GUI.contentColor = c; }
            catch (System.Exception ex) { GuiFail("GUI.contentColor", ex); }
        }

        private void SafeLabel(string text, GUIStyle style = null)
        {
            if (_failedGuiCalls.Contains("GUILayout.Label")) return;
            try
            {
                if (style != null) GUILayout.Label(text, style);
                else GUILayout.Label(text);
            }
            catch (System.Exception ex) { GuiFail("GUILayout.Label", ex); }
        }

        private bool SafeButton(string text, GUIStyle style = null)
        {
            if (_failedGuiCalls.Contains("GUILayout.Button")) return false;
            try
            {
                return style != null ? GUILayout.Button(text, style) : GUILayout.Button(text);
            }
            catch (System.Exception ex) { GuiFail("GUILayout.Button", ex); return false; }
        }

        private bool SafeToggle(bool value, string text, GUIStyle style = null)
        {
            if (!_failedGuiCalls.Contains("GUILayout.Toggle"))
            {
                try
                {
                    return style != null ? GUILayout.Toggle(value, text, style) : GUILayout.Toggle(value, text);
                }
                catch (System.Exception ex) { if (!GuiFail("GUILayout.Toggle", ex)) return value; }
            }
            // Tartalék: ha a Toggle ki van vágva, egy gomb kapcsolja át az értéket
            if (SafeButton((value ? "[ON]  " : "[OFF] ") + text, _customBtnStyle)) return !value;
            return value;
        }

        private float SafeSlider(float value, float min, float max)
        {
            if (!_failedGuiCalls.Contains("GUILayout.HorizontalSlider"))
            {
                try { return GUILayout.HorizontalSlider(value, min, max); }
                catch (System.Exception ex) { if (!GuiFail("GUILayout.HorizontalSlider", ex)) return value; }
            }
            // Tartalék: ha a csúszka ki van vágva, két gombbal léptethető az érték
            float step = (max - min) / 20f;
            if (SafeButton("-  (" + value.ToString("F2") + ")", _customBtnStyle)) value = Mathf.Max(min, value - step);
            if (SafeButton("+", _customBtnStyle)) value = Mathf.Min(max, value + step);
            return value;
        }

        private void SafeSpace(float pixels)
        {
            if (_failedGuiCalls.Contains("GUILayout.Space")) { SafeLabel(""); return; } // tartalék: üres sor
            try { GUILayout.Space(pixels); }
            catch (System.Exception ex) { GuiFail("GUILayout.Space", ex); SafeLabel(""); }
        }

        private void DrawMenuWindow(int windowID)
        {
            // IMGUI: a Layout és az eseménykezelő lefutás ugyanannyi vezérlőt kérjen. A feltételesen
            // megjelenő elemek állapotát ezért a kirajzolás ELEJÉN rögzítjük, nem a kattintás után olvassuk.
            bool showVortexSlider = _vortexMode;
            bool showNextDuck = _cameraFollowActive;
            bool showDebugPanel = _showDebugPanel;
            bool showRebuild = _corruptedDucksCount > 0;
            bool showFreeCamInfo = _freeCamEnabled;
            bool showOpt = _optimizationMode;
            _secSnapshot = _openSection;

            SetContentColor(Color.yellow);
            SafeLabel($"FPS: <color=cyan>{_fps:F0}</color> | " + T("Ducks", "Kacsák") + $": <color=yellow>{_cachedDucks.Count}</color>");
            SetContentColor(Color.white);

            // Nyelvváltó: a gomb a CÉLNYELVET mutatja
            if (SafeButton(_hu ? "English" : "Magyar", _customBtnStyle)) SetLanguage(!_hu);
            if (SafeButton(_showGuide ? T("Close guide", "Útmutató bezárása") : T("Guide (what each button does)", "Útmutató (mit csinál az egyes gomb)"), _customBtnStyle))
                _showGuide = !_showGuide;

            // A GUILayout.BeginScrollView IL2CPP alatt Method unstripping failed hibát dobott.
            // Egyszerű függőleges layoutot használunk, hogy a menü többi vezérlője is kirajzolódjon.

            // ---- ALAPBEÁLLÍTÁSOK ----
            SafeLabel(T("Basic Settings", "Alapbeállítások"), _headerStyle);
            SafeLabel(T("Game speed", "Játék sebessége") + $": {Time.timeScale:F1}x");
            if (_mpUi)
            {
                SafeLabel(T("Game speed is locked in multiplayer (it would affect other players).", "A játék sebessége multiplayerben zárolva van (más játékosokat is érintene)."));
            }
            else
            {
                float newSpeed = SafeSlider(_gameSpeed, 0.1f, 10.0f);
                if (!Mathf.Approximately(newSpeed, _gameSpeed))
                {
                    // Csak akkor írjuk a timeScale-t, ha a felhasználó tényleg mozdította a csúszkát
                    _gameSpeed = newSpeed;
                    Time.timeScale = _gameSpeed;
                }
            }
            if (SafeButton(T("Rotate Sun", "Napszak Forgatása"), _customBtnStyle))
            {
                LoggerInstance.Msg("[SUN] Napszak Forgatása megnyomva.");
                if (_mainSunLight == null) _mainSunLight = FindSunLight();
                if (_mainSunLight != null) _mainSunLight.transform.Rotate(new Vector3(45f, 0, 0));
            }
            if (SafeButton(T("Reset all duck changes", "Minden kacsa-módosítás visszaállítása"), _customBtnStyle)) ResetAllToDefaults();

            // ---- 1. FIZIKA ÉS VÍZ ----
            if (Section(1, T("1. Physics & Environment", "1. Fizika és Környezet Manipuláció")))
            {
            if (SafeButton(T("DUCK TSUNAMI", "KACSA CUNAMI"), _customBtnStyle))
            {
                for (int i = 0; i < _cachedDucks.Count; i++)
                    if (_cachedDucks[i].rigidbody != null) _cachedDucks[i].rigidbody.AddForce(Vector3.up * 25f, ForceMode.Impulse);
            }
            _geyserMode = SafeToggle(_geyserMode, T("Geyser Mode", "Gejzír Mód"));

            SafeLabel(T("Gravity", "Gravitáció") + $": {_gravityMultiplier:F1}x");
            float newGrav = Mathf.Round(SafeSlider(_gravityMultiplier, 0.0f, 10.0f) * 10f) / 10f; // 0,1-es lépések, hogy pontosan 0x és 1x is beállítható legyen
            if (!Mathf.Approximately(newGrav, _gravityMultiplier)) _gravityMultiplier = newGrav;

            SafeLabel(T("Water friction", "Víz súrlódása") + $": {_waterFriction:F2}");
            float newFric = SafeSlider(_waterFriction, 0.0f, 2.0f);
            if (!Mathf.Approximately(newFric, _waterFriction))
            {
                _waterFriction = newFric;
                _frictionTouched = true;
                for (int i = 0; i < _cachedDucks.Count; i++)
                {
                    if (_cachedDucks[i].rigidbody != null)
                    {
                        _cachedDucks[i].rigidbody.drag = _waterFriction;
                        _cachedDucks[i].rigidbody.angularDrag = _waterFriction * 2f;
                    }
                }
            }

            // ---- 2. VIZUÁLIS ÉS MÉRET ----
            }
            if (Section(2, T("2. Cosmetics & Size Madness", "2. Kozmetikai és Méret Őrület")))
            {
            bool newGhost = SafeToggle(_ghostMode, T("Ghost Mode", "Ghost Mód"));
            if (newGhost != _ghostMode)
            {
                _ghostMode = newGhost;
                for (int i = 0; i < _cachedDucks.Count; i++)
                    ApplyGhost(_cachedDucks[i], _ghostMode);
            }
            bool newDisco = SafeToggle(_discoMode, T("Disco Flash", "Diszkó Villódzás"));
            if (newDisco != _discoMode)
            {
                _discoMode = newDisco;
                if (!_discoMode) RestoreDiscoColors();
            }
            _duckEspActive = SafeToggle(_duckEspActive, T("Duck Markers (ESP / Wallhack)", "Kacsák Megjelölése (ESP / Wallhack)"));

            SafeLabel(T("Duck body size", "Kacsa Testméret") + $": {_duckScale:F1}x");
            float newScale = SafeSlider(_duckScale, 0.2f, 12.0f);
            if (!Mathf.Approximately(newScale, _duckScale))
            {
                _duckScale = newScale;
                for (int i = 0; i < _cachedDucks.Count; i++)
                    if (_cachedDucks[i].gameObject != null) _cachedDucks[i].transform.localScale = _cachedDucks[i].origScale * _duckScale;
            }


            // ---- 3. INTERAKCIÓK ----
            }
            if (Section(3, T("3. Duck Interactions", "3. Kacsák Közötti Interakciók")))
            {
            if (SafeButton(T("Duck Domino (push the last duck)", "Kacsa Dominó (Utolsó meglökése)"), _customBtnStyle))
            {
                if (_cachedDucks.Count > 0)
                {
                    var last = _cachedDucks[_cachedDucks.Count - 1];
                    if (last.rigidbody != null) last.rigidbody.AddForce(Vector3.forward * 60f, ForceMode.VelocityChange);
                }
            }
            if (SafeButton(T("Global Quack (all ducks)", "Globális Hápogás (minden kacsa)") + $" [{_cachedDucks.Count}]", _customBtnStyle)) GlobalQuack();
            _socialDistancing = SafeToggle(_socialDistancing, T("Social Distancing (repulsion)", "Közösségi Távolságtartás (Taszítás)"));
            _blackHoleMode = SafeToggle(_blackHoleMode, T("Duck Black Hole (pull to first duck)", "Kacsa Fekete Lyuk (Első kacsához szívás)"));
            _clonePickerActive = SafeToggle(_clonePickerActive, T("Duck Picker (left click a duck to select it)", "Kacsaválasztó (bal klikk egy kacsára)"));
            SafeLabel(T("Selected duck", "Kiválasztott kacsa") + ": " + SelectedDuckLabel());
            if (SafeButton(T("Clone selected duck", "Kijelölt kacsa klónozása"), _customBtnStyle)) CloneSelectedDuck();
            if (_mpUi) SafeLabel(T("Duck protection: singleplayer only.", "Kacsa-védelem: csak egyjátékos módban."));
            else
            {
                bool selProtected = _selectedDuck != null && _protectedIds.Contains(_selectedDuckId);
                if (SafeButton(selProtected ? T("Remove protection from selected duck", "Kijelölt kacsa védelmének levétele") : T("Protect selected duck (from the mod and despawn)", "Kijelölt kacsa védelme (a modtól és a despawntól)"), _customBtnStyle)) ToggleProtectSelected();
                if (SafeButton(T("Remove all protection", "Minden védelem levétele") + $" [{_protectedIds.Count}]", _customBtnStyle)) { UnprotectAll(); _protectStatus = T("All protection removed.", "Minden védelem levéve."); }
                SafeLabel(string.IsNullOrEmpty(_protectStatus) ? " " : _protectStatus);
            }
            _gravityGunActive = SafeToggle(_gravityGunActive, T("Gravity Gun (right click: nearest duck jumps to the mouse)", "Gravitációs Fegyver (jobb klikk: a legközelebbi kacsa az egérhez ugrik)"));

            // ---- 4. ESZKÖZÖK ----
            }
            if (Section(4, T("4. Developer & Sandbox Tools", "4. Fejlesztői és Sandbox Eszközök")))
            {
            _vortexMode = SafeToggle(_vortexMode, T("Vortex Mode", "Örvény (Vortex) Mód"));
            if (showVortexSlider) _vortexSpeed = SafeSlider(_vortexSpeed, 1.0f, 25.0f);

            _duckCannonActive = SafeToggle(_duckCannonActive, T("Duck Cannon", "Kacsaágyú"));
            _duckMagnetActive = SafeToggle(_duckMagnetActive, T("Magnet (Mouse)", "Mágnes (Egér)"));

            bool newCam = SafeToggle(_cameraFollowActive, T("Camera Follow", "Kamera Követés"));
            if (newCam != _cameraFollowActive)
            {
                _cameraFollowActive = newCam;
                LoggerInstance.Msg($"[CAMERA] Kamera Követés: {(newCam ? "BE" : "KI")}");
                if (!_cameraFollowActive) ResetCamera();
            }
            if (showNextDuck && SafeButton(T("Previous Duck", "Előző Kacsa"), _customBtnStyle))
                _cameraTargetIndex = _cameraTargetIndex > 0 ? _cameraTargetIndex - 1 : Mathf.Max(0, _cachedDucks.Count - 1);
            if (showNextDuck && SafeButton(T("Next Duck", "Következő Kacsa"), _customBtnStyle)) _cameraTargetIndex++;

            bool newFree = SafeToggle(_freeCamEnabled, T("Free Camera (Space = fly on/off)", "Szabad Kamera (Space = repülés be/ki)"));
            if (newFree != _freeCamEnabled)
            {
                _freeCamEnabled = newFree;
                if (!_freeCamEnabled) SetFlight(false);
            }
            if (showFreeCamInfo)
            {
                SafeLabel(_freeCamFlying
                    ? T("<color=lime>FLYING</color>: WASD move, Q/E down/up, Shift fast, right mouse = look, Space = exit",
                        "<color=lime>REPÜLÉS</color>: WASD mozgás, Q/E le/fel, Shift gyors, jobb egérgomb = nézelődés, Space = kilépés")
                    : T("Press Space in the game to start flying", "Nyomd meg a Space-t a játékban a repüléshez"));
                SafeLabel(T("Fly speed", "Repülési sebesség") + $": {_freeCamSpeed:F0}");
                _freeCamSpeed = SafeSlider(_freeCamSpeed, 2f, 60f);
            }

            _rescueLostDucks = SafeToggle(_rescueLostDucks, T("Rescue Lost Ducks", "Eltűnt Kacsák Visszahozása") + $" ({T("rescued", "visszahozva")}: {_rescuedCount})");

            }

            // ---- 5. IDŐJÁRÁS ÉS ÉVSZAK ----
            if (Section(5, T("5. Weather", "5. Időjárás")))
            {
                if (SafeButton(T("Clear sky", "Tiszta ég"), _customBtnStyle)) SetWeather("clear");
                if (SafeButton(T("Rain", "Eső"), _customBtnStyle)) SetWeather("rain");
                if (SafeButton(T("Snow", "Hó"), _customBtnStyle)) SetWeather("snow");
                if (SafeButton(T("Fog", "Köd"), _customBtnStyle)) SetWeather("fog");
                if (SafeButton(T("Clear ALL weather", "Minden időjárás törlése"), _customBtnStyle)) ClearAllWeather();
                SafeLabel(string.IsNullOrEmpty(_weatherStatus) ? " " : _weatherStatus);
            }

            // ---- 6. SPAWNER ÉS FORMÁCIÓK ----
            if (Section(6, T("6. Spawner & Formations", "6. Spawner és Formációk")))
            {
                _collectionSpawner = SafeToggle(_collectionSpawner, T("Collection Spawner (click a duck in the Collection menu)", "Collection Spawner (kattints egy kacsára a Collection menüben)"));
                SafeLabel(string.IsNullOrEmpty(_spawnerStatus) ? " " : _spawnerStatus);
                if (SafeButton(T("Formation: Circle", "Formáció: Kör"), _customBtnStyle)) ArrangeDucks("circle");
                if (SafeButton(T("Formation: Line", "Formáció: Sor"), _customBtnStyle)) ArrangeDucks("line");
                if (SafeButton(T("Formation: Spiral", "Formáció: Spirál"), _customBtnStyle)) ArrangeDucks("spiral");
                if (SafeButton(T("Formation: Tower", "Formáció: Torony"), _customBtnStyle)) ArrangeDucks("tower");
                SafeLabel(string.IsNullOrEmpty(_formationStatus) ? " " : _formationStatus);
                if (SafeButton(T("Respawn All Ducks (to the spawn point)", "Respawn All Ducks (a spawn-pontra)"), _customBtnStyle)) RespawnAllDucks();
                SafeLabel(string.IsNullOrEmpty(_respawnStatus) ? " " : _respawnStatus);
            }

            // ---- 7. MULTIPLAYER ----
            if (_mpUi && Section(7, T("7. Multiplayer", "7. Multiplayer")))
            {
                SafeLabel(T("Other players' ducks are protected: the mod does not see or change them.", "Más játékosok kacsái védettek: a mod nem látja és nem módosítja őket."));
                SafeLabel(T("Ducks per owner:", "Kacsák tulajdonosonként:"), _headerStyle);
                foreach (var kv in _playerDuckCounts) SafeLabel($"{kv.Key}: <color=yellow>{kv.Value}</color>");
            }

            // ---- UTASÍTÁSOK ÉS RENDSZER ----
            SafeSpace(10);
            SafeLabel(T("System Commands", "Rendszer Parancsok"), _headerStyle);

            if (SafeButton(_rebindingMenuKey ? T("Press a key... (Esc = cancel)", "Nyomj meg egy billentyűt... (Esc = mégse)") : T("Menu key: ", "Menü-billentyű: ") + _menuKey + T("  (click to change)", "  (kattints a módosításhoz)"), _customBtnStyle))
                _rebindingMenuKey = !_rebindingMenuKey;

            bool newOpt = SafeToggle(_optimizationMode, T("Optimization Mode", "Optimization Mode"), _customBtnStyle);
            if (newOpt != _optimizationMode)
            {
                _optimizationMode = newOpt;
                if (!newOpt) _optStatus = "";
                SaveModeSettings();
            }
            if (showOpt) SafeLabel(string.IsNullOrEmpty(_optStatus)
                ? T($"Level {OptStride()}x ({_cachedDucks.Count} ducks): sliced physics, rarer scans, faster Disco, max 80 ESP labels, FPS guard (25).", $"Szint {OptStride()}x ({_cachedDucks.Count} kacsa): szeletelt fizika, ritkább keresés, gyorsabb Disco, max 80 ESP címke, FPS-védelem (25).")
                : _optStatus);

            if (SafeButton(T("Screenshot mode (hides ALL UI; F8 or the menu key brings it back)", "Képernyőkép mód (MINDEN felületet elrejt; F8 vagy a menü-billentyű hozza vissza)"), _customBtnStyle)) SetScreenshotMode(true);


            _chaosModeActive = SafeToggle(_chaosModeActive, T("Chaos Flood", "Káosz Özön"), _customBtnStyle);
            if (SafeButton(T("Quick Spawn", "Gyors Spawn"), _customBtnStyle))
            {
                if (TrySpawnRandomDuck()) UpdateDuckCache();
            }

            // Törlés: két kattintás kell (3 másodpercen belül), hogy véletlenül ne lehessen mindent elveszíteni
            bool confirmingDelete = Time.unscaledTime < _deleteConfirmUntil;
            string deleteLabel = confirmingDelete
                ? T("CLICK AGAIN TO CONFIRM", "KATTINTS MÉG EGYSZER A MEGERŐSÍTÉSHEZ")
                : T("DELETE ALL DUCKS", "MINDEN KACSA TÖRLÉSE");
            if (SafeButton("<color=red>" + deleteLabel + "</color>", _customBtnStyle))
            {
                if (confirmingDelete)
                {
                    _deleteConfirmUntil = 0f;
                    DeleteAllDucks();
                }
                else _deleteConfirmUntil = Time.unscaledTime + 3f;
            }
            string saveLabel = T("Force Save", "Kényszerített Mentés") + (_forceSaveSlot >= 0
                ? $" ({T("slot", "slot")} {_forceSaveSlot})"
                : $" ({T("creates a new slot", "új slotot hoz létre")})");
            if (SafeButton(saveLabel, _customBtnStyle)) ForceSave();
            SafeLabel(string.IsNullOrEmpty(_saveStatus) ? " " : _saveStatus); // mindig ugyanannyi vezérlő (IMGUI Layout/esemény egyezés)

            // ---- TELEMETRIA PANEL ----
            SafeSpace(5);
            _showDebugPanel = SafeToggle(_showDebugPanel, $"[V{DebugVersion}] " + T("DEBUG & TELEMETRY", "HIBAKERESÉS & TELEMETRIA"), _headerStyle);
            if (showDebugPanel)
            {
                GUI.backgroundColor = new Color(0.25f, 0.1f, 0.1f, 0.9f);
                string cacheState = _corruptedDucksCount > 0
                    ? "<color=orange>" + T("WARNING", "FIGYELMEZTETÉS") + "</color>"
                    : "<color=lime>" + T("STABLE", "STABIL") + "</color>";
                SafeLabel(T("Il2Cpp cache state", "Il2Cpp Cache állapot") + $": {cacheState} (" + T("scans", "frissítések") + $": {_totalCacheAttempts})");
                string corruptedColor = _corruptedDucksCount > 0 ? "red" : "green";
                SafeLabel(T("Corrupted / faulty ducks", "Sérült / Hibás kacsák száma") + $": <color={corruptedColor}>{_corruptedDucksCount}</color>");
                string lastLog = string.IsNullOrEmpty(_lastErrorMessage) ? T("No errors logged.", "Nincs hiba logolva.") : _lastErrorMessage;
                SafeLabel(T("Last system log", "Utolsó rendszer log") + $": <color=orange>{lastLog}</color>");
                if (showRebuild && SafeButton(T("Force Cache Rebuild", "Kényszerített Cache Újraépítés"), _customBtnStyle))
                {
                    RebuildDuckCache();
                }
                    GUI.backgroundColor = Color.white;
            }
            DrawMenuCursor(); // utolsónak rajzoljuk, hogy az ablak tartalma fölött legyen
            try { GUI.DragWindow(new Rect(0, 0, 10000, 20)); }
            catch (System.Exception ex) { GuiFail("GUI.DragWindow", ex); }
        }

        // ---- Kényszerített mentés ----
        // Az első megnyomásra a mod kiválaszt egy szabad save slotot, eltárolja (PlayerPrefs), és onnantól
        // mindig csak abba a slotba ment, a játékok újraindítása után is.
        private const string SaveSlotPrefKey = "DuckGodMenu_SaveSlot";
        private int _forceSaveSlot = -1;          // -1: még nincs slot létrehozva
        private bool _saveSlotLoaded = false;
        private string _saveStatus = "";
        private float _saveCheckAt = -1f;
        private int _saveCheckSlot = -1;
        private bool _saveCheckCreated = false;

        private void LoadSaveSlotPref()
        {
            if (_saveSlotLoaded) return;
            _saveSlotLoaded = true;
            try { _forceSaveSlot = PlayerPrefs.GetInt(SaveSlotPrefKey, -1); }
            catch { _forceSaveSlot = -1; }
        }

        // Az első szabad slot megkeresése: a játék saját slot-listájából (PauseManager.slots), ennek hiányában
        // a jelenetben lévő SaveSlot objektumokból olvassuk ki a slot azonosítókat.
        private int FindFreeSaveSlot(GeneralManager gm)
        {
            List<int> ids = new List<int>();
            try
            {
                var pm = gm.PauseManager;
                if (pm != null)
                {
                    var slots = pm.slots;
                    if (slots != null)
                        foreach (var sl in slots)
                            if (sl != null && !ids.Contains(sl.ID)) ids.Add(sl.ID);
                }
            }
            catch (System.Exception ex) { LogErrorOnce($"[SAVE] PauseManager.slots nem olvasható: {ex.Message}"); }

            if (ids.Count == 0)
            {
                try
                {
                    var all = Resources.FindObjectsOfTypeAll<SaveSlot>();
                    if (all != null)
                        foreach (var sl in all)
                            if (sl != null && !ids.Contains(sl.ID)) ids.Add(sl.ID);
                }
                catch (System.Exception ex) { LogErrorOnce($"[SAVE] SaveSlot objektumok keresése sikertelen: {ex.Message}"); }
            }

            ids.Sort();
            LoggerInstance.Msg($"[SAVE-DIAG] Ismert slot azonosítók: {string.Join(", ", ids)}");
            foreach (int id in ids)
                if (!SaveSystem.SaveExists(id)) return id;
            return -1;
        }

        private void ForceSave()
        {
            try
            {
                LoadSaveSlotPref();
                GeneralManager gm = GeneralManager.I;
                if (gm == null)
                {
                    _saveStatus = T("Save failed: game manager not found.", "Mentés sikertelen: a játék kezelője nem található.");
                    return;
                }

                bool created = false;
                if (_forceSaveSlot < 0)
                {
                    int free = FindFreeSaveSlot(gm);
                    if (free < 0)
                    {
                        _saveStatus = T("No free save slot. Delete one in the game first.", "Nincs szabad save slot. Törölj egyet a játékban.");
                        return;
                    }
                    _forceSaveSlot = free;
                    created = true;
                    try { PlayerPrefs.SetInt(SaveSlotPrefKey, free); PlayerPrefs.Save(); }
                    catch (System.Exception ex) { LogErrorOnce($"[SAVE] A slot száma nem menthető: {ex.Message}"); }
                }

                int slot = _forceSaveSlot;
                bool existedBefore = SaveSystem.SaveExists(slot);
                LoggerInstance.Msg($"[SAVE-DIAG] Mentés a(z) {slot}. slotba (új slot: {created}, már létezett: {existedBefore})");

                var pauseManager = gm.PauseManager;
                if (pauseManager != null) pauseManager.Save(slot);
                else if (Saves.instance != null && Saves.instance.gameSave != null) Saves.instance.gameSave.Save(slot);
                else
                {
                    _saveStatus = T("Save failed: no save system found.", "Mentés sikertelen: a mentési rendszer nem található.");
                    return;
                }

                _saveCheckSlot = slot;
                _saveCheckCreated = created;
                _saveCheckAt = Time.unscaledTime + 3f; // a játék a mentést késleltetve is végezheti
                _saveStatus = T("Saving...", "Mentés folyamatban...");
            }
            catch (System.Exception ex)
            {
                _saveStatus = T("Save failed: ", "Mentés sikertelen: ") + ex.Message;
                LogErrorOnce($"[SAVE] ForceSave hiba: {ex.GetType().Name}: {ex.Message}");
            }
        }

        // 3 másodperccel a mentés után megnézi, tényleg létezik-e a slot a lemezen
        private void CheckSaveResult()
        {
            if (_saveCheckAt < 0f || Time.unscaledTime < _saveCheckAt) return;
            _saveCheckAt = -1f;
            try
            {
                bool ok = SaveSystem.SaveExists(_saveCheckSlot);
                _saveStatus = ok
                    ? T("Saved to slot ", "Mentve a(z) ") + _saveCheckSlot + T("", ". slotba") + (_saveCheckCreated ? T(" (new)", " (új)") : "")
                    : T("Save may have failed: slot ", "A mentés nem biztos, hogy sikerült: slot ") + _saveCheckSlot + T(" not found.", " nem található.");
                LoggerInstance.Msg($"[SAVE-DIAG] Ellenőrzés: slot {_saveCheckSlot} létezik = {ok}");
            }
            catch (System.Exception ex) { LogErrorOnce($"[SAVE] Ellenőrzés hiba: {ex.Message}"); }
        }

        // ---- Globális Hápogás ----
        // Minden ismert kacsán meghívja a DuckManager.DuckQuack() metódust (a MenlikDuck felülírt változata is így fut le).
        private void GlobalQuack()
        {
            int ok = 0;
            for (int i = 0; i < _cachedDucks.Count; i++)
            {
                DuckData d = _cachedDucks[i];
                if (d.gameObject == null || d.manager == null) continue;
                try
                {
                    d.manager.DuckQuack();
                    ok++;
                }
                catch (System.Exception ex)
                {
                    LogErrorOnce($"[QUACK] DuckManager.DuckQuack hiba ({d.duckName}): {ex.GetType().Name}: {ex.Message}");
                }
            }
            LoggerInstance.Msg($"[QUACK] {ok}/{_cachedDucks.Count} kacsa hápogott.");
        }

        // ---- Szabad Kamera ----
        private void SetFlight(bool on)
        {
            if (on == _freeCamFlying) return;

            if (on)
            {
                if (_cachedMainCamera == null) UpdateCameraCache();
                if (_cachedMainCamera == null) return; // nincs kamera, nincs mit repíteni

                Transform t = _cachedMainCamera.transform;
                _freeCamSavedPos = t.position;
                _freeCamSavedRot = t.rotation;
                _freeCamHasSaved = true;
                _freeCamRig = t.parent;
                _freeCamRigSaved = _freeCamRig != null;
                if (_freeCamRigSaved)
                {
                    _freeCamRigPos = _freeCamRig.position;
                    _freeCamRigRot = _freeCamRig.rotation;
                }

                Vector3 e = t.eulerAngles;
                _freeCamYaw = e.y;
                _freeCamPitch = e.x > 180f ? e.x - 360f : e.x;
                _freeCamLooking = false;
                _freeCamFlying = true;
                DisableGameCameraScripts(t); // a játék saját kameravezérlője ne kapja meg a repülés bemenetét
            }
            else
            {
                _freeCamFlying = false;
                _freeCamLooking = false;
                // kilépéskor visszaáll az eredeti kamera
                if (_freeCamHasSaved && _cachedMainCamera != null)
                {
                    RestoreSavedCamera();
                    _freeCamRestoreFrames = 10; // az OnLateUpdate még pár képkockán át megismétli
                }
                EnableGameCameraScripts(); // előbb a pozíció áll vissza, utána kapcsolódik be a játék kamerája
            }
        }

        // Repülés közben a játék kameravezérlő szkriptjei (a kamerán és a szülőin) ki vannak kapcsolva,
        // különben a WASD / Q / E / jobb egér / görgő az ő belső állapotukat is elmozdítaná, és kilépéskor
        // a kamera egy furcsa, elcsúszott állapotba ugrana vissza.
        private readonly List<Behaviour> _freeCamDisabled = new List<Behaviour>();
        private bool _freeCamDiagLogged = false;

        // A kamera szülője (CameraRig) és a rajta lévő SmoothMouseLook: repülés alatt végig kikapcsolva tartjuk,
        // és a rig helyzetét is mentjük/visszaállítjuk, mert az egérkamera a rigot forgatja.
        private Transform _freeCamRig;
        private Vector3 _freeCamRigPos;
        private Quaternion _freeCamRigRot;
        private bool _freeCamRigSaved = false;
        private readonly List<Behaviour> _freeCamRigScripts = new List<Behaviour>();
        private readonly List<bool> _freeCamRigWasEnabled = new List<bool>();

        private void RestoreSavedCamera()
        {
            if (_cachedMainCamera == null) return;
            if (_freeCamRigSaved && _freeCamRig != null)
            {
                _freeCamRig.position = _freeCamRigPos;
                _freeCamRig.rotation = _freeCamRigRot;
            }
            _cachedMainCamera.transform.position = _freeCamSavedPos;
            _cachedMainCamera.transform.rotation = _freeCamSavedRot;
        }
        private int _freeCamRestoreFrames = 0; // kilépés után ennyi képkockán át újra ráírjuk az eredeti kamerahelyzetet

        // Il2Cpp alatt a GetType() az alaptípust (MonoBehaviour) adja, a valódi osztálynevet az Il2Cpp típus tudja
        private static string RealTypeName(Behaviour b)
        {
            try { return b.GetIl2CppType().FullName; }
            catch { return b.GetType().Name; }
        }

        private void DisableGameCameraScripts(Transform camT)
        {
            _freeCamDisabled.Clear();
            _freeCamRigScripts.Clear();
            _freeCamRigWasEnabled.Clear();
            try
            {
                // A kamera szülői (pl. CameraRig / SmoothMouseLook): minden szkriptjük kikapcsol, az eredeti állapotot megjegyezzük
                Transform par = camT.parent;
                for (int depth = 0; depth < 3 && par != null; depth++, par = par.parent)
                {
                    var pcomps = par.GetComponents<MonoBehaviour>();
                    if (pcomps == null) continue;
                    foreach (var pm in pcomps)
                    {
                        if (pm == null) continue;
                        string pn = RealTypeName(pm);
                        if (pn.Contains("Melon") || pn.Contains("DuckGod")) continue;
                        _freeCamRigScripts.Add(pm);
                        _freeCamRigWasEnabled.Add(pm.enabled);
                        pm.enabled = false;
                    }
                }

                // Diagnosztika (egyszer): minden szkript a kamerán és a szülőin
                if (!_freeCamDiagLogged)
                {
                    _freeCamDiagLogged = true;
                    Transform dc = camT;
                    for (int depth = 0; depth < 4 && dc != null; depth++, dc = dc.parent)
                    {
                        var dcomps = dc.GetComponents<MonoBehaviour>();
                        var dn = new List<string>();
                        if (dcomps != null) foreach (var m in dcomps) if (m != null) dn.Add(RealTypeName(m));
                        LoggerInstance.Msg($"[FREECAM-DIAG] {dc.name}: {string.Join(", ", dn)}");
                    }
                }

                // Csak a név alapján kameravezérlőnek tűnő szkriptek (az egész jelenetben). A megjelenítési
                // effektek (Suimono, Enviro, köd, post-process) érintetlenek maradnak.
                string[] include = { "Camera", "Orbit", "Cinemachine", "MouseLook", "FreeLook", "CamControl" };
                string[] exclude = { "Suimono", "Enviro", "Underwater", "Fog", "PostProcess", "Volume", "Audio", "AdditionalCameraData", "Melon", "DuckGod", "LookAt" };
                var all = Object.FindObjectsOfType<MonoBehaviour>();
                if (all != null)
                {
                    foreach (var mb in all)
                    {
                        if (mb == null || !mb.enabled) continue;
                        string n = RealTypeName(mb);
                        bool hit = false;
                        foreach (var s in include) if (n.Contains(s)) { hit = true; break; }
                        if (!hit) continue;
                        foreach (var s in exclude) if (n.Contains(s)) { hit = false; break; }
                        if (!hit) continue;
                        mb.enabled = false;
                        _freeCamDisabled.Add(mb);
                    }
                }
                if (_freeCamDisabled.Count > 0)
                {
                    var names = new List<string>();
                    foreach (var b in _freeCamDisabled) names.Add(RealTypeName(b));
                    LoggerInstance.Msg($"[FREECAM] Letiltott játék-kameraszkriptek: {string.Join(", ", names)}");
                }
            }
            catch (System.Exception ex) { LogErrorOnce($"[FREECAM] Kameraszkriptek letiltása sikertelen: {ex.Message}"); }
        }

        private void EnableGameCameraScripts()
        {
            try
            {
                foreach (var b in _freeCamDisabled)
                    if (b != null) b.enabled = true;
                for (int i = 0; i < _freeCamRigScripts.Count; i++)
                    if (_freeCamRigScripts[i] != null) _freeCamRigScripts[i].enabled = _freeCamRigWasEnabled[i];
            }
            catch (System.Exception ex) { LogErrorOnce($"[FREECAM] Kameraszkriptek visszakapcsolása sikertelen: {ex.Message}"); }
            _freeCamDisabled.Clear();
            _freeCamRigScripts.Clear();
            _freeCamRigWasEnabled.Clear();
        }

        private void UpdateFreeCamera()
        {
            if (_cachedMainCamera == null) UpdateCameraCache();
            if (_cachedMainCamera == null)
            {
                _freeCamFlying = false;
                EnableGameCameraScripts(); // a letiltott játék-kameraszkriptek ne maradjanak kikapcsolva
                return;
            }

            Transform t = _cachedMainCamera.transform;
            float dt = Time.unscaledDeltaTime; // a játék sebességétől (akár 0-tól) független mozgás

            // Ha a játék repülés közben visszakapcsolná a saját kameravezérlőjét (pl. jobb egérgombra), azonnal kikapcsoljuk
            for (int i = 0; i < _freeCamRigScripts.Count; i++)
            {
                Behaviour rs = _freeCamRigScripts[i];
                if (rs != null && rs.enabled) rs.enabled = false;
            }

            // Nézelődés: jobb egérgomb (ha nem a menü fölött kezdődött)
            if (Input.GetMouseButtonDown(1))
            {
                _freeCamLooking = !MouseOverMenu();
                _freeCamLastMouse = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(1)) _freeCamLooking = false;

            if (_freeCamLooking && Input.GetMouseButton(1))
            {
                float mx, my;
                try
                {
                    mx = Input.GetAxis("Mouse X") * FreeCamLookSensitivity;
                    my = Input.GetAxis("Mouse Y") * FreeCamLookSensitivity;
                }
                catch (System.Exception ex)
                {
                    // ha a játékban nincs "Mouse X/Y" tengely, az egér pozíciójának változásából számoljuk
                    LogErrorOnce($"[FREECAM] Mouse X/Y tengely nem érhető el, tartalék: {ex.Message}");
                    Vector3 m = Input.mousePosition;
                    mx = (m.x - _freeCamLastMouse.x) * 0.15f;
                    my = (m.y - _freeCamLastMouse.y) * 0.15f;
                    _freeCamLastMouse = m;
                }
                _freeCamYaw += mx;
                _freeCamPitch = Mathf.Clamp(_freeCamPitch - my, -89f, 89f);
            }
            t.rotation = Quaternion.Euler(_freeCamPitch, _freeCamYaw, 0f);

            // Mozgás: WASD, Q = le, E = fel, Shift = gyors
            Vector3 move = Vector3.zero;
            if (Input.GetKey(KeyCode.W)) move += t.forward;
            if (Input.GetKey(KeyCode.S)) move -= t.forward;
            if (Input.GetKey(KeyCode.D)) move += t.right;
            if (Input.GetKey(KeyCode.A)) move -= t.right;
            if (Input.GetKey(KeyCode.E)) move += Vector3.up;
            if (Input.GetKey(KeyCode.Q)) move -= Vector3.up;

            if (move.sqrMagnitude > 0.0001f)
            {
                float speed = _freeCamSpeed;
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) speed *= FreeCamFastMultiplier;
                t.position += move.normalized * speed * dt;
            }
        }

        // ---- Eltűnt Kacsák Visszahozása ----
        // Ha egy kacsa a pályán kívülre kerül (60 egységgel mélyebbre esik az első helyzeténél, 300 egységnél messzebb jut tőle,
        // vagy érvénytelen a pozíciója), visszakerül az első látott helyére, a sebessége nullázva.
        private static bool IsInvalid(Vector3 p)
        {
            return float.IsNaN(p.x) || float.IsNaN(p.y) || float.IsNaN(p.z)
                || float.IsInfinity(p.x) || float.IsInfinity(p.y) || float.IsInfinity(p.z);
        }

        private void RescueLostDucks()
        {
            int n = _cachedDucks.Count;
            if (n == 0) return;

            if (_rescueDespawnSq <= 0f) _rescueDespawnSq = 1000f * 1000f; // az első kacsánál kiolvasott érték felülírja (RESCUE-DIAG)
            float farSq = _rescueDespawnSq * 0.64f; // a játék despawn-távolságának 80%-a: még a despawn ELŐTT visszahozzuk

            var lostIdx = new List<int>();
            for (int i = 0; i < n; i++)
            {
                DuckData d = _cachedDucks[i];
                if (d.gameObject == null || d.transform == null) continue;
                if (IsInvalid(d.firstPos)) continue; // nincs hova visszatenni

                Vector3 p = d.transform.position;
                bool lost;
                if (IsInvalid(p)) lost = true;
                else
                {
                    // 1) a játék despawn-távolsága közelében (a tó nagy: a sima sodródás nem számít)
                    bool tooFar = (p - PoolCenter).sqrMagnitude > farSq;
                    // 2) mélyen a víz alatt / a világ alatt (a levegőben spawnolt kacsa lezuhanása a vízre nem számít)
                    float floorY = Mathf.Min(d.firstPos.y, LakeLevelGuess) - RescueDepth;
                    bool tooDeep = p.y < floorY;
                    lost = tooFar || tooDeep;
                }
                if (lost) lostIdx.Add(i);
            }
            if (lostIdx.Count == 0) return;

            // Védelem: ha a kacsák nagy része egyszerre "elveszett", a szabály nem illik a pályához - inkább nem nyúlunk hozzájuk
            if (n >= 5 && lostIdx.Count > n * RescueMassFraction)
            {
                if (!_rescueMassLogged)
                {
                    _rescueMassLogged = true;
                    LoggerInstance.Msg($"[RESCUE] {lostIdx.Count}/{n} kacsa egyszerre elveszettnek látszik - a visszahozás kihagyva (a szabály valószínűleg nem illik ehhez a pályához).");
                }
                return;
            }
            _rescueMassLogged = false;

            foreach (int i in lostIdx)
            {
                DuckData d = _cachedDucks[i];
                Vector3 p = d.transform.position;

                if (_lastRescueTime.TryGetValue(d.id, out float last) && Time.unscaledTime - last < RescueCooldown) continue;
                if (!IsInvalid(p) && d.manager != null && IsInOtherZone(d)) continue;

                _lastRescueTime[d.id] = Time.unscaledTime;
                d.transform.position = d.firstPos;
                if (d.rigidbody != null && !d.rigidbody.isKinematic)
                {
                    d.rigidbody.velocity = Vector3.zero;
                    d.rigidbody.angularVelocity = Vector3.zero;
                }
                _rescuedCount++;

                if (_rescueLogCount < 10)
                {
                    _rescueLogCount++;
                    LoggerInstance.Msg($"[RESCUE] {d.duckName} visszahozva az első helyére (előző pozíció: {p}).");
                }
            }
        }

        // ---- Lenyitható szakasz ----
        // A nyitott állapot a kirajzolás elején készült pillanatképből jön, a kattintás csak a KÖVETKEZŐ képkockára kapcsol.
        private bool Section(int id, string title)
        {
            bool open = _secSnapshot == id;
            if (SafeButton((open ? "[-] " : "[+] ") + title, _customBtnStyle)) _openSection = open ? 0 : id;
            return open;
        }

        // ---- Kacsa Klónozó ----
        private string SelectedDuckLabel()
        {
            try { return _selectedDuck != null ? _selectedDuck.name : T("none", "nincs"); }
            catch { return "?"; }
        }

        private void PickDuckUnderMouse()
        {
            try
            {
                if (_cachedMainCamera == null) UpdateCameraCache();
                if (_cachedMainCamera == null) return;

                DuckManager found = null;
                Ray ray = _cachedMainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Collider c = hit.collider;
                    if (c != null) found = c.GetComponentInParent<DuckManager>();
                }

                if (found == null)
                {
                    // tartalék: a kurzorhoz képernyőn legközelebbi kacsa 60 pixelen belül
                    float bestSq = 60f * 60f;
                    float mx = Input.mousePosition.x;
                    float my = Input.mousePosition.y;
                    for (int i = 0; i < _cachedDucks.Count; i++)
                    {
                        DuckData d = _cachedDucks[i];
                        if (d.gameObject == null || d.manager == null) continue;
                        Vector3 sp = _cachedMainCamera.WorldToScreenPoint(d.transform.position);
                        if (sp.z <= 0f) continue;
                        float dx = sp.x - mx;
                        float dy = sp.y - my;
                        float sq = dx * dx + dy * dy;
                        if (sq < bestSq) { bestSq = sq; found = d.manager; }
                    }
                }

                if (found != null)
                {
                    _selectedDuck = found;
                    _selectedDuckId = found.GetInstanceID();
                }
            }
            catch (System.Exception ex) { LogErrorOnce($"[CLONE] Kacsa kijelölése sikertelen: {ex.GetType().Name}: {ex.Message}"); }
        }

        // A klónozott kacsa a játék saját spawnolásával jön létre (Fusion hálózati objektum). A sima Object.Instantiate
        // másolat nincs regisztrálva a hálózatban, így a FixedUpdateNetwork-ben futó felhajtóerő nem hat rá, és lesüllyed.
        private HashSet<int> _cloneKnownIds = null;
        private Vector3 _clonePendingPos;
        private float _clonePendingUntil = 0f;

        private void CloneSelectedDuck()
        {
            try
            {
                if (_selectedDuck == null)
                {
                    LoggerInstance.Msg("[CLONE] Nincs kijelölt kacsa: kapcsold be a Kacsaválasztót és kattints egy kacsára.");
                    return;
                }

                string duckId = null;
                try { duckId = GetMemberValue(_selectedDuck, typeof(DuckManager), "duckID")?.ToString(); } catch { }
                GeneralManager gm = GeneralManager.I;

                if (gm != null && !string.IsNullOrEmpty(duckId))
                {
                    var known = new HashSet<int>();
                    foreach (var d in _cachedDucks) known.Add(d.id);
                    _cloneKnownIds = known;
                    _clonePendingPos = _selectedDuck.transform.position + new Vector3(0f, 1.5f, 0f);
                    _clonePendingUntil = Time.unscaledTime + 5f;
                    gm.DebugSpawnDuck(duckId);
                    _nextCacheUpdateTime = 0f;
                    LoggerInstance.Msg($"[CLONE] {duckId} spawnolva a játék saját spawnolásával.");
                    return;
                }

                LoggerInstance.Msg("[CLONE] A játék spawnolása nem elérhető (duckID/GeneralManager), sima másolat készül (süllyedhet).");
                GameObject src = _selectedDuck.gameObject;
                Vector3 pos = _selectedDuck.transform.position + new Vector3(0f, 1.5f, 0f);
                GameObject copy = Object.Instantiate<GameObject>(src, pos, _selectedDuck.transform.rotation);
                if (copy == null)
                {
                    LogErrorOnce("[CLONE] Az Instantiate nem adott vissza objektumot.");
                    return;
                }
                _nextCacheUpdateTime = 0f;
                LoggerInstance.Msg($"[CLONE] {_selectedDuck.name} klónozva (másolat).");
            }
            catch (System.Exception ex) { LogErrorOnce($"[CLONE] Klónozás sikertelen: {ex.GetType().Name}: {ex.Message}"); }
        }

        // Az újonnan spawnolt kacsát az eredeti fölé teszi (a játék a saját spawn-pontján hozza létre)
        private void ProcessPendingClone()
        {
            if (_cloneKnownIds == null) return;
            if (Time.unscaledTime > _clonePendingUntil) { _cloneKnownIds = null; return; }
            foreach (var d in _cachedDucks)
            {
                if (d.gameObject == null || _cloneKnownIds.Contains(d.id)) continue;
                d.transform.position = _clonePendingPos;
                if (d.rigidbody != null && !d.rigidbody.isKinematic)
                {
                    d.rigidbody.velocity = Vector3.zero;
                    d.rigidbody.angularVelocity = Vector3.zero;
                }
                _cloneKnownIds = null;
                return;
            }
            // még nem jelent meg: hamarosan újra keresünk (de nem képkockánként, a teljes keresés drága)
            if (_nextCacheUpdateTime > Time.unscaledTime + 0.25f) _nextCacheUpdateTime = Time.unscaledTime + 0.25f;
        }

        // ---- Gravitációs Fegyver ----
        // Jobb klikk: a kurzor alatti pontra a hozzá legközelebbi kacsa teleportál.
        private void GravityGunPull()
        {
            try
            {
                if (_cachedMainCamera == null) UpdateCameraCache();
                if (_cachedMainCamera == null || _cachedDucks.Count == 0) return;

                Ray ray = _cachedMainCamera.ScreenPointToRay(Input.mousePosition);
                Vector3 target;
                if (Physics.Raycast(ray, out RaycastHit hit)) target = hit.point + new Vector3(0f, 0.6f, 0f);
                else target = ray.GetPoint(8f);

                int best = -1;
                float bestSq = float.MaxValue;
                for (int i = 0; i < _cachedDucks.Count; i++)
                {
                    DuckData d = _cachedDucks[i];
                    if (d.gameObject == null || d.transform == null) continue;
                    float sq = (d.transform.position - target).sqrMagnitude;
                    if (sq < bestSq) { bestSq = sq; best = i; }
                }
                if (best < 0) return;

                DuckData duck = _cachedDucks[best];
                duck.transform.position = target;
                if (duck.rigidbody != null && !duck.rigidbody.isKinematic)
                {
                    duck.rigidbody.velocity = Vector3.zero;
                    duck.rigidbody.angularVelocity = Vector3.zero;
                }
                // az új hely lesz az "első helyzet", különben az Eltűnt Kacsák Visszahozása visszadobná
                duck.firstPos = target;
                _cachedDucks[best] = duck;
                _duckById[duck.id] = duck;
            }
            catch (System.Exception ex) { LogErrorOnce($"[GRAVGUN] Hiba: {ex.GetType().Name}: {ex.Message}"); }
        }

        // ---- Időjárás és Évszak (Enviro, reflexióval) ----
        // A játék Enviro rendszerének pontos API-ját nem ismerjük, ezért futásidőben keressük meg a típusokat és metódusokat.
        private static System.Type FindTypeByName(string name)
        {
            foreach (var asm in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                System.Type[] types;
                try { types = asm.GetTypes(); }
                catch (System.Reflection.ReflectionTypeLoadException e) { types = e.Types; }
                catch { continue; }
                if (types == null) continue;
                foreach (var t in types)
                    if (t != null && t.Name == name) return t;
            }
            return null;
        }

        private static object GetMemberValue(object obj, System.Type type, string name)
        {
            const System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic
                | System.Reflection.BindingFlags.Instance
                | System.Reflection.BindingFlags.Static;
            try
            {
                var p = type.GetProperty(name, flags);
                if (p != null) return p.GetValue(obj, null);
            }
            catch { }
            try
            {
                var f = type.GetField(name, flags);
                if (f != null) return f.GetValue(obj);
            }
            catch { }
            return null;
        }

        private void LogEnviroMethods(string label, object module)
        {
            if (module == null) return;
            var names = new List<string>();
            foreach (var m in module.GetType().GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if (m.Name.Contains("Change") || m.Name.Contains("Season") || m.Name.Contains("Weather"))
                    names.Add(m.Name + "(" + m.GetParameters().Length + ")");
            }
            LoggerInstance.Msg($"[WEATHER-DIAG] {label} modul ({module.GetType().Name}) metódusai: {string.Join(", ", names)}");
        }

        private bool EnsureEnviro()
        {
            if (_enviroWeatherModule != null || _enviroEnvModule != null) return true;
            if (Time.unscaledTime < _nextEnviroSearch) return false;
            _nextEnviroSearch = Time.unscaledTime + 3f;
            try
            {
                System.Type mt = FindTypeByName("EnviroManager");
                if (mt == null) { LogErrorOnce("[WEATHER] Az EnviroManager típus nem található."); return false; }

                object inst = GetMemberValue(null, mt, "instance");
                if (inst == null) { LogErrorOnce("[WEATHER] EnviroManager.instance == null (még nem töltött be?)"); return false; }

                _enviroWeatherModule = GetMemberValue(inst, mt, "Weather");
                _enviroEnvModule = GetMemberValue(inst, mt, "Environment");

                _weatherNames.Clear();
                _weatherObjs.Clear();
                var sos = Resources.FindObjectsOfTypeAll<ScriptableObject>();
                if (sos != null)
                {
                    foreach (var so in sos)
                    {
                        if (so == null) continue;
                        string tn = null;
                        try { tn = so.GetIl2CppType().FullName; } catch { }
                        if (tn != null && tn.EndsWith("EnviroWeatherType")) { _weatherNames.Add(so.name); _weatherObjs.Add(so); }
                    }
                }

                LoggerInstance.Msg($"[WEATHER-DIAG] Enviro megtalálva. Weather modul: {_enviroWeatherModule != null}, Environment modul: {_enviroEnvModule != null}. Időjárás-típusok: {string.Join(", ", _weatherNames)}");
                LogEnviroMethods("Weather", _enviroWeatherModule);
                LogEnviroMethods("Environment", _enviroEnvModule);
                return _enviroWeatherModule != null || _enviroEnvModule != null;
            }
            catch (System.Exception ex)
            {
                LogErrorOnce($"[WEATHER] Enviro keresése sikertelen: {ex.GetType().Name}: {ex.Message}");
                return false;
            }
        }

        // A megnevezett időjárás-típusok közül a kulcsszóhoz illőt választja (a "heavy" nélkülit előnyben részesíti).
        // A játékban csak ezek vannak: Snow, Clear Sky, Rain, Cloudy 1-3 - ezért a Köd és a Vihar tartalék típusra esik vissza.
        private string PickWeatherName(string key)
        {
            string[][] groups;
            switch (key)
            {
                case "clear": groups = new[] { new[] { "clear", "sunny" } }; break;
                case "rain": groups = new[] { new[] { "rain" } }; break;
                case "snow": groups = new[] { new[] { "snow" } }; break;
                case "fog": groups = new[] { new[] { "fog", "mist" }, new[] { "cloudy 3" }, new[] { "cloudy" } }; break;
                case "storm": groups = new[] { new[] { "storm", "thunder" }, new[] { "rain" } }; break;
                default: groups = new[] { new[] { key } }; break;
            }

            foreach (var words in groups)
            {
                string anyMatch = null;
                foreach (var n in _weatherNames)
                {
                    if (string.IsNullOrEmpty(n)) continue;
                    string low = n.ToLowerInvariant();
                    bool hit = false;
                    foreach (var w in words) if (low.Contains(w)) { hit = true; break; }
                    if (!hit) continue;
                    if (key == "rain" && low.Contains("storm")) continue;
                    if (!low.Contains("heavy")) return n;
                    if (anyMatch == null) anyMatch = n;
                }
                if (anyMatch != null) return anyMatch;
            }
            return null;
        }

        // ---- A játék saját időjárás-vezérlője (MeteoManager) ----
        // A játék MeteoManager-e időzítővel magától váltogatja az időjárást, és felülírja a mi váltásunkat.
        // Ezért az első váltáskor az időtartamot hatalmasra állítjuk, az időzítőt nullázzuk.
        private object _meteoMgr = null;
        private bool _meteoFrozenLogged = false;

        private static bool SetMemberValue(object obj, string name, object value)
        {
            if (obj == null) return false;
            const System.Reflection.BindingFlags flags = System.Reflection.BindingFlags.Public
                | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
            var type = obj.GetType();
            try
            {
                var p = type.GetProperty(name, flags);
                if (p != null && p.CanWrite)
                {
                    p.SetValue(obj, System.Convert.ChangeType(value, p.PropertyType), null);
                    return true;
                }
            }
            catch { }
            try
            {
                var f = type.GetField(name, flags);
                if (f != null)
                {
                    f.SetValue(obj, System.Convert.ChangeType(value, f.FieldType));
                    return true;
                }
            }
            catch { }
            return false;
        }

        private void FreezeMeteoManager()
        {
            try
            {
                if (_meteoMgr == null)
                {
                    System.Type mt = FindTypeByName("MeteoManager");
                    if (mt == null) { LogErrorOnce("[WEATHER] A MeteoManager típus nem található."); return; }
                    var all = Object.FindObjectsOfType<MonoBehaviour>();
                    if (all != null)
                    {
                        foreach (var mb in all)
                        {
                            if (mb == null) continue;
                            if (RealTypeName(mb).EndsWith("MeteoManager"))
                            {
                                _meteoMgr = System.Activator.CreateInstance(mt, new object[] { mb.Pointer });
                                break;
                            }
                        }
                    }
                    if (_meteoMgr == null) { LogErrorOnce("[WEATHER] MeteoManager példány nem található a jelenetben."); return; }
                }

                if (!_meteoFrozenLogged)
                {
                    _meteoFrozenLogged = true;
                    var t = _meteoMgr.GetType();
                    LoggerInstance.Msg($"[WEATHER-DIAG] MeteoManager: currentWeather={GetMemberValue(_meteoMgr, t, "currentWeather")}, WeatherDuration={GetMemberValue(_meteoMgr, t, "WeatherDuration")}, WeatherTimer={GetMemberValue(_meteoMgr, t, "WeatherTimer")}");
                }
                SetMemberValue(_meteoMgr, "WeatherDuration", 1000000f);
                SetMemberValue(_meteoMgr, "WeatherTimer", 0f);
            }
            catch (System.Exception ex)
            {
                _meteoMgr = null; // a példány elavult lehet (jelenetváltás), legközelebb újra keressük
                LogErrorOnce($"[WEATHER] MeteoManager lefagyasztása sikertelen: {ex.GetType().Name}: {ex.Message}");
            }
        }

        private void LogWeatherState(string label)
        {
            try
            {
                string target = "?";
                if (_enviroWeatherModule != null)
                {
                    object tw = GetMemberValue(_enviroWeatherModule, _enviroWeatherModule.GetType(), "targetWeatherType");
                    if (tw != null) target = GetMemberValue(tw, tw.GetType(), "name")?.ToString() ?? "?";
                }
                string season = "?", auto = "?";
                if (_enviroEnvModule != null)
                {
                    object st = GetMemberValue(_enviroEnvModule, _enviroEnvModule.GetType(), "Settings");
                    if (st != null)
                    {
                        season = GetMemberValue(st, st.GetType(), "season")?.ToString() ?? "?";
                        auto = GetMemberValue(st, st.GetType(), "changeSeason")?.ToString() ?? "?";
                    }
                }
                LoggerInstance.Msg($"[WEATHER] {label} -> cél időjárás: {target}, évszak: {season}, auto évszakváltás: {auto}");
            }
            catch (System.Exception ex) { LogErrorOnce($"[WEATHER] Állapot-napló hiba: {ex.Message}"); }
        }

        // Az Enviro 3 ChangeWeather metódusa nem stringet, hanem EnviroWeatherType objektumot (vagy int-et) vár,
        // ezért a ScriptableObject-ből a metódus paraméter-típusának megfelelő il2cpp burkolót készítünk.
        private bool ApplyWeatherType(string name, bool instant)
        {
            int idx = _weatherNames.IndexOf(name);
            if (idx < 0 || idx >= _weatherObjs.Count || _weatherObjs[idx] == null) return false;
            string wanted = instant ? "ChangeWeatherInstant" : "ChangeWeather";

            foreach (var m in _enviroWeatherModule.GetType().GetMethods(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if (m.Name != wanted) continue;
                var ps = m.GetParameters();
                if (ps.Length != 1) continue;
                var pt = ps[0].ParameterType;
                if (pt == typeof(string) || pt == typeof(int) || !pt.Name.EndsWith("EnviroWeatherType")) continue;

                object arg = System.Activator.CreateInstance(pt, new object[] { _weatherObjs[idx].Pointer });
                m.Invoke(_enviroWeatherModule, new object[] { arg });
                return true;
            }
            return false;
        }

        private void ResetEnviroCache()
        {
            _enviroWeatherModule = null;
            _enviroEnvModule = null;
            _meteoMgr = null;
            _meteoFrozenLogged = false;
            _nextEnviroSearch = 0f;
        }

        private void SaveOrigFog()
        {
            if (_origFogSaved) return;
            _origFog = RenderSettings.fog;
            _origFogMode = RenderSettings.fogMode;
            _origFogDensity = RenderSettings.fogDensity;
            _origFogColor = RenderSettings.fogColor;
            _origFogSaved = true;
        }

        private void RestoreOrigFog()
        {
            if (!_origFogSaved) return;
            RenderSettings.fog = _origFog;
            RenderSettings.fogMode = _origFogMode;
            RenderSettings.fogDensity = _origFogDensity;
            RenderSettings.fogColor = _origFogColor;
        }

        private void SetWeather(string key)
        {
            bool ok = false;
            try
            {
                if (EnsureEnviro() && _enviroWeatherModule != null)
                {
                    string name = PickWeatherName(key);
                    if (name == null)
                    {
                        _weatherStatus = T("No matching weather type found (see the log).", "Nincs megfelelő időjárás-típus (lásd a naplót).");
                    }
                    else if (ApplyWeatherType(name, true) || ApplyWeatherType(name, false))
                    {
                        ok = true;
                        FreezeMeteoManager();
                        _weatherStatus = T("Weather: ", "Időjárás: ") + name;
                        LogWeatherState($"SetWeather({key}) [{name}]");
                    }
                    else _weatherStatus = T("ChangeWeather(EnviroWeatherType) not found (see the log).", "A ChangeWeather(EnviroWeatherType) nem található (lásd a naplót).");
                }
            }
            catch (System.Exception ex)
            {
                _weatherStatus = T("Weather change failed: ", "Időjárás-váltás sikertelen: ") + (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                LogErrorOnce($"[WEATHER] SetWeather({key}) hiba: {ex.GetType().Name}: {ex.Message}");
                ResetEnviroCache(); // az elavult hivatkozások (jelenetváltás) újrakeresésre kerülnek
            }

            // Tartalék: a köd a Unity saját ködjével is megy (a tiszta ég az eredeti ködöt állítja vissza)
            if (key == "fog")
            {
                try
                {
                    SaveOrigFog();
                    RenderSettings.fog = true;
                    RenderSettings.fogMode = FogMode.Exponential;
                    RenderSettings.fogDensity = 0.03f;
                    RenderSettings.fogColor = new Color(0.7f, 0.75f, 0.8f);
                    if (!ok) _weatherStatus = T("Enviro not available, basic fog setting used.", "Az Enviro nem érhető el, az egyszerű köd-beállítás lett használva.");
                }
                catch (System.Exception ex) { LogErrorOnce($"[WEATHER] RenderSettings köd hiba: {ex.Message}"); }
            }
            else if (key == "clear")
            {
                try { RestoreOrigFog(); } catch (System.Exception ex) { LogErrorOnce($"[WEATHER] RenderSettings köd hiba: {ex.Message}"); }
                if (!ok && string.IsNullOrEmpty(_weatherStatus))
                    _weatherStatus = T("Enviro weather system not found (see the log).", "Az Enviro időjárás-rendszer nem található (lásd a naplót).");
            }
            else if (!ok && string.IsNullOrEmpty(_weatherStatus))
                _weatherStatus = T("Enviro weather system not found (see the log).", "Az Enviro időjárás-rendszer nem található (lásd a naplót).");
        }

        // Minden időjárási hatás törlése: azonnali tiszta ég + a módosított köd visszaállítása
        private void ClearAllWeather()
        {
            bool ok = false;
            _weatherStatus = "";
            try
            {
                if (EnsureEnviro() && _enviroWeatherModule != null)
                {
                    string name = PickWeatherName("clear");
                    if (name != null)
                    {
                        ok = ApplyWeatherType(name, true) || ApplyWeatherType(name, false);
                        if (ok)
                        {
                            FreezeMeteoManager();
                            _weatherStatus = T("All weather cleared: ", "Minden időjárás törölve: ") + name;
                            LogWeatherState("ClearAllWeather [" + name + "]");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                _weatherStatus = T("Clear weather failed: ", "Időjárás törlése sikertelen: ") + (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                LogErrorOnce($"[WEATHER] ClearAllWeather hiba: {ex.GetType().Name}: {ex.Message}");
                ResetEnviroCache();
            }

            try { RestoreOrigFog(); }
            catch (System.Exception ex) { LogErrorOnce($"[WEATHER] Köd visszaállítás hiba: {ex.Message}"); }

            if (!ok && string.IsNullOrEmpty(_weatherStatus))
                _weatherStatus = _origFogSaved
                    ? T("Fog reset (Enviro clear sky unavailable).", "Köd visszaállítva (az Enviro tiszta ég nem elérhető).")
                    : T("Enviro weather system not found (see the log).", "Az Enviro időjárás-rendszer nem található (lásd a naplót).");
        }

        // ---- Útmutató ----
        // {angol cím, magyar cím, angol leírás, magyar leírás}
        private static readonly string[][] GuideEntries = new string[][]
        {
            new[] { "Language", "Nyelv", "Switches the menu between English and Hungarian. The choice is remembered.", "Átvált angol és magyar között. A választást megjegyzi." },
            new[] { "Game speed", "Játék sebessége", "Slider for Time.timeScale, 0.1x to 10x.", "A játék sebessége (Time.timeScale), 0,1x-től 10x-ig." },
            new[] { "Rotate Sun", "Napszak Forgatása", "Rotates the sun by 45 degrees per click, which changes the time of day look.", "Kattintásonként 45 fokkal elforgatja a napot, így változik a napszak." },
            new[] { "Reset all duck changes", "Minden kacsa-módosítás visszaállítása", "Restores size, drag, gravity and visibility of every duck, and turns Ghost, Disco and the gravity/size/friction sliders back to default.", "Visszaállítja a kacsák méretét, súrlódását, gravitációját és láthatóságát, a Ghost, Disco és a csúszkák alapértékre kerülnek." },
            new[] { "DUCK TSUNAMI", "KACSA CUNAMI", "Gives every duck a strong upward impulse once.", "Egyszer erősen felfelé lök minden kacsát." },
            new[] { "Geyser Mode", "Gejzír Mód", "Ducks within 6 units of the ducks' center are pushed upward continuously.", "A kacsák súlypontja körül 6 egységen belül folyamatosan felfelé lökődnek." },
            new[] { "Gravity", "Gravitáció", "Gravity multiplier for ducks only, 0x (weightless) to 10x.", "Csak a kacsákra ható gravitáció, 0x (súlytalan) és 10x között." },
            new[] { "Water friction", "Víz súrlódása", "Sets the drag of all ducks. It only changes the game's value once you move the slider.", "Az összes kacsa közegellenállása. Csak akkor írja át a játék értékét, ha mozgatod a csúszkát." },
            new[] { "Ghost Mode", "Ghost Mód", "Hides every duck model, but they stay physical.", "Elrejti a kacsák modelljét, de a fizikájuk megmarad." },
            new[] { "Disco Flash", "Diszkó Villódzás", "Changes the duck colors randomly every 0.1 s. Turning it off restores the original colors.", "Tizedmásodpercenként véletlen színt ad a kacsáknak. Kikapcsoláskor visszaáll az eredeti szín." },
            new[] { "Duck Markers (ESP)", "Kacsák Megjelölése (ESP)", "Draws a numbered label over each duck, also through walls.", "Számozott címkét rajzol minden kacsa fölé, falon át is." },
            new[] { "Duck body size", "Kacsa Testméret", "Scales all ducks from 0.2x to 12x of their original size.", "Az eredeti méret 0,2-szereséről 12-szereséig méretezi a kacsákat." },
            new[] { "Duck Domino", "Kacsa Dominó", "Pushes the newest duck forward hard.", "Erősen meglöki a legutolsó (legújabb) kacsát." },
            new[] { "Global Quack", "Globális Hápogás", "Every duck quacks at once.", "Az összes kacsa egyszerre hápog." },
            new[] { "Social Distancing", "Közösségi Távolságtartás", "Ducks closer than 1.6 units push each other away.", "Az 1,6 egységnél közelebbi kacsák eltaszítják egymást." },
            new[] { "Duck Black Hole", "Kacsa Fekete Lyuk", "Pulls all ducks toward the first duck.", "Az összes kacsát az első kacsához szívja." },
            new[] { "Duck Picker", "Kacsaválasztó", "When on, left click a duck to select it. If the click misses, the duck nearest to the cursor (within 60 px) is chosen.", "Bekapcsolva a bal klikk kijelöli a kacsát. Ha mellé kattintasz, a kurzorhoz legközelebbi (60 pixelen belüli) kacsát választja." },
            new[] { "Clone selected duck", "Kijelölt kacsa klónozása", "Creates an identical duck 1.5 units above the selected one.", "Egy ugyanolyan kacsát hoz létre a kijelölt fölött 1,5 egységgel." },
            new[] { "Gravity Gun", "Gravitációs Fegyver", "When on, right click teleports the duck nearest to the cursor point to that point. Not active while flying with the free camera.", "Bekapcsolva a jobb klikk a kurzor alatti pontra teleportálja a hozzá legközelebbi kacsát. Szabad kamerás repülés közben nem működik." },
            new[] { "Vortex Mode", "Örvény (Vortex) Mód", "Spins the ducks around the pool center. The slider sets the speed.", "A medence közepe körül forgatja a kacsákat. A csúszka a sebességet állítja." },
            new[] { "Duck Cannon", "Kacsaágyú", "Each left click spawns a duck and shoots it toward the cursor.", "Minden bal klikk egy kacsát spawnol és a kurzor irányába lövi." },
            new[] { "Magnet (Mouse)", "Mágnes (Egér)", "Ducks are pulled toward the point under the cursor.", "A kacsák a kurzor alatti pont felé húzódnak." },
            new[] { "Camera Follow", "Kamera Követés", "The camera follows a duck. Next Duck switches the target. Turning it off restores the camera.", "A kamera egy kacsát követ. A Következő Kacsa váltja a célpontot. Kikapcsoláskor visszaáll a kamera." },
            new[] { "Free Camera", "Szabad Kamera", "Enable it, then Space starts and stops flying. WASD moves, Q/E down/up, Shift is fast, hold right mouse to look. Exiting restores the camera.", "Kapcsold be, utána a Space indítja és állítja le a repülést. WASD mozgás, Q/E le/fel, Shift gyors, jobb egérgomb nyomva = nézelődés. Kilépéskor visszaáll a kamera." },
            new[] { "Rescue Lost Ducks", "Eltűnt Kacsák Visszahozása", "Ducks that fall far below the water, get close to the game's despawn distance or get an invalid position are put back to their first position (once per 10 s per duck). Ducks in other zones are left alone, and nothing is moved if many ducks look lost at once.", "A vízszint alá mélyen lezuhant, a játék despawn-távolsága közelébe jutott vagy érvénytelen helyű kacsák visszakerülnek az első helyükre (kacsánként 10 mp-enként egyszer). A más területeken lévő kacsákhoz nem nyúl, és ha egyszerre sok kacsa tűnik elveszettnek, semmit sem mozgat." },
            new[] { "Weather buttons", "Időjárás gombok", "Clear sky, Rain, Snow and Fog change the weather through the game's Enviro system. Fog uses the closest weather type this game has (Cloudy 3). Without Enviro, only Fog and Clear sky work (basic fog).", "A Tiszta ég, Eső, Hó és Köd a játék Enviro rendszerén át váltja az időjárást. Enviro nélkül csak a Köd és a Tiszta ég működik (egyszerű köd)." },
            new[] { "Clear ALL weather", "Minden időjárás törlése", "Instantly switches to Clear sky and restores the original fog (undoes Fog/Rain/Snow).", "Azonnal tiszta égre vált, és visszaállítja az eredeti ködöt (visszavonja a Köd/Eső/Hó hatását)." },
            new[] { "Chaos Flood", "Káosz Özön", "Spawns a duck every 0.15 s until 50 ducks exist, then switches itself off.", "0,15 másodpercenként spawnol egy kacsát, amíg 50 kacsa nincs, utána magától kikapcsol." },
            new[] { "Collection Spawner", "Collection Spawner", "With it on, clicking a duck in the game's Collection menu spawns that duck.", "Bekapcsolva a játék Collection menüjében egy kacsára kattintva az a kacsa lespawnol." },
            new[] { "Formations", "Formációk", "Circle, Line, Spiral and Tower arrange all your ducks around the point the camera is looking at.", "A Kör, Sor, Spirál és Torony a kameráddal nézett pont köré rendezi az összes kacsádat." },
            new[] { "Optimization Mode", "Optimization Mode", "Disco updates only a quarter of the visible ducks per tick, physics forces are applied to a rotating slice of the ducks (2x above 80 ducks, 3x above 160, 4x above 240, with proportionally stronger forces), Social Distancing and Rescue run less often, the full duck scan runs less often with many ducks, ESP shows at most 80 labels, and Chaos Flood stops when FPS stays under 25 for 3 seconds. The setting is saved.", "A Disco tickenként csak a látható kacsák negyedét frissíti, a fizikai erők a kacsák egy körbeforgó szeletére hatnak (80 kacsa felett 2x, 160 felett 3x, 240 felett 4x, arányosan erősebb lökéssel), a Social Distancing és a Rescue ritkábban fut, sok kacsánál a teljes kacsa-keresés ritkábban fut, az ESP legfeljebb 80 címkét mutat, és a Káosz Özön leáll, ha az FPS 3 másodpercig 25 alatt van. A beállítás mentődik." },
            new[] { "Screenshot mode", "Képernyőkép mód", "Hides the mod menu, the ESP and all of the game's own UI (every Canvas) so you can take clean screenshots. F8 toggles it; the menu key or F8 brings everything back.", "Elrejti a mod menüjét, az ESP-t és a játék saját felületét (minden Canvas-t), hogy tiszta képernyőképet készíthess. Az F8 be/ki kapcsolja; a menü-billentyű vagy az F8 mindent visszahoz." },
            new[] { "Multiplayer protection", "Multiplayer védelem", "While hosting, other players' ducks are not touched by the mod. The Multiplayer section lists how many ducks each owner has.", "Hostolás közben a mod nem nyúl más játékosok kacsáihoz. A Multiplayer szekció megmutatja, kinek hány kacsája van." },
            new[] { "Respawn All Ducks", "Respawn All Ducks", "Puts every duck you control onto the game's spawn point (with a small spread). Click twice to confirm.", "Minden általad kezelhető kacsát a játék spawn-pontjára tesz (kis szórással). A megerősítéshez kétszer kell kattintani." },
            new[] { "Protect selected duck", "Kijelölt kacsa védelme", "Singleplayer only. A protected duck is invisible to every mod feature (its mod changes are removed) and the game's despawn distance for it is set huge. Use the Remove buttons to undo it.", "Csak egyjátékos módban. A védett kacsát a mod egyik funkciója sem látja (a modos módosítások lekerülnek róla), és a játék despawn-távolsága rá hatalmasra van állítva. A levétel gombokkal visszavonható." },
            new[] { "Menu key", "Menü-billentyű", "Click the Menu key button, then press the key you want to open and close the menu with. Esc cancels. The key is saved.", "Kattints a Menü-billentyű gombra, majd nyomd meg a billentyűt, amivel a menüt nyitni és zárni szeretnéd. Az Esc mégse. A billentyű mentődik." },
            new[] { "[MOD] tag (multiplayer)", "[MOD] jelzés (multiplayer)", "When you host a multiplayer game, \"[MOD] \" is put in front of your duck's name so other players can see the server is modded. It cannot be turned off while hosting; the name is restored when you leave.", "Multiplayer hostolásnál a kacsád neve elé \"[MOD] \" kerül, hogy a többi játékos lássa, hogy a szerver moddal fut. Hostolás közben nem kapcsolható ki; kilépéskor a név visszaáll." },
            new[] { "Quick Spawn", "Gyors Spawn", "Spawns one random duck.", "Egy véletlen kacsát spawnol." },
            new[] { "DELETE ALL DUCKS", "MINDEN KACSA TÖRLÉSE", "Deletes every duck. It needs two clicks within 3 seconds.", "Törli az összes kacsát. 3 másodpercen belül két kattintás kell hozzá." },
            new[] { "Force Save", "Kényszerített Mentés", "Saves the game into a dedicated slot. The first press picks a free slot and remembers it. It checks after 3 seconds that the slot exists.", "Egy külön slotba menti a játékot. Az első megnyomás szabad slotot választ és megjegyzi. 3 másodperc múlva ellenőrzi, hogy létrejött-e." },
            new[] { "Debug & Telemetry", "Hibakeresés & Telemetria", "Shows diagnostic info: scan count, faulty ducks, last error. Force Cache Rebuild appears when faulty ducks exist.", "Diagnosztikát mutat: frissítések száma, hibás kacsák, utolsó hiba. Hibás kacsák esetén megjelenik a Kényszerített Cache Újraépítés." },
            new[] { "F9 and moving the window", "F9 és az ablak mozgatása", "F9 hides or shows the menu. Drag the title bar to move the window. Section headers open and close their group.", "Az F9 elrejti vagy megjeleníti a menüt. A címsávnál fogva mozgatható. A szakaszcímek lenyitják és összecsukják a csoportjukat." }
        };

        private void DrawGuideWindow(int windowID)
        {
            const int perPage = 6;
            int total = GuideEntries.Length;
            int pages = (total + perPage - 1) / perPage;
            int page = _guidePage;
            if (page < 0 || page >= pages) page = 0;
            int start = page * perPage;

            if (_guideTextStyle == null)
            {
                _guideTextStyle = new GUIStyle(GUI.skin.label);
                _guideTextStyle.wordWrap = true;
                _guideTextStyle.richText = true;
            }

            SafeLabel(T("Page", "Oldal") + $" {page + 1}/{pages}", _headerStyle);

            // Mindig ugyanannyi vezérlő rajzolódik (az utolsó oldalon üres sorok), hogy az IMGUI Layout és eseménykezelő lefutása egyezzen
            for (int i = 0; i < perPage; i++)
            {
                int idx = start + i;
                if (idx < total)
                {
                    string[] e = GuideEntries[idx];
                    SafeLabel("<b><color=yellow>" + T(e[0], e[1]) + "</color></b>");
                    SafeLabel(T(e[2], e[3]), _guideTextStyle);
                }
                else
                {
                    SafeLabel(" ");
                    SafeLabel(" ");
                }
            }

            if (SafeButton(T("< Previous", "< Előző"), _customBtnStyle)) _guidePage = page > 0 ? page - 1 : pages - 1;
            if (SafeButton(T("Next >", "Következő >"), _customBtnStyle)) _guidePage = page < pages - 1 ? page + 1 : 0;

            DrawMenuCursor(); // az útmutatón is látszódjon a négyzet-kurzor
            try { GUI.DragWindow(new Rect(0, 0, 10000, 20)); }
            catch (System.Exception ex) { GuiFail("GUI.DragWindow(guide)", ex); }
        }

        private void ResetCamera()
        {
            if (_hasSavedCamera && _cachedMainCamera != null)
            {
                _cachedMainCamera.transform.position = _originalCameraPosition;
                _cachedMainCamera.transform.rotation = _originalCameraRotation;
            }
            _hasSavedCamera = false;
            _cameraFollowActive = false;
        }

        private void DeleteAllDucks()
        {
            for (int i = 0; i < _cachedDucks.Count; i++)
            {
                if (_cachedDucks[i].gameObject != null) Object.Destroy(_cachedDucks[i].gameObject);
            }
            _cachedDucks.Clear();
            _duckById.Clear();
            _discoStates.Clear();
            _pendingSpawnTimes.Clear();
            _nextCacheUpdateTime = Time.unscaledTime + 0.5f; // a Destroy késleltetett, ezért hamarosan újraszkennelünk
            if (_cameraFollowActive) ResetCamera();
            LoggerInstance.Msg("All ducks destroyed.");
        }

        // Az újonnan spawnolt kacsát lövi ki (megvárja, amíg a mod regisztrálja); ha nem jelenik meg, nem lő ki egy régit
        private System.Collections.IEnumerator FireNewDuckCoroutine(HashSet<int> known)
        {
            for (int frame = 0; frame < 40; frame++)
            {
                yield return null; // nem függ a Time.timeScale-től
                if (frame % 4 != 3) continue;
                UpdateDuckCache();
                if (_cachedMainCamera == null) UpdateCameraCache();
                for (int i = _cachedDucks.Count - 1; i >= 0; i--)
                {
                    DuckData d = _cachedDucks[i];
                    if (d.gameObject == null || known.Contains(d.id)) continue;
                    if (d.rigidbody != null && _cachedMainCamera != null)
                    {
                        Ray ray = _cachedMainCamera.ScreenPointToRay(Input.mousePosition);
                        d.rigidbody.AddForce(ray.direction.normalized * 45f, ForceMode.VelocityChange);
                    }
                    yield break;
                }
            }
        }
    }
}
