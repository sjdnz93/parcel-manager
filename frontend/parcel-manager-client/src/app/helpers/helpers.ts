export function extractMessages(obj: any) {
  let messages: string[] = [];

  for (let key in obj) {
    if (obj.hasOwnProperty(key)) {
      let messagesArray = obj[key];
      messages = messages.concat(messagesArray);
    }
  }

  return messages.join('\n');
}
