
export const dateAsUTCDate = (date: Date) => {
  if (!date) {
      return null;
  }
  const dayjs = require('dayjs')
  const utc = require('dayjs/plugin/utc')
  dayjs.extend(utc)
  return dayjs.utc(date);
}