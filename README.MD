# ALD semestrální práce

Radek Mocek, Jiří Růta

## Aplikace

Při spuštění se vygeneruje úvodní obrázek o velikosti 15×15. Uživatel může v input boxech změnit velikost mřížky a tlačítkem vygenerovat obrázek nový. Lze vybírat šířku a výšku v rozsahu 2 až 50.

## Algoritmus

Pracujeme s 2D polem stringů. Každý string je 4 znaky dlouhý a skládá se z nul a jedniček. Znaky ve stringu reprezentují jednotlivé světové strany v pořadí `NESW` (začíná se horní stranou a pak se jede podle hodinových ručiček). Jednička pak znamená, že na tuto stranu vede trubka, nula znamená opak.

Souřadnice první položené dlaždice je vybrána náhodně, pro každou položenou dlaždici pak:

1. Vygenerujeme náhodný string
2. Zkontrolujeme již obsazené sousedy a upravíme podle nich náš string (pokud soused vlevo má `x1xx`, my musíme mít `xxx1`)
3. Na všechny neobsazené sousedy položíme dlaždici a opakujeme tyto kroky

Na políčku se může objevit celkem 16 různých typů dlaždic (`0000` – `1111`). Pro všechny tyto případy máme připravený obrázek, tudíž nemůže nastat situace, kdy by algoritmus neměl k dispozici vhodnou dlaždici.
