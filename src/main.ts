import { Server } from "colyseus"
const port = parseInt(process.env.PORT, 10) || 4488

const gameServer = new Server()
gameServer.listen(port)
    .then(_ => {
        console.log(`[GameServer] Listening on Port: ${port}`)
    })
    .catch(err => {
        console.log(`[GameServer] start fail: ${err}`)
    })