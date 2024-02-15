from socket import AF_INET, socket, SOCK_STREAM
from threading import Thread

def ReadRequest(Client):
	request = ""
	Client.settimeout(1)
	try:
		request = Client.recv(1024).decode()
		while (request):
			request = request + Client.recv(1024).decode()
	except socket.timeout: # fail after 1 second of no activity
		if not request:
			print("Didn't receive data! [Timeout]")
	finally:
		return request


def SendHomepage(Client):
	f = open("index.html", "rb")
	L = f.read()
	header ="""HTTP/1.1 200 OK
Content-Length: %d

"""%len(L)
	header += L.decode()
	Client.send(bytes(header, 'utf-8'))

def SendDownloadpage(Client):
	f = open ("file.html", "rb")
	L = f.read()
	header ="""HTTP/1.1 200 OK
Content-Length: %d

"""%len(L)
	header += L.decode()
	Client.send(bytes(header, 'utf-8'))

def SendInfo(Client):
	f = open ("info.html", "rb")
	L = f.read()
	header ="""HTTP/1.1 200 OK
Content-Length: %d

"""%len(L)
	header += L.decode()
	Client.send(bytes(header, 'utf-8'))

def Send404(Client):
	f = open ("404.html", "rb")
	L = f.read()
	header ="""HTTP/1.1 404 Not Found
Content-Length: %d

"""%len(L) 
	header += L.decode()
	Client.send(bytes(header, 'utf-8'))

def MovetoInfo(Client):
	header = """HTTP/1.1 301 Moved Permanently
Location: info.html

"""
	Client.send(bytes(header,'utf-8'))

def Moveto404(Client):
	header = """HTTP/1.1 301 Moved Permanently
Location: 404.html

"""
	Client.send(bytes(header,'utf-8'))

def PostRequest(Client, Request):
	if "username=admin&password=admin" in Request:
		MovetoInfo(Client)
	else:
		Moveto404(Client)

def SendDownloadFile(Client,filename):
	f=open(filename,"rb")
	header="""HTTP/1.1 200 OK
Transfer-Encoding: chunked

"""
	body = "".encode()
	data = f.read(CHUNK_SIZE)
	while(data):
		body += ("{:x}\r\n".format(len(data))).encode('utf-8')
		body += data
		body += "\r\n".encode()
		data = f.read(CHUNK_SIZE)
	body += "0\r\n\r\n".encode('utf-8')
	header = header.encode('utf-8') + body
	Client.send(header)
	f.close()
	print("Completed!")

def GetFileType(Client, Request):
	kind = ["picture.jpg","video.mp4","text.txt","music.mp3"]
	for x in kind:
		if x in Request:
			print(x, "downloading...")
			x = "download/" + x
			SendDownloadFile(Client,x)
			return

def TakeRequest(Client):
	while True:
		Request = ReadRequest(Client)
		if not Request:
			Client.close()
			break
		print("--> Got a request")
		if "GET / HTTP/1.1" in Request or "GET /index" in Request:		#Enter localhost:[port] or localhost:[port]/index
			SendHomepage(Client)
		elif "GET /file.html" in Request:		#Click on button linked to download.html
			SendDownloadpage(Client)
		elif "GET /info.html" in Request:
			SendInfo(Client)
		elif "POST" in Request:						#POST request - check username & password
			PostRequest(Client, Request)
		elif "GET /download/" in Request:			#Click download file
			GetFileType(Client, Request)
		elif "GET /404.html" in Request:
			Send404(Client)

def WaitingConnection():
	while True:
		Client, Address = SERVER.accept()
		print("Client", Address ,"connected!")
		Thread(target=TakeRequest, args=(Client,)).start()

HOST = ''
PORT = 7000
ADDR = (HOST, PORT)
CHUNK_SIZE = 65536

SERVER = socket(AF_INET, SOCK_STREAM)
SERVER.bind(ADDR)

if __name__ == "__main__":
	try:
		SERVER.listen(5)
		print("Waiting for Client...")
		
		ACCEPT_THREAD = Thread(target=WaitingConnection)
		ACCEPT_THREAD.start()
		ACCEPT_THREAD.join()
	except:
		print("Error occured!")
	finally:
		SERVER.close()
