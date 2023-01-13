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
