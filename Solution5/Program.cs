using Solution5;

var string1 = " odagirbO";
var string2 = " tegraT";
var string3 = "!sametsiS";

var stringConcat = StringReverse.Reverse(string1);
stringConcat += StringReverse.Reverse(string2);
stringConcat += StringReverse.Reverse(string3);

Console.Write(stringConcat);