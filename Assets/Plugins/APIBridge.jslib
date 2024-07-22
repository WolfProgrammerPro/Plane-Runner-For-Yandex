mergeInto(LibraryManager.library, {

  AuthI: function() {
    Auth();
  },

  GetDataI: function() {
    GetData();
  },
  
  SetDataI : function(data){
    SetData(UTF8ToString(data));
  },

  ShowFullscrenAdvI: function () {
    ShowFullscrenAdv();
  },

  ShowRewardAdvI: function() {
    ShowRewardAdv();
  },
  
  GetLeaderBoardI: function(){
    GetLeaderBoard();
  },
  
  SetLeaderBoardI: function(score, name){
    //SetLeaderBoard(UTF8ToString(score));
    console.log("mylib" + score + " : " + name);
    SetLeaderBoard(score, UTF8ToString(name));
  },

  GetDeviceI: function () {
    GetDevice();
  },            

  GetLanguageI: function () {
    GetLanguage();
  },


});