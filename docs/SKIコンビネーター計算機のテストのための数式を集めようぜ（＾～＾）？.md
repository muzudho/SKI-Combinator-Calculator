# è§£ç­

ð [SKIã³ã³ããã¼ã¿ã§éãã§ã¿ãã](https://qiita.com/Anko_9801/items/74af196cce123550001a)  

ð Swap:  

```
  S(K(SI))K x y
= yx
```

ð B combinator:  

```
B x y z = S (K S) K x y z
        = x ( y z )
```

ð Î© combinator:

```
Î© x = SII x
    = x x
```

ð W combinator:

```
W x y = S S(S K) x y
      = x y y
```

ð Y combinator:

```
Y f = S(K(SII))(S(S(KS)K)(K(SII))) f
    = S(K(SII))(S(S(KS)K)(K(SII))) f
```

# SKIã³ã³ããã¼ã¿ã¼è¨ç®æ©ã®ããã®ãã¹ãã±ã¼ã¹

ð ãã¹ã¦ã®å¤æ°

```
  abcdefghijklmnopqrstuvwxyz
= abcdefghijklmnopqrstuvwxyz
```

ð I ã³ã³ããã¼ã¿ã¼

```
  I x
= x
```

ð K ã³ã³ããã¼ã¿ã¼

```
  K x y
= x
```

ð ä¸¸æ¬å¼§å¤ã

```
  a(b(c(d(e)f)g)h)i
= abcdefghi
```
