import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
/*class Square extends React.Component {
  /*constructor(props) {
    super(props);
    
    properties: là trạng thái do parent component quản lý, truyền xuống cho 1 component
    Đối với 1 component thi properties là read only, chỉ xem thôi chứ không sửa được
    Muốn sửa, muốn quản lý thì phải thông qua state 
    State này chỉ sửa, đọc được bên trong component thôi, còn bên ngoài thì không giao tiếp
    
    this.state = {
      value: null,
    };
    Update 01: Xoá constructor
}
render() {
  return (
    <button
      className="square" 
      onClick = {() => this.props.onClick()}
    >
      {this.props.value}
    </button>
      /*
      <button className="square" onClick = { function() { console.log('click'); }}> => Nhân sự kiện click, thông báo số lần click ra màn hình console
      {this.props.value} => show the value - xuất các số ra
      Update 01: 
      - Thay {this.props.value} bằng {this.state.value} 
      - Thay onClick={...} bằng  onClick = {() => this.setState({value: 'X'})} 
      - Nên đặt className và onClick ở 2 dòng khác nhau để dễ đọc
      => để hiển thị chữ X vào ô trên màn hình khi click

      Update 02:
      - Thay đổi {this.state.value} thành {this.props.value}
      - Thay đổi this.setState{value: 'X'} thành this.props.onClick()
      - Xoá constructor ra khỏi class Square

      => Khi ô vuông (Square) được click, hàm onClick được viết trong Board sẽ được gọi. Bởi vì:
      1. onClick được xây ở DOM <button> sẽ gọi cho React để cài đặt sự kiện nghe
      2. Khi button được click, React sẽ gọi sự kiện onClick dược định nghĩa trong phương thức render của class Square
      3. Sự kiện xử lý (event handler) gọi this.props.onCick(). Mà onClick prop của Square được đặt tả trong Board.
      4. Kể từ Board passed onClick={() => this.handleClick(i)} đến Square thì Square sẽ gọi handleClick() của Board mỗi khi được click
      5. Ta sẽ chưa định nghĩa handleClick() method nên code lúc này sẽ crash. Nếu nhấn vào square lsc này sẽ bị báo lỗi
      
   
  );
  }
}

Update: Thay thế class Square bằng function Square(props) bên dưới và thay this.props thành props
*/

function Square(props) {
  return(
    <button className="square" onClick={props.onClick}>
      {props.value}
    </button>
  );
}

class Board extends React.Component {
    /*
  Thêm 1 hàm tạo vào Board và đặt trạng thái ban đầu của Board để chứa 1 mảng 9 nulls tương ứng với 9 hình vuông
   
  constructor (props) {
    super(props);
    this.state = {
      squares: Array(9).fill(null),
      xIsNext: true, //XIsNext là biến boolean để xác định biến nào sẽ tiếp theo và trạng thái game sẽ được lưu
    };
  }

  Update: Xoá construtor ở Board để đen xuuoosng history

  handleClick(i) {
    const squares = this.state.squares.slice();
    if (calculateWinner(squares) || squares[i]) { //Kiểm tra nếu có người thắng hoặc nếu full rồi thì không click được nữa
      return;
    }
    squares[i] = this.state.xIsNext ? 'X':'O';
    this.setState({
      squares:squares,
      xIsNext: !this.state.xIsNext, //X và O xoay vòng
    });

  }
  
  Sau khi thêm handleClick thì ta có thể fill square như lúc đầu.
  Tuy nhiên, lúc này state sẽ được lưu trữ trong Board component thay vì trong từng Square components riêng lẻ.
  Khi trạng thái của Board thay đổi, Square compopent sẽ re-render tự động.
  Giữ state ở tất cả các ô vuông trong Board component sẽ cho phép xác định người chiến thắng trong tương lai.

  Kể từ Square component không còn chưa state, thì Square component nhận giá trị từ Board component
  => Square components lúc này là component bị kiểm soát (controlled components)
  - gọi .slice() để tạp 1 bản sao của mảng squares để chỉnh sửa thay vì chỉnh sửa trên mảng đang tồn tại

  Update: Move handleClick đến Game component
  */

  renderSquare(i) {
      return (
      <Square 
        value = {this.props.squares[i]}
        onClick={() => this.props.onClick(i)}
      />
      ); 
  }
  /*passed a prop
  Update 01: 
  - Chuyển thành this.state.square[i]: Không truyền theo value nữa mà sẽ truyền theo vị trí của mảng
  - thêm vào onClick={() => this.handleClick(i)}
  Update 02:
  - Cài đặt hàm handleClick
  Update 03:
  - Thay this.state.square[i] bằng this.props.suqare[i]
  - Thay this.hanldleClick(i) với this.props.onClick(i)
  */


  render() {
  /*const winner = calculateWinner(this.state.squares);
  let status;
  if (winner) {
    status = 'Winner: ' + winner;
  } else {
    status = 'Next player: ' + (this.state.xIsNext ? 'X' : 'O'); //Hiển thị X hay O ở câu Next player */
  
    const squares = [];
    let MaxCol = 0;
    let row, col;
    for (row = 0; row < 5; row ++) {
      const boardRow = [];
       for(col = 0; col < 5; col++) {
        boardRow.push(<span key={MaxCol}> {this.renderSquare(MaxCol)}</span> )
        MaxCol++;
       }
       squares.push(<div key={row} className ="board-row">{boardRow}</div>)
    }
  
    return (
    <div>
      {squares}
    </div>
  );
  }
}

