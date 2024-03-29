### 1. У чому відмінність асинхронного і багатопоточного програмування?
>    Відмінність між асинхронним та багатопоточним програмуванням полягає у тому, що багатопоточне програмування використовує кілька потоків для виконання завдань паралельно, тоді як асинхронне програмування використовує один потік для виконання завдань у неблокуючому режимі.

### 2. Які типи даних може повертати async – await?
>   async - await може повертати будь-який тип даних, який може бути повернутий зі звичайного методу.

### 3. Які модифікатори для параметрів не можна використовувати в асинхронних методах?
>   У асинхронних методах не можна використовувати **ref** та **out** модифікатори для параметрів.

### 4. Які властивості надає клас Thread? Опишіть їх.
>
>*  CurrentThread: повертає посилання на потік, який виконується в даний момент.
>*  IsAlive: повертає значення, яке вказує, чи є потік живим.
>*  Name: встановлює або повертає ім'я потоку.
>*  Priority: встановлює або повертає пріоритет потоку.

### 5. Які методи надає клас Thread? Опишіть їх.
>
>*  Start(): починає виконання потоку.
>*  Join(): чекає, поки потік завершиться.
>*  Sleep(): призупиняє виконання потоку на певний час.
>*  Interrupt(): перериває виконання потоку.
>*  Abort(): припиняє виконання потоку.
###
