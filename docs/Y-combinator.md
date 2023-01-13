Y := S(K(SII))(S(S(KS)K)(K(SII)))
Y f = 
    = 
    = S(KS)K f (K(SII)f) (S(S(KS)K)(K(SII)) f)
    = K S f (K f) (K(SII)f) (S(S(KS)K)(K(SII)) f)
    = S (K f) (K(SII)f) (S(S(KS)K)(K(SII)) f)
    = K f (S(S(KS)K)(K(SII)) f) (K(SII)f (S(S(KS)K)(K(SII)) f))
    = f (K(SII) f (S(S(KS)K)(K(SII)) f))
    = f (S (K(SII)) (S(S(KS)K)(K(SII))) f)
    = f (Y f)
    
----

S(K(SII))(S(S(KS)K)(K(SII))) f
    formatting S(K(SII))(S(S(KS)K)(K(SII)))f
    ok

    S
      1 K(SII)
      2 S(S(KS)K)(K(SII))
      3 f
    ok
    # コンビネーターの評価時に、大外両側の丸括弧は外しておく必要がある
    
    # 正   K  (SII)  f  (  S(S(KS)K)(K(SII))  f  )
    # 現   K  (SII)  f  (  S(S(KS)K)(K(SII))  f  )
    ok


    K
      1 SII
      2 f
      _ (S(S(KS)K)(K(SII))f)
    ok


    # 正 SII (S(S(KS)K)(K(SII)) f)
    # 現 SII (S(S(KS)K)(K(SII)) f)
    ok


    S
      1 I
      2 I
      3 S(S(KS)K)(K(SII))f
    ok
    
    # 正 I で始まるので省略している
    # 現 IS(S(KS)K)(K(SII))f(IS(S(KS)K)(K(SII))f)

    I
      1 S
      _ (S(KS)K)(K(SII))f(IS(S(KS)K)(K(SII))f)

    # 正 S (S(KS)K) (K(SII)) f ( S(S(KS)K)(K(SII))  f)
    # 現 S (S(KS)K) (K(SII)) f (IS(S(KS)K)(K(SII))  f)
                                ^
                                I が混入？ 正しい？ どっちにしろ後で消えるか
    # 丸括弧の中は積極的にパースしないといけない？
    # つまり `(Ix)` は積極的に I を消す？
    # つまり、丸括弧の中の計算可能は、積極的に解消する？ そのときは内側優先か？
    # つまり、解消は左端だけで起こるわけではない？
    # つまり、最深部への フォーカスのようなものがある？
    # では、毎回 ツリー構造 を作る必要がある？

    S
      1 S(KS)K
      2 K(SII)
      3 f
      _ (IS(S(KS)K)(K(SII))f)

S(KS)Kf(K(SII)f)(IS(S(KS)K)(K(SII))f)

    S
      1 KS
      2 K
      3 f
      _ (K(SII)f)(IS(S(KS)K)(K(SII))f)

KSf(Kf)(K(SII)f)(IS(S(KS)K)(K(SII))f)

    K
      1 S
      2 f
      _ (Kf)(K(SII)f)(IS(S(KS)K)(K(SII))f)

S(Kf)(K(SII)f)(IS(S(KS)K)(K(SII))f)

    S
      1 Kf
      2 K(SII)f
      3 IS(S(KS)K)(K(SII))f
      _ 

