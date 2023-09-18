## Tecnologie utilizzate

- **IDE**: Visual Studio Community 2022
- **ORM**: Entity Framework 6 per le migrazioni verso il database
- **Web Framework**: ASP.NET Core per la creazione della Web API
- **Containerization**: Docker un'immagine locale di un database MSSQL
- **Database Tool**: SQL Server Management Studio per eseguire query di interrogazione sul database
- **Version Control**: GitHub per il versioning del codice
- **Object Mapping**: Mapster per un mapping automatico tra DTO e db Entities

## Design Pattern utilizzati

- Repository pattern
- Dependency Injection
- DTO(Data Transfer Object)

## Docker e MSSQL

Impostato l'intero progetto partendo da Docker, scaricata ed installata di un'immagine di MSSQL. Controllato il funzionamento e il corretto accesso a questo database tramite SQL Server Management Studio.

## Struttura del Progetto

La soluzione è composta da due distinti progetti: 
1. **DB_Test_Fox (Data Access Layer)**:
   - Definizione delle tre Entità principali: `Accommodation`, `RoomType`, e `PriceList`
   - Relazioni tra le entità: 
     - `Accomodation` --> più `RoomType` e una `PriceList` per ogni RoomType.
     - `RoomType` --> tipi diversi (Single, Double, Deluxe e Suite) con una lista di prezzi per hotel.
     - `PriceList` --> costi per tipologia di stanza basati sulla data.

   - Creazione del `BookingContext` per i DbSet delle tre entità e per recuperare la connection string
   - Implementazione del Repository pattern, con una interfaccia ed un repository per ogni Entity
   - Classi di configurazione e startup

    ## Migrazioni tramite EF
    
    Uso di comandi:
    - `Add-Migration` per creare una nuova migrazione
    - `Update-Database` per applicare la migrazione al database

2. **Api_Test_Fox (Web API Layer)**:
   - Generato da un template di ASP.NET Core Web API
   - Modifica dei controller e iniezione delle dipendenze tramite Dependency Injection
   - Registrazione dei repositories come servizi Scoped(per mantenerli per tutta la durata della request Http) e aggiunta della connection string.
   - Uso di DTO per operazioni CRUD: 
     - `Detail` per le operazioni di GET
     - `Create` per le operazioni di PUT e POST

