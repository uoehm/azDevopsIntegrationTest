# Cake Template - dotnet

Template für .net 3.1+ (nicht Framework) Anwendungen ohne Asciidoc Dokumentation.

## Branches

Main: Ist fertig und kann verwendet werden

Develop: Ist im Allgemeinen Funktionsfähig, kann aber noch Fehler enthalten.

## Orderstruktur

- `root`: Solution, Azure Pipelines, Versionsinformationen, Nuget Konfiguration und Cake Startskript sowie diese Readme
- `build`: Cake Pipeline mit ihren Targets, Abläufen und Aufgaben
- `src`: Die einzelnen Projekte der Solution, welche die finale Anwendung abbilden
- `tests`: Die Testprojekte

## Setup

- Repo Inhalt als Zip herunterladen und an geeigneter Stelle entpacken
- `build.ps1` über Powershell ausführen um Funktionalität zu prüfen
- Eigene Solution und (Test)Projekte analog den vorhandenen `Demo` Dateien in die Ordnerstruktur einfügen.
  - Die `Demo` Dateien können dabei gelöscht werden.
  - Bei einem bereits bestehenden Projekt können folgende Bestandteile in das bestehende Projekt übernommen werden:
    - `build`
    - `azure-pipelines-*.*`
    - `build.ps1`
    - Bei der Übernahme von `.gitignore` und `.editorconfig` müssen diese mit evtl. bereits vorhandenen Dateien zusammengeführt werden.
- `build/Build/Context.cs` mit einem geeigneten Editor öffnen und folgende Werte anpassen:
  - `General.Name`: Der Name, der z.B: in Artefakten verwendet werden soll. Kann abweichend des tatsächelichen Anwendungsnamen sein.
  - `App.BuildConfig`: Die Buildkonfiguration. Standardmäßig `Release`
  - `App.MainProject`: Das zu bauende Projekt (.csproj Datei).
  - `Tests.TestProjectName`: Der Name des Testprojekts.
  - `Tests.TestProject`: Die Projektdatei (.csproj) des Testprojekts.
    - Es können weitere Testprojekte mit Namen und Projektdatei definiert werden, welche anschließend im `RunTestsAndPublishResults.cs` Task eingebunden werden müssen.
- Die Versionsnummer der Anwendung wird aus der Assembly Version des Hauptprojekts abgeleitet.

## Targets

|Name|Shell Parameter|
|----|---------------|
|Default||

## Abläufe

|Task|Default|
|-|-|
|Format Check|x|
|Nuget Restore|x|
|allg. Versionsnummer|x|
|App Build|x|
|App Tests|x|
|Testergebnisse veröffentlichen|x (nur remote)|
|App Veröffentlichen|x|
|Zip App|x|
|Upload zu Pipeline|x (nur remote)|
|Upload zu queo Transfer|Nicht enthalten. Kann aber aus Framework Templates bezogen werden.|