KfIS(S(KS)K)(K(SII))f(K(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 I
      _ S(S(KS)K)(K(SII))f(K(SII)fIS(S(KS)K)(K(SII))f)

fS(S(KS)K)(K(SII))f(K(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 S(KS)K
      2 K(SII)
      3 f
      _ (K(SII)fIS(S(KS)K)(K(SII))f)

fS(KS)Kf(K(SII)f)(K(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 KS
      2 K
      3 f
      _ (K(SII)f)(K(SII)fIS(S(KS)K)(K(SII))f)

fKSf(Kf)(K(SII)f)(K(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 S
      2 f
      _ (Kf)(K(SII)f)(K(SII)fIS(S(KS)K)(K(SII))f)

fS(Kf)(K(SII)f)(K(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 Kf
      2 K(SII)f
      3 K(SII)fIS(S(KS)K)(K(SII))f
      _ 

fKfK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 K
      _ (SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ff(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped ffSIIfIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 f
      _ IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffIf(If)IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ (If)IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fff(If)IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped fffIfIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 S
      _ (S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffS(S(KS)K)(K(SII))f(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 S(KS)K
      2 K(SII)
      3 f
      _ (K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffS(KS)Kf(K(SII)f)(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 KS
      2 K
      3 f
      _ (K(SII)f)(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffKSf(Kf)(K(SII)f)(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 S
      2 f
      _ (Kf)(K(SII)f)(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffS(Kf)(K(SII)f)(K(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 Kf
      2 K(SII)f
      3 K(SII)fK(SII)fIS(S(KS)K)(K(SII))f
      _ 

ffffKfK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 K
      _ (SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffff(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped fffffSIIfK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 f
      _ K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffIf(If)K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ (If)K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffff(If)K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped ffffffIfK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 SII
      2 f
      _ IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffSIIIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 I
      _ S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffII(II)S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 I
      _ (II)S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffI(II)S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 II
      _ S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffIIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 I
      _ S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 S
      _ (S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 S(KS)K
      2 K(SII)
      3 f
      _ (K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffS(KS)Kf(K(SII)f)(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 KS
      2 K
      3 f
      _ (K(SII)f)(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffKSf(Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 S
      2 f
      _ (Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffS(Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 Kf
      2 K(SII)f
      3 K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f
      _ 

fffffffKfK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 K
      _ (SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffff(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped ffffffffSIIfK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 f
      _ K(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffIf(If)K(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ (If)K(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffff(If)K(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped fffffffffIfK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ K(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 SII
      2 f
      _ K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffSIIK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 K
      _ (SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffIK(IK)(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 K
      _ (IK)(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffK(IK)(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 IK
      2 SII
      _ fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffIKfIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 K
      _ fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffKfIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 I
      _ S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 S(KS)K
      2 K(SII)
      3 f
      _ (K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffS(KS)Kf(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 KS
      2 K
      3 f
      _ (K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffKSf(Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 S
      2 f
      _ (Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffS(Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 Kf
      2 K(SII)f
      3 K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f
      _ 

fffffffffffKfK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 K
      _ (SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffff(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped ffffffffffffSIIfK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 f
      _ K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffIf(If)K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ (If)K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffff(If)K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped fffffffffffffIfK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 SII
      2 f
      _ K(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffSIIK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 K
      _ (SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffIK(IK)(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 K
      _ (IK)(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffK(IK)(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 IK
      2 SII
      _ fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffIKfK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 K
      _ fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffKfK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 K
      _ (SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffff(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped fffffffffffffffSIIfIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 f
      _ IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffIf(If)IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ (If)IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffff(If)IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped ffffffffffffffffIfIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 S
      _ (S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 S(KS)K
      2 K(SII)
      3 f
      _ (K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffS(KS)Kf(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 KS
      2 K
      3 f
      _ (K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffKSf(Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 S
      2 f
      _ (Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffS(Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 Kf
      2 K(SII)f
      3 K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f
      _ 

fffffffffffffffffKfK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 K
      _ (SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffff(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped ffffffffffffffffffSIIfK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 f
      _ K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffIf(If)K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ (If)K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffff(If)K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped fffffffffffffffffffIfK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 SII
      2 f
      _ K(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffSIIK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 K
      _ (SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffIK(IK)(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 K
      _ (IK)(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffK(IK)(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 IK
      2 SII
      _ fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffIKfK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 K
      _ fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffKfK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 K
      _ (SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffff(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped fffffffffffffffffffffSIIfK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 f
      _ K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffIf(If)K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ (If)K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffff(If)K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped ffffffffffffffffffffffIfK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ K(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 SII
      2 f
      _ IS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffSIIIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 I
      _ S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffII(II)S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 I
      _ (II)S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffI(II)S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 II
      _ S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffIIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 I
      _ S(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 S
      _ (S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 S(KS)K
      2 K(SII)
      3 f
      _ (K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffS(KS)Kf(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 KS
      2 K
      3 f
      _ (K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffKSf(Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 S
      2 f
      _ (Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffS(Kf)(K(SII)f)(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 Kf
      2 K(SII)f
      3 K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f
      _ 

fffffffffffffffffffffffKfK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 f
      2 K
      _ (SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffffff(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped ffffffffffffffffffffffffSIIfK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 f
      _ K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffffffIf(If)K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ (If)K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

fffffffffffffffffffffffff(If)K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)
    stripped fffffffffffffffffffffffffIfK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 f
      _ K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffffffffK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 SII
      2 f
      _ K(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffffffffSIIK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    S
      1 I
      2 I
      3 K
      _ (SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffffffffIK(IK)(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 K
      _ (IK)(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffffffffK(IK)(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    K
      1 IK
      2 SII
      _ fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffffffffIKfK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

    I
      1 K
      _ fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

ffffffffffffffffffffffffffKfK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f(K(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fK(SII)fIS(S(KS)K)(K(SII))f)

Very tired...
