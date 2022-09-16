module Smtp =
    open System
    open System.Net.Mail

    type SmtpMessage =
        { From : MailAddress
          Subject : string
          Body : string
          Recipients : string list
          Attachments : Attachment list }

    let sendMessage (client : SmtpClient) (smtpMessage : SmtpMessage) =
        let msg = new MailMessage()
        msg.From <- smtpMessage.From
        msg.Subject <- smtpMessage.Subject
        msg.Body <- smtpMessage.Body
        msg.IsBodyHtml <- true

        for r in smtpMessage.Recipients do
            msg.To.Add(MailAddress(r))

        for attachment in smtpMessage.Attachments do
            msg.Attachments.Add(attachment)

        client.Send(msg)