class Game extends React.Component {

  constructor (props) {
    super(props);
    this.state = {
      history: [{
        squares: Array(9).fill(null),

        // Khởi tạo biến col và row để lưu vị trí
        col: null,
        row: null
      }],
      stepNumber: 0,
      xIsNext: true, //XIsNext là biến boolean để xác định biến nào sẽ tiếp theo và trạng thái game sẽ được lưu
      SortNext: "asc",
      
    };
  }


  
  handleClick(i) {
    const history = this.state.history.slice(0, this.state.stepNumber +1);
    const current = history[history.length - 1];
    const squares = current.squares.slice();
    // Khai báo biến coordinate để tìm toạ độ (x,y) của 1 ô thứ i
    const coordinate = findCoordinate(i);
    if (calculateWinner(squares) || squares[i]) { //Kiểm tra nếu có người thắng hoặc nếu full rồi thì không click được nữa
      return;
    }
    squares[i] = this.state.xIsNext ? 'X' : 'O';
    this.setState({
      history: history.concat([{
        squares : squares,
        row: coordinate[0],
        col: coordinate[1],
        
      }]),
      stepNumber: history.length,
      xIsNext: !this.state.xIsNext, //X và O xoay vòng
    });
  }
  chooseSort(){
    const sort = (this.state.SortNext === "desc") ? "asc" : "desc";
    this.setState({
        SortNext: sort,
    })
  }
  jumpTo(step) {
    this.setState({
      stepNumber: step,
      xIsNext: (step % 2) === 0,
    });
  }
render() {
  const history = this.state.history;
  const current = history[this.state.stepNumber];
  const winner = calculateWinner (current.squares, this.state.stepNumber);
 
  const moves = history.map((step, move) => {

    //In đâm nut bước đi gần đây
    let currentSelected = (move === this.state.stepNumber ? 'currentSelected' : '')
    const desc = move ?
    ' Go to move #' + move +" at (" + step.col + "," + step.row + ")":
    'Go to game start';
    return (
      <li key={move}>
      <button 
      className={currentSelected}
      onClick={() => this.jumpTo(move)}>{desc}</button>
      </li>
    );
  });
  const reversedMoves = moves.slice().reverse()
  let status;
  if (winner) {
    status ='Winner: ' + winner[0];
  }
  else {
    status = 'Next player: '+ (this.state.xIsNext ? 'X' : 'O');
  }
  return (
    <div className="game">
      <div className="game-board">
        <Board
           squares = {current.squares}
           onClick={(i) => this.handleClick(i)} 
        />
      </div>
      <div className="game-info">

        <div>{status}</div>

        

        <button onClick={() => this.chooseSort()}> The next sort is: {this.state.SortNext}</button>
        <br></br>
        <div className="step-buttons">{((this.state.SortNext === "desc") ? moves : reversedMoves)}</div>
      </div>
    </div>
  );
}
}

// ========================================

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<Game />);
  function findCoordinate (i) {
    let row;
    let col;
    switch(i) {
      case 0:
      case 1:
      case 2: 
      case 3:
      case 4:
          row = 1; 
          break;
      case 5:
      case 6:
      case 7:
      case 8:
      case 9:
          row = 2; 
          break;
      case 10:
      case 11:
      case 12:
      case 13:
      case 14:
          row = 3;
          break;
      case 15:
      case 16:
      case 17:
      case 18:
      case 19:
          row = 4;
          break;
      case 20:
      case 21:
      case 22:
      case 23:
      case 24:
          row = 5;
          break;
      default:
          break;
    }

    switch(i) {
      case 0:
      case 5:
      case 10:
      case 15:
      case 20: 
          col = 1; 
          break;
      case 1:
      case 6:
      case 11:
      case 16:
      case 21:
          col = 2; 
          break;
      case 2:
      case 7:
      case 12:
      case 17:
      case 22:
          col = 3;
          break;
      case 3:
      case 8:
      case 13:
      case 18:
      case 23:
          col = 4;
          break;
      case 4:
      case 9:
      case 14:
      case 19:
      case 24:
          col = 5;
          break;
      default:
          break;
    }
    return [row,col];
  }

  function calculateWinner(squares, step) {
    const lines = [
      [0, 1, 2, 3, 4],
      [5, 6, 7, 8, 9],
      [10, 11, 12, 13, 14],
      [15, 16, 17, 18, 19],
      [20, 21, 22, 23, 24],
      [0, 5, 10, 15, 20],
      [1, 6, 11, 16, 21],
      [2, 7, 12, 17, 22],
      [3, 8, 13, 18, 23],
      [4, 9, 14, 19, 24],
      [0, 6, 12, 18, 24],
      [4, 8, 12, 16, 20],
    ];
    for (let i = 0; i < lines.length; i++) {
      const [a, b, c, d, e] = lines[i];
      if (squares[a] 
        && squares[a] === squares[b]
        && squares[a] === squares[c]
        && squares[a] === squares[d] 
        && squares[a] === squares[e]) {
        return squares[a];
      }
    }
    if (step === 26) {
      return "IT'S A TIE! NO ONE WINS";
    }
    return null;
  }
  // 