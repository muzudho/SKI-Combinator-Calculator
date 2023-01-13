Y := S(K(SII))(S(S(KS)K)(K(SII)))
Y f = 
    = K (SII) f (S(S(KS)K)(K(SII) f)
    = SII (S(S(KS)K)(K(SII)) f)
    = S (S(KS)K) (K(SII)) f (S(S(KS)K)(K(SII)) f)
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
      1 (K(SII))
      2 (S(S(KS)K)(K(SII)))
      3 f
    ok
    
    # 正   K(SII)  f (  S(S(KS)K) (K(SII)    f)
    # 現  (K(SII)) f ( (S(S(KS)K) (K(SII) )) f)
    # コンビネーターの評価時に、左端の丸括弧は外しておく必要があるか？
    # 試   K(SII)  f (  S(S(KS)K) (K(SII) )  f)

(K(SII))f((S(S(KS)K)(K(SII)))f)
    stripped K(SII)f((S(S(KS)K)(K(SII)))f)

    K
      1 (SII)
      2 f
      _ ((S(S(KS)K)(K(SII)))f)

(SII)((S(S(KS)K)(K(SII)))f)
    stripped SII((S(S(KS)K)(K(SII)))f)

    S
      1 I
      2 I
      3 ((S(S(KS)K)(K(SII)))f)
      _ 

I((S(S(KS)K)(K(SII)))f)(I((S(S(KS)K)(K(SII)))f))

    I
      1 ((S(S(KS)K)(K(SII)))f)
      _ (I((S(S(KS)K)(K(SII)))f))

((S(S(KS)K)(K(SII)))f)(I((S(S(KS)K)(K(SII)))f))
    stripped (S(S(KS)K)(K(SII)))f(I((S(S(KS)K)(K(SII)))f))
    stripped S(S(KS)K)(K(SII))f(I((S(S(KS)K)(K(SII)))f))

    S
      1 (S(KS)K)
      2 (K(SII))
      3 f
      _ (I((S(S(KS)K)(K(SII)))f))

(S(KS)K)f((K(SII))f)(I((S(S(KS)K)(K(SII)))f))
    stripped S(KS)Kf((K(SII))f)(I((S(S(KS)K)(K(SII)))f))

    S
      1 (KS)
      2 K
      3 f
      _ ((K(SII))f)(I((S(S(KS)K)(K(SII)))f))

(KS)f(Kf)((K(SII))f)(I((S(S(KS)K)(K(SII)))f))
    stripped KSf(Kf)((K(SII))f)(I((S(S(KS)K)(K(SII)))f))

    K
      1 S
      2 f
      _ (Kf)((K(SII))f)(I((S(S(KS)K)(K(SII)))f))

S(Kf)((K(SII))f)(I((S(S(KS)K)(K(SII)))f))

    S
      1 (Kf)
      2 ((K(SII))f)
      3 (I((S(S(KS)K)(K(SII)))f))
      _ 

(Kf)(I((S(S(KS)K)(K(SII)))f))(((K(SII))f)(I((S(S(KS)K)(K(SII)))f)))
    stripped Kf(I((S(S(KS)K)(K(SII)))f))(((K(SII))f)(I((S(S(KS)K)(K(SII)))f)))

    K
      1 f
      2 (I((S(S(KS)K)(K(SII)))f))
      _ (((K(SII))f)(I((S(S(KS)K)(K(SII)))f)))

f(((K(SII))f)(I((S(S(KS)K)(K(SII)))f)))
    stripped f((K(SII))f(I((S(S(KS)K)(K(SII)))f)))
    stripped f(K(SII)f(I((S(S(KS)K)(K(SII)))f)))

    K
      1 (SII)
      2 f
      _ (I((S(S(KS)K)(K(SII)))f)))

f((SII)(I((S(S(KS)K)(K(SII)))f)))
    stripped f(SII(I((S(S(KS)K)(K(SII)))f)))

    S
      1 I
      2 I
      3 (I((S(S(KS)K)(K(SII)))f))
      _ )

f(I(I((S(S(KS)K)(K(SII)))f))(I(I((S(S(KS)K)(K(SII)))f))))

    I
      1 (I((S(S(KS)K)(K(SII)))f))
      _ (I(I((S(S(KS)K)(K(SII)))f))))

f((I((S(S(KS)K)(K(SII)))f))(I(I((S(S(KS)K)(K(SII)))f))))
    stripped f(I((S(S(KS)K)(K(SII)))f)(I(I((S(S(KS)K)(K(SII)))f))))

    I
      1 ((S(S(KS)K)(K(SII)))f)
      _ (I(I((S(S(KS)K)(K(SII)))f))))

f(((S(S(KS)K)(K(SII)))f)(I(I((S(S(KS)K)(K(SII)))f))))
    stripped f((S(S(KS)K)(K(SII)))f(I(I((S(S(KS)K)(K(SII)))f))))
    stripped f(S(S(KS)K)(K(SII))f(I(I((S(S(KS)K)(K(SII)))f))))

    S
      1 (S(KS)K)
      2 (K(SII))
      3 f
      _ (I(I((S(S(KS)K)(K(SII)))f))))

f((S(KS)K)f((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f))))
    stripped f(S(KS)Kf((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f))))

    S
      1 (KS)
      2 K
      3 f
      _ ((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f))))

f((KS)f(Kf)((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f))))
    stripped f(KSf(Kf)((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f))))

    K
      1 S
      2 f
      _ (Kf)((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f))))

f(S(Kf)((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f))))

    S
      1 (Kf)
      2 ((K(SII))f)
      3 (I(I((S(S(KS)K)(K(SII)))f)))
      _ )

f((Kf)(I(I((S(S(KS)K)(K(SII)))f)))(((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f)))))
    stripped f(Kf(I(I((S(S(KS)K)(K(SII)))f)))(((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f)))))

    K
      1 f
      2 (I(I((S(S(KS)K)(K(SII)))f)))
      _ (((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f)))))

f(f(((K(SII))f)(I(I((S(S(KS)K)(K(SII)))f)))))
    stripped f(f((K(SII))f(I(I((S(S(KS)K)(K(SII)))f)))))
    stripped f(f(K(SII)f(I(I((S(S(KS)K)(K(SII)))f)))))

    K
      1 (SII)
      2 f
      _ (I(I((S(S(KS)K)(K(SII)))f)))))

f(f((SII)(I(I((S(S(KS)K)(K(SII)))f)))))
    stripped f(f(SII(I(I((S(S(KS)K)(K(SII)))f)))))

    S
      1 I
      2 I
      3 (I(I((S(S(KS)K)(K(SII)))f)))
      _ ))

f(f(I(I(I((S(S(KS)K)(K(SII)))f)))(I(I(I((S(S(KS)K)(K(SII)))f))))))

    I
      1 (I(I((S(S(KS)K)(K(SII)))f)))
      _ (I(I(I((S(S(KS)K)(K(SII)))f))))))

f(f((I(I((S(S(KS)K)(K(SII)))f)))(I(I(I((S(S(KS)K)(K(SII)))f))))))
    stripped f(f(I(I((S(S(KS)K)(K(SII)))f))(I(I(I((S(S(KS)K)(K(SII)))f))))))

    I
      1 (I((S(S(KS)K)(K(SII)))f))
      _ (I(I(I((S(S(KS)K)(K(SII)))f))))))

f(f((I((S(S(KS)K)(K(SII)))f))(I(I(I((S(S(KS)K)(K(SII)))f))))))
    stripped f(f(I((S(S(KS)K)(K(SII)))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))

    I
      1 ((S(S(KS)K)(K(SII)))f)
      _ (I(I(I((S(S(KS)K)(K(SII)))f))))))

f(f(((S(S(KS)K)(K(SII)))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))
    stripped f(f((S(S(KS)K)(K(SII)))f(I(I(I((S(S(KS)K)(K(SII)))f))))))
    stripped f(f(S(S(KS)K)(K(SII))f(I(I(I((S(S(KS)K)(K(SII)))f))))))

    S
      1 (S(KS)K)
      2 (K(SII))
      3 f
      _ (I(I(I((S(S(KS)K)(K(SII)))f))))))

f(f((S(KS)K)f((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))
    stripped f(f(S(KS)Kf((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))

    S
      1 (KS)
      2 K
      3 f
      _ ((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))

f(f((KS)f(Kf)((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))
    stripped f(f(KSf(Kf)((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))

    K
      1 S
      2 f
      _ (Kf)((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))

f(f(S(Kf)((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f))))))

    S
      1 (Kf)
      2 ((K(SII))f)
      3 (I(I(I((S(S(KS)K)(K(SII)))f))))
      _ ))

f(f((Kf)(I(I(I((S(S(KS)K)(K(SII)))f))))(((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f)))))))
    stripped f(f(Kf(I(I(I((S(S(KS)K)(K(SII)))f))))(((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f)))))))

    K
      1 f
      2 (I(I(I((S(S(KS)K)(K(SII)))f))))
      _ (((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f)))))))

f(f(f(((K(SII))f)(I(I(I((S(S(KS)K)(K(SII)))f)))))))
    stripped f(f(f((K(SII))f(I(I(I((S(S(KS)K)(K(SII)))f)))))))
    stripped f(f(f(K(SII)f(I(I(I((S(S(KS)K)(K(SII)))f)))))))

    K
      1 (SII)
      2 f
      _ (I(I(I((S(S(KS)K)(K(SII)))f)))))))

f(f(f((SII)(I(I(I((S(S(KS)K)(K(SII)))f)))))))
    stripped f(f(f(SII(I(I(I((S(S(KS)K)(K(SII)))f)))))))

    S
      1 I
      2 I
      3 (I(I(I((S(S(KS)K)(K(SII)))f))))
      _ )))

f(f(f(I(I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

    I
      1 (I(I(I((S(S(KS)K)(K(SII)))f))))
      _ (I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

f(f(f((I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
    stripped f(f(f(I(I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

    I
      1 (I(I((S(S(KS)K)(K(SII)))f)))
      _ (I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

f(f(f((I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
    stripped f(f(f(I(I((S(S(KS)K)(K(SII)))f))(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

    I
      1 (I((S(S(KS)K)(K(SII)))f))
      _ (I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

f(f(f((I((S(S(KS)K)(K(SII)))f))(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
    stripped f(f(f(I((S(S(KS)K)(K(SII)))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

    I
      1 ((S(S(KS)K)(K(SII)))f)
      _ (I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

f(f(f(((S(S(KS)K)(K(SII)))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
    stripped f(f(f((S(S(KS)K)(K(SII)))f(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
    stripped f(f(f(S(S(KS)K)(K(SII))f(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

    S
      1 (S(KS)K)
      2 (K(SII))
      3 f
      _ (I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

f(f(f((S(KS)K)f((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
    stripped f(f(f(S(KS)Kf((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

    S
      1 (KS)
      2 K
      3 f
      _ ((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

f(f(f((KS)f(Kf)((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
    stripped f(f(f(KSf(Kf)((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

    K
      1 S
      2 f
      _ (Kf)((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

f(f(f(S(Kf)((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))

    S
      1 (Kf)
      2 ((K(SII))f)
      3 (I(I(I(I((S(S(KS)K)(K(SII)))f)))))
      _ )))

f(f(f((Kf)(I(I(I(I((S(S(KS)K)(K(SII)))f)))))(((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))
    stripped f(f(f(Kf(I(I(I(I((S(S(KS)K)(K(SII)))f)))))(((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))

    K
      1 f
      2 (I(I(I(I((S(S(KS)K)(K(SII)))f)))))
      _ (((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))

f(f(f(f(((K(SII))f)(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))
    stripped f(f(f(f((K(SII))f(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))
    stripped f(f(f(f(K(SII)f(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))

    K
      1 (SII)
      2 f
      _ (I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))

f(f(f(f((SII)(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))
    stripped f(f(f(f(SII(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))

    S
      1 I
      2 I
      3 (I(I(I(I((S(S(KS)K)(K(SII)))f)))))
      _ ))))

f(f(f(f(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    I
      1 (I(I(I(I((S(S(KS)K)(K(SII)))f)))))
      _ (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

f(f(f(f((I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))
    stripped f(f(f(f(I(I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    I
      1 (I(I(I((S(S(KS)K)(K(SII)))f))))
      _ (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

f(f(f(f((I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))
    stripped f(f(f(f(I(I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    I
      1 (I(I((S(S(KS)K)(K(SII)))f)))
      _ (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

f(f(f(f((I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))
    stripped f(f(f(f(I(I((S(S(KS)K)(K(SII)))f))(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    I
      1 (I((S(S(KS)K)(K(SII)))f))
      _ (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

f(f(f(f((I((S(S(KS)K)(K(SII)))f))(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))
    stripped f(f(f(f(I((S(S(KS)K)(K(SII)))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    I
      1 ((S(S(KS)K)(K(SII)))f)
      _ (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

f(f(f(f(((S(S(KS)K)(K(SII)))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))
    stripped f(f(f(f((S(S(KS)K)(K(SII)))f(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))
    stripped f(f(f(f(S(S(KS)K)(K(SII))f(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    S
      1 (S(KS)K)
      2 (K(SII))
      3 f
      _ (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

f(f(f(f((S(KS)K)f((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))
    stripped f(f(f(f(S(KS)Kf((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    S
      1 (KS)
      2 K
      3 f
      _ ((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

f(f(f(f((KS)f(Kf)((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))
    stripped f(f(f(f(KSf(Kf)((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    K
      1 S
      2 f
      _ (Kf)((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

f(f(f(f(S(Kf)((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))

    S
      1 (Kf)
      2 ((K(SII))f)
      3 (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))
      _ ))))

f(f(f(f((Kf)(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))
    stripped f(f(f(f(Kf(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))

    K
      1 f
      2 (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))
      _ (((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))

f(f(f(f(f(((K(SII))f)(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))
    stripped f(f(f(f(f((K(SII))f(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))
    stripped f(f(f(f(f(K(SII)f(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))

    K
      1 (SII)
      2 f
      _ (I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))

f(f(f(f(f((SII)(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))
    stripped f(f(f(f(f(SII(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))

    S
      1 I
      2 I
      3 (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))
      _ )))))

f(f(f(f(f(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    I
      1 (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))
      _ (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f((I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    I
      1 (I(I(I(I((S(S(KS)K)(K(SII)))f)))))
      _ (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f((I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f(I(I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    I
      1 (I(I(I((S(S(KS)K)(K(SII)))f))))
      _ (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f((I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f(I(I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    I
      1 (I(I((S(S(KS)K)(K(SII)))f)))
      _ (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f((I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f(I(I((S(S(KS)K)(K(SII)))f))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    I
      1 (I((S(S(KS)K)(K(SII)))f))
      _ (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f((I((S(S(KS)K)(K(SII)))f))(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f(I((S(S(KS)K)(K(SII)))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    I
      1 ((S(S(KS)K)(K(SII)))f)
      _ (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f(((S(S(KS)K)(K(SII)))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f((S(S(KS)K)(K(SII)))f(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f(S(S(KS)K)(K(SII))f(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    S
      1 (S(KS)K)
      2 (K(SII))
      3 f
      _ (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f((S(KS)K)f((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f(S(KS)Kf((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    S
      1 (KS)
      2 K
      3 f
      _ ((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f((KS)f(Kf)((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))
    stripped f(f(f(f(f(KSf(Kf)((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    K
      1 S
      2 f
      _ (Kf)((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

f(f(f(f(f(S(Kf)((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))

    S
      1 (Kf)
      2 ((K(SII))f)
      3 (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))
      _ )))))

f(f(f(f(f((Kf)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))(((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))
    stripped f(f(f(f(f(Kf(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))(((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))

    K
      1 f
      2 (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))
      _ (((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))

f(f(f(f(f(f(((K(SII))f)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))
    stripped f(f(f(f(f(f((K(SII))f(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))
    stripped f(f(f(f(f(f(K(SII)f(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))

    K
      1 (SII)
      2 f
      _ (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))

f(f(f(f(f(f((SII)(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))
    stripped f(f(f(f(f(f(SII(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))

    S
      1 I
      2 I
      3 (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))
      _ ))))))

f(f(f(f(f(f(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    I
      1 (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f((I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    I
      1 (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f((I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    I
      1 (I(I(I(I((S(S(KS)K)(K(SII)))f)))))
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f((I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(I(I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    I
      1 (I(I(I((S(S(KS)K)(K(SII)))f))))
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f((I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(I(I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    I
      1 (I(I((S(S(KS)K)(K(SII)))f)))
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f((I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(I(I((S(S(KS)K)(K(SII)))f))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    I
      1 (I((S(S(KS)K)(K(SII)))f))
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f((I((S(S(KS)K)(K(SII)))f))(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(I((S(S(KS)K)(K(SII)))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    I
      1 ((S(S(KS)K)(K(SII)))f)
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f(((S(S(KS)K)(K(SII)))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f((S(S(KS)K)(K(SII)))f(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(S(S(KS)K)(K(SII))f(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    S
      1 (S(KS)K)
      2 (K(SII))
      3 f
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f((S(KS)K)f((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(S(KS)Kf((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    S
      1 (KS)
      2 K
      3 f
      _ ((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f((KS)f(Kf)((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))
    stripped f(f(f(f(f(f(KSf(Kf)((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    K
      1 S
      2 f
      _ (Kf)((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

f(f(f(f(f(f(S(Kf)((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))

    S
      1 (Kf)
      2 ((K(SII))f)
      3 (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
      _ ))))))

f(f(f(f(f(f((Kf)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))(((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))
    stripped f(f(f(f(f(f(Kf(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))(((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))

    K
      1 f
      2 (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
      _ (((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))

f(f(f(f(f(f(f(((K(SII))f)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))
    stripped f(f(f(f(f(f(f((K(SII))f(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))
    stripped f(f(f(f(f(f(f(K(SII)f(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))

    K
      1 (SII)
      2 f
      _ (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))

f(f(f(f(f(f(f((SII)(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))
    stripped f(f(f(f(f(f(f(SII(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))

    S
      1 I
      2 I
      3 (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
      _ )))))))

f(f(f(f(f(f(f(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    I
      1 (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    I
      1 (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    I
      1 (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    I
      1 (I(I(I(I((S(S(KS)K)(K(SII)))f)))))
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(I(I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    I
      1 (I(I(I((S(S(KS)K)(K(SII)))f))))
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((I(I(I((S(S(KS)K)(K(SII)))f))))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(I(I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    I
      1 (I(I((S(S(KS)K)(K(SII)))f)))
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((I(I((S(S(KS)K)(K(SII)))f)))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(I(I((S(S(KS)K)(K(SII)))f))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    I
      1 (I((S(S(KS)K)(K(SII)))f))
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((I((S(S(KS)K)(K(SII)))f))(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(I((S(S(KS)K)(K(SII)))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    I
      1 ((S(S(KS)K)(K(SII)))f)
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f(((S(S(KS)K)(K(SII)))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f((S(S(KS)K)(K(SII)))f(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(S(S(KS)K)(K(SII))f(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    S
      1 (S(KS)K)
      2 (K(SII))
      3 f
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((S(KS)K)f((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(S(KS)Kf((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    S
      1 (KS)
      2 K
      3 f
      _ ((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f((KS)f(Kf)((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))
    stripped f(f(f(f(f(f(f(KSf(Kf)((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    K
      1 S
      2 f
      _ (Kf)((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

f(f(f(f(f(f(f(S(Kf)((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))

    S
      1 (Kf)
      2 ((K(SII))f)
      3 (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))
      _ )))))))

f(f(f(f(f(f(f((Kf)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))(((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))
    stripped f(f(f(f(f(f(f(Kf(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))(((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))

    K
      1 f
      2 (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))
      _ (((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))

f(f(f(f(f(f(f(f(((K(SII))f)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))
    stripped f(f(f(f(f(f(f(f((K(SII))f(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))
    stripped f(f(f(f(f(f(f(f(K(SII)f(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))

    K
      1 (SII)
      2 f
      _ (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))

f(f(f(f(f(f(f(f((SII)(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))
    stripped f(f(f(f(f(f(f(f(SII(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))))))))))

    S
      1 I
      2 I
      3 (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))
      _ ))))))))

f(f(f(f(f(f(f(f(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

    I
      1 (I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))
      _ (I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

f(f(f(f(f(f(f(f((I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))
    stripped f(f(f(f(f(f(f(f(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

    I
      1 (I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))
      _ (I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

f(f(f(f(f(f(f(f((I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))
    stripped f(f(f(f(f(f(f(f(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

    I
      1 (I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))
      _ (I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

f(f(f(f(f(f(f(f((I(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))
    stripped f(f(f(f(f(f(f(f(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

    I
      1 (I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))
      _ (I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

f(f(f(f(f(f(f(f((I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))
    stripped f(f(f(f(f(f(f(f(I(I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

    I
      1 (I(I(I(I((S(S(KS)K)(K(SII)))f)))))
      _ (I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

f(f(f(f(f(f(f(f((I(I(I(I((S(S(KS)K)(K(SII)))f)))))(I(I(I(I(I(I(I(I(I((S(S(KS)K)(K(SII)))f))))))))))))))))))

Very tired...
