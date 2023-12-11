
const DateFormats = {
  'dd.mm.yyyy': 'dd.MM.yyyy',
  'mm.dd.yyyy': 'MM.dd.yyyy',
  'dd-MM-yyyy': 'dd-MM-yyyy',
  'mm-dd-yyyy': 'MM-dd-yyyy',
  'dd/mm/yyyy': 'dd/MM/yyyy',
  'mm/dd/yyyy': 'MM/dd/yyyy',
}
const getOrDefault = (value) => {
  if (value) {
      return value;
  }
  return DateFormats["dd.mm.yyyy"];
}
export default {
  ...DateFormats,
  toSelect: Object.keys(DateFormats).map(key => ({key, value: DateFormats[key]})),
  mask: (value) => getOrDefault(value).replace(/[a-zA-Z]/gi, '_'),
  default: DateFormats["dd.mm.yyyy"],
  getOrDefault
}