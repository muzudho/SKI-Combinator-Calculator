# 解答

📖 [SKIコンビネータで遊んでみよう](https://qiita.com/Anko_9801/items/74af196cce123550001a)  

👇 Swap:  

```
  S(K(SI))K x y
= yx
```

👇 B combinator:  

```
B x y z = S (K S) K x y z
        = x ( y z )
```

👇 Ω combinator:

```
Ω x = SII x
    = x x
```

👇 W combinator:

```
W x y = S S(S K) x y
      = x y y
```

👇 Y combinator:

```
Y f = S(K(SII))(S(S(KS)K)(K(SII))) f
    = S(K(SII))(S(S(KS)K)(K(SII))) f
```

# SKIコンビネーター計算機のためのテストケース

👇 すべての変数

```
  abcdefghijklmnopqrstuvwxyz
= abcdefghijklmnopqrstuvwxyz
```

👇 I コンビネーター

```
  I x
= x
```

👇 K コンビネーター

```
  K x y
= x
```

👇 丸括弧外し

```
  a(b(c(d(e)f)g)h)i
= abcdefghi
```
