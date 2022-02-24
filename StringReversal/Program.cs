string value = "The simple engineer";
// var result = StringReversal(value, value.Length - 1);
var result = StringReversalV2(value);
System.Console.WriteLine(result);

static string StringReversal(string value, int offset)
{
  if (offset <= 0) return value[offset].ToString();
  return value[offset].ToString() + StringReversal(value, --offset);
}

static string StringReversalV2(string value)
{
  if (string.IsNullOrWhiteSpace(value)) return string.Empty;
  return StringReversalV2(value.Substring(1)) + value[0].ToString();
}