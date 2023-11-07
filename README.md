Użycie programu decode.exe:

Program należy wywołać z wiersza poleceń podając jako argumenty kolejne liczby odebrane z multimetru
w formacie szestnastkowym. Nie ma konieczności podawania dwóch otatnich wartości (0D 0A).
Przykład:
	decode 00 02 06 05 00 0C 00 01 04
W rezultanie program poda wynik:
	0,562 uF

00 02 08 00 02 02 01 01 02  20,82 mA DC - OK

00 08 06 09 01 03 02 00 02  196,8 mA AC - OK

00 04 05 06 02 02 00 01 02  2,654 mA DC - OK

00 00 04 00 00 09 00 00 02  0,4 A AC  - OK

00 05 05 04 00 00 02 01 04  4,55 V DC - OK

01 08 06 04 00 04 05 01 04  0,468 Ohm - OK

00 02 05 01 00 06 01 01 02  0,152V (dioda) - OK

00 02 06 05 00 0C 00 01 04  0,562 uF - OK